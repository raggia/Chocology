using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AdjustSdk;

namespace Rush.Chocology.Integrations.Analytics
{
    [UnityEngine.Scripting.APIUpdating.MovedFrom(true, "", "Assembly-CSharp", "AdjustManager")]
    public class AdjustManager : Singleton<AdjustManager>
    {
        [global::System.Serializable]
        private sealed class AdjustManagerField
        {
            [UnityEngine.Serialization.FormerlySerializedAs("PlayGameToken")]
            [UnityEngine.SerializeField]
            private string m_PlayGameToken;
            public string PlayGameToken { get => m_PlayGameToken; set => m_PlayGameToken = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("BackToHomeToken")]
            [UnityEngine.SerializeField]
            private string m_BackToHomeToken;
            public string BackToHomeToken { get => m_BackToHomeToken; set => m_BackToHomeToken = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("BonusLevelClearRewardClaimedToken")]
            [UnityEngine.SerializeField]
            private string m_BonusLevelClearRewardClaimedToken;
            public string BonusLevelClearRewardClaimedToken { get => m_BonusLevelClearRewardClaimedToken; set => m_BonusLevelClearRewardClaimedToken = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("BreakPiggyBankToken")]
            [UnityEngine.SerializeField]
            private string m_BreakPiggyBankToken;
            public string BreakPiggyBankToken { get => m_BreakPiggyBankToken; set => m_BreakPiggyBankToken = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("ContinueWith100CoinToken")]
            [UnityEngine.SerializeField]
            private string m_ContinueWith100CoinToken;
            public string ContinueWith100CoinToken { get => m_ContinueWith100CoinToken; set => m_ContinueWith100CoinToken = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("ContinueWithAdsToken")]
            [UnityEngine.SerializeField]
            private string m_ContinueWithAdsToken;
            public string ContinueWithAdsToken { get => m_ContinueWithAdsToken; set => m_ContinueWithAdsToken = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("LevelClearToken")]
            [UnityEngine.SerializeField]
            private string m_LevelClearToken;
            public string LevelClearToken { get => m_LevelClearToken; set => m_LevelClearToken = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("LevelFailedToken")]
            [UnityEngine.SerializeField]
            private string m_LevelFailedToken;
            public string LevelFailedToken { get => m_LevelFailedToken; set => m_LevelFailedToken = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("LuckySpinClaimedToken")]
            [UnityEngine.SerializeField]
            private string m_LuckySpinClaimedToken;
            public string LuckySpinClaimedToken { get => m_LuckySpinClaimedToken; set => m_LuckySpinClaimedToken = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("NextLevelToken")]
            [UnityEngine.SerializeField]
            private string m_NextLevelToken;
            public string NextLevelToken { get => m_NextLevelToken; set => m_NextLevelToken = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("RestartGameToken")]
            [UnityEngine.SerializeField]
            private string m_RestartGameToken;
            public string RestartGameToken { get => m_RestartGameToken; set => m_RestartGameToken = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("ShopOpenToken")]
            [UnityEngine.SerializeField]
            private string m_ShopOpenToken;
            public string ShopOpenToken { get => m_ShopOpenToken; set => m_ShopOpenToken = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("HintToken")]
            [UnityEngine.SerializeField]
            private string m_HintToken;
            public string HintToken { get => m_HintToken; set => m_HintToken = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("IAPPurchasedSuccessToken")]
            [UnityEngine.SerializeField]
            private string m_IAPPurchasedSuccessToken;
            public string IAPPurchasedSuccessToken { get => m_IAPPurchasedSuccessToken; set => m_IAPPurchasedSuccessToken = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("IAPPurchasedFailedToken")]
            [UnityEngine.SerializeField]
            private string m_IAPPurchasedFailedToken;
            public string IAPPurchasedFailedToken { get => m_IAPPurchasedFailedToken; set => m_IAPPurchasedFailedToken = value; }
        }

        [global::UnityEngine.SerializeField]
        private AdjustManagerField m_AdjustManagerFields = new AdjustManagerField();
        public void PlayGame() => PlayGameInternal();
        private void PlayGameInternal() => DoEvent(m_AdjustManagerFields.PlayGameToken);
        public void BackToHome() => BackToHomeInternal();
        private void BackToHomeInternal() => DoEvent(m_AdjustManagerFields.BackToHomeToken);
        public void BonusLevelClearRewardClaimed() => BonusLevelClearRewardClaimedInternal();
        private void BonusLevelClearRewardClaimedInternal() => DoEvent(m_AdjustManagerFields.BonusLevelClearRewardClaimedToken);
        public void BreakPiggyBank() => BreakPiggyBankInternal();
        private void BreakPiggyBankInternal() => DoEvent(m_AdjustManagerFields.BreakPiggyBankToken);
        public void ContinueWith100Coin() => ContinueWith100CoinInternal();
        private void ContinueWith100CoinInternal() => DoEvent(m_AdjustManagerFields.ContinueWith100CoinToken);
        public void ContinueWithAds() => ContinueWithAdsInternal();
        private void ContinueWithAdsInternal() => DoEvent(m_AdjustManagerFields.ContinueWithAdsToken);
        public void LevelClear() => LevelClearInternal();
        private void LevelClearInternal() => DoEvent(m_AdjustManagerFields.LevelClearToken);
        public void LevelFailed() => LevelFailedInternal();
        private void LevelFailedInternal() => DoEvent(m_AdjustManagerFields.LevelFailedToken);
        public void LuckySpinClaimed() => LuckySpinClaimedInternal();
        private void LuckySpinClaimedInternal() => DoEvent(m_AdjustManagerFields.LuckySpinClaimedToken);
        public void NextLevel() => NextLevelInternal();
        private void NextLevelInternal() => DoEvent(m_AdjustManagerFields.NextLevelToken);
        public void RestartGame() => RestartGameInternal();
        private void RestartGameInternal() => DoEvent(m_AdjustManagerFields.RestartGameToken);
        public void ShopOpen() => ShopOpenInternal();
        private void ShopOpenInternal() => DoEvent(m_AdjustManagerFields.ShopOpenToken);
        public void Hint() => HintInternal();
        private void HintInternal() => DoEvent(m_AdjustManagerFields.HintToken);
        public void IAPPurchasedSuccess() => IAPPurchasedSuccessInternal();
        private void IAPPurchasedSuccessInternal() => DoEvent(m_AdjustManagerFields.IAPPurchasedSuccessToken);
        public void IAPPurchasedFailed() => IAPPurchasedFailedInternal();
        private void IAPPurchasedFailedInternal() => DoEvent(m_AdjustManagerFields.IAPPurchasedFailedToken);
        void DoEvent(string _token)
        {
            AdjustEvent adjust = new(_token);
            Adjust.TrackEvent(adjust);
        }
    }
}
