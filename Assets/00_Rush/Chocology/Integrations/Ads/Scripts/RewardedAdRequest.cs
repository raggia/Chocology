using BsplabsMobileAds;
using UnityEngine.Events;

namespace Rush.Integrations.Ads
{
    // One request per button press. BSPLABS does not complete unavailable requests,
    // so finish those here to let the calling popup release its input lock.
    public sealed class RewardedAdRequest
    {
        private UnityAction<bool> m_Callback;
        private bool m_Started;
        private bool m_Completed;
        public void Show(UnityAction<bool> callback) => ShowInternal(callback);
        private void ShowInternal(UnityAction<bool> callback)
        {
            if (m_Started)
                return;
            m_Started = true;
            m_Callback = callback;
            var ads = BspLabsAdsMobile.Instance;
            if (!ads.IsRewardVideoAvailable())
            {
                CompleteInternal(false);
                return;
            }

            ads.ShowRewardedVideo(CompleteInternal);
        }

        private void CompleteInternal(bool completed)
        {
            if (m_Completed)
                return;
            m_Completed = true;
            var callback = m_Callback;
            m_Callback = null;
            callback?.Invoke(completed);
        }
    }
}
