using System.Collections;
using System.Collections.Generic;
using BsplabsMobileAds;
using Unity.Services.LevelPlay;
using UnityEngine;
using UnityEngine.Events;

namespace Rush.Integrations.Ads
{
    // Implements the existing BSPLABS contract with LevelPlay's ad-unit API.
    public class LevelPlayAdsProvider : MonoBehaviour, ICustomAds
    {
        private const string c_SettingsResource = "LevelPlayAdUnits";
        private const string c_AdvertiserName = "IronSource";
        private const float c_RetrySeconds = 30f;
        private const float c_RewardCallbackGraceSeconds = 5f;
        private const int c_MaxRetries = 10;
        private global::Rush.Integrations.Ads.LevelPlayAdUnitSettings m_Settings;
        private LevelPlayInterstitialAd m_Interstitial;
        private LevelPlayRewardedAd m_Rewarded;
        private LevelPlayBannerAd m_Banner;
        private string m_AppKey;
        private bool m_Initializing;
        private bool m_Initialized;
        private bool m_BannerUsed;
        private bool m_BannerRequested;
        private bool m_InterstitialShowing;
        private bool m_RewardedShowing;
        private int m_InitRetries;
        private int m_InterstitialRetries;
        private int m_RewardedRetries;
        private BannerPosition m_BannerPosition;
        private BannerType m_BannerType;
        private UnityAction<bool, BannerPosition, BannerType> m_BannerCallback;
        private UnityAction m_InterstitialCallback;
        private UnityAction<string> m_InterstitialAdvertiserCallback;
        private UnityAction<bool> m_RewardCallback;
        private UnityAction<bool, string> m_RewardAdvertiserCallback;
        private Coroutine m_RewardCloseRoutine;
        private bool RewardedAvailable => m_Rewarded != null && !m_RewardedShowing && m_Rewarded.IsAdReady();
        private bool InterstitialAvailable => m_Interstitial != null && !m_InterstitialShowing && m_Interstitial.IsAdReady();
        private bool BannerAvailable => m_Initialized && m_Settings != null && !string.IsNullOrWhiteSpace(m_Settings.BannerAdUnitId);

        public void InitializeAds(UserConsent consent, UserConsent ccpaConsent, List<PlatformSettings> platformSettings) => InitializeAdsInternal(consent, ccpaConsent, platformSettings);
        private void InitializeAdsInternal(UserConsent consent, UserConsent ccpaConsent, List<PlatformSettings> platformSettings)
        {
            if (m_Initializing || m_Initialized)
                return;
            var platform = SupportedPlatforms.Android;
#if UNITY_IOS
            platform = SupportedPlatforms.iOS;
#endif
            PlatformSettings selected = platformSettings.Find(settings => settings.platform == platform);
            if (selected == null || !selected.enabled)
                return;
            m_AppKey = selected.appId?.id;
            m_Settings = Resources.Load<global::Rush.Integrations.Ads.LevelPlayAdUnitSettings>(c_SettingsResource);
            if (string.IsNullOrWhiteSpace(m_AppKey))
            {
                Debug.LogWarning("LevelPlay needs an App Key in Window > BSPLABS > Mobile Ads.", this);
                return;
            }

            if (m_Settings == null || string.IsNullOrWhiteSpace(m_Settings.InterstitialAdUnitId))
                Debug.LogWarning("Set the new LevelPlay ad unit IDs in LevelPlayAdUnits. Legacy placement names cannot be used as ad unit IDs.", this);
            UpdateConsentInternal(consent, ccpaConsent);
            LevelPlay.SetMetaData("is_child_directed", selected.directedForChildren ? "true" : "false");
            LevelPlay.OnInitSuccess += OnInitialized;
            LevelPlay.OnInitFailed += OnInitializationFailed;
            m_Initializing = true;
            LevelPlay.Init(m_AppKey);
        }

        private void OnInitialized(LevelPlayConfiguration configuration)
        {
            m_Initializing = false;
            m_Initialized = true;
            m_InitRetries = 0;
            if (m_Settings == null)
                return;
            if (!string.IsNullOrWhiteSpace(m_Settings.InterstitialAdUnitId))
            {
                m_Interstitial = new LevelPlayInterstitialAd(m_Settings.InterstitialAdUnitId);
                m_Interstitial.OnAdLoaded += OnInterstitialLoaded;
                m_Interstitial.OnAdLoadFailed += OnInterstitialLoadFailed;
                m_Interstitial.OnAdClosed += OnInterstitialClosed;
                m_Interstitial.OnAdDisplayFailed += OnInterstitialDisplayFailed;
                LoadInterstitialInternal();
            }

            if (!string.IsNullOrWhiteSpace(m_Settings.RewardedAdUnitId))
            {
                m_Rewarded = new LevelPlayRewardedAd(m_Settings.RewardedAdUnitId);
                m_Rewarded.OnAdLoaded += OnRewardedLoaded;
                m_Rewarded.OnAdLoadFailed += OnRewardedLoadFailed;
                m_Rewarded.OnAdRewarded += OnRewardGranted;
                m_Rewarded.OnAdClosed += OnRewardedClosed;
                m_Rewarded.OnAdDisplayFailed += OnRewardedDisplayFailed;
                LoadRewardedInternal();
            }
        }

        private void OnInitializationFailed(LevelPlayInitError error)
        {
            m_Initializing = false;
            Debug.LogWarning("LevelPlay initialization failed: " + error, this);
            if (++m_InitRetries <= c_MaxRetries)
                Invoke(nameof(RetryInitializationInternal), c_RetrySeconds);
        }

        private void RetryInitializationInternal()
        {
            if (m_Initialized || m_Initializing)
                return;
            m_Initializing = true;
            LevelPlay.Init(m_AppKey);
        }

        public bool IsInterstitialAvailable() => InterstitialAvailable;
        public bool IsRewardVideoAvailable() => RewardedAvailable;
        public bool IsBannerAvailable() => BannerAvailable;
        public bool BannerAlreadyUsed() => m_BannerUsed;
        public void ResetBannerUsage() => m_BannerUsed = false;
        public void ShowInterstitial(UnityAction callback) => ShowInterstitialInternal(callback, null);
        public void ShowInterstitial(UnityAction<string> callback) => ShowInterstitialInternal(null, callback);
        private void ShowInterstitialInternal(UnityAction callback, UnityAction<string> advertiserCallback)
        {
            if (!InterstitialAvailable)
            {
                callback?.Invoke();
                advertiserCallback?.Invoke(c_AdvertiserName);
                return;
            }

            m_InterstitialCallback = callback;
            m_InterstitialAdvertiserCallback = advertiserCallback;
            m_InterstitialShowing = true;
            m_Interstitial.ShowAd();
        }

        private void OnInterstitialLoaded(LevelPlayAdInfo info) => m_InterstitialRetries = 0;
        private void LoadInterstitialInternal() => m_Interstitial?.LoadAd();
        private void OnInterstitialLoadFailed(LevelPlayAdError error)
        {
            if (++m_InterstitialRetries <= c_MaxRetries)
                Invoke(nameof(LoadInterstitialInternal), c_RetrySeconds);
        }

        private void OnInterstitialClosed(LevelPlayAdInfo info) => CompleteInterstitialInternal();
        private void OnInterstitialDisplayFailed(LevelPlayAdInfo info, LevelPlayAdError error) => CompleteInterstitialInternal();
        private void CompleteInterstitialInternal()
        {
            m_InterstitialShowing = false;
            var callback = m_InterstitialCallback;
            var advertiserCallback = m_InterstitialAdvertiserCallback;
            m_InterstitialCallback = null;
            m_InterstitialAdvertiserCallback = null;
            LoadInterstitialInternal();
            callback?.Invoke();
            advertiserCallback?.Invoke(c_AdvertiserName);
        }

        public void ShowRewardVideo(UnityAction<bool> callback) => ShowRewardedInternal(callback, null);
        public void ShowRewardVideo(UnityAction<bool, string> callback) => ShowRewardedInternal(null, callback);
        private void ShowRewardedInternal(UnityAction<bool> callback, UnityAction<bool, string> advertiserCallback)
        {
            if (!RewardedAvailable || m_RewardCallback != null || m_RewardAdvertiserCallback != null)
            {
                callback?.Invoke(false);
                advertiserCallback?.Invoke(false, c_AdvertiserName);
                return;
            }

            m_RewardCallback = callback;
            m_RewardAdvertiserCallback = advertiserCallback;
            m_RewardedShowing = true;
            m_Rewarded.ShowAd();
        }

        private void OnRewardedLoaded(LevelPlayAdInfo info) => m_RewardedRetries = 0;
        private void LoadRewardedInternal() => m_Rewarded?.LoadAd();
        private void OnRewardedLoadFailed(LevelPlayAdError error)
        {
            if (++m_RewardedRetries <= c_MaxRetries)
                Invoke(nameof(LoadRewardedInternal), c_RetrySeconds);
        }

        private void OnRewardGranted(LevelPlayAdInfo info, LevelPlayReward reward) => CompleteRewardInternal(true);
        private void OnRewardedClosed(LevelPlayAdInfo info)
        {
            m_RewardedShowing = false;
            LoadRewardedInternal();
            // Reward and close callbacks can arrive in either order.
            if (m_RewardCallback != null || m_RewardAdvertiserCallback != null)
                m_RewardCloseRoutine = StartCoroutine(CompleteSkippedRewardInternal());
        }

        private IEnumerator CompleteSkippedRewardInternal()
        {
            yield return new WaitForSecondsRealtime(c_RewardCallbackGraceSeconds);
            m_RewardCloseRoutine = null;
            CompleteRewardInternal(false);
        }

        private void OnRewardedDisplayFailed(LevelPlayAdInfo info, LevelPlayAdError error)
        {
            m_RewardedShowing = false;
            CompleteRewardInternal(false);
            LoadRewardedInternal();
        }

        private void CompleteRewardInternal(bool rewarded)
        {
            if (m_RewardCloseRoutine != null)
            {
                StopCoroutine(m_RewardCloseRoutine);
                m_RewardCloseRoutine = null;
            }

            var callback = m_RewardCallback;
            var advertiserCallback = m_RewardAdvertiserCallback;
            m_RewardCallback = null;
            m_RewardAdvertiserCallback = null;
            callback?.Invoke(rewarded);
            advertiserCallback?.Invoke(rewarded, c_AdvertiserName);
        }

        public void ShowBanner(BannerPosition position, BannerType bannerType, UnityAction<bool, BannerPosition, BannerType> callback) => ShowBannerInternal(position, bannerType, callback);
        private void ShowBannerInternal(BannerPosition position, BannerType bannerType, UnityAction<bool, BannerPosition, BannerType> callback)
        {
            if (!BannerAvailable)
            {
                callback?.Invoke(false, position, bannerType);
                return;
            }

            DisposeBannerInternal();
            m_BannerPosition = position;
            m_BannerType = bannerType;
            m_BannerCallback = callback;
            m_BannerRequested = true;
            var config = new LevelPlayBannerAd.Config.Builder().SetSize(bannerType == BannerType.Adaptive ? LevelPlayAdSize.CreateAdaptiveAdSize() : LevelPlayAdSize.BANNER).SetPosition(position == BannerPosition.TOP ? LevelPlayBannerPosition.TopCenter : LevelPlayBannerPosition.BottomCenter).SetDisplayOnLoad(false).Build();
            m_Banner = new LevelPlayBannerAd(m_Settings.BannerAdUnitId, config);
            m_Banner.OnAdLoaded += OnBannerLoaded;
            m_Banner.OnAdLoadFailed += OnBannerLoadFailed;
            m_Banner.LoadAd();
        }

        private void OnBannerLoaded(LevelPlayAdInfo info)
        {
            if (!m_BannerRequested)
                return;
            m_BannerUsed = true;
            m_Banner?.ShowAd();
            var callback = m_BannerCallback;
            m_BannerCallback = null;
            callback?.Invoke(true, m_BannerPosition, m_BannerType);
        }

        private void OnBannerLoadFailed(LevelPlayAdError error)
        {
            var callback = m_BannerCallback;
            m_BannerCallback = null;
            callback?.Invoke(false, m_BannerPosition, m_BannerType);
        }

        public void HideBanner() => HideBannerInternal();
        private void HideBannerInternal()
        {
            m_BannerRequested = false;
            m_Banner?.HideAd();
        }

        private void DisposeBannerInternal()
        {
            if (m_Banner == null)
                return;
            m_Banner.OnAdLoaded -= OnBannerLoaded;
            m_Banner.OnAdLoadFailed -= OnBannerLoadFailed;
            m_Banner.Dispose();
            m_Banner = null;
        }

        public void UpdateConsent(UserConsent consent, UserConsent ccpaConsent) => UpdateConsentInternal(consent, ccpaConsent);
        private void UpdateConsentInternal(UserConsent consent, UserConsent ccpaConsent)
        {
            if (consent != UserConsent.Unset)
                LevelPlay.SetConsent(consent == UserConsent.Accept);
            if (ccpaConsent != UserConsent.Unset)
                LevelPlay.SetMetaData("do_not_sell", ccpaConsent == UserConsent.Deny ? "true" : "false");
        }

        private void OnDestroy()
        {
            CancelInvoke();
            LevelPlay.OnInitSuccess -= OnInitialized;
            LevelPlay.OnInitFailed -= OnInitializationFailed;
            DisposeBannerInternal();
            m_Interstitial?.Dispose();
            m_Rewarded?.Dispose();
        }
    }
}
