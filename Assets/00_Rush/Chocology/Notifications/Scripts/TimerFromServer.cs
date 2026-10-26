using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using Redcode.Awaiting;
using System.IO;
using System.Threading;

namespace Rush.Chocology.Notifications
{
    [UnityEngine.Scripting.APIUpdating.MovedFrom(true, "", "Assembly-CSharp", "TimerFromServer")]
    public class TimerFromServer : MonoBehaviour
    {
        private static global::Rush.Chocology.Notifications.TimerFromServer s_Instance;
        public static global::Rush.Chocology.Notifications.TimerFromServer Instance { get => s_Instance; set => s_Instance = value; }

        private const int c_TimeRequestTimeoutSeconds = 15;
        private const int c_TimeRequestRetryMilliseconds = 2000;
        private readonly CancellationTokenSource m_LifetimeCancellation = new CancellationTokenSource();
        private UnityWebRequest m_ActiveTimeRequest;
        async void Start()
        {
            s_Instance = this;
            DontDestroyOnLoad(this);
            LoadDataNotificationInternal();
            NotificationPermission();
            try
            {
                DateTimeNowOnServer = await RequestRealDateTimeFromAPTaskInternal();
                m_LifetimeCancellation.Token.ThrowIfCancellationRequested();
                StartCoroutine(CountDownTimer());
            }
            catch (OperationCanceledException)
            {
            // Destruction or leaving Play Mode ends this component's pending work.
            }
        }

        /// <summary>
        /// for requesting permissions
        /// </summary>
        void NotificationPermission()
        {
#if UNITY_ANDROID
            if (!global::Rush.Chocology.Notifications.GlobalVar.Runtime.HasNotificationPermissionAndroid())
                global::Rush.Chocology.Notifications.GlobalVar.Runtime.RequestNotificationPermissionAndroid();
#endif
            try
            {
#if UNITY_IOS
        var result = GlobalVar.RequestNotificationPermissionIOS();
#endif
            }
            catch (Exception ex)
            {
                Debug.LogException(ex);
            }
        }

        IEnumerator CountDownTimer()
        {
            print("Calling");
            while (true)
            {
                if (DoneGetTime)
                {
                    DateTimeNowOnServer = DateTimeNowOnServer.AddSeconds(1);
                    yield return new WaitForSeconds(1f);
                }
                else
                {
                    yield return null;
                }
            }
        }

        public DateTime DateTimeNowOnServer { get; set; }
        public bool DoneGetTime { get; set; }

        private const string c_WorldTimeApiUrl = "https://worldtimeapi.org/api/ip";
        struct TimeData
        {
            [UnityEngine.Serialization.FormerlySerializedAs("datetime")]
            [UnityEngine.SerializeField]
            private string m_Datetime;
            [Newtonsoft.Json.JsonProperty("datetime")]
            public string Datetime { get => m_Datetime; set => m_Datetime = value; }
        //..
        }

        /// <summary>
        /// Async to call real time API
        /// </summary>
        /// <returns></returns>
        public Task<DateTime> RequestRealDateTimeFromAPTask() => RequestRealDateTimeFromAPTaskInternal();
        private async Task<DateTime> RequestRealDateTimeFromAPTaskInternal()
        {
            CancellationToken cancellation = m_LifetimeCancellation.Token;
            while (true)
            {
                cancellation.ThrowIfCancellationRequested();
                using (UnityWebRequest webRequest = UnityWebRequest.Get(c_WorldTimeApiUrl))
                {
                    m_ActiveTimeRequest = webRequest;
                    webRequest.timeout = c_TimeRequestTimeoutSeconds;
                    try
                    {
                        var operation = webRequest.SendWebRequest();
                        // Unity 6's native AsyncOperation awaiter can outlive its scripting
                        // domain. Managed polling registers no native Awaitable GC handle.
                        while (!operation.isDone)
                        {
                            cancellation.ThrowIfCancellationRequested();
                            await Task.Yield();
                        }

                        cancellation.ThrowIfCancellationRequested();
                        if (webRequest.result == UnityWebRequest.Result.Success)
                        {
                            global::Rush.Chocology.Notifications.TimerFromServer.TimeData timeData = Newtonsoft.Json.JsonConvert.DeserializeObject<global::Rush.Chocology.Notifications.TimerFromServer.TimeData>(webRequest.downloadHandler.text);
                            DateTimeNowOnServer = ParseDateTime(timeData.Datetime);
                            DoneGetTime = true;
                            return DateTimeNowOnServer;
                        }
                    }
                    finally
                    {
                        m_ActiveTimeRequest = null;
                    }
                }

                // Dispose failed requests before retrying; never recurse or accumulate requests.
                await Task.Delay(c_TimeRequestRetryMilliseconds, cancellation);
            }
        }

        private void OnDestroy()
        {
            m_LifetimeCancellation.Cancel();
            m_ActiveTimeRequest?.Abort();
            if (s_Instance == this)
                s_Instance = null;
        }

        /// <summary>
        /// parse the json date time from real time API
        /// </summary>
        /// <param name = "datetime"></param>
        /// <returns></returns>
        static DateTime ParseDateTime(string datetime)
        {
            //match 0000-00-00
            string date = Regex.Match(datetime, @"^\d{4}-\d{2}-\d{2}").Value;
            //match 00:00:00
            string time = Regex.Match(datetime, @"\d{2}:\d{2}:\d{2}").Value;
            return DateTime.Parse(string.Format("{0} {1}", date, time));
        }

        public ServerTimeSnapshot ServerTime => new ServerTimeSnapshot(
            DoneGetTime ? DateTimeNowOnServer : DateTime.MinValue, DoneGetTime);

        public void LoadDataNotification() => LoadDataNotificationInternal();
        private void LoadDataNotificationInternal()
        {
            StartCoroutine(ReadTime());
        }

        IEnumerator DownloaderImageNotif(string url)
        {
            string _splitUrl = Path.GetFileName(url);
            string _urlPath = Path.Combine(Application.persistentDataPath, _splitUrl);
            if (!File.Exists(_urlPath))
            {
                using (var uwr = new UnityWebRequest(url, UnityWebRequest.kHttpVerbGET))
                {
                    uwr.downloadHandler = new DownloadHandlerFile(_urlPath);
                    yield return uwr.SendWebRequest();
                    if (uwr.result != UnityWebRequest.Result.Success)
                    {
                        Debug.LogError(uwr.error);
                        yield break;
                    }
                }
            }
        }

        IEnumerator ReadTime()
        {
            using UnityWebRequest webRequest = UnityWebRequest.Get("https://gameson.r3ste.mobi/VCPushNotification.json");
            {
                yield return webRequest.SendWebRequest();
                if (webRequest.isDone)
                {
                    if (webRequest.error == null)
                    {
                        global::Rush.Chocology.Notifications.TimerFromServer.NotificationAPI newDataAPI = Newtonsoft.Json.JsonConvert.DeserializeObject<global::Rush.Chocology.Notifications.TimerFromServer.NotificationAPI>(webRequest.downloadHandler.text);
                        Debug.Log(newDataAPI.ToString());
                        if (newDataAPI != null)
                        {
                            if (newDataAPI.Notification.Count > 0)
                            {
                                foreach (global::Rush.Chocology.Notifications.TimerFromServer.NotificationAPIData notif in newDataAPI.Notification)
                                {
                                    //create the timer
                                    var jams = notif.Jam.Split('.');
                                    string jam = jams[0] + ":" + jams[1];
                                    DateTime _timeSeconds = DateTime.ParseExact(jam, "HH:mm", null);
                                    DateTime _timerDate = _timeSeconds;
                                    if (DateTime.Now > _timerDate)
                                    {
                                        _timerDate = _timerDate.AddDays(1);
                                    }

                                    //download image if exist
                                    if (!string.IsNullOrEmpty(notif.Image))
                                    {
                                        yield return StartCoroutine(DownloaderImageNotif(notif.Image));
                                    }

                                    global::Rush.Chocology.Notifications.GlobalVar.Runtime.CreateNotification(notif.Code, notif.Title, notif.Title, notif.Message, _timerDate, (notif.Loop == 1), true, new TimeSpan(24, 0, 0));
                                }
                            }
                        }
                    }
                }
            }
        }

        [Serializable]
        class NotificationAPI
        {
            [UnityEngine.Serialization.FormerlySerializedAs("Notification")]
            [UnityEngine.SerializeField]
            private List<global::Rush.Chocology.Notifications.TimerFromServer.NotificationAPIData> m_Notification;
            public global::System.Collections.Generic.List<global::Rush.Chocology.Notifications.TimerFromServer.NotificationAPIData> Notification { get => m_Notification; set => m_Notification = value; }
        }

        [Serializable]
        class NotificationAPIData
        {
            [global::System.Serializable]
            private sealed class NotificationAPIDataField
            {
                [UnityEngine.Serialization.FormerlySerializedAs("Loop")]
                [UnityEngine.SerializeField]
                private int m_Loop = 0;
                public int Loop { get => m_Loop; set => m_Loop = value; }

                [UnityEngine.Serialization.FormerlySerializedAs("Code")]
                [UnityEngine.SerializeField]
                private string m_Code = "";
                public string Code { get => m_Code; set => m_Code = value; }

                [UnityEngine.Serialization.FormerlySerializedAs("Title")]
                [UnityEngine.SerializeField]
                private string m_Title = "";
                public string Title { get => m_Title; set => m_Title = value; }

                [UnityEngine.Serialization.FormerlySerializedAs("Message")]
                [UnityEngine.SerializeField]
                private string m_Message = "";
                public string Message { get => m_Message; set => m_Message = value; }

                [UnityEngine.Serialization.FormerlySerializedAs("Jam")]
                [UnityEngine.SerializeField]
                private string m_Jam = "";
                public string Jam { get => m_Jam; set => m_Jam = value; }

                [UnityEngine.Serialization.FormerlySerializedAs("Image")]
                [UnityEngine.SerializeField]
                private string m_Image = "";
                public string Image { get => m_Image; set => m_Image = value; }
            }

            [global::UnityEngine.SerializeField]
            private NotificationAPIDataField m_NotificationAPIDataFields = new NotificationAPIDataField();
            public int Loop { get => m_NotificationAPIDataFields.Loop; set => m_NotificationAPIDataFields.Loop = value; }
            public string Code { get => m_NotificationAPIDataFields.Code; set => m_NotificationAPIDataFields.Code = value; }
            public string Title { get => m_NotificationAPIDataFields.Title; set => m_NotificationAPIDataFields.Title = value; }
            public string Message { get => m_NotificationAPIDataFields.Message; set => m_NotificationAPIDataFields.Message = value; }
            public string Jam { get => m_NotificationAPIDataFields.Jam; set => m_NotificationAPIDataFields.Jam = value; }
            public string Image { get => m_NotificationAPIDataFields.Image; set => m_NotificationAPIDataFields.Image = value; }
        }

    }
}
