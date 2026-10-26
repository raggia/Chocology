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

namespace Rush.Chocology.Rewards
{
    [UnityEngine.Scripting.APIUpdating.MovedFrom(true, "", "Assembly-CSharp", "PiggyBankPopup")]
    public class PiggyBankPopup : MonoBehaviour
    {
        [global::System.Serializable]
        private sealed class PiggyBankPopupField
        {
            [UnityEngine.Serialization.FormerlySerializedAs("btnClose")]
            [UnityEngine.SerializeField]
            private BBUIButton m_BtnClose;
            public global::BBUIButton BtnClose { get => m_BtnClose; set => m_BtnClose = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("btnBuy")]
            [UnityEngine.SerializeField]
            private BBUIButton m_BtnBuy;
            public global::BBUIButton BtnBuy { get => m_BtnBuy; set => m_BtnBuy = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("popup")]
            [UnityEngine.SerializeField]
            private GameObject m_Popup;
            public global::UnityEngine.GameObject Popup { get => m_Popup; set => m_Popup = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("lockGroup")]
            [UnityEngine.SerializeField]
            private GameObject m_LockGroup;
            public global::UnityEngine.GameObject LockGroup { get => m_LockGroup; set => m_LockGroup = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("txtMinBankCoin")]
            [UnityEngine.SerializeField]
            private Text m_TxtMinBankCoin;
            public global::UnityEngine.UI.Text TxtMinBankCoin { get => m_TxtMinBankCoin; set => m_TxtMinBankCoin = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("txtMaxBankCoin")]
            [UnityEngine.SerializeField]
            private Text m_TxtMaxBankCoin;
            public global::UnityEngine.UI.Text TxtMaxBankCoin { get => m_TxtMaxBankCoin; set => m_TxtMaxBankCoin = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("txtCurrBankCoin")]
            [UnityEngine.SerializeField]
            private Text m_TxtCurrBankCoin;
            public global::UnityEngine.UI.Text TxtCurrBankCoin { get => m_TxtCurrBankCoin; set => m_TxtCurrBankCoin = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("txtPrice")]
            [UnityEngine.SerializeField]
            private Text m_TxtPrice;
            public global::UnityEngine.UI.Text TxtPrice { get => m_TxtPrice; set => m_TxtPrice = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("txtContent")]
            [UnityEngine.SerializeField]
            private Text m_TxtContent;
            public global::UnityEngine.UI.Text TxtContent { get => m_TxtContent; set => m_TxtContent = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("imgBankCoinProgress")]
            [UnityEngine.SerializeField]
            private Image m_ImgBankCoinProgress;
            public global::UnityEngine.UI.Image ImgBankCoinProgress { get => m_ImgBankCoinProgress; set => m_ImgBankCoinProgress = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("rewardPopup")]
            [UnityEngine.SerializeField]
            private global::Rush.Chocology.Economy.RewardPopup m_RewardPopup;
            public global::Rush.Chocology.Economy.RewardPopup RewardPopup { get => m_RewardPopup; set => m_RewardPopup = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("menu_CoinGroup")]
            [UnityEngine.SerializeField]
            private global::Rush.Chocology.Economy.Menu_CoinGroup m_MenuCoinGroup;
            public global::Rush.Chocology.Economy.Menu_CoinGroup MenuCoinGroup { get => m_MenuCoinGroup; set => m_MenuCoinGroup = value; }
        }

        [global::UnityEngine.SerializeField]
        private PiggyBankPopupField m_PiggyBankPopupFields = new PiggyBankPopupField();
        private static global::Rush.Chocology.Rewards.PiggyBankPopup s_Instance;
        public static global::Rush.Chocology.Rewards.PiggyBankPopup Instance { get => s_Instance; set => s_Instance = value; }
        public global::BBUIButton BtnClose { get => m_PiggyBankPopupFields.BtnClose; set => m_PiggyBankPopupFields.BtnClose = value; }
        public global::BBUIButton BtnBuy { get => m_PiggyBankPopupFields.BtnBuy; set => m_PiggyBankPopupFields.BtnBuy = value; }
        public global::UnityEngine.GameObject Popup { get => m_PiggyBankPopupFields.Popup; set => m_PiggyBankPopupFields.Popup = value; }
        public global::UnityEngine.GameObject LockGroup { get => m_PiggyBankPopupFields.LockGroup; set => m_PiggyBankPopupFields.LockGroup = value; }
        public global::UnityEngine.UI.Text TxtMinBankCoin { get => m_PiggyBankPopupFields.TxtMinBankCoin; set => m_PiggyBankPopupFields.TxtMinBankCoin = value; }
        public global::UnityEngine.UI.Text TxtMaxBankCoin { get => m_PiggyBankPopupFields.TxtMaxBankCoin; set => m_PiggyBankPopupFields.TxtMaxBankCoin = value; }
        public global::UnityEngine.UI.Text TxtCurrBankCoin { get => m_PiggyBankPopupFields.TxtCurrBankCoin; set => m_PiggyBankPopupFields.TxtCurrBankCoin = value; }
        public global::UnityEngine.UI.Text TxtPrice { get => m_PiggyBankPopupFields.TxtPrice; set => m_PiggyBankPopupFields.TxtPrice = value; }
        public global::UnityEngine.UI.Text TxtContent { get => m_PiggyBankPopupFields.TxtContent; set => m_PiggyBankPopupFields.TxtContent = value; }
        public global::UnityEngine.UI.Image ImgBankCoinProgress { get => m_PiggyBankPopupFields.ImgBankCoinProgress; set => m_PiggyBankPopupFields.ImgBankCoinProgress = value; }

        private void Awake()
        {
            s_Instance = this;
        }

        // Start is called before the first frame update
        void Start()
        {
            m_PiggyBankPopupFields.BtnClose.OnPointerClickCallBack_Completed.AddListener(TouchCloseInternal);
            m_PiggyBankPopupFields.BtnBuy.OnPointerClickCallBack_Completed.AddListener(TouchBuyInternal);
            global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::BBUIView>(m_PiggyBankPopupFields.Popup).HideBehavior.onCallback_Completed.AddListener(HidePopupFinishedInternal);
        }

        public void TouchPiggyBank() => TouchPiggyBankInternal();
        private void TouchPiggyBankInternal() => OpenPiggyBankPopupInternal();
        public void OpenPiggyBankPopup() => OpenPiggyBankPopupInternal();
        private void OpenPiggyBankPopupInternal() => OpenPiggyBankInternal();
        public void OpenPiggyBank() => OpenPiggyBankInternal();
        private void OpenPiggyBankInternal()
        {
            gameObject.SetActive(true);
            InitViewsInternal();
        }

        public void TouchClose() => TouchCloseInternal();
        private void TouchCloseInternal()
        {
            m_PiggyBankPopupFields.LockGroup.gameObject.SetActive(true);
            global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::BBUIView>(m_PiggyBankPopupFields.Popup).HideView();
        }

        public void TouchBuy() => TouchBuyInternal();
        private void TouchBuyInternal()
        {
            //WatchAds
            //BuyPiggyBankCoin_Success();
            m_PiggyBankPopupFields.LockGroup.gameObject.SetActive(true);
            new global::Rush.Integrations.Ads.RewardedAdRequest().Show((x) =>
            {
                m_PiggyBankPopupFields.LockGroup.gameObject.SetActive(false);
                if (x)
                {
                    BuyPiggyBankCoinSuccessInternal();
                    global::Rush.Chocology.Notifications.GlobalVar.Runtime.CallAnalytics("open_piggybank");
                }
                else
                {
                    global::Rush.Chocology.Notifications.NotificationPopup.Instance.AddNotification("Failed to claim piggy bank");
                }
            });
        ///Piggy bank using IAP
         /* 
        PurchaserManager.instance.BuyConsumable(Config.IAP_ID.piggy_bank, (string _iapID, PurchaserManager.IAP_CALLBACK_STATE _state) =>
        {
            if (_state == PurchaserManager.IAP_CALLBACK_STATE.SUCCESS)
            {
                lockGroup.gameObject.SetActive(false);
                if (_iapID.Equals(Config.IAP_ID.piggy_bank.ToString()))
                {
                    BuyPiggyBankCoin_Success();
                }
            }
            else
            {
                lockGroup.gameObject.SetActive(false);
                NotificationPopup.instance.AddNotification("Buy Fail!");
            }
        });*/
        }

        public void BuyPiggyBankCoinSuccess() => BuyPiggyBankCoinSuccessInternal();
        private void BuyPiggyBankCoinSuccessInternal()
        {
            //Config.SetCoin(Config.currCoin + Config.currPiggyBankCoin * Config.PIGGYBANK_COIN_xVALUE);
            global::Rush.Chocology.Economy.ConfigItemShopData configItemShopData = new global::Rush.Chocology.Economy.ConfigItemShopData();
            configItemShopData.CountItem = global::Rush.Chocology.Economy.Config.Runtime.CurrPiggyBankCoin * global::Rush.Chocology.Economy.Config.Runtime.PiggybankCoinXVALUE;
            configItemShopData.ShopItemType = global::Rush.Chocology.Economy.Config.SHOPITEM.COIN;
            configItemShopData.Price = 0;
            if (global::Rush.Chocology.Gameplay.GamePlayManager.Instance != null)
                global::Rush.Chocology.Gameplay.GamePlayManager.Instance.OpenRewardPopup(new List<global::Rush.Chocology.Economy.ConfigItemShopData>() { configItemShopData }, false);
            else
                m_PiggyBankPopupFields.RewardPopup.OpenRewardPopup(new List<global::Rush.Chocology.Economy.ConfigItemShopData>() { configItemShopData }, false);
            global::Rush.Chocology.Economy.Config.Runtime.SetPiggyBank(0);
            gameObject.SetActive(false);
        //if (menu_CoinGroup != null)
        //    menu_CoinGroup.ShowCoin();
        }

        public void InitViews() => InitViewsInternal();
        private void InitViewsInternal()
        {
            global::Rush.Chocology.Audio.SoundManager.Instance.PlaySoundPopup();
            m_PiggyBankPopupFields.LockGroup.gameObject.SetActive(false);
            m_PiggyBankPopupFields.Popup.gameObject.SetActive(false);
            m_PiggyBankPopupFields.BtnBuy.gameObject.SetActive(false);
            //txtPrice.text = PurchaserManager.instance.GetLocalizedPriceString(Config.IAP_ID.piggy_bank.ToString());
            //InitIAP();
            //Debug.Log("Chay vao day + txtPrice " + txtPrice.text);
            if (global::Rush.Chocology.Economy.Config.Runtime.CurrPiggyBankCoin > global::Rush.Chocology.Economy.Config.Runtime.PiggybankCoinMin)
            {
                m_PiggyBankPopupFields.BtnBuy.Interactable = true;
            }
            else
            {
                m_PiggyBankPopupFields.BtnBuy.Interactable = false;
            }

            m_PiggyBankPopupFields.TxtContent.text = $"Your coin <color=#ffff00ff>{(global::Rush.Chocology.Economy.Config.Runtime.CurrPiggyBankCoin)}</color> in Piggy Bank.\nBreak this Piggy Bank and take your coins, to buy whatever you want";
            m_PiggyBankPopupFields.BtnClose.gameObject.SetActive(false);
            m_PiggyBankPopupFields.TxtMaxBankCoin.text = $"{(global::Rush.Chocology.Economy.Config.Runtime.PiggybankCoinMax)}";
            m_PiggyBankPopupFields.TxtMinBankCoin.text = $"{(global::Rush.Chocology.Economy.Config.Runtime.PiggybankCoinMin)}";
            m_PiggyBankPopupFields.TxtCurrBankCoin.text = $"{(global::Rush.Chocology.Economy.Config.Runtime.CurrPiggyBankCoin)}";
            m_PiggyBankPopupFields.ImgBankCoinProgress.fillAmount = 0;
            m_PiggyBankPopupFields.ImgBankCoinProgress.DOFillAmount((global::Rush.Chocology.Economy.Config.Runtime.CurrPiggyBankCoin * 1f) / global::Rush.Chocology.Economy.Config.Runtime.PiggybankCoinMax, 0.2f).SetEase(Ease.OutQuad);
            InitViewShowViewInternal();
        }

        //public void InitIAP()
        //{
        //    if (PurchaserManager.instance.IsInitialized())
        //    {
        //        txtPrice.text = PurchaserManager.instance.GetLocalizedPriceString(Config.IAP_ID.piggy_bank.ToString());
        //        btnBuy.Interactable = true;
        //    }
        //    else
        //    {
        //        txtPrice.text = "0.01$";
        //        btnBuy.Interactable = false;
        //    }
        //}
        public void InitViewShowView() => InitViewShowViewInternal();
        private void InitViewShowViewInternal()
        {
            //Debug.LogError("Chay vao day + InitView_ShowView ");
            Sequence sequenceShowView = DOTween.Sequence();
            sequenceShowView.InsertCallback(0.1f, () =>
            {
                //  Debug.LogError("Chay vao day + InitView_ShowView popup ");
                m_PiggyBankPopupFields.Popup.gameObject.SetActive(true);
                global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::BBUIView>(m_PiggyBankPopupFields.Popup).ShowView();
            });
            sequenceShowView.InsertCallback(0.4f, () =>
            {
                //Debug.LogError("Chay vao day + InitView_ShowView btnBuy ");
                m_PiggyBankPopupFields.BtnBuy.gameObject.SetActive(false);
                global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::BBUIView>(m_PiggyBankPopupFields.BtnBuy.gameObject).ShowView();
            });
            sequenceShowView.InsertCallback(1.2f, () =>
            {
                m_PiggyBankPopupFields.BtnClose.gameObject.SetActive(false);
                global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::BBUIView>(m_PiggyBankPopupFields.BtnClose.gameObject).ShowView();
            });
        }

        public void HidePopupFinished() => HidePopupFinishedInternal();
        private void HidePopupFinishedInternal()
        {
            if (global::Rush.Chocology.Gameplay.GamePlayManager.Instance != null)
                global::Rush.Chocology.Gameplay.GamePlayManager.Instance.CloseShopSucces();
            gameObject.SetActive(false);
        }

        public global::Rush.Chocology.Economy.RewardPopup RewardPopup { get => m_PiggyBankPopupFields.RewardPopup; set => m_PiggyBankPopupFields.RewardPopup = value; }
        public global::Rush.Chocology.Economy.Menu_CoinGroup MenuCoinGroup { get => m_PiggyBankPopupFields.MenuCoinGroup; set => m_PiggyBankPopupFields.MenuCoinGroup = value; }

    }
}
