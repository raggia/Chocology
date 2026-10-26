using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using bonbon;
using BsplabsMobileAds;
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

        private void Awake()
        {
            s_Instance = this;
        }

        // Start is called before the first frame update
        void Start()
        {
            m_SpinPopupFields.BtnClose.OnPointerClickCallBack_Completed.AddListener(TouchCloseInternal);
            m_SpinPopupFields.BtnWatchAds.OnPointerClickCallBack_Completed.AddListener(TouchWatchAdsInternal);
            m_SpinPopupFields.BtnCoin.OnPointerClickCallBack_Completed.AddListener(TouchSpinCoin);
            global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::BBUIView>(m_SpinPopupFields.Popup).HideBehavior.onCallback_Completed.AddListener(HidePopupFinishedInternal);
        }

        private // Update is called once per frame
        int m_RotateSoundIndex = 0;
        void Update()
        {
            if (m_IsSpin)
            {
                int spinIndex = Mathf.FloorToInt(global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::UnityEngine.RectTransform>(m_SpinPopupFields.SpinObj).eulerAngles.z / 45f);
                if (m_RotateSoundIndex != spinIndex)
                {
                    m_RotateSoundIndex = spinIndex;
                    global::Rush.Chocology.Audio.SoundManager.Instance.PlaySoundSpin();
                }
            }
        }

        public void OpenSpinPopup() => OpenSpinPopupInternal();
        private void OpenSpinPopupInternal()
        {
            gameObject.SetActive(true);
            InitViewsInternal();
        }

        public void TouchClose() => TouchCloseInternal();
        private void TouchCloseInternal()
        {
            m_SpinPopupFields.LockGroup.gameObject.SetActive(true);
            global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::BBUIView>(m_SpinPopupFields.Popup).HideView();
        }

        private void TouchSpinCoin()
        {
            if (global::Rush.Chocology.Economy.Config.Runtime.CurrCoin >= global::Rush.Chocology.Economy.Config.Runtime.SpinPrice)
            {
                global::Rush.Chocology.Economy.Config.Runtime.SetCoin(global::Rush.Chocology.Economy.Config.Runtime.CurrCoin - global::Rush.Chocology.Economy.Config.Runtime.SpinPrice);
                WatchAdsFinishedInternal();
            }
            else
            {
                global::Rush.Chocology.Notifications.NotificationPopup.Instance.AddNotification("Not enough Coin!");
                //GamePlayManager.instance.OpenShopPopup();
                global::Rush.Chocology.LevelMap.MenuManager.Instance.OpenShopCoin();
            }
        }

        public void TouchWatchAds() => TouchWatchAdsInternal();
        private void TouchWatchAdsInternal()
        {
            m_SpinPopupFields.BtnWatchAds.Interactable = false;
            m_SpinPopupFields.LockGroup.gameObject.SetActive(true);
            new global::Rush.Integrations.Ads.RewardedAdRequest().Show(CompleteMethod);
        }

        private void CompleteMethod(bool completed)
        {
            if (completed == true)
            {
                m_SpinPopupFields.LockGroup.gameObject.SetActive(false);
                //WatchAds
                WatchAdsFinishedInternal();
                global::Rush.Chocology.Integrations.Analytics.AdjustManager.instance.LuckySpinClaimed();
                global::Rush.Chocology.Notifications.GlobalVar.Runtime.CreateSpinClaimNotification(global::Rush.Chocology.Notifications.TimerFromServer.Instance.DateTimeNowOnServer.AddSeconds(global::Rush.Chocology.Economy.Config.TIME_SPIN));
                Debug.Log("Message Will appear in : " + global::Rush.Chocology.Economy.Config.TIME_SPIN + "h");
            }
            else
            {
                m_SpinPopupFields.LockGroup.gameObject.SetActive(false);
            }
        }

        private int m_IndexResult;
        private bool m_IsSpin = false;
        public void WatchAdsFinished() => WatchAdsFinishedInternal();
        private void WatchAdsFinishedInternal()
        {
            //Spin
            m_IndexResult = RandomExtension.RandomPercentage(m_SpinPopupFields.ListPercents.ToArray());
            //indexResult = 1;
            if (m_IndexResult == 8)
                m_IndexResult = 0;
            Debug.Log("indexResult" + m_IndexResult);
            m_SpinPopupFields.LockGroup.gameObject.SetActive(true);
            m_IsSpin = true;
            m_SpinPopupFields.SpinObj.transform.DORotate(new Vector3(0f, 0f, -4 * 360 - (8 - m_IndexResult) * 45), 5f).SetEase(Ease.InOutExpo).OnComplete(() =>
            {
                m_IsSpin = false;
                m_SpinPopupFields.LockGroup.gameObject.SetActive(false);
                Debug.Log(m_SpinPopupFields.ListSpinDatas[m_IndexResult].ShopItemType);
                Debug.Log(m_SpinPopupFields.ListSpinDatas[m_IndexResult].CountItem);
                global::Rush.Chocology.Economy.Config.Runtime.SetSpinLastTime();
                global::Rush.Chocology.LevelMap.MenuManager.Instance.OpenRewardPopup(new List<global::Rush.Chocology.Economy.ConfigItemShopData>() { m_SpinPopupFields.ListSpinDatas[m_IndexResult] });
            //GamePlayManager.instance.OpenRewardPopup(new List<ConfigItemShopData>() { listSpinDatas[indexResult] });
            });
            global::Rush.Chocology.Notifications.GlobalVar.Runtime.CallAnalytics("play_spin");
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
            global::Rush.Chocology.Audio.SoundManager.Instance.PlaySoundPopup();
            m_SpinPopupFields.LockGroup.gameObject.SetActive(false);
            m_SpinPopupFields.Popup.gameObject.SetActive(false);
            m_SpinPopupFields.BtnWatchAds.gameObject.SetActive(false);
            m_SpinPopupFields.BtnCoin.gameObject.SetActive(false);
            //Debug.Log("isRewardAds_Avaiable"+ Advertisements.Instance.IsRewardVideoAvailable());
            long currTimeLastTime = global::Rush.Chocology.Economy.Config.Runtime.SpinLastTime;
            if (currTimeLastTime + global::Rush.Chocology.Economy.Config.TIME_SPIN < global::Rush.Chocology.Economy.Config.Runtime.TimeStamp)
            {
                m_SpinPopupFields.BtnWatchAds.Interactable = true;
            }
            else
            {
                m_SpinPopupFields.BtnWatchAds.Interactable = false;
            }

            m_SpinPopupFields.BtnClose.gameObject.SetActive(false);
            for (int i = 0; i < m_SpinPopupFields.ListItemsPos.Count; i++)
            {
                m_SpinPopupFields.ListItemsPos[i].gameObject.SetActive(false);
            }

            InitListItemsInternal();
            InitViewShowViewInternal();
        }

        public void InitListItems() => InitListItemsInternal();
        private void InitListItemsInternal()
        {
            for (int i = 0; i < m_SpinPopupFields.ListItemsPos.Count; i++)
            {
                foreach (Transform child in m_SpinPopupFields.ListItemsPos[i])
                {
                    Destroy(child.gameObject);
                }
            }

            List<global::Rush.Chocology.Economy.ConfigItemShopData> listSpinDatas_Temp = new List<global::Rush.Chocology.Economy.ConfigItemShopData>(m_SpinPopupFields.ListDatas);
            m_SpinPopupFields.ListSpinDatas.Clear();
            for (int i = 0; i < m_SpinPopupFields.ListDatas.Count; i++)
            {
                int index = Random.Range(0, listSpinDatas_Temp.Count);
                m_SpinPopupFields.ListSpinDatas.Add(listSpinDatas_Temp[index]);
                listSpinDatas_Temp.RemoveAt(index);
            }

            for (int i = 0; i < m_SpinPopupFields.ListItemsPos.Count; i++)
            {
                global::Rush.Chocology.Rewards.SpinItem spinItem = null;
                if (m_SpinPopupFields.ListSpinDatas[i].ShopItemType == global::Rush.Chocology.Economy.Config.SHOPITEM.COIN)
                {
                    spinItem = Instantiate(m_SpinPopupFields.SpinItemCoinPrefab, m_SpinPopupFields.ListItemsPos[i]);
                }
                else if (m_SpinPopupFields.ListSpinDatas[i].ShopItemType == global::Rush.Chocology.Economy.Config.SHOPITEM.UNDO)
                {
                    spinItem = Instantiate(m_SpinPopupFields.SpinItemUndoPrefab, m_SpinPopupFields.ListItemsPos[i]);
                }
                else if (m_SpinPopupFields.ListSpinDatas[i].ShopItemType == global::Rush.Chocology.Economy.Config.SHOPITEM.SUGGEST)
                {
                    spinItem = Instantiate(m_SpinPopupFields.SpinItemSuggestPrefab, m_SpinPopupFields.ListItemsPos[i]);
                }
                else if (m_SpinPopupFields.ListSpinDatas[i].ShopItemType == global::Rush.Chocology.Economy.Config.SHOPITEM.SHUFFLE)
                {
                    spinItem = Instantiate(m_SpinPopupFields.SpinItemShufflePrefab, m_SpinPopupFields.ListItemsPos[i]);
                }

                spinItem.InitSpinItem(m_SpinPopupFields.ListSpinDatas[i]);
            }
        }

        public void InitViewShowView() => InitViewShowViewInternal();
        private void InitViewShowViewInternal()
        {
            Sequence sequenceShowView = DOTween.Sequence();
            sequenceShowView.InsertCallback(0.1f, () =>
            {
                m_SpinPopupFields.Popup.gameObject.SetActive(true);
                global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::BBUIView>(m_SpinPopupFields.Popup).ShowView();
            });
            sequenceShowView.InsertCallback(0.5f, () =>
            {
                global::Rush.Chocology.Audio.SoundManager.Instance.PlaySoundWinStarPop();
                m_SpinPopupFields.ListItemsPos[0].gameObject.SetActive(true);
                global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::BBUIView>(m_SpinPopupFields.ListItemsPos[0]).ShowView();
            });
            sequenceShowView.InsertCallback(0.6f, () =>
            {
                global::Rush.Chocology.Audio.SoundManager.Instance.PlaySoundWinStarPop();
                m_SpinPopupFields.ListItemsPos[1].gameObject.SetActive(true);
                global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::BBUIView>(m_SpinPopupFields.ListItemsPos[1]).ShowView();
            });
            sequenceShowView.InsertCallback(0.7f, () =>
            {
                global::Rush.Chocology.Audio.SoundManager.Instance.PlaySoundWinStarPop();
                m_SpinPopupFields.ListItemsPos[2].gameObject.SetActive(true);
                global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::BBUIView>(m_SpinPopupFields.ListItemsPos[2]).ShowView();
            });
            sequenceShowView.InsertCallback(0.8f, () =>
            {
                global::Rush.Chocology.Audio.SoundManager.Instance.PlaySoundWinStarPop();
                m_SpinPopupFields.ListItemsPos[3].gameObject.SetActive(true);
                global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::BBUIView>(m_SpinPopupFields.ListItemsPos[3]).ShowView();
            });
            sequenceShowView.InsertCallback(0.9f, () =>
            {
                global::Rush.Chocology.Audio.SoundManager.Instance.PlaySoundWinStarPop();
                m_SpinPopupFields.ListItemsPos[4].gameObject.SetActive(true);
                global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::BBUIView>(m_SpinPopupFields.ListItemsPos[4]).ShowView();
            });
            sequenceShowView.InsertCallback(1f, () =>
            {
                global::Rush.Chocology.Audio.SoundManager.Instance.PlaySoundWinStarPop();
                m_SpinPopupFields.ListItemsPos[5].gameObject.SetActive(true);
                global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::BBUIView>(m_SpinPopupFields.ListItemsPos[5]).ShowView();
            });
            sequenceShowView.InsertCallback(1.1f, () =>
            {
                global::Rush.Chocology.Audio.SoundManager.Instance.PlaySoundWinStarPop();
                m_SpinPopupFields.ListItemsPos[6].gameObject.SetActive(true);
                global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::BBUIView>(m_SpinPopupFields.ListItemsPos[6]).ShowView();
            });
            sequenceShowView.InsertCallback(1.2f, () =>
            {
                global::Rush.Chocology.Audio.SoundManager.Instance.PlaySoundWinStarPop();
                m_SpinPopupFields.ListItemsPos[7].gameObject.SetActive(true);
                global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::BBUIView>(m_SpinPopupFields.ListItemsPos[7]).ShowView();
            });
            sequenceShowView.InsertCallback(1.3f, () =>
            {
                global::Rush.Chocology.Audio.SoundManager.Instance.PlaySoundWinStarPop();
                m_SpinPopupFields.ListItemsPos[8].gameObject.SetActive(true);
                global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::BBUIView>(m_SpinPopupFields.ListItemsPos[8]).ShowView();
            });
            sequenceShowView.InsertCallback(1.5f, () =>
            {
                m_SpinPopupFields.BtnWatchAds.gameObject.SetActive(false);
                global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::BBUIView>(m_SpinPopupFields.BtnWatchAds.gameObject).ShowView();
            });
            sequenceShowView.InsertCallback(1.7f, () =>
            {
                m_SpinPopupFields.BtnCoin.gameObject.SetActive(false);
                global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::BBUIView>(m_SpinPopupFields.BtnCoin.gameObject).ShowView();
            });
            sequenceShowView.InsertCallback(2f, () =>
            {
                m_SpinPopupFields.BtnClose.gameObject.SetActive(false);
                global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::BBUIView>(m_SpinPopupFields.BtnClose.gameObject).ShowView();
            });
        }
    }
}
