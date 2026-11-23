using System;
using System.IO;
using System.Threading;
using UnityEngine;

namespace Rush.Chocology.Sharing
{
    /// <summary>Shares or saves an existing level card without broad storage permissions.</summary>
    public sealed class LevelClearImageShareAndroid
    {
        private const string c_ShareFolder = "chocology-share";
        private const string c_UnityPlayerClass = "com.unity3d.player.UnityPlayer";
        private const string c_ImageShareClass = "com.gameson.chocology.sharing.ChocologyImageShare";
        private const string c_SaveCallbackClass = "com.gameson.chocology.sharing.ChocologyImageShare$ExportCallback";
        private const string c_UnsupportedStatus = "Image sharing is available on Android. Your card can still be saved.";
        private const string c_InvalidCardStatus = "The level card is not ready to share.";
        private const string c_ChooserStatus = "Choose an app to share your level card.";
        private const string c_FailureStatus = "Could not open image sharing. Please try again.";
        private const string c_SaveFailureStatus = "Could not save your level card. Please try again.";

        private bool m_IsLaunching = false;
#if UNITY_ANDROID && !UNITY_EDITOR
        private ExportCallbackProxy m_PendingSaveCallback;
#endif
        public bool IsBusy => m_IsLaunching;
        public bool IsSupported
        {
            get
            {
#if UNITY_ANDROID && !UNITY_EDITOR
                return true;
#else
                return false;
#endif
            }
        }

        public void Share(string pngPath, LevelClearShareContent content, Action<bool, string> callback)
        {
            ShareInternal(pngPath, content, callback);
        }

        public void SaveToGallery(string pngPath, LevelClearShareContent content, Action<bool, string> callback)
        {
            SaveToGalleryInternal(pngPath, content, callback);
        }

        private void ShareInternal(string pngPath, LevelClearShareContent content, Action<bool, string> callback)
        {
            if (m_IsLaunching)
                return;
            if (!IsValidCardPath(pngPath, content))
            {
                callback?.Invoke(false, c_InvalidCardStatus);
                return;
            }
#if UNITY_ANDROID && !UNITY_EDITOR
            ShareAndroidInternal(Path.GetFullPath(pngPath), content, callback);
#else
            callback?.Invoke(false, c_UnsupportedStatus);
#endif
        }

        private void SaveToGalleryInternal(string pngPath, LevelClearShareContent content, Action<bool, string> callback)
        {
            if (m_IsLaunching)
                return;
            if (!IsValidCardPath(pngPath, content))
            {
                callback?.Invoke(false, c_InvalidCardStatus);
                return;
            }
#if UNITY_ANDROID && !UNITY_EDITOR
            SaveAndroidInternal(Path.GetFullPath(pngPath), content.CompletedLevel, callback);
#else
            callback?.Invoke(false, c_UnsupportedStatus);
#endif
        }

        private bool IsValidCardPath(string pngPath, LevelClearShareContent content)
        {
            if (!content.CanShare || string.IsNullOrWhiteSpace(pngPath))
                return false;
            try
            {
                string root = Path.GetFullPath(Path.Combine(Application.temporaryCachePath, c_ShareFolder)) + Path.DirectorySeparatorChar;
                string fullPath = Path.GetFullPath(pngPath);
                return fullPath.StartsWith(root, StringComparison.Ordinal) &&
                    string.Equals(Path.GetExtension(fullPath), ".png", StringComparison.OrdinalIgnoreCase) && File.Exists(fullPath);
            }
            catch (Exception)
            {
                return false;
            }
        }

#if UNITY_ANDROID && !UNITY_EDITOR
        private void ShareAndroidInternal(string pngPath, LevelClearShareContent content, Action<bool, string> callback)
        {
            var unityContext = SynchronizationContext.Current;
            if (unityContext == null)
            {
                callback?.Invoke(false, c_FailureStatus);
                return;
            }
            AndroidJavaObject activity = null;
            try
            {
                using (var unityPlayer = new AndroidJavaClass(c_UnityPlayerClass))
                    activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
                if (activity == null)
                    throw new InvalidOperationException("The Android activity is unavailable.");
                m_IsLaunching = true;
                var shareActivity = activity;
                activity.Call("runOnUiThread", new AndroidJavaRunnable(() =>
                {
                    Exception failure = null;
                    try
                    {
                        using (var imageShare = new AndroidJavaClass(c_ImageShareClass))
                        using (var intent = imageShare.CallStatic<AndroidJavaObject>("createChooser", shareActivity, pngPath, content.Text, content.Subject))
                            shareActivity.Call("startActivity", intent);
                    }
                    catch (Exception exception)
                    {
                        failure = exception;
                    }
                    finally
                    {
                        shareActivity.Dispose();
                    }
                    unityContext.Post(_ =>
                    {
                        m_IsLaunching = false;
                        if (failure != null)
                        {
                            Debug.LogWarning("Chocology Android image sharing failed: " + failure.Message);
                            callback?.Invoke(false, c_FailureStatus);
                            return;
                        }
                        // Opening the chooser is not proof that the player published a post.
                        callback?.Invoke(true, c_ChooserStatus);
                    }, null);
                }));
                activity = null;
            }
            catch (Exception exception)
            {
                activity?.Dispose();
                m_IsLaunching = false;
                Debug.LogWarning("Chocology could not request Android image sharing: " + exception.Message);
                callback?.Invoke(false, c_FailureStatus);
            }
        }

        private void SaveAndroidInternal(string pngPath, int completedLevel, Action<bool, string> callback)
        {
            var unityContext = SynchronizationContext.Current;
            if (unityContext == null)
            {
                callback?.Invoke(false, c_SaveFailureStatus);
                return;
            }
            AndroidJavaObject activity = null;
            try
            {
                using (var unityPlayer = new AndroidJavaClass(c_UnityPlayerClass))
                    activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
                if (activity == null)
                    throw new InvalidOperationException("The Android activity is unavailable.");
                m_IsLaunching = true;
                m_PendingSaveCallback = new ExportCallbackProxy(unityContext, (saved, message) =>
                {
                    m_IsLaunching = false;
                    m_PendingSaveCallback = null;
                    callback?.Invoke(saved, message);
                });
                var saveActivity = activity;
                var saveCallback = m_PendingSaveCallback;
                activity.Call("runOnUiThread", new AndroidJavaRunnable(() =>
                {
                    try
                    {
                        using (var imageShare = new AndroidJavaClass(c_ImageShareClass))
                            imageShare.CallStatic("saveToGallery", saveActivity, pngPath, completedLevel, saveCallback);
                    }
                    catch (Exception exception)
                    {
                        Debug.LogWarning("Chocology Android card saving failed: " + exception.Message);
                        saveCallback.Complete(false, c_SaveFailureStatus);
                    }
                    finally
                    {
                        saveActivity.Dispose();
                    }
                }));
                activity = null;
            }
            catch (Exception exception)
            {
                activity?.Dispose();
                m_IsLaunching = false;
                m_PendingSaveCallback = null;
                Debug.LogWarning("Chocology could not request Android card saving: " + exception.Message);
                callback?.Invoke(false, c_SaveFailureStatus);
            }
        }

        [UnityEngine.Scripting.Preserve]
        private sealed class ExportCallbackProxy : AndroidJavaProxy
        {
            private readonly SynchronizationContext m_UnityContext;
            private readonly Action<bool, string> m_Callback;
            private int m_IsCompleted;

            public ExportCallbackProxy(SynchronizationContext unityContext, Action<bool, string> callback) : base(c_SaveCallbackClass)
            {
                m_UnityContext = unityContext;
                m_Callback = callback;
            }

            // Exact Java interface spelling is required by AndroidJavaProxy dispatch.
            [UnityEngine.Scripting.Preserve]
            public void onCompleted(bool saved, string message)
            {
                CompleteInternal(saved, message);
            }

            public void Complete(bool saved, string message)
            {
                CompleteInternal(saved, message);
            }

            private void CompleteInternal(bool saved, string message)
            {
                if (Interlocked.Exchange(ref m_IsCompleted, 1) != 0)
                    return;
                m_UnityContext.Post(_ => m_Callback?.Invoke(saved, message), null);
            }
        }
#endif
    }
}
