/*
 * Created on 2022
 *
 * Copyright (c) 2022 dotmobstudio
 * Support : dotmobstudio@gmail.com
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using bonbon;

namespace Rush.Chocology.Economy
{
    [UnityEngine.Scripting.APIUpdating.MovedFrom(true, "", "Assembly-CSharp", "RewardPopup")]
    public class RewardPopup : MonoBehaviour
    {
        [global::System.Serializable]
        private sealed class RewardPopupField
        {
            [UnityEngine.Serialization.FormerlySerializedAs("btnClose")]
            [UnityEngine.SerializeField]
            private BBUIButton m_BtnClose;
            public global::BBUIButton BtnClose { get => m_BtnClose; set => m_BtnClose = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("popup")]
            [UnityEngine.SerializeField]
            private GameObject m_Popup;
            public global::UnityEngine.GameObject Popup { get => m_Popup; set => m_Popup = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("lockGroup")]
            [UnityEngine.SerializeField]
            private GameObject m_LockGroup;
            public global::UnityEngine.GameObject LockGroup { get => m_LockGroup; set => m_LockGroup = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("objLight")]
            [UnityEngine.SerializeField]
            private GameObject m_ObjLight;
            public global::UnityEngine.GameObject ObjLight { get => m_ObjLight; set => m_ObjLight = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("txtCollect")]
            [UnityEngine.SerializeField]
            private Text m_TxtCollect;
            public global::UnityEngine.UI.Text TxtCollect { get => m_TxtCollect; set => m_TxtCollect = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("listDatas")]
            [UnityEngine.SerializeField]
            private List<global::Rush.Chocology.Economy.ConfigItemShopData> m_ListDatas = new List<global::Rush.Chocology.Economy.ConfigItemShopData>();
            public global::System.Collections.Generic.List<global::Rush.Chocology.Economy.ConfigItemShopData> ListDatas { get => m_ListDatas; set => m_ListDatas = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("rewardItem_Coin_Prefab")]
            [UnityEngine.SerializeField]
            private global::Rush.Chocology.Economy.RewardItem m_RewardItemCoinPrefab;
            public global::Rush.Chocology.Economy.RewardItem RewardItemCoinPrefab { get => m_RewardItemCoinPrefab; set => m_RewardItemCoinPrefab = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("rewardItem_Undo_Prefab")]
            [UnityEngine.SerializeField]
            private global::Rush.Chocology.Economy.RewardItem m_RewardItemUndoPrefab;
            public global::Rush.Chocology.Economy.RewardItem RewardItemUndoPrefab { get => m_RewardItemUndoPrefab; set => m_RewardItemUndoPrefab = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("rewardItem_Suggest_Prefab")]
            [UnityEngine.SerializeField]
            private global::Rush.Chocology.Economy.RewardItem m_RewardItemSuggestPrefab;
            public global::Rush.Chocology.Economy.RewardItem RewardItemSuggestPrefab { get => m_RewardItemSuggestPrefab; set => m_RewardItemSuggestPrefab = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("rewardItem_Shuffle_Prefab")]
            [UnityEngine.SerializeField]
            private global::Rush.Chocology.Economy.RewardItem m_RewardItemShufflePrefab;
            public global::Rush.Chocology.Economy.RewardItem RewardItemShufflePrefab { get => m_RewardItemShufflePrefab; set => m_RewardItemShufflePrefab = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("contentReward")]
            [UnityEngine.SerializeField]
            private Transform m_ContentReward;
            public global::UnityEngine.Transform ContentReward { get => m_ContentReward; set => m_ContentReward = value; }
        }

        [global::UnityEngine.SerializeField]
        private RewardPopupField m_RewardPopupFields = new RewardPopupField();
        private static global::Rush.Chocology.Economy.RewardPopup s_Instance;
        public static global::Rush.Chocology.Economy.RewardPopup Instance { get => s_Instance; set => s_Instance = value; }
        public global::BBUIButton BtnClose { get => m_RewardPopupFields.BtnClose; set => m_RewardPopupFields.BtnClose = value; }
        public global::UnityEngine.GameObject Popup { get => m_RewardPopupFields.Popup; set => m_RewardPopupFields.Popup = value; }
        public global::UnityEngine.GameObject LockGroup { get => m_RewardPopupFields.LockGroup; set => m_RewardPopupFields.LockGroup = value; }
        public global::UnityEngine.GameObject ObjLight { get => m_RewardPopupFields.ObjLight; set => m_RewardPopupFields.ObjLight = value; }
        public global::UnityEngine.UI.Text TxtCollect { get => m_RewardPopupFields.TxtCollect; set => m_RewardPopupFields.TxtCollect = value; }
        public global::System.Collections.Generic.List<global::Rush.Chocology.Economy.ConfigItemShopData> ListDatas { get => m_RewardPopupFields.ListDatas; set => m_RewardPopupFields.ListDatas = value; }
        public global::Rush.Chocology.Economy.RewardItem RewardItemCoinPrefab { get => m_RewardPopupFields.RewardItemCoinPrefab; set => m_RewardPopupFields.RewardItemCoinPrefab = value; }
        public global::Rush.Chocology.Economy.RewardItem RewardItemUndoPrefab { get => m_RewardPopupFields.RewardItemUndoPrefab; set => m_RewardPopupFields.RewardItemUndoPrefab = value; }
        public global::Rush.Chocology.Economy.RewardItem RewardItemSuggestPrefab { get => m_RewardPopupFields.RewardItemSuggestPrefab; set => m_RewardPopupFields.RewardItemSuggestPrefab = value; }
        public global::Rush.Chocology.Economy.RewardItem RewardItemShufflePrefab { get => m_RewardPopupFields.RewardItemShufflePrefab; set => m_RewardPopupFields.RewardItemShufflePrefab = value; }
        public global::UnityEngine.Transform ContentReward { get => m_RewardPopupFields.ContentReward; set => m_RewardPopupFields.ContentReward = value; }

        private void Awake()
        {
            s_Instance = this;
        }

        // Start is called before the first frame update
        void Start()
        {
            m_RewardPopupFields.BtnClose.OnPointerClickCallBack_Completed.AddListener(TouchCloseInternal);
            // btnWatchAds.OnPointerClickCallBack_Completed.AddListener(TouchWatchAds);
            global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::BBUIView>( // btnWatchAds.OnPointerClickCallBack_Completed.AddListener(TouchWatchAds);
            m_RewardPopupFields.Popup).HideBehavior.onCallback_Completed.AddListener(HidePopupFinishedInternal);
        }

        // Update is called once per frame
        void Update()
        {
        }

        private bool m_IsShowCollectx2 = true;
        public void OpenRewardPopup(List<global::Rush.Chocology.Economy.ConfigItemShopData> _listDatas, bool _isShowCollectx2 = true) => OpenRewardPopupInternal(_listDatas, _isShowCollectx2);
        private void OpenRewardPopupInternal(List<global::Rush.Chocology.Economy.ConfigItemShopData> _listDatas, bool _isShowCollectx2 = true)
        {
            m_RewardPopupFields.ListDatas = _listDatas;
            gameObject.SetActive(true);
            m_IsShowCollectx2 = _isShowCollectx2;
            InitViewsInternal();
        }

        public void TouchClose() => TouchCloseInternal();
        private void TouchCloseInternal()
        {
            global::Rush.Chocology.Audio.SoundManager.Instance.PlaySoundCash();
            for (int i = 0; i < m_RewardPopupFields.ListDatas.Count; i++)
            {
                global::Rush.Chocology.Economy.Config.Runtime.BuySuccesItemShop(m_RewardPopupFields.ListDatas[i]);
            }

            m_RewardPopupFields.LockGroup.gameObject.SetActive(true);
            if (global::Rush.Chocology.Gameplay.GamePlayManager.Instance != null)
            {
                global::Rush.Chocology.Gameplay.GamePlayManager.Instance.SetUpdateCountItem();
            }

            StartCoroutine(TouchCloseIEnumeratorInternal());
        }

        public IEnumerator TouchCloseIEnumerator() => TouchCloseIEnumeratorInternal();
        private IEnumerator TouchCloseIEnumeratorInternal()
        {
            yield return new WaitForSeconds(.1f);
            global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::BBUIView>(m_RewardPopupFields.Popup).HideView();
        }

        public void TouchWatchAds() => TouchWatchAdsInternal();
        private void TouchWatchAdsInternal()
        {
        // btnWatchAds.Interactable = false;
        //        lockGroup.gameObject.SetActive(true);
        //        AdmobManager.instance.ShowRewardAd_CallBack((AdmobManager.ADS_CALLBACK_STATE state) => {
        //            if (state == AdmobManager.ADS_CALLBACK_STATE.SUCCESS)
        //            {
        //                lockGroup.gameObject.SetActive(false);
        //                //WatchAds
        //                WatchAds_Finished();
        //            }
        //            else
        //            {
        //                lockGroup.gameObject.SetActive(false);
        //            }
        //        });
        }

        public void WatchAdsFinished() => WatchAdsFinishedInternal();
        private void WatchAdsFinishedInternal()
        {
            global::Rush.Chocology.Audio.SoundManager.Instance.PlaySoundCash();
            for (int i = 0; i < m_RewardPopupFields.ListDatas.Count; i++)
            {
                m_RewardPopupFields.ListDatas[i].CountItem = m_RewardPopupFields.ListDatas[i].CountItem * 2;
                global::Rush.Chocology.Economy.Config.Runtime.BuySuccesItemShop(m_RewardPopupFields.ListDatas[i]);
            }

            m_RewardPopupFields.LockGroup.gameObject.SetActive(true);
            global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::BBUIView>(m_RewardPopupFields.Popup).HideView();
            if (global::Rush.Chocology.Gameplay.GamePlayManager.Instance != null)
            {
                global::Rush.Chocology.Gameplay.GamePlayManager.Instance.SetUpdateCountItem();
            }
        }

        public void InitViews() => InitViewsInternal();
        private void InitViewsInternal()
        {
            //SoundManager.instance.PlaySound_Popup();
            global::Rush.Chocology.Audio.SoundManager.Instance.PlaySoundReward();
            m_RewardPopupFields.LockGroup.gameObject.SetActive(false);
            m_RewardPopupFields.Popup.gameObject.SetActive(false);
            // if (isShowCollectx2)
            // {
            //     btnWatchAds.gameObject.SetActive(false);
            //     if (AdmobManager.instance.isRewardAds_Avaiable())
            //     {
            //         btnWatchAds.Interactable = true;
            //     }
            //     else {
            //         btnWatchAds.Interactable = false;
            //     }
            //
            //     txtCollect.color = new Color(156f/255f, 156f / 255f, 156f / 255f,1f);
            // }
            // else {
            //     btnWatchAds.gameObject.SetActive(false);
            //     txtCollect.color = new Color(1f,1f,1f, 1f);
            // }
            m_RewardPopupFields.BtnClose.gameObject.SetActive(false);
            foreach (Transform child in m_RewardPopupFields.ContentReward)
            {
                Destroy(child.gameObject);
            }

            m_RewardPopupFields.ObjLight.transform.localScale = Vector3.zero;
            InitListRewardsInternal();
            InitViewShowViewInternal();
        }

        public void InitListRewards() => InitListRewardsInternal();
        private void InitListRewardsInternal()
        {
            for (int i = 0; i < m_RewardPopupFields.ListDatas.Count; i++)
            {
                global::Rush.Chocology.Economy.RewardItem rewardItem = null;
                if (m_RewardPopupFields.ListDatas[i].ShopItemType == global::Rush.Chocology.Economy.Config.SHOPITEM.COIN)
                {
                    rewardItem = Instantiate(m_RewardPopupFields.RewardItemCoinPrefab, m_RewardPopupFields.ContentReward);
                }
                else if (m_RewardPopupFields.ListDatas[i].ShopItemType == global::Rush.Chocology.Economy.Config.SHOPITEM.UNDO)
                {
                    rewardItem = Instantiate(m_RewardPopupFields.RewardItemUndoPrefab, m_RewardPopupFields.ContentReward);
                }
                else if (m_RewardPopupFields.ListDatas[i].ShopItemType == global::Rush.Chocology.Economy.Config.SHOPITEM.SUGGEST)
                {
                    rewardItem = Instantiate(m_RewardPopupFields.RewardItemSuggestPrefab, m_RewardPopupFields.ContentReward);
                }
                else if (m_RewardPopupFields.ListDatas[i].ShopItemType == global::Rush.Chocology.Economy.Config.SHOPITEM.SHUFFLE)
                {
                    rewardItem = Instantiate(m_RewardPopupFields.RewardItemShufflePrefab, m_RewardPopupFields.ContentReward);
                }

                rewardItem.InitSpinItem(m_RewardPopupFields.ListDatas[i]);
            }
        }

        public void InitViewShowView() => InitViewShowViewInternal();
        private void InitViewShowViewInternal()
        {
            Sequence sequenceShowView = DOTween.Sequence();
            sequenceShowView.InsertCallback(0.1f, () =>
            {
                m_RewardPopupFields.Popup.gameObject.SetActive(true);
                global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::BBUIView>(m_RewardPopupFields.Popup).ShowView();
            });
            sequenceShowView.Insert(0.2f, m_RewardPopupFields.ObjLight.transform.DOScale(1f, 0.3f).SetEase(Ease.OutBack));
            sequenceShowView.InsertCallback(0.6f, () =>
            {
                SetRotateLight();
            });
            sequenceShowView.InsertCallback(0.6f, () =>
            {
                foreach (Transform child in m_RewardPopupFields.ContentReward)
                {
                    global::Rush.Chocology.Audio.SoundManager.Instance.PlaySoundWinStarPop();
                    global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::Rush.Chocology.Economy.RewardItem>(child).ShowView();
                }
            });
            // sequenceShowView.InsertCallback(1f, () =>
            // {
            //     if (isShowCollectx2)
            //     {
            //         btnWatchAds.gameObject.SetActive(true);
            //         btnWatchAds.gameObject.GetComponent<BBUIView>().ShowView();
            //     }
            // });
            sequenceShowView.InsertCallback(1f, () =>
            {
                m_RewardPopupFields.BtnClose.gameObject.SetActive(false);
                global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::BBUIView>(m_RewardPopupFields.BtnClose.gameObject).ShowView();
            });
        }

        public void HidePopupFinished() => HidePopupFinishedInternal();
        private void HidePopupFinishedInternal()
        {
            if (global::Rush.Chocology.LevelMap.MenuManager.Instance != null)
            {
                global::Rush.Chocology.LevelMap.MenuManager.Instance.SetRewardPpopupFinished();
            }
            else if (global::Rush.Chocology.Gameplay.GamePlayManager.Instance != null)
            {
                global::Rush.Chocology.Gameplay.GamePlayManager.Instance.SetRewardPpopupFinished();
            }

            gameObject.SetActive(false);
        }

        private void SetRotateLight()
        {
            //Debug.Log("SetRotateLightSetRotateLight");
            m_RewardPopupFields.ObjLight.transform.DORotate(new Vector3(0f, 0f, -90f), 1f).SetRelative(true).SetEase(Ease.Linear).SetLoops(-1, LoopType.Incremental);
        }
    }
}
