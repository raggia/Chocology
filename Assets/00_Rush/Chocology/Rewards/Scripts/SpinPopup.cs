using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using Random = UnityEngine.Random;

namespace Rush.Chocology.Rewards
{
    [UnityEngine.Scripting.APIUpdating.MovedFrom(true, "", "Assembly-CSharp", "SpinPopup")]
    public class SpinPopup : MonoBehaviour
    {
        [global::System.Serializable]
        private sealed class SpinPopupField
        {
            [UnityEngine.Serialization.FormerlySerializedAs("btnClose")]
            [UnityEngine.SerializeField]
            private BBUIButton m_BtnClose;
            public global::BBUIButton BtnClose { get => m_BtnClose; set => m_BtnClose = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("btnWatchAds")]
            [UnityEngine.SerializeField]
            private BBUIButton m_BtnWatchAds;
            public global::BBUIButton BtnWatchAds { get => m_BtnWatchAds; set => m_BtnWatchAds = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("btnCoin")]
            [UnityEngine.SerializeField]
            private BBUIButton m_BtnCoin;
            public global::BBUIButton BtnCoin { get => m_BtnCoin; set => m_BtnCoin = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("popup")]
            [UnityEngine.SerializeField]
            private GameObject m_Popup;
            public global::UnityEngine.GameObject Popup { get => m_Popup; set => m_Popup = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("lockGroup")]
            [UnityEngine.SerializeField]
            private GameObject m_LockGroup;
            public global::UnityEngine.GameObject LockGroup { get => m_LockGroup; set => m_LockGroup = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("spinObj")]
            [UnityEngine.SerializeField]
            private GameObject m_SpinObj;
            public global::UnityEngine.GameObject SpinObj { get => m_SpinObj; set => m_SpinObj = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("listDatas")]
            [UnityEngine.SerializeField]
            private List<global::Rush.Chocology.Economy.ConfigItemShopData> m_ListDatas = new List<global::Rush.Chocology.Economy.ConfigItemShopData>();
            public global::System.Collections.Generic.List<global::Rush.Chocology.Economy.ConfigItemShopData> ListDatas { get => m_ListDatas; set => m_ListDatas = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("listPercents")]
            [UnityEngine.SerializeField]
            private List<float> m_ListPercents = new List<float>();
            public global::System.Collections.Generic.List<float> ListPercents { get => m_ListPercents; set => m_ListPercents = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("listSpinDatas")]
            [UnityEngine.SerializeField]
            private List<global::Rush.Chocology.Economy.ConfigItemShopData> m_ListSpinDatas = new List<global::Rush.Chocology.Economy.ConfigItemShopData>();
            public global::System.Collections.Generic.List<global::Rush.Chocology.Economy.ConfigItemShopData> ListSpinDatas { get => m_ListSpinDatas; set => m_ListSpinDatas = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("spinItem_Coin_Prefab")]
            [UnityEngine.SerializeField]
            private global::Rush.Chocology.Rewards.SpinItem m_SpinItemCoinPrefab;
            public global::Rush.Chocology.Rewards.SpinItem SpinItemCoinPrefab { get => m_SpinItemCoinPrefab; set => m_SpinItemCoinPrefab = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("spinItem_Undo_Prefab")]
            [UnityEngine.SerializeField]
            private global::Rush.Chocology.Rewards.SpinItem m_SpinItemUndoPrefab;
            public global::Rush.Chocology.Rewards.SpinItem SpinItemUndoPrefab { get => m_SpinItemUndoPrefab; set => m_SpinItemUndoPrefab = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("spinItem_Suggest_Prefab")]
            [UnityEngine.SerializeField]
            private global::Rush.Chocology.Rewards.SpinItem m_SpinItemSuggestPrefab;
            public global::Rush.Chocology.Rewards.SpinItem SpinItemSuggestPrefab { get => m_SpinItemSuggestPrefab; set => m_SpinItemSuggestPrefab = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("spinItem_Shuffle_Prefab")]
            [UnityEngine.SerializeField]
            private global::Rush.Chocology.Rewards.SpinItem m_SpinItemShufflePrefab;
            public global::Rush.Chocology.Rewards.SpinItem SpinItemShufflePrefab { get => m_SpinItemShufflePrefab; set => m_SpinItemShufflePrefab = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("listItemsPos")]
            [UnityEngine.SerializeField]
            private List<Transform> m_ListItemsPos = new List<Transform>();
            public global::System.Collections.Generic.List<global::UnityEngine.Transform> ListItemsPos { get => m_ListItemsPos; set => m_ListItemsPos = value; }
        }

        [global::UnityEngine.SerializeField]
        private SpinPopupField m_SpinPopupFields = new SpinPopupField();
        private static global::Rush.Chocology.Rewards.SpinPopup s_Instance;
        public static global::Rush.Chocology.Rewards.SpinPopup Instance { get => s_Instance; set => s_Instance = value; }
        public global::BBUIButton BtnClose { get => m_SpinPopupFields.BtnClose; set => m_SpinPopupFields.BtnClose = value; }
        public global::BBUIButton BtnWatchAds { get => m_SpinPopupFields.BtnWatchAds; set => m_SpinPopupFields.BtnWatchAds = value; }
        public global::BBUIButton BtnCoin { get => m_SpinPopupFields.BtnCoin; set => m_SpinPopupFields.BtnCoin = value; }
        public global::UnityEngine.GameObject Popup { get => m_SpinPopupFields.Popup; set => m_SpinPopupFields.Popup = value; }
        public global::UnityEngine.GameObject LockGroup { get => m_SpinPopupFields.LockGroup; set => m_SpinPopupFields.LockGroup = value; }
        public global::UnityEngine.GameObject SpinObj { get => m_SpinPopupFields.SpinObj; set => m_SpinPopupFields.SpinObj = value; }
        public global::System.Collections.Generic.List<global::Rush.Chocology.Economy.ConfigItemShopData> ListDatas { get => m_SpinPopupFields.ListDatas; set => m_SpinPopupFields.ListDatas = value; }
        public global::System.Collections.Generic.List<float> ListPercents { get => m_SpinPopupFields.ListPercents; set => m_SpinPopupFields.ListPercents = value; }
        public global::System.Collections.Generic.List<global::Rush.Chocology.Economy.ConfigItemShopData> ListSpinDatas { get => m_SpinPopupFields.ListSpinDatas; set => m_SpinPopupFields.ListSpinDatas = value; }
        public global::Rush.Chocology.Rewards.SpinItem SpinItemCoinPrefab { get => m_SpinPopupFields.SpinItemCoinPrefab; set => m_SpinPopupFields.SpinItemCoinPrefab = value; }
        public global::Rush.Chocology.Rewards.SpinItem SpinItemUndoPrefab { get => m_SpinPopupFields.SpinItemUndoPrefab; set => m_SpinPopupFields.SpinItemUndoPrefab = value; }
        public global::Rush.Chocology.Rewards.SpinItem SpinItemSuggestPrefab { get => m_SpinPopupFields.SpinItemSuggestPrefab; set => m_SpinPopupFields.SpinItemSuggestPrefab = value; }
        public global::Rush.Chocology.Rewards.SpinItem SpinItemShufflePrefab { get => m_SpinPopupFields.SpinItemShufflePrefab; set => m_SpinPopupFields.SpinItemShufflePrefab = value; }
        public global::System.Collections.Generic.List<global::UnityEngine.Transform> ListItemsPos { get => m_SpinPopupFields.ListItemsPos; set => m_SpinPopupFields.ListItemsPos = value; }

        private const float c_FullTurn = 360f;
        private const int c_SpinTurns = 4;
        private const float c_SpinDuration = 5f;
        private const float c_PopupRevealDelay = 0.1f;
        private const float c_FirstItemRevealDelay = 0.5f;
        private const float c_ItemRevealInterval = 0.1f;
        private const float c_FirstButtonRevealDelay = 1.5f;
        private const float c_ButtonRevealInterval = 0.2f;
        private const float c_CloseRevealDelay = 2f;
        private const float c_ButtonRefreshInterval = 0.5f;

        private Sequence m_RevealSequence;
        private Tween m_SpinTween;
        private int m_IndexResult;
        private int m_RotateSoundIndex;
        private int m_PaidSpinCost;
        private bool m_IsSpin;
        private bool m_AdPending;
        private bool m_IsClosing;
        private bool m_ControlsReady;
        private bool m_IsFreeSpin;
        private float m_NextButtonRefresh;

        private bool CanStartSpin => isActiveAndEnabled && m_ControlsReady &&
            !m_IsClosing && !m_IsSpin && !m_AdPending && WheelConfigurationValid;

        private bool WheelConfigurationValid
        {
            get
            {
                int count = m_SpinPopupFields.ListItemsPos.Count;
                if (count == 0 || count != m_SpinPopupFields.ListDatas.Count ||
                    count != m_SpinPopupFields.ListPercents.Count || m_SpinPopupFields.SpinObj == null)
                    return false;
                float total = 0f;
                for (int i = 0; i < count; i++)
                {
                    float weight = m_SpinPopupFields.ListPercents[i];
                    if (m_SpinPopupFields.ListItemsPos[i] == null || weight < 0f ||
                        float.IsNaN(weight) || float.IsInfinity(weight))
                        return false;
                    total += weight;
                }
                return total > 0f && !float.IsInfinity(total);
            }
        }

        private void Awake() => s_Instance = this;

        private void Start()
        {
            m_SpinPopupFields.BtnClose.OnPointerClickCallBack_Completed.AddListener(TouchCloseInternal);
            m_SpinPopupFields.BtnWatchAds.OnPointerClickCallBack_Completed.AddListener(TouchWatchAdsInternal);
            m_SpinPopupFields.BtnCoin.OnPointerClickCallBack_Completed.AddListener(TouchSpinCoinInternal);
            global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::BBUIView>(m_SpinPopupFields.Popup)
                .HideBehavior.onCallback_Completed.AddListener(HidePopupFinishedInternal);
        }

        private void Update()
        {
            if (m_IsSpin)
            {
                float sectorAngle = c_FullTurn / m_SpinPopupFields.ListItemsPos.Count;
                int index = Mathf.FloorToInt(m_SpinPopupFields.SpinObj.transform.localEulerAngles.z / sectorAngle);
                if (index != m_RotateSoundIndex)
                {
                    m_RotateSoundIndex = index;
                    global::Rush.Chocology.Audio.SoundManager.Instance.PlaySoundSpin();
                }
            }
            if (m_ControlsReady && Time.unscaledTime >= m_NextButtonRefresh)
            {
                m_NextButtonRefresh = Time.unscaledTime + c_ButtonRefreshInterval;
                RefreshButtonsInternal();
            }
        }

        public void OpenSpinPopup() => OpenSpinPopupInternal();
        private void OpenSpinPopupInternal()
        {
            if (m_IsSpin || m_AdPending || m_IsClosing)
                return;
            gameObject.SetActive(true);
            InitViewsInternal();
        }

        public void TouchClose() => TouchCloseInternal();
        private void TouchCloseInternal()
        {
            if (m_IsSpin || m_AdPending || m_IsClosing)
                return;
            m_IsClosing = true;
            m_ControlsReady = false;
            m_RevealSequence?.Kill();
            m_SpinPopupFields.LockGroup.SetActive(true);
            global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::BBUIView>(m_SpinPopupFields.Popup).HideView();
        }

        private void TouchSpinCoinInternal()
        {
            if (!CanStartSpin)
                return;
            var config = global::Rush.Chocology.Economy.Config.Runtime;
            if (config.CurrCoin < config.SpinPrice)
            {
                global::Rush.Chocology.Notifications.NotificationPopup.Instance.AddNotification("Not enough Coin!");
                global::Rush.Chocology.LevelMap.MenuManager.Instance.OpenShopCoin();
                return;
            }
            StartSpinInternal(false);
        }

        public void TouchWatchAds() => TouchWatchAdsInternal();
        private void TouchWatchAdsInternal()
        {
            if (!CanStartSpin || global::Rush.Chocology.Economy.Config.Runtime.SpinCooldownRemaining > 0)
                return;
            m_AdPending = true;
            RefreshButtonsInternal();
            new global::Rush.Integrations.Ads.RewardedAdRequest().Show(CompleteMethod);
        }

        private void CompleteMethod(bool completed)
        {
            if (!m_AdPending)
                return;
            m_AdPending = false;
            if (!isActiveAndEnabled || m_IsClosing)
                return;
            if (completed)
                WatchAdsFinishedInternal();
            else
                RefreshButtonsInternal();
        }

        public void WatchAdsFinished() => WatchAdsFinishedInternal();
        private void WatchAdsFinishedInternal()
        {
            if (!CanStartSpin || global::Rush.Chocology.Economy.Config.Runtime.SpinCooldownRemaining > 0)
                return;
            StartSpinInternal(true);
        }

        private void StartSpinInternal(bool freeSpin)
        {
            if (!CanStartSpin || m_SpinPopupFields.ListSpinDatas.Count != m_SpinPopupFields.ListItemsPos.Count)
                return;
            SetSpinResultInternal();
            m_IsSpin = true;
            m_IsFreeSpin = freeSpin;
            var config = global::Rush.Chocology.Economy.Config.Runtime;
            m_PaidSpinCost = freeSpin ? 0 : config.SpinPrice;
            if (m_PaidSpinCost > 0)
                config.SetCoin(config.CurrCoin - m_PaidSpinCost);
            RefreshButtonsInternal();

            // Explicit multi-turn local rotation: the default Fast mode discards full revolutions.
            float sectorAngle = c_FullTurn / m_SpinPopupFields.ListItemsPos.Count;
            float start = m_SpinPopupFields.SpinObj.transform.localEulerAngles.z;
            float target = m_IndexResult * sectorAngle;
            float end = start - c_SpinTurns * c_FullTurn - Mathf.Repeat(start - target, c_FullTurn);
            m_SpinTween = m_SpinPopupFields.SpinObj.transform
                .DOLocalRotate(new Vector3(0f, 0f, end), c_SpinDuration, RotateMode.FastBeyond360)
                .SetEase(Ease.InOutExpo).SetUpdate(true).SetLink(gameObject)
                .OnComplete(CompleteSpinInternal);
            global::Rush.Chocology.Notifications.GlobalVar.Runtime.CallAnalytics("play_spin");
        }

        private void SetSpinResultInternal()
        {
            float total = 0f;
            foreach (float weight in m_SpinPopupFields.ListPercents)
                total += weight;
            float sample = Random.Range(0f, total);
            m_IndexResult = 0;
            for (int i = 0; i < m_SpinPopupFields.ListPercents.Count; i++)
            {
                float weight = m_SpinPopupFields.ListPercents[i];
                if (weight <= 0f)
                    continue;
                m_IndexResult = i;
                if (sample < weight)
                    return;
                sample -= weight;
            }
        }

        private void CompleteSpinInternal()
        {
            if (!m_IsSpin)
                return;
            m_IsSpin = false;
            m_PaidSpinCost = 0;
            m_SpinTween = null;
            if (m_IsFreeSpin)
            {
                var config = global::Rush.Chocology.Economy.Config.Runtime;
                config.SetSpinLastTime();
                global::Rush.Chocology.Integrations.Analytics.AdjustManager.instance.LuckySpinClaimed();
                global::Rush.Chocology.Notifications.GlobalVar.Runtime.CreateSpinClaimNotification(
                    config.SpinTimeUtc.AddSeconds(global::Rush.Chocology.Economy.Config.TIME_SPIN).ToLocalTime());
            }
            RefreshButtonsInternal();
            global::Rush.Chocology.LevelMap.MenuManager.Instance.OpenRewardPopup(
                new List<global::Rush.Chocology.Economy.ConfigItemShopData> { m_SpinPopupFields.ListSpinDatas[m_IndexResult] });
        }

        private void RefreshButtonsInternal()
        {
            bool busy = m_IsSpin || m_AdPending || m_IsClosing;
            m_SpinPopupFields.LockGroup.SetActive(busy);
            m_SpinPopupFields.BtnClose.Interactable = !busy;
            m_SpinPopupFields.BtnCoin.Interactable = !busy && m_ControlsReady && WheelConfigurationValid;
            m_SpinPopupFields.BtnWatchAds.Interactable = !busy && m_ControlsReady && WheelConfigurationValid &&
                global::Rush.Chocology.Economy.Config.Runtime.SpinCooldownRemaining == 0;
        }

        public void HidePopupFinished() => HidePopupFinishedInternal();
        private void HidePopupFinishedInternal()
        {
            global::Rush.Chocology.LevelMap.MenuManager.Instance.CloseShopSucces();
            gameObject.SetActive(false);
        }

        public void InitViews() => InitViewsInternal();
        private void InitViewsInternal()
        {
            if (m_IsSpin || m_AdPending)
                return;
            m_RevealSequence?.Kill();
            m_IsClosing = false;
            m_ControlsReady = false;
            global::Rush.Chocology.Audio.SoundManager.Instance.PlaySoundPopup();
            m_SpinPopupFields.LockGroup.SetActive(false);
            m_SpinPopupFields.Popup.SetActive(false);
            m_SpinPopupFields.BtnWatchAds.gameObject.SetActive(false);
            m_SpinPopupFields.BtnCoin.gameObject.SetActive(false);
            m_SpinPopupFields.BtnClose.gameObject.SetActive(false);
            foreach (var slot in m_SpinPopupFields.ListItemsPos)
                slot.gameObject.SetActive(false);
            InitListItemsInternal();
            InitViewShowViewInternal();
        }

        public void InitListItems() => InitListItemsInternal();
        private void InitListItemsInternal()
        {
            if (!WheelConfigurationValid)
            {
                Debug.LogError("Spin wheel requires matching slots, rewards, and non-negative weights.", this);
                return;
            }
            foreach (var slot in m_SpinPopupFields.ListItemsPos)
                foreach (Transform child in slot)
                    Destroy(child.gameObject);
            var remaining = new List<global::Rush.Chocology.Economy.ConfigItemShopData>(m_SpinPopupFields.ListDatas);
            m_SpinPopupFields.ListSpinDatas.Clear();
            while (remaining.Count > 0)
            {
                int index = Random.Range(0, remaining.Count);
                m_SpinPopupFields.ListSpinDatas.Add(remaining[index]);
                remaining.RemoveAt(index);
            }
            for (int i = 0; i < m_SpinPopupFields.ListItemsPos.Count; i++)
            {
                var data = m_SpinPopupFields.ListSpinDatas[i];
                SpinItem prefab = null;
                switch (data.ShopItemType)
                {
                    case global::Rush.Chocology.Economy.Config.SHOPITEM.COIN: prefab = m_SpinPopupFields.SpinItemCoinPrefab; break;
                    case global::Rush.Chocology.Economy.Config.SHOPITEM.UNDO: prefab = m_SpinPopupFields.SpinItemUndoPrefab; break;
                    case global::Rush.Chocology.Economy.Config.SHOPITEM.SUGGEST: prefab = m_SpinPopupFields.SpinItemSuggestPrefab; break;
                    case global::Rush.Chocology.Economy.Config.SHOPITEM.SHUFFLE: prefab = m_SpinPopupFields.SpinItemShufflePrefab; break;
                }
                if (prefab != null)
                    Instantiate(prefab, m_SpinPopupFields.ListItemsPos[i]).InitSpinItem(data);
            }
        }

        public void InitViewShowView() => InitViewShowViewInternal();
        private void InitViewShowViewInternal()
        {
            m_RevealSequence?.Kill();
            var sequence = DOTween.Sequence().SetUpdate(true).SetLink(gameObject);
            m_RevealSequence = sequence;
            sequence.InsertCallback(c_PopupRevealDelay, () =>
                global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::BBUIView>(m_SpinPopupFields.Popup).ShowView());
            for (int i = 0; i < m_SpinPopupFields.ListItemsPos.Count; i++)
            {
                var slot = m_SpinPopupFields.ListItemsPos[i];
                sequence.InsertCallback(c_FirstItemRevealDelay + i * c_ItemRevealInterval, () =>
                {
                    global::Rush.Chocology.Audio.SoundManager.Instance.PlaySoundWinStarPop();
                    global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::BBUIView>(slot).ShowView();
                });
            }
            sequence.InsertCallback(c_FirstButtonRevealDelay, () =>
            {
                m_ControlsReady = true;
                global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::BBUIView>(m_SpinPopupFields.BtnWatchAds).ShowView();
                RefreshButtonsInternal();
            });
            sequence.InsertCallback(c_FirstButtonRevealDelay + c_ButtonRevealInterval, () =>
                global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::BBUIView>(m_SpinPopupFields.BtnCoin).ShowView());
            sequence.InsertCallback(c_CloseRevealDelay, () =>
                global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::BBUIView>(m_SpinPopupFields.BtnClose).ShowView());
        }

        private void OnDisable()
        {
            m_RevealSequence?.Kill();
            m_SpinTween?.Kill();
            m_RevealSequence = null;
            m_SpinTween = null;
            // A forced panel/scene interruption must not charge an unfinished paid spin.
            if (m_IsSpin && m_PaidSpinCost > 0 && global::Rush.Chocology.Economy.Config.Runtime != null)
            {
                var config = global::Rush.Chocology.Economy.Config.Runtime;
                config.SetCoin(config.CurrCoin + m_PaidSpinCost);
            }
            m_PaidSpinCost = 0;
            m_IsSpin = false;
            m_AdPending = false;
            m_IsClosing = false;
            m_ControlsReady = false;
        }

        private void OnDestroy()
        {
            if (s_Instance == this)
                s_Instance = null;
        }

    }
}
