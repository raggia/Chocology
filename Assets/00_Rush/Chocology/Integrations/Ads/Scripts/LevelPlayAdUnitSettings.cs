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
            [global::System.Serializable]
            private sealed class PlatformFieldField
            {
                [UnityEngine.Serialization.FormerlySerializedAs("m_BannerAdUnitId")]
                [UnityEngine.SerializeField]
                private string m_BannerAdUnitId;
                public string BannerAdUnitIdValue { get => m_BannerAdUnitId; set => m_BannerAdUnitId = value; }

                [UnityEngine.Serialization.FormerlySerializedAs("m_InterstitialAdUnitId")]
                [UnityEngine.SerializeField]
                private string m_InterstitialAdUnitId;
                public string InterstitialAdUnitIdValue { get => m_InterstitialAdUnitId; set => m_InterstitialAdUnitId = value; }

                [UnityEngine.Serialization.FormerlySerializedAs("m_RewardedAdUnitId")]
                [UnityEngine.SerializeField]
                private string m_RewardedAdUnitId;
                public string RewardedAdUnitIdValue { get => m_RewardedAdUnitId; set => m_RewardedAdUnitId = value; }
            }

            [global::UnityEngine.SerializeField]
            private PlatformFieldField m_PlatformFieldFields = new PlatformFieldField();
            public string BannerAdUnitId => m_PlatformFieldFields.BannerAdUnitIdValue;
            public string InterstitialAdUnitId => m_PlatformFieldFields.InterstitialAdUnitIdValue;
            public string RewardedAdUnitId => m_PlatformFieldFields.RewardedAdUnitIdValue;
        }

        [UnityEngine.Serialization.FormerlySerializedAs("m_Android")]
        [UnityEngine.SerializeField]
        private global::Rush.Integrations.Ads.LevelPlayAdUnitSettings.PlatformField m_Android = new global::Rush.Integrations.Ads.LevelPlayAdUnitSettings.PlatformField();
        [UnityEngine.Serialization.FormerlySerializedAs("m_Ios")]
        [UnityEngine.SerializeField]
        private global::Rush.Integrations.Ads.LevelPlayAdUnitSettings.PlatformField m_Ios = new global::Rush.Integrations.Ads.LevelPlayAdUnitSettings.PlatformField();
        private global::Rush.Integrations.Ads.LevelPlayAdUnitSettings.PlatformField CurrentPlatform
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
