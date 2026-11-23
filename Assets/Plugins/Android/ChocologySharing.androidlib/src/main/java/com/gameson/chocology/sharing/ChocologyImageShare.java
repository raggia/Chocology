package com.gameson.chocology.sharing;

import android.content.ClipData;
import android.content.ContentResolver;
import android.content.ContentValues;
import android.content.Context;
import android.content.Intent;
import android.net.Uri;
import android.os.Build;
import android.os.Environment;
import android.provider.MediaStore;
import android.util.Log;

import androidx.core.content.FileProvider;

import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;
import java.io.OutputStream;
import java.nio.file.Files;
import java.nio.file.StandardCopyOption;
import java.util.Locale;
import java.util.UUID;
import java.util.concurrent.ConcurrentHashMap;

/** Shares only PNG cards from the app's own dedicated cache folder. */
public final class ChocologyImageShare {
    private static final String SHARE_FOLDER = "chocology-share";
    private static final String AUTHORITY_SUFFIX = ".chocology.share";
    private static final String MIME_PNG = "image/png";
    private static final String CHOOSER_TITLE = "Share your Chocology win";
    private static final String SAVE_FAILED = "Could not save your level card. Please try again.";
    private static final long MAX_PNG_BYTES = 16L * 1024L * 1024L;
    private static final long PRIVATE_COPY_RETENTION_MS = 7L * 24L * 60L * 60L * 1000L;
    private static final byte[] PNG_SIGNATURE = {(byte) 137, 80, 78, 71, 13, 10, 26, 10};
    static final String EXPORT_TOKEN_EXTRA = "com.gameson.chocology.sharing.EXPORT_TOKEN";
    private static final ConcurrentHashMap<String, ExportRequest> EXPORTS = new ConcurrentHashMap<>();

    private ChocologyImageShare() { }

    public interface ExportCallback {
        void onCompleted(boolean saved, String message);
    }

    static final class ExportRequest {
        final File source;
        final String displayName;
        final ExportCallback callback;

        ExportRequest(File source, String displayName, ExportCallback callback) {
            this.source = source;
            this.displayName = displayName;
            this.callback = callback;
        }
    }

    public static Intent createShareIntent(Context context, String pngPath, String text, String subject) throws IOException {
        File card = preparePrivateCard(context, pngPath);
        Uri contentUri = FileProvider.getUriForFile(context, context.getPackageName() + AUTHORITY_SUFFIX, card);
        Intent send = new Intent(Intent.ACTION_SEND);
        send.setType(MIME_PNG);
        send.putExtra(Intent.EXTRA_STREAM, contentUri);
        send.putExtra(Intent.EXTRA_TEXT, text);
        send.putExtra(Intent.EXTRA_SUBJECT, subject);
        send.setClipData(ClipData.newRawUri("Chocology level card", contentUri));
        send.addFlags(Intent.FLAG_GRANT_READ_URI_PERMISSION);
        return send;
    }

    public static Intent createChooser(Context context, String pngPath, String text, String subject) throws IOException {
        Intent send = createShareIntent(context, pngPath, text, subject);
        Intent chooser = Intent.createChooser(send, CHOOSER_TITLE);
        chooser.setClipData(send.getClipData());
        chooser.addFlags(Intent.FLAG_GRANT_READ_URI_PERMISSION);
        return chooser;
    }

    public static void saveToGallery(Context context, String pngPath, int completedLevel, ExportCallback callback) throws IOException {
        if (completedLevel <= 0)
            throw new IllegalArgumentException("A completed level is required.");
        File card = preparePrivateCard(context, pngPath);
        String displayName = "Chocology-Level-" + completedLevel + "-" + System.currentTimeMillis() + ".png";
        if (Build.VERSION.SDK_INT >= 29) {
            Context appContext = context.getApplicationContext();
            new Thread(() -> MediaStore29.save(appContext, card, displayName, callback), "ChocologyCardSave").start();
            return;
        }

        // Android 8/9: let the user choose a destination through the Storage Access Framework.
        String token = UUID.randomUUID().toString();
        EXPORTS.put(token, new ExportRequest(card, displayName, callback));
        try {
            Intent save = new Intent(context, ChocologyCardSaveActivity.class);
            save.putExtra(EXPORT_TOKEN_EXTRA, token);
            context.startActivity(save);
        } catch (RuntimeException exception) {
            finishExport(token, false, SAVE_FAILED);
        }
    }

    static ExportRequest pendingExport(String token) {
        return token == null ? null : EXPORTS.get(token);
    }

    static void finishExport(String token, boolean saved, String message) {
        ExportRequest request = token == null ? null : EXPORTS.remove(token);
        if (request != null)
            complete(request.callback, saved, message);
    }

    private static void complete(ExportCallback callback, boolean saved, String message) {
        if (callback == null)
            return;
        try {
            callback.onCompleted(saved, message);
        } catch (RuntimeException exception) {
            // An app shutting down can invalidate its Unity callback; never crash a Java UI/worker thread.
            Log.w("ChocologyShare", "The card-save callback is no longer available.", exception);
        }
    }

    @android.annotation.TargetApi(29)
    private static final class MediaStore29 {
        private static void save(Context context, File source, String displayName, ExportCallback callback) {
            ContentResolver resolver = context.getContentResolver();
            Uri inserted = null;
            try {
                ContentValues values = new ContentValues();
                values.put(MediaStore.Images.Media.DISPLAY_NAME, displayName);
                values.put(MediaStore.Images.Media.MIME_TYPE, MIME_PNG);
                values.put(MediaStore.Images.Media.RELATIVE_PATH, Environment.DIRECTORY_PICTURES + "/Chocology");
                values.put(MediaStore.Images.Media.IS_PENDING, 1);
                Uri collection = MediaStore.Images.Media.getContentUri(MediaStore.VOLUME_EXTERNAL_PRIMARY);
                inserted = resolver.insert(collection, values);
                if (inserted == null)
                    throw new IOException("No image destination was created.");
                try (OutputStream output = resolver.openOutputStream(inserted, "w")) {
                    if (output == null)
                        throw new IOException("The image destination is unavailable.");
                    Files.copy(source.toPath(), output);
                }
                values.clear();
                values.put(MediaStore.Images.Media.IS_PENDING, 0);
                if (resolver.update(inserted, values, null, null) <= 0)
                    throw new IOException("The saved image could not be published to the gallery.");
                complete(callback, true, "Saved to Photos in Pictures/Chocology. Open Instagram Stories and choose it from your gallery.");
            } catch (Exception exception) {
                if (inserted != null) {
                    try {
                        resolver.delete(inserted, null, null);
                    } catch (RuntimeException ignored) {
                        // Leave no successful-save claim when cleanup is unavailable.
                    }
                }
                complete(callback, false, SAVE_FAILED);
            }
        }
    }

    private static File preparePrivateCard(Context context, String pngPath) throws IOException {
        if (context == null || pngPath == null)
            throw new IllegalArgumentException("A share context and PNG path are required.");
        File source = new File(pngPath).getCanonicalFile();
        if (!source.isFile() || !source.getName().toLowerCase(Locale.ROOT).endsWith(".png") ||
                source.length() < PNG_SIGNATURE.length || source.length() > MAX_PNG_BYTES || !isInAppShareCache(context, source))
            throw new SecurityException("Only a PNG card in Chocology's own share cache may be shared.");
        try (FileInputStream input = new FileInputStream(source)) {
            for (byte expected : PNG_SIGNATURE)
                if (input.read() != (expected & 0xff))
                    throw new IOException("The shared card is not a PNG image.");
        }

        // Unity may use internal or external app cache; the provider exposes only this internal subdirectory.
        File root = shareRoot(context.getCacheDir());
        if (!root.isDirectory() && !root.mkdirs())
            throw new IOException("Cannot create Chocology's private share cache.");
        removeExpiredPrivateCopies(root, source);
        // Keep one immutable private copy per operation. Do not delete on chooser dismissal:
        // the receiving app may still read it while its own editor is open.
        File sharedCopy = File.createTempFile("chocology-card-", ".png", root);
        Files.copy(source.toPath(), sharedCopy.toPath(), StandardCopyOption.REPLACE_EXISTING);
        return sharedCopy;
    }

    private static void removeExpiredPrivateCopies(File root, File currentSource) {
        File[] files = root.listFiles();
        if (files == null)
            return;
        long cutoff = System.currentTimeMillis() - PRIVATE_COPY_RETENTION_MS;
        for (File candidate : files) {
            if (!candidate.isFile() || !candidate.getName().startsWith("chocology-card-") ||
                    !candidate.getName().endsWith(".png") || candidate.lastModified() >= cutoff || candidate.equals(currentSource))
                continue;
            boolean activeExport = false;
            for (ExportRequest request : EXPORTS.values())
                if (candidate.equals(request.source)) {
                    activeExport = true;
                    break;
                }
            if (activeExport)
                continue;
            try {
                Files.deleteIfExists(candidate.toPath());
            } catch (IOException | SecurityException ignored) {
                // Private-cache housekeeping must not block an explicit share or touch gallery files.
            }
        }
    }

    private static boolean isInAppShareCache(Context context, File source) throws IOException {
        if (isWithin(source, shareRoot(context.getCacheDir())))
            return true;
        File[] externalCaches = context.getExternalCacheDirs();
        if (externalCaches != null)
            for (File cache : externalCaches)
                if (cache != null && isWithin(source, shareRoot(cache)))
                    return true;
        return false;
    }

    private static File shareRoot(File cache) throws IOException {
        File canonicalCache = cache.getCanonicalFile();
        File root = new File(canonicalCache, SHARE_FOLDER).getCanonicalFile();
        if (!canonicalCache.equals(root.getParentFile()))
            throw new SecurityException("The share cache may not point outside app cache.");
        return root;
    }

    private static boolean isWithin(File file, File directory) {
        return file.getPath().startsWith(directory.getPath() + File.separator);
    }
}
