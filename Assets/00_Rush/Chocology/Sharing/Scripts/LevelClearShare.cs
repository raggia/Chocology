using System;
using System.Threading;
using UnityEngine;
using UnityEngine.Events;

namespace Rush.Chocology.Sharing
{
    /// <summary>Opens the system share chooser only after the player explicitly taps Share.</summary>
    public sealed class LevelClearShare : MonoBehaviour
    {
        private const float c_RepeatTapDelay = 1f;
        private const string c_ChooserTitle = "Share your Chocology win";
        private const string c_NoCompletedLevelStatus = "Clear a level first to share your achievement.";
        private const string c_ChooseAppStatus = "Choose an app to share your achievement.";
        private const string c_ClipboardStatus = "Achievement copied! Paste it into your favorite app.";
        private const string c_ClipboardFallbackStatus = "Sharing is unavailable. Your achievement was copied; paste it into your favorite app.";
        private const string c_ClipboardUnavailableStatus = "Could not copy your achievement. Please try again.";
        private const string c_PreparingCardStatus = "Preparing your flex card...";
        private const string c_CardPreviewStatus = "Card created! Your PNG is ready for preview.";
        private const string c_ChooseImageAppStatus = "Choose an app to share your flex card.";
        private const string c_CardFailureStatus = "Could not prepare the image. Please try again.";
        private const string c_SavingCardStatus = "Saving your flex card...";
        private const string c_CardSavedStatus = "Saved! Open Instagram, choose Story and select your card.";
        private const string c_UnityPlayerClass = "com.unity3d.player.UnityPlayer";
        private const string c_IntentClass = "android.content.Intent";
        private const string c_SendAction = "android.intent.action.SEND";
        private const string c_TextMimeType = "text/plain";
        private const string c_TextExtra = "android.intent.extra.TEXT";
        private const string c_SubjectExtra = "android.intent.extra.SUBJECT";

        [SerializeField] private UnityEvent<string> m_OnStatusChanged = new UnityEvent<string>();
        [SerializeField] private LevelClearShareCard m_Card;

        private LevelClearShareContent m_Content;
        private string m_LastShareStatus = string.Empty;
        private bool m_IsLaunchingShare = false;
        private float m_NextShareAllowedTime;
        private int m_OperationToken;
        private string m_LastCardPath = string.Empty;
        private readonly LevelClearImageShareAndroid m_ImageShare = new LevelClearImageShareAndroid();

        public int CompletedLevel => m_Content.CompletedLevel;
        public bool CanShare => m_Content.CanShare && !m_IsLaunchingShare && !m_ImageShare.IsBusy;
        public string ShareText => m_Content.Text;
        public string ShareSubject => m_Content.Subject;
        public string LastShareStatus => m_LastShareStatus;
        public string LastCardPath => m_LastCardPath;
        public UnityEvent<string> OnStatusChanged => m_OnStatusChanged;

        public void SetCompletedLevel(int completedLevel)
        {
            SetCompletedLevelInternal(completedLevel);
        }

        public void Share()
        {
            ShareInternal();
        }

        public void SaveForStory()
        {
            SaveForStoryInternal();
        }

        public void ShareTextOnly()
        {
            ShareTextInternal();
        }

        private void SetCompletedLevelInternal(int completedLevel)
        {
            m_Content = new LevelClearShareContent(completedLevel);
            unchecked { m_OperationToken++; }
            m_IsLaunchingShare = false;
            m_NextShareAllowedTime = 0f;
            m_LastCardPath = string.Empty;
            SetStatusInternal(string.Empty);
        }

        private void ShareInternal()
        {
            BeginCardOperationInternal(false);
        }

        private void SaveForStoryInternal()
        {
            BeginCardOperationInternal(true);
        }

        private void BeginCardOperationInternal(bool saveForStory)
        {
            if (!m_Content.CanShare)
            {
                SetStatusInternal(c_NoCompletedLevelStatus);
                return;
            }

            if (m_IsLaunchingShare || m_ImageShare.IsBusy || Time.realtimeSinceStartup < m_NextShareAllowedTime)
                return;

            m_NextShareAllowedTime = Time.realtimeSinceStartup + c_RepeatTapDelay;
            m_IsLaunchingShare = true;
            var content = m_Content;
            int token = m_OperationToken;
            SetStatusInternal(c_PreparingCardStatus);
            if (m_Card == null)
            {
                CompleteCardOperationInternal(token, c_CardFailureStatus);
                return;
            }
            m_Card.Export(content.CompletedLevel,
                path => OnCardExportedInternal(path, content, token, saveForStory),
                error => CompleteCardOperationInternal(token, error));
        }

        private void OnCardExportedInternal(string path, LevelClearShareContent content, int token, bool saveForStory)
        {
            if (this == null || token != m_OperationToken)
                return;
            m_LastCardPath = path;
            if (!m_ImageShare.IsSupported)
            {
                CompleteCardOperationInternal(token, c_CardPreviewStatus);
                return;
            }
            if (saveForStory)
            {
                SetStatusInternal(c_SavingCardStatus);
                m_ImageShare.SaveToGallery(path, content,
                    (success, status) => CompleteCardOperationInternal(token,
                        success && string.IsNullOrWhiteSpace(status) ? c_CardSavedStatus : status));
            }
            else
            {
                m_ImageShare.Share(path, content, (success, status) =>
                {
                    CompleteCardOperationInternal(token, success ? c_ChooseImageAppStatus : status);
                });
            }
        }

        private void CompleteCardOperationInternal(int token, string status)
        {
            if (this == null)
                return;
            if (token != m_OperationToken)
            {
                // A save picker may finish after another level is shown. Refresh availability
                // without replacing that newer level's feedback with the old operation's result.
                SetStatusInternal(m_LastShareStatus);
                return;
            }
            m_IsLaunchingShare = false;
            m_NextShareAllowedTime = Time.realtimeSinceStartup + c_RepeatTapDelay;
            SetStatusInternal(status);
        }

        private void ShareTextInternal()
        {
            if (!m_Content.CanShare)
            {
                SetStatusInternal(c_NoCompletedLevelStatus);
                return;
            }
            if (m_IsLaunchingShare || m_ImageShare.IsBusy || Time.realtimeSinceStartup < m_NextShareAllowedTime)
                return;
            m_NextShareAllowedTime = Time.realtimeSinceStartup + c_RepeatTapDelay;
            var content = m_Content;
#if UNITY_ANDROID && !UNITY_EDITOR
            ShareAndroidInternal(content, m_OperationToken);
#else
            CopyShareTextInternal(content.Text, c_ClipboardStatus);
#endif
        }

#if UNITY_ANDROID && !UNITY_EDITOR
        private void ShareAndroidInternal(LevelClearShareContent content, int token)
        {
            // Android UI callbacks must return to Unity's synchronization context before touching UI/events.
            var unityContext = SynchronizationContext.Current;
            if (unityContext == null)
            {
                CopyShareTextInternal(content.Text, c_ClipboardFallbackStatus);
                return;
            }

            AndroidJavaObject activity = null;
            try
            {
                using (var unityPlayer = new AndroidJavaClass(c_UnityPlayerClass))
                    activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");

                if (activity == null)
                    throw new InvalidOperationException("The Android activity is unavailable.");

                m_IsLaunchingShare = true;
                var shareActivity = activity;
                activity.Call("runOnUiThread", new AndroidJavaRunnable(() =>
                {
                    Exception failure = null;
                    try
                    {
                        using (var intent = new AndroidJavaObject(c_IntentClass, c_SendAction))
                        using (var intentClass = new AndroidJavaClass(c_IntentClass))
                        {
                            using (intent.Call<AndroidJavaObject>("setType", c_TextMimeType)) { }
                            using (intent.Call<AndroidJavaObject>("putExtra", c_TextExtra, content.Text)) { }
                            using (intent.Call<AndroidJavaObject>("putExtra", c_SubjectExtra, content.Subject)) { }
                            using (var chooser = intentClass.CallStatic<AndroidJavaObject>("createChooser", intent, c_ChooserTitle))
                                shareActivity.Call("startActivity", chooser);
                        }
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
                        if (this == null)
                            return;

                        if (token != m_OperationToken)
                            return;
                        m_IsLaunchingShare = false;

                        if (failure == null)
                        {
                            SetStatusInternal(c_ChooseAppStatus);
                        }
                        else
                        {
                            Debug.LogWarning("Chocology could not open the Android share chooser: " + failure.Message, this);
                            CopyShareTextInternal(content.Text, c_ClipboardFallbackStatus);
                        }
                    }, null);
                }));

                // The UI callback owns this JNI reference until startActivity completes.
                activity = null;
            }
            catch (Exception exception)
            {
                activity?.Dispose();
                m_IsLaunchingShare = false;
                Debug.LogWarning("Chocology could not request Android sharing: " + exception.Message, this);
                CopyShareTextInternal(content.Text, c_ClipboardFallbackStatus);
            }
        }
#endif

        private void CopyShareTextInternal(string text, string status)
        {
            try
            {
                GUIUtility.systemCopyBuffer = text;
                SetStatusInternal(status);
            }
            catch (Exception exception)
            {
                Debug.LogWarning("Chocology could not copy the share message: " + exception.Message, this);
                SetStatusInternal(c_ClipboardUnavailableStatus);
            }
        }

        private void SetStatusInternal(string status)
        {
            m_LastShareStatus = status;
            OnStatusChangedInvoke(status);
        }

        private void OnStatusChangedInvoke(string status)
        {
            m_OnStatusChanged.Invoke(status);
        }
    }
}
