using System;
using UnityEngine;

namespace Rush.Integrations.Ads
{
    [CreateAssetMenu(menuName = "Rush/Ads/LevelPlay Ad Units")]
    public sealed class LevelPlayAdUnitSettings : ScriptableObject
    {
        [Serializable]
        private sealed class PlatformField
        {
            [SerializeField] private string m_BannerAdUnitId;
            [SerializeField] private string m_InterstitialAdUnitId;
            [SerializeField] private string m_RewardedAdUnitId;

            public string BannerAdUnitId => m_BannerAdUnitId;
            public string InterstitialAdUnitId => m_InterstitialAdUnitId;
            public string RewardedAdUnitId => m_RewardedAdUnitId;
        }

        [SerializeField] private PlatformField m_Android = new PlatformField();
        [SerializeField] private PlatformField m_Ios = new PlatformField();

        private PlatformField CurrentPlatform
        {
            get
            {
#if UNITY_IOS
                return m_Ios;
#else
                return m_Android;
#endif
            }
        }

        public string BannerAdUnitId => CurrentPlatform.BannerAdUnitId;
        public string InterstitialAdUnitId => CurrentPlatform.InterstitialAdUnitId;
        public string RewardedAdUnitId => CurrentPlatform.RewardedAdUnitId;
    }
}
