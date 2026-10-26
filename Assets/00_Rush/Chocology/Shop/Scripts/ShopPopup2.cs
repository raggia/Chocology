/*
 * Created on 2022
 *
 * Copyright (c) 2022 dotmobstudio
 * Support : dotmobstudio@gmail.com
 */
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Rush.Chocology.Shop
{
    [UnityEngine.Scripting.APIUpdating.MovedFrom(true, "", "Assembly-CSharp", "ShopPopup2")]
    public class ShopPopup2 : MonoBehaviour
    {
        [global::System.Serializable]
        private sealed class ShopPopup2Field
        {
            [UnityEngine.Serialization.FormerlySerializedAs("popup")]
            [UnityEngine.SerializeField]
            private BBUIView m_Popup;
            public global::BBUIView Popup { get => m_Popup; set => m_Popup = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("btnClose")]
            [UnityEngine.SerializeField]
            private BBUIButton m_BtnClose;
            public global::BBUIButton BtnClose { get => m_BtnClose; set => m_BtnClose = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("lockGroup")]
            [UnityEngine.SerializeField]
            private GameObject m_LockGroup;
            public global::UnityEngine.GameObject LockGroup { get => m_LockGroup; set => m_LockGroup = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("scrollView")]
            [UnityEngine.SerializeField]
            private ScrollRect m_ScrollView;
            public global::UnityEngine.UI.ScrollRect ScrollView { get => m_ScrollView; set => m_ScrollView = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("btnLoadMores")]
            [UnityEngine.SerializeField]
            private BBUIButton m_BtnLoadMores;
            public global::BBUIButton BtnLoadMores { get => m_BtnLoadMores; set => m_BtnLoadMores = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("loadMoreObj")]
            [UnityEngine.SerializeField]
            private GameObject m_LoadMoreObj;
            public global::UnityEngine.GameObject LoadMoreObj { get => m_LoadMoreObj; set => m_LoadMoreObj = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("listLoadMore_ItemShops")]
            [UnityEngine.SerializeField]
            private List<GameObject> m_ListLoadMoreItemShops = new List<GameObject>();
            public global::System.Collections.Generic.List<global::UnityEngine.GameObject> ListLoadMoreItemShops { get => m_ListLoadMoreItemShops; set => m_ListLoadMoreItemShops = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("iapRemoveAd")]
            [UnityEngine.SerializeField]
            private global::Rush.Chocology.Shop.ItemShopIAP m_IapRemoveAd;
            public global::Rush.Chocology.Shop.ItemShopIAP IapRemoveAd { get => m_IapRemoveAd; set => m_IapRemoveAd = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("listItemShopIAPs")]
            [UnityEngine.SerializeField]
            private List<global::Rush.Chocology.Shop.ItemShopIAP> m_ListItemShopIAPs = new List<global::Rush.Chocology.Shop.ItemShopIAP>();
            public global::System.Collections.Generic.List<global::Rush.Chocology.Shop.ItemShopIAP> ListItemShopIAPs { get => m_ListItemShopIAPs; set => m_ListItemShopIAPs = value; }
        }

        [global::UnityEngine.SerializeField]
        private ShopPopup2Field m_ShopPopup2Fields = new ShopPopup2Field();
        private static global::Rush.Chocology.Shop.ShopPopup2 s_Instance;
        public static global::Rush.Chocology.Shop.ShopPopup2 Instance { get => s_Instance; set => s_Instance = value; }
        public global::BBUIView Popup { get => m_ShopPopup2Fields.Popup; set => m_ShopPopup2Fields.Popup = value; }
        public global::BBUIButton BtnClose { get => m_ShopPopup2Fields.BtnClose; set => m_ShopPopup2Fields.BtnClose = value; }
        public global::UnityEngine.GameObject LockGroup { get => m_ShopPopup2Fields.LockGroup; set => m_ShopPopup2Fields.LockGroup = value; }
        public global::UnityEngine.UI.ScrollRect ScrollView { get => m_ShopPopup2Fields.ScrollView; set => m_ShopPopup2Fields.ScrollView = value; }

        private void Awake()
        {
            s_Instance = this;
        }

        // Start is called before the first frame update
        void Start()
        {
            global::Rush.Chocology.Integrations.Purchasing.PurchaserManager.InitializeSucceeded += PurchaserManagerInitializeSucceeded;
            m_ShopPopup2Fields.Popup.ShowBehavior.onCallback_Completed.AddListener(ShowViewFinished);
            m_ShopPopup2Fields.Popup.HideBehavior.onCallback_Completed.AddListener(HideViewFinished);
            m_ShopPopup2Fields.BtnClose.OnPointerClickCallBack_Completed.AddListener(TouchClose);
            m_ShopPopup2Fields.BtnLoadMores.OnPointerClickCallBack_Completed.AddListener(TouchLoadMore);
            InitIAP();
        }

        private void OnDestroy()
        {
            global::Rush.Chocology.Integrations.Purchasing.PurchaserManager.InitializeSucceeded -= PurchaserManagerInitializeSucceeded;
            m_ShopPopup2Fields.Popup.ShowBehavior.onCallback_Completed.RemoveAllListeners();
            m_ShopPopup2Fields.Popup.HideBehavior.onCallback_Completed.RemoveAllListeners();
            m_ShopPopup2Fields.BtnClose.OnPointerClickCallBack_Completed.RemoveAllListeners();
            m_ShopPopup2Fields.BtnLoadMores.OnPointerClickCallBack_Completed.RemoveAllListeners();
        }

        // Update is called once per frame
        void Update()
        {
        }

        [ContextMenu("OpenPopup")]
        public void OpenPopup() => OpenPopupInternal();
        private void OpenPopupInternal()
        {
            m_ShopPopup2Fields.LockGroup.SetActive(true);
            gameObject.SetActive(true);
            InitLoadMores();
            m_ShopPopup2Fields.ScrollView.verticalNormalizedPosition = 1f;
            ShowViews();
        }

        private void ShowViews()
        {
            global::Rush.Chocology.Audio.SoundManager.Instance.PlaySoundPopup();
            m_ShopPopup2Fields.LockGroup.SetActive(true);
            StartCoroutine(ShowViewsIEnumerator());
        }

        private IEnumerator ShowViewsIEnumerator()
        {
            m_ShopPopup2Fields.Popup.gameObject.SetActive(false);
            m_ShopPopup2Fields.BtnClose.gameObject.SetActive(false);
            yield return new WaitForSeconds(0.1f);
            m_ShopPopup2Fields.Popup.gameObject.SetActive(true);
            m_ShopPopup2Fields.Popup.ShowView();
            yield return new WaitForSeconds(0.1f);
            m_ShopPopup2Fields.BtnClose.gameObject.SetActive(true);
            global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::BBUIView>(m_ShopPopup2Fields.BtnClose).ShowView();
        }

        private void ShowViewFinished()
        {
            m_ShopPopup2Fields.LockGroup.SetActive(false);
        }

        private void HideViewFinished()
        {
            gameObject.SetActive(false);
        }

        private void TouchClose()
        {
            m_ShopPopup2Fields.LockGroup.SetActive(true);
            m_ShopPopup2Fields.Popup.HideView();
        }

        public global::BBUIButton BtnLoadMores { get => m_ShopPopup2Fields.BtnLoadMores; set => m_ShopPopup2Fields.BtnLoadMores = value; }
        public global::UnityEngine.GameObject LoadMoreObj { get => m_ShopPopup2Fields.LoadMoreObj; set => m_ShopPopup2Fields.LoadMoreObj = value; }
        public global::System.Collections.Generic.List<global::UnityEngine.GameObject> ListLoadMoreItemShops { get => m_ShopPopup2Fields.ListLoadMoreItemShops; set => m_ShopPopup2Fields.ListLoadMoreItemShops = value; }

        private void TouchLoadMore()
        {
            for (int i = 0; i < m_ShopPopup2Fields.ListLoadMoreItemShops.Count; i++)
            {
                m_ShopPopup2Fields.ListLoadMoreItemShops[i].SetActive(true);
            }

            m_ShopPopup2Fields.LoadMoreObj.SetActive(false);
            InitIAPRemoveAd();
        }

        private void InitLoadMores()
        {
            m_ShopPopup2Fields.LoadMoreObj.SetActive(true);
            for (int i = 0; i < m_ShopPopup2Fields.ListLoadMoreItemShops.Count; i++)
            {
                m_ShopPopup2Fields.ListLoadMoreItemShops[i].SetActive(false);
            }
        }

        public global::Rush.Chocology.Shop.ItemShopIAP IapRemoveAd { get => m_ShopPopup2Fields.IapRemoveAd; set => m_ShopPopup2Fields.IapRemoveAd = value; }

        private void InitIAPRemoveAd()
        {
            if (global::Rush.Chocology.Economy.Config.Runtime.RemoveAd)
            {
                m_ShopPopup2Fields.IapRemoveAd.gameObject.SetActive(false);
            }
            else
            {
                m_ShopPopup2Fields.IapRemoveAd.gameObject.SetActive(true);
            }
        }

        public global::System.Collections.Generic.List<global::Rush.Chocology.Shop.ItemShopIAP> ListItemShopIAPs { get => m_ShopPopup2Fields.ListItemShopIAPs; set => m_ShopPopup2Fields.ListItemShopIAPs = value; }

        public void TouchBuyShopItem(global::Rush.Chocology.Economy.ConfigPackData configPackData) => TouchBuyShopItemInternal(configPackData);
        private void TouchBuyShopItemInternal(global::Rush.Chocology.Economy.ConfigPackData configPackData)
        {
            Debug.Log("TouchBuy_ShopItem" + configPackData.IdPack.ToString());
            m_ShopPopup2Fields.LockGroup.gameObject.SetActive(true);
            global::Rush.Chocology.SceneFlow.LoadingManager.Instance.SpawnLoading();
            global::Rush.Chocology.Integrations.Purchasing.PurchaserManager.Instance.BuyConsumable(configPackData.IdPack, (string _iapID, global::Rush.Chocology.Integrations.Purchasing.PurchaserManager.IAP_CALLBACK_STATE _state) =>
            {
                if (_state == global::Rush.Chocology.Integrations.Purchasing.PurchaserManager.IAP_CALLBACK_STATE.SUCCESS)
                {
                    Debug.Log("SUCCESSSUCCESS " + _iapID);
                    m_ShopPopup2Fields.LockGroup.gameObject.SetActive(false);
                    if (_iapID.Equals(global::Rush.Chocology.Economy.Config.IAP_ID.removead.ToString()))
                    {
                        global::Rush.Chocology.Economy.Config.Runtime.SetRemoveAd();
                        global::Rush.Chocology.Economy.Config.Runtime.SetBuyIAP(configPackData.IdPack);
                        global::Rush.Chocology.Notifications.NotificationPopup.Instance.AddNotification("RemoveAd Success!");
                        InitIAPRemoveAd();
                    }
                    else
                    {
                        BuyPackSuccess(configPackData);
                    }

                    global::Rush.Chocology.Notifications.GlobalVar.Runtime.CallAnalytics($"payment_{(configPackData.IdPack)}_success");
                }
                else
                {
                    Debug.Log("Buy Fail!Buy Fail!Buy Fail!Buy Fail!Buy Fail!");
                    m_ShopPopup2Fields.LockGroup.gameObject.SetActive(false);
                    global::Rush.Chocology.Notifications.NotificationPopup.Instance.AddNotification("Buy Fail!");
                    global::Rush.Chocology.Notifications.GlobalVar.Runtime.CallAnalytics($"payment_{(configPackData.IdPack)}_cancel");
                }

                global::Rush.Chocology.SceneFlow.LoadingManager.Instance.CloseLoading();
            });
        }

        private void BuyPackSuccess(global::Rush.Chocology.Economy.ConfigPackData configPackData)
        {
            if (global::Rush.Chocology.LevelMap.MenuManager.Instance != null && global::Rush.Chocology.LevelMap.MenuManager.Instance.isActiveAndEnabled)
            {
                global::Rush.Chocology.LevelMap.MenuManager.Instance.OpenRewardPopup(configPackData.ConfigItemShopDatas, false);
            }
            else if (global::Rush.Chocology.Gameplay.GamePlayManager.Instance != null && global::Rush.Chocology.Gameplay.GamePlayManager.Instance.isActiveAndEnabled)
            {
                global::Rush.Chocology.Gameplay.GamePlayManager.Instance.OpenRewardPopup(configPackData.ConfigItemShopDatas, false);
            }

            gameObject.SetActive(false);
        }

        private void PurchaserManagerInitializeSucceeded()
        {
            InitIAP();
        }

        private void InitIAP()
        {
            for (int i = 0; i < m_ShopPopup2Fields.ListItemShopIAPs.Count; i++)
            {
                m_ShopPopup2Fields.ListItemShopIAPs[i].InitIAP();
            }
        }

    }
}
