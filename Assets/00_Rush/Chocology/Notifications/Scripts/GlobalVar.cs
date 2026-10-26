using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using System.Threading.Tasks;
using UnityEngine;
using System.Text.RegularExpressions;
using Redcode.Awaiting;
using UnityEngine.UI;
using System.Net;
using Newtonsoft.Json;
using UnityEngine.Android;
using UnityEngine.Playables;
using System.IO;
#if UNITY_ANDROID
using Unity.Notifications.Android;

namespace Rush.Chocology.Notifications
{
    [UnityEngine.Scripting.APIUpdating.MovedFrom(true, "", "Assembly-CSharp", "GlobalVar")]
#endif
#if UNITY_IOS
using Unity.Notifications.iOS;
#endif
    public class GlobalVar : UnityEngine.ScriptableObject
    {
        private static GlobalVar s_Runtime;
        public static GlobalVar Runtime => s_Runtime;

        public const string PlayerPrefs_MisteryChest = "mistery_chest";
        public const string PlayerPrefs_SpeedupChest = "speed_up_chest";
        public void SetMisteryChestTimer(string _timer) => SetMisteryChestTimerInternal(_timer);
        private void SetMisteryChestTimerInternal(string _timer)
        {
            PlayerPrefs.SetString(PlayerPrefs_MisteryChest, _timer);
            //set push notification
            CreateMisteryChestNotificationInternal(Convert.ToDateTime(_timer));
        }

        public string MisteryChestTimer => PlayerPrefs.GetString(PlayerPrefs_MisteryChest, "");

        public void SetSpeedUpChest(bool _isUsed) => SetSpeedUpChestInternal(_isUsed);
        private void SetSpeedUpChestInternal(bool _isUsed) => PlayerPrefs.SetInt(PlayerPrefs_SpeedupChest, (_isUsed) ? 1 : 0);
        public bool IsSpeedUpUsed() => IsSpeedUpUsedInternal();
        private bool IsSpeedUpUsedInternal() => (PlayerPrefs.GetInt(PlayerPrefs_SpeedupChest, 0) == 0) ? false : true;
        public void DeleteKey(string _dataKey) => DeleteKeyInternal(_dataKey);
        private void DeleteKeyInternal(string _dataKey) => PlayerPrefs.DeleteKey(_dataKey);
        public int CountDaysReward => PlayerPrefs.GetInt("totalClaimDay", 1);

        public void SetCountDaysReward(int value) => SetCountDaysRewardInternal(value);
        private void SetCountDaysRewardInternal(int value) => PlayerPrefs.SetInt("totalClaimDay", value);
        public void SetDaysForClaim(string value) => SetDaysForClaimInternal(value);
        private void SetDaysForClaimInternal(string value)
        {
            PlayerPrefs.SetString("DayNextClaim", value);
            //set push notification
            CreateDailyRewardClaimNotificationInternal(Convert.ToDateTime(value));
        }

        public string DaysForClaim => PlayerPrefs.GetString("DayNextClaim", "");

        public bool IsCanClaimDailyReward(int dayClick) => IsCanClaimDailyRewardInternal(dayClick);
        private bool IsCanClaimDailyRewardInternal(int dayClick)
        {
            if (global::Rush.Chocology.Notifications.TimerFromServer.Instance == null)
            {
            }

            DateTime _currdate = global::Rush.Chocology.Notifications.TimerFromServer.Instance.ServerTime.Value;
            if (!string.IsNullOrEmpty(DaysForClaim))
            {
                DateTime lastDate = Convert.ToDateTime(DaysForClaim);
                if (dayClick == CountDaysReward && _currdate >= lastDate)
                {
                    return true;
                }
                else
                    return false;
            }
            else
            {
                if (dayClick == 1)
                    return true;
                else
                    return false;
            }
        }

        /// <summary>
        /// Insert the analytics
        /// </summary>
        /// <param name = "_parameterName">Parameter name</param>
        public void CallAnalytics(string _parameterName) => CallAnalyticsInternal(_parameterName);
        private void CallAnalyticsInternal(string _parameterName)
        {
            try
            {
                Debug.Log($"Calling {(_parameterName)}");
            }
            catch (Exception e)
            {
                Debug.LogError(e);
            }
        }



#if UNITY_ANDROID
        /// <summary>
        /// checker android notification permission
        /// </summary>
        /// <returns></returns>
        public bool HasNotificationPermissionAndroid() => HasNotificationPermissionAndroidInternal();
        private bool HasNotificationPermissionAndroidInternal()
        {
            return Permission.HasUserAuthorizedPermission("android.permission.POST_NOTIFICATIONS");
        }

#endif
        /// <summary>
        /// enable android notification permission
        /// </summary>
        public void RequestNotificationPermissionAndroid() => RequestNotificationPermissionAndroidInternal();
        private void RequestNotificationPermissionAndroidInternal()
        {
#if UNITY_ANDROID
            Permission.RequestUserPermission("android.permission.POST_NOTIFICATIONS");
#endif
        }

        /// <summary>
        /// request notification ios
        /// </summary>
        /// <returns></returns>
        
#if UNITY_IOS
    public static async Task<bool> RequestNotificationPermissionIOS()
    {

        try
        {
            using var req = new AuthorizationRequest(
         AuthorizationOption.Alert | AuthorizationOption.Badge, true);
            while (!req.IsFinished)
            {

                await new WaitForSeconds(Time.deltaTime);
            }
            return true;
        }
        catch (Exception e)
        {
            Debug.LogError(e);
            return false;
        }

}
#endif

        public void CreateMisteryChestNotification(DateTime _fireTime) => CreateMisteryChestNotificationInternal(_fireTime);
        private void CreateMisteryChestNotificationInternal(DateTime _fireTime) => CreateNotificationInternal("mistery_chest_id", "Mistery Chest", "Mistery Chest", "Hey players,your chest is ready to claim up!!", _fireTime);
        public void CreateDailyRewardClaimNotification(DateTime _fireTime) => CreateDailyRewardClaimNotificationInternal(_fireTime);
        private void CreateDailyRewardClaimNotificationInternal(DateTime _fireTime) => CreateNotificationInternal("daily_reward_claim", "Daily Reward", "Daily Reward", "Hey players,your daily reward is ready to claim up!!", _fireTime);
        public void CreateSpinClaimNotification(DateTime _fireTime) => CreateSpinClaimNotificationInternal(_fireTime);
        private void CreateSpinClaimNotificationInternal(DateTime _fireTime) => CreateNotificationInternal("spin_claim", "Daily Reward", "Daily Reward", "Hey players, your free spin is ready to claim up!!", _fireTime);
        public bool TryGetNotifImagePath(string path) => TryGetNotifImagePathInternal(path);
        private bool TryGetNotifImagePathInternal(string path)
        {
            string urlImage = Path.Combine(Application.persistentDataPath, path);
            if (File.Exists(Path.Combine(Application.persistentDataPath, path)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void CreateNotification(string _id, string _name, string _notifTitle, string _notifText, DateTime _fireTime, bool _loop = false, bool _cancelIfSame = false, TimeSpan _repeateTime = default, string _notifImage = "") => CreateNotificationInternal(_id, _name, _notifTitle, _notifText, _fireTime, _loop, _cancelIfSame, _repeateTime, _notifImage);
        private void CreateNotificationInternal(string _id, string _name, string _notifTitle, string _notifText, DateTime _fireTime, bool _loop = false, bool _cancelIfSame = false, TimeSpan _repeateTime = default, string _notifImage = "")
        {
#if UNITY_ANDROID
            //cancel the duplicate notification that we create
            if (_cancelIfSame)
                AndroidNotificationCenter.CancelNotification(_id.GetHashCode());
            var channel = new AndroidNotificationChannel()
            {
                Id = _id,
                Name = _name,
                Importance = Importance.Default,
                Description = _notifTitle,
            };
            AndroidNotificationCenter.RegisterNotificationChannel(channel);
            var notif = new AndroidNotification();
            notif.Title = _notifTitle;
            notif.Text = _notifText;
            notif.FireTime = _fireTime;
            notif.ShouldAutoCancel = true;
            if (TryGetNotifImagePathInternal(_notifImage))
            {
                string urlImage = Path.Combine(Application.persistentDataPath, _notifImage);
                notif.BigPicture = new BigPictureStyle
                {
                    Picture = urlImage
                };
            }

            if (_loop)
            {
                notif.RepeatInterval = (_repeateTime == default) ? new TimeSpan(24, 0, 0) : _repeateTime;
            }

            var idNotif = AndroidNotificationCenter.SendNotification(notif, _id);
#endif
#if UNITY_IOS

   if(_cancelIfSame)
            iOSNotificationCenter.RemoveScheduledNotification(_id);

var notifIos = new iOSNotification()
        {
            Identifier = _id,
            Title = _notifTitle,
            Body = _notifText,
            Subtitle = _notifText,
            ShowInForeground = true,
            ForegroundPresentationOption = (PresentationOption.Alert | PresentationOption.Sound),
            CategoryIdentifier = _id,
            ThreadIdentifier = "thread1",
            Trigger = new iOSNotificationTimeIntervalTrigger()
            {
                TimeInterval = _fireTime - TimerFromServer.instance.dateTimeNowOnServer,
                Repeats = _loop 
            }
        };
        iOSNotificationCenter.ScheduleNotification(notifIos);
#endif
        }

        private void OnEnable()
        {
            s_Runtime = this;
        }

        public void ActivateRuntime() => ActivateRuntimeInternal();
        private void ActivateRuntimeInternal()
        {
            s_Runtime = this;
        }

    }
}
