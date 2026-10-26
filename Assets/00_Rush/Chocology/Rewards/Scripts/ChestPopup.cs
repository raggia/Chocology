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
using BsplabsMobileAds;

namespace Rush.Chocology.Rewards
{
    [UnityEngine.Scripting.APIUpdating.MovedFrom(true, "", "Assembly-CSharp", "ChestPopup")]
    public class ChestPopup : MonoBehaviour
    {
        [global::System.Serializable]
        private sealed class ChestPopupField
        {
            [UnityEngine.Serialization.FormerlySerializedAs("btnClose")]
            [UnityEngine.SerializeField]
            private BBUIButton m_BtnClose;
            public global::BBUIButton BtnClose { get => m_BtnClose; set => m_BtnClose = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("btnWatchAds")]
            [UnityEngine.SerializeField]
            private BBUIButton m_BtnWatchAds;
            public global::BBUIButton BtnWatchAds { get => m_BtnWatchAds; set => m_BtnWatchAds = value; }

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

            [UnityEngine.Serialization.FormerlySerializedAs("objChest")]
            [UnityEngine.SerializeField]
            private GameObject m_ObjChest;
            public global::UnityEngine.GameObject ObjChest { get => m_ObjChest; set => m_ObjChest = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("objChest2")]
            [UnityEngine.SerializeField]
            private GameObject m_ObjChest2;
            public global::UnityEngine.GameObject ObjChest2 { get => m_ObjChest2; set => m_ObjChest2 = value; }

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

            [UnityEngine.Serialization.FormerlySerializedAs("fx1")]
            [UnityEngine.SerializeField]
            private ParticleSystem m_Fx1;
            public global::UnityEngine.ParticleSystem Fx1 { get => m_Fx1; set => m_Fx1 = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("fx2")]
            [UnityEngine.SerializeField]
            private ParticleSystem m_Fx2;
            public global::UnityEngine.ParticleSystem Fx2 { get => m_Fx2; set => m_Fx2 = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("fx3")]
            [UnityEngine.SerializeField]
            private ParticleSystem m_Fx3;
            public global::UnityEngine.ParticleSystem Fx3 { get => m_Fx3; set => m_Fx3 = value; }
        }

        [global::UnityEngine.SerializeField]
        private ChestPopupField m_ChestPopupFields = new ChestPopupField();
        private static global::Rush.Chocology.Rewards.ChestPopup s_Instance;
        public static global::Rush.Chocology.Rewards.ChestPopup Instance { get => s_Instance; set => s_Instance = value; }
        public global::BBUIButton BtnClose { get => m_ChestPopupFields.BtnClose; set => m_ChestPopupFields.BtnClose = value; }
        public global::BBUIButton BtnWatchAds { get => m_ChestPopupFields.BtnWatchAds; set => m_ChestPopupFields.BtnWatchAds = value; }
        public global::UnityEngine.GameObject Popup { get => m_ChestPopupFields.Popup; set => m_ChestPopupFields.Popup = value; }
        public global::UnityEngine.GameObject LockGroup { get => m_ChestPopupFields.LockGroup; set => m_ChestPopupFields.LockGroup = value; }
        public global::UnityEngine.GameObject ObjLight { get => m_ChestPopupFields.ObjLight; set => m_ChestPopupFields.ObjLight = value; }
        public global::UnityEngine.GameObject ObjChest { get => m_ChestPopupFields.ObjChest; set => m_ChestPopupFields.ObjChest = value; }
        public global::UnityEngine.GameObject ObjChest2 { get => m_ChestPopupFields.ObjChest2; set => m_ChestPopupFields.ObjChest2 = value; }
        public global::System.Collections.Generic.List<global::Rush.Chocology.Economy.ConfigItemShopData> ListDatas { get => m_ChestPopupFields.ListDatas; set => m_ChestPopupFields.ListDatas = value; }
        public global::Rush.Chocology.Economy.RewardItem RewardItemCoinPrefab { get => m_ChestPopupFields.RewardItemCoinPrefab; set => m_ChestPopupFields.RewardItemCoinPrefab = value; }
        public global::Rush.Chocology.Economy.RewardItem RewardItemUndoPrefab { get => m_ChestPopupFields.RewardItemUndoPrefab; set => m_ChestPopupFields.RewardItemUndoPrefab = value; }
        public global::Rush.Chocology.Economy.RewardItem RewardItemSuggestPrefab { get => m_ChestPopupFields.RewardItemSuggestPrefab; set => m_ChestPopupFields.RewardItemSuggestPrefab = value; }
        public global::Rush.Chocology.Economy.RewardItem RewardItemShufflePrefab { get => m_ChestPopupFields.RewardItemShufflePrefab; set => m_ChestPopupFields.RewardItemShufflePrefab = value; }
        public global::UnityEngine.Transform ContentReward { get => m_ChestPopupFields.ContentReward; set => m_ChestPopupFields.ContentReward = value; }
        public global::UnityEngine.ParticleSystem Fx1 { get => m_ChestPopupFields.Fx1; set => m_ChestPopupFields.Fx1 = value; }
        public global::UnityEngine.ParticleSystem Fx2 { get => m_ChestPopupFields.Fx2; set => m_ChestPopupFields.Fx2 = value; }
        public global::UnityEngine.ParticleSystem Fx3 { get => m_ChestPopupFields.Fx3; set => m_ChestPopupFields.Fx3 = value; }

        private void Awake()
        {
            s_Instance = this;
        }

        // Start is called before the first frame update
        void Start()
        {
            m_ChestPopupFields.BtnClose.OnPointerClickCallBack_Completed.AddListener(TouchCloseInternal);
            m_ChestPopupFields.BtnWatchAds.OnPointerClickCallBack_Completed.AddListener(TouchWatchAdsInternal);
            global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::BBUIView>(m_ChestPopupFields.Popup).HideBehavior.onCallback_Completed.AddListener(HidePopupFinishedInternal);
        }

        // Update is called once per frame
        void Update()
        {
        }

        public void OpenChestPopup(bool isFullStar) => OpenChestPopupInternal(isFullStar);
        private void OpenChestPopupInternal(bool isFullStar)
        {
            global::Rush.Chocology.Economy.ConfigItemShopData configItemShopData_Coin = new global::Rush.Chocology.Economy.ConfigItemShopData();
            configItemShopData_Coin.ShopItemType = global::Rush.Chocology.Economy.Config.SHOPITEM.COIN;
            if (isFullStar)
            {
                configItemShopData_Coin.CountItem = Random.Range(50, 100);
            }
            else
            {
                configItemShopData_Coin.CountItem = Random.Range(50, 100);
            }

            configItemShopData_Coin.Price = 0;
            m_ChestPopupFields.ListDatas.Add(configItemShopData_Coin);
            global::Rush.Chocology.Economy.ConfigItemShopData configItemShopData_Undo = new global::Rush.Chocology.Economy.ConfigItemShopData();
            configItemShopData_Undo.ShopItemType = global::Rush.Chocology.Economy.Config.SHOPITEM.UNDO;
            if (isFullStar)
            {
                configItemShopData_Undo.CountItem = Random.Range(0, 2);
            }
            else
            {
                configItemShopData_Undo.CountItem = Random.Range(0, 2);
            }

            configItemShopData_Undo.Price = 0;
            if (configItemShopData_Undo.CountItem > 0)
            {
                m_ChestPopupFields.ListDatas.Add(configItemShopData_Undo);
            }

            global::Rush.Chocology.Economy.ConfigItemShopData configItemShopData_Suggest = new global::Rush.Chocology.Economy.ConfigItemShopData();
            configItemShopData_Suggest.ShopItemType = global::Rush.Chocology.Economy.Config.SHOPITEM.SUGGEST;
            if (isFullStar)
            {
                configItemShopData_Suggest.CountItem = Random.Range(1, 3);
            }
            else
            {
                configItemShopData_Suggest.CountItem = Random.Range(0, 2);
            }

            configItemShopData_Suggest.Price = 0;
            if (configItemShopData_Suggest.CountItem > 0)
            {
                m_ChestPopupFields.ListDatas.Add(configItemShopData_Suggest);
            }

            global::Rush.Chocology.Economy.ConfigItemShopData configItemShopData_Shuffle = new global::Rush.Chocology.Economy.ConfigItemShopData();
            configItemShopData_Shuffle.ShopItemType = global::Rush.Chocology.Economy.Config.SHOPITEM.SHUFFLE;
            if (isFullStar)
            {
                configItemShopData_Shuffle.CountItem = Random.Range(0, 2);
            }
            else
            {
                configItemShopData_Shuffle.CountItem = Random.Range(0, 2);
            }

            configItemShopData_Shuffle.Price = 0;
            if (configItemShopData_Shuffle.CountItem > 0)
            {
                m_ChestPopupFields.ListDatas.Add(configItemShopData_Shuffle);
            }

            gameObject.SetActive(true);
            InitViewsInternal();
        }

        public void TouchClose() => TouchCloseInternal();
        private void TouchCloseInternal()
        {
            /*SoundManager.instance.PlaySound_Cash();
        for (int i = 0; i < listDatas.Count; i++)
        {
            Config.BuySucces_ItemShop(listDatas[i]);
        }*/
            m_ChestPopupFields.LockGroup.gameObject.SetActive(true);
            global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::BBUIView>(m_ChestPopupFields.Popup).HideView();
        }

        public void TouchWatchAds() => TouchWatchAdsInternal();
        private void TouchWatchAdsInternal()
        {
            m_ChestPopupFields.LockGroup.gameObject.SetActive(true);
            new global::Rush.Integrations.Ads.RewardedAdRequest().Show(CompleteMethod);
        }

        private void CompleteMethod(bool completed)
        {
            if (completed == true)
            {
                m_ChestPopupFields.LockGroup.gameObject.SetActive(false);
                //WatchAds
                WatchAdsFinishedInternal();
            }
            else
            {
                m_ChestPopupFields.LockGroup.gameObject.SetActive(false);
            }
        }

        public void WatchAdsFinished() => WatchAdsFinishedInternal();
        private void WatchAdsFinishedInternal()
        {
            global::Rush.Chocology.Audio.SoundManager.Instance.PlaySoundCash();
            for (int i = 0; i < m_ChestPopupFields.ListDatas.Count; i++)
            {
                m_ChestPopupFields.ListDatas[i].CountItem = m_ChestPopupFields.ListDatas[i].CountItem;
                global::Rush.Chocology.Economy.Config.Runtime.BuySuccesItemShop(m_ChestPopupFields.ListDatas[i]);
            }

            m_ChestPopupFields.LockGroup.gameObject.SetActive(true);
            global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::BBUIView>(m_ChestPopupFields.Popup).HideView();
            if (global::Rush.Chocology.Gameplay.GamePlayManager.Instance != null && global::Rush.Chocology.Gameplay.GamePlayManager.Instance.isActiveAndEnabled)
            {
                global::Rush.Chocology.Gameplay.GamePlayManager.Instance.SetUpdateCountItem();
            }
        }

        public void InitViews() => InitViewsInternal();
        private void InitViewsInternal()
        {
            global::Rush.Chocology.Audio.SoundManager.Instance.PlaySoundPopup();
            m_ChestPopupFields.LockGroup.gameObject.SetActive(false);
            m_ChestPopupFields.Popup.gameObject.SetActive(false);
            m_ChestPopupFields.BtnWatchAds.gameObject.SetActive(false);
            if (BspLabsAdsMobile.Instance.IsRewardVideoAvailable())
            {
                m_ChestPopupFields.BtnWatchAds.Interactable = true;
            }
            else
            {
                m_ChestPopupFields.BtnWatchAds.Interactable = false;
            }

            m_ChestPopupFields.BtnClose.gameObject.SetActive(false);
            foreach (Transform child in m_ChestPopupFields.ContentReward)
            {
                Destroy(m_ChestPopupFields.ContentReward);
            }

            m_ChestPopupFields.ObjLight.transform.localScale = Vector3.zero;
            m_ChestPopupFields.ObjChest.transform.localScale = Vector3.zero;
            m_ChestPopupFields.ObjChest2.transform.localScale = Vector3.zero;
            global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::UnityEngine.RectTransform>(m_ChestPopupFields.ObjChest2).anchoredPosition = new Vector2(390f, -173f);
            InitListRewardsInternal();
            InitViewShowViewInternal();
        }

        public void InitListRewards() => InitListRewardsInternal();
        private void InitListRewardsInternal()
        {
            for (int i = 0; i < m_ChestPopupFields.ListDatas.Count; i++)
            {
                global::Rush.Chocology.Economy.RewardItem rewardItem = null;
                if (m_ChestPopupFields.ListDatas[i].ShopItemType == global::Rush.Chocology.Economy.Config.SHOPITEM.COIN)
                {
                    rewardItem = Instantiate(m_ChestPopupFields.RewardItemCoinPrefab, m_ChestPopupFields.ContentReward);
                }
                else if (m_ChestPopupFields.ListDatas[i].ShopItemType == global::Rush.Chocology.Economy.Config.SHOPITEM.UNDO)
                {
                    rewardItem = Instantiate(m_ChestPopupFields.RewardItemUndoPrefab, m_ChestPopupFields.ContentReward);
                }
                else if (m_ChestPopupFields.ListDatas[i].ShopItemType == global::Rush.Chocology.Economy.Config.SHOPITEM.SUGGEST)
                {
                    rewardItem = Instantiate(m_ChestPopupFields.RewardItemSuggestPrefab, m_ChestPopupFields.ContentReward);
                }
                else if (m_ChestPopupFields.ListDatas[i].ShopItemType == global::Rush.Chocology.Economy.Config.SHOPITEM.SHUFFLE)
                {
                    rewardItem = Instantiate(m_ChestPopupFields.RewardItemShufflePrefab, m_ChestPopupFields.ContentReward);
                }

                rewardItem.InitSpinItem(m_ChestPopupFields.ListDatas[i]);
            }
        }

        public void InitViewShowView() => InitViewShowViewInternal();
        private void InitViewShowViewInternal()
        {
            float timeOpenChest = 2.5f;
            Sequence sequenceShowView = DOTween.Sequence();
            sequenceShowView.InsertCallback(0f, () =>
            {
                m_ChestPopupFields.ObjChest2.gameObject.SetActive(true);
                m_ChestPopupFields.ObjChest2.transform.localScale = new Vector3(0.35f, 0.35f, 0.35f);
                global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::UnityEngine.RectTransform>(m_ChestPopupFields.ObjChest2).DOAnchorPos(new Vector2(0f, -338f), 0.3f).SetEase(Ease.OutQuad);
                m_ChestPopupFields.ObjChest2.transform.DOScale(Vector3.one, 0.3f).SetEase(Ease.OutBack);
            });
            sequenceShowView.InsertCallback(0.5f, () =>
            {
                //objChest2.transform.DOShakeRotation(0.5f, new Vector3(0, 0, 10f), 5, 3);
                m_ChestPopupFields.ObjChest2.transform.DOPunchPosition(new Vector3(10f, 10f, 10f), 2f, 10, 3).SetEase(Ease.InQuart);
                m_ChestPopupFields.ObjChest2.transform.DOPunchRotation(new Vector3(0f, 0f, 20f), 2f, 10, 3).SetEase(Ease.InQuart);
            //objChest2.transform.DOShakeRotation(0.5f, new Vector3(0, 0, 10f), 5, 3);
            });
            sequenceShowView.InsertCallback(0.1f + timeOpenChest, () =>
            {
                m_ChestPopupFields.Popup.gameObject.SetActive(true);
                global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::BBUIView>(m_ChestPopupFields.Popup).ShowView();
            });
            sequenceShowView.InsertCallback(0.2f + timeOpenChest, () =>
            {
                m_ChestPopupFields.ObjChest2.gameObject.SetActive(false);
                m_ChestPopupFields.Fx1.gameObject.SetActive(true);
                m_ChestPopupFields.Fx1.Play();
                m_ChestPopupFields.Fx2.gameObject.SetActive(true);
                m_ChestPopupFields.Fx2.Play();
                global::Rush.Chocology.Audio.SoundManager.Instance.PlaySoundPhaoGiay();
            });
            sequenceShowView.Insert(0.2f + timeOpenChest, m_ChestPopupFields.ObjLight.transform.DOScale(1f, 0.3f).SetEase(Ease.OutBack));
            sequenceShowView.Insert(0.2f + timeOpenChest, m_ChestPopupFields.ObjChest.transform.DOScale(1f, 0.3f).SetEase(Ease.OutBack));
            sequenceShowView.InsertCallback(0.6f + timeOpenChest, () =>
            {
                SetRotateLight();
                m_ChestPopupFields.Fx3.gameObject.SetActive(true);
                m_ChestPopupFields.Fx3.Play();
            });
            sequenceShowView.InsertCallback(0.6f + timeOpenChest, () =>
            {
                foreach (Transform child in m_ChestPopupFields.ContentReward)
                {
                    global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::Rush.Chocology.Economy.RewardItem>(child).ShowView();
                }
            });
            sequenceShowView.InsertCallback(1f + timeOpenChest, () =>
            {
                m_ChestPopupFields.BtnWatchAds.gameObject.SetActive(false);
                global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::BBUIView>(m_ChestPopupFields.BtnWatchAds.gameObject).ShowView();
            });
            sequenceShowView.InsertCallback(4f + timeOpenChest, () =>
            {
                m_ChestPopupFields.BtnClose.gameObject.SetActive(false);
                global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::BBUIView>(m_ChestPopupFields.BtnClose.gameObject).ShowView();
            });
        }

        public void HidePopupFinished() => HidePopupFinishedInternal();
        private void HidePopupFinishedInternal()
        {
            if (global::Rush.Chocology.Gameplay.GamePlayManager.Instance != null && global::Rush.Chocology.Gameplay.GamePlayManager.Instance.isActiveAndEnabled)
            {
                global::Rush.Chocology.Gameplay.GamePlayManager.Instance.CloseChestPopup();
            }

            m_ChestPopupFields.Fx1.gameObject.SetActive(false);
            m_ChestPopupFields.Fx2.gameObject.SetActive(false);
            m_ChestPopupFields.Fx3.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }

        private void SetRotateLight()
        {
            //Debug.Log("SetRotateLightSetRotateLight");
            m_ChestPopupFields.ObjLight.transform.DORotate(new Vector3(0f, 0f, -90f), 1f).SetRelative(true).SetEase(Ease.Linear).SetLoops(-1, LoopType.Incremental);
        }
    }
}
