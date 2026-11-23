using System;
using System.Collections;
using UnityEngine;

namespace Rush.Chocology.Integrations.Review
{
    /// <summary>
    /// Shows the Google Play in-app review sheet over the game, without opening the Play Store.
    /// Google decides whether the sheet actually appears (quota), and never reports whether a review was left.
    /// Calls the Play Review library (com.google.android.play:review) directly through JNI.
    /// </summary>
    public sealed class InAppReviewRequest
    {
        private const string c_UnityPlayerClass = "com.unity3d.player.UnityPlayer";
        private const string c_CurrentActivityField = "currentActivity";
        private const string c_ReviewManagerFactoryClass = "com.google.android.play.core.review.ReviewManagerFactory";
        private const string c_CreateMethod = "create";
        private const string c_RequestReviewFlowMethod = "requestReviewFlow";
        private const string c_LaunchReviewFlowMethod = "launchReviewFlow";
        private const string c_AddOnCompleteListenerMethod = "addOnCompleteListener";
        private const string c_IsSuccessfulMethod = "isSuccessful";
        private const string c_GetResultMethod = "getResult";
        private const string c_OnCompleteListenerInterface = "com.google.android.gms.tasks.OnCompleteListener";
        private const float c_TaskTimeoutSeconds = 10f;

        /// <summary>
        /// Runs the review flow. <paramref name="onUnavailable"/> is called when the sheet could not be requested
        /// (not installed from Play, no Play Services, editor, timeout); it is not called when Google simply chooses not to show it.
        /// </summary>
        public IEnumerator Launch(Action onUnavailable) => LaunchInternal(onUnavailable);

        private IEnumerator LaunchInternal(Action onUnavailable)
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            AndroidJavaObject activity = null;
            AndroidJavaObject manager = null;
            AndroidJavaObject requestTask = null;
            AndroidJavaObject reviewInfo = null;
            AndroidJavaObject launchTask = null;
            TaskCompleteListener requestListener = new TaskCompleteListener();
            TaskCompleteListener launchListener = new TaskCompleteListener();
            bool isRequested = false;
            try
            {
                using (AndroidJavaClass unityPlayer = new AndroidJavaClass(c_UnityPlayerClass))
                    activity = unityPlayer.GetStatic<AndroidJavaObject>(c_CurrentActivityField);
                using (AndroidJavaClass factory = new AndroidJavaClass(c_ReviewManagerFactoryClass))
                    manager = factory.CallStatic<AndroidJavaObject>(c_CreateMethod, activity);
                requestTask = manager.Call<AndroidJavaObject>(c_RequestReviewFlowMethod);
                requestTask.Call<AndroidJavaObject>(c_AddOnCompleteListenerMethod, requestListener).Dispose();
                isRequested = true;
            }
            catch (Exception exception)
            {
                Debug.LogWarning("In-app review could not be requested: " + exception.Message);
            }

            if (isRequested)
            {
                float requestDeadline = Time.realtimeSinceStartup + c_TaskTimeoutSeconds;
                while (!requestListener.IsCompleted && Time.realtimeSinceStartup < requestDeadline)
                    yield return null;
            }

            bool isLaunched = false;
            if (isRequested && requestListener.IsCompleted)
            {
                try
                {
                    if (requestTask.Call<bool>(c_IsSuccessfulMethod))
                    {
                        reviewInfo = requestTask.Call<AndroidJavaObject>(c_GetResultMethod);
                        launchTask = manager.Call<AndroidJavaObject>(c_LaunchReviewFlowMethod, activity, reviewInfo);
                        launchTask.Call<AndroidJavaObject>(c_AddOnCompleteListenerMethod, launchListener).Dispose();
                        isLaunched = true;
                    }
                }
                catch (Exception exception)
                {
                    Debug.LogWarning("In-app review could not be launched: " + exception.Message);
                }
            }

            if (isLaunched)
            {
                float launchDeadline = Time.realtimeSinceStartup + c_TaskTimeoutSeconds;
                while (!launchListener.IsCompleted && Time.realtimeSinceStartup < launchDeadline)
                    yield return null;
            }
            else
            {
                onUnavailable?.Invoke();
            }

            launchTask?.Dispose();
            reviewInfo?.Dispose();
            requestTask?.Dispose();
            manager?.Dispose();
            activity?.Dispose();
#else
            onUnavailable?.Invoke();
            yield break;
#endif
        }

#if UNITY_ANDROID && !UNITY_EDITOR
        /// <summary>Java OnCompleteListener; Play calls onComplete on its own thread, so it only raises a flag.</summary>
        private sealed class TaskCompleteListener : AndroidJavaProxy
        {
            private volatile bool m_IsCompleted;

            public TaskCompleteListener() : base(c_OnCompleteListenerInterface) { }

            public bool IsCompleted => m_IsCompleted;

            // Name and signature are fixed by the Java interface com.google.android.gms.tasks.OnCompleteListener.
            public void onComplete(AndroidJavaObject task)
            {
                m_IsCompleted = true;
            }
        }
#endif
    }
}
