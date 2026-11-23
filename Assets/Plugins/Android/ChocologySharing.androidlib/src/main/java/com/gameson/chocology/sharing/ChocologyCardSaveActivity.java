package com.gameson.chocology.sharing;

import android.app.Activity;
import android.content.Intent;
import android.net.Uri;
import android.os.Bundle;
import android.provider.DocumentsContract;

import java.io.IOException;
import java.io.OutputStream;
import java.nio.file.Files;

/** Android 8/9 permission-free fallback: writes only to the document URI chosen by the player. */
public final class ChocologyCardSaveActivity extends Activity {
    private static final int CREATE_CARD_REQUEST = 20342;
    private static final String PICKER_LAUNCHED_STATE = "chocology_card_picker_launched";
    private static final String CANCELED = "Save canceled. Your card has not been added to Photos.";
    private String m_Token;
    private boolean m_PickerLaunched;
    private boolean m_IsWriting;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        m_Token = getIntent().getStringExtra(ChocologyImageShare.EXPORT_TOKEN_EXTRA);
        ChocologyImageShare.ExportRequest request = ChocologyImageShare.pendingExport(m_Token);
        if (request == null) {
            finish();
            return;
        }
        m_PickerLaunched = savedInstanceState != null && savedInstanceState.getBoolean(PICKER_LAUNCHED_STATE);
        if (m_PickerLaunched)
            return;
        try {
            Intent create = new Intent(Intent.ACTION_CREATE_DOCUMENT);
            create.addCategory(Intent.CATEGORY_OPENABLE);
            create.setType("image/png");
            create.putExtra(Intent.EXTRA_TITLE, request.displayName);
            Uri pictures = DocumentsContract.buildDocumentUri("com.android.externalstorage.documents", "primary:Pictures");
            create.putExtra(DocumentsContract.EXTRA_INITIAL_URI, pictures);
            m_PickerLaunched = true;
            startActivityForResult(create, CREATE_CARD_REQUEST);
        } catch (RuntimeException exception) {
            ChocologyImageShare.finishExport(m_Token, false, "Could not open the image-save picker. Please try again.");
            finish();
        }
    }

    @Override
    protected void onSaveInstanceState(Bundle state) {
        state.putBoolean(PICKER_LAUNCHED_STATE, m_PickerLaunched);
        super.onSaveInstanceState(state);
    }

    @Override
    protected void onActivityResult(int requestCode, int resultCode, Intent data) {
        super.onActivityResult(requestCode, resultCode, data);
        if (requestCode != CREATE_CARD_REQUEST)
            return;
        ChocologyImageShare.ExportRequest request = ChocologyImageShare.pendingExport(m_Token);
        if (request == null) {
            finish();
            return;
        }
        if (resultCode != RESULT_OK || data == null || data.getData() == null) {
            ChocologyImageShare.finishExport(m_Token, false, CANCELED);
            finish();
            return;
        }

        final Uri destination = data.getData();
        final String token = m_Token;
        m_IsWriting = true;
        new Thread(() -> {
            boolean saved = false;
            try (OutputStream output = getContentResolver().openOutputStream(destination, "w")) {
                if (output == null)
                    throw new IOException("The chosen image destination is unavailable.");
                Files.copy(request.source.toPath(), output);
                saved = true;
            } catch (Exception exception) {
                saved = false;
            }
            // Success is reported only after the output stream has closed successfully.
            ChocologyImageShare.finishExport(token, saved, saved
                ? "Card saved to the location you selected. You can now add it to Instagram Stories."
                : "Could not save the card to that location. Please try again.");
            runOnUiThread(this::finish);
        }, "ChocologyDocumentSave").start();
    }

    @Override
    protected void onDestroy() {
        if (isFinishing() && !m_IsWriting)
            ChocologyImageShare.finishExport(m_Token, false, CANCELED);
        super.onDestroy();
    }
}
