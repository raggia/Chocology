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
    [UnityEngine.Scripting.APIUpdating.MovedFrom(true, "", "Assembly-CSharp", "ItemShopIAP")]
    public class ItemShopIAP : MonoBehaviour
    {
        [global::System.Serializable]
        private sealed class ItemShopIAPField
        {
            [UnityEngine.Serialization.FormerlySerializedAs("configPackData")]
            [UnityEngine.SerializeField]
            private global::Rush.Chocology.Economy.ConfigPackData m_ConfigPackData;
            public global::Rush.Chocology.Economy.ConfigPackData ConfigPackData { get => m_ConfigPackData; set => m_ConfigPackData = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("btnBuy")]
            [UnityEngine.SerializeField]
            private BBUIButton m_BtnBuy;
            public global::BBUIButton BtnBuy { get => m_BtnBuy; set => m_BtnBuy = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("txtPrice")]
            [UnityEngine.SerializeField]
            private Text m_TxtPrice;
            public global::UnityEngine.UI.Text TxtPrice { get => m_TxtPrice; set => m_TxtPrice = value; }
        }

        [global::UnityEngine.SerializeField]
        private ItemShopIAPField m_ItemShopIAPFields = new ItemShopIAPField();
        public global::Rush.Chocology.Economy.ConfigPackData ConfigPackData { get => m_ItemShopIAPFields.ConfigPackData; set => m_ItemShopIAPFields.ConfigPackData = value; }
        public global::BBUIButton BtnBuy { get => m_ItemShopIAPFields.BtnBuy; set => m_ItemShopIAPFields.BtnBuy = value; }
        public global::UnityEngine.UI.Text TxtPrice { get => m_ItemShopIAPFields.TxtPrice; set => m_ItemShopIAPFields.TxtPrice = value; }

        // Start is called before the first frame update
        public virtual void Start()
        {
            m_ItemShopIAPFields.BtnBuy.OnPointerClickCallBack_Completed.AddListener(TouchBuy);
            InitIAPInternal();
        }

        private void OnDestroy()
        {
            m_ItemShopIAPFields.BtnBuy.OnPointerClickCallBack_Completed.RemoveAllListeners();
        }

        // Update is called once per frame
        void Update()
        {
        }

        private void TouchBuy()
        {
            global::Rush.Chocology.SceneFlow.LoadingManager.Instance.SpawnLoading();
            if (global::Rush.Chocology.Shop.ShopPopup2.Instance != null && global::Rush.Chocology.Shop.ShopPopup2.Instance.isActiveAndEnabled)
            {
                global::Rush.Chocology.Shop.ShopPopup2.Instance.TouchBuyShopItem(m_ItemShopIAPFields.ConfigPackData);
            }
            else if (global::Rush.Chocology.LegacyGameplay.WinPopup.Instance != null && global::Rush.Chocology.LegacyGameplay.WinPopup.Instance.isActiveAndEnabled)
            {
                global::Rush.Chocology.LegacyGameplay.WinPopup.Instance.BuyRemoveAd(m_ItemShopIAPFields.ConfigPackData);
            }
        }

        public void InitIAP() => InitIAPInternal();
        private void InitIAPInternal()
        {
            if (global::Rush.Chocology.Integrations.Purchasing.PurchaserManager.Instance.IsInitialized())
            {
                m_ItemShopIAPFields.TxtPrice.text = global::Rush.Chocology.Integrations.Purchasing.PurchaserManager.Instance.ReadLocalizedPriceString(m_ItemShopIAPFields.ConfigPackData.IdPack.ToString());
                m_ItemShopIAPFields.BtnBuy.Interactable = true;
            }
            else
            {
                m_ItemShopIAPFields.TxtPrice.text = "0.01$";
                m_ItemShopIAPFields.BtnBuy.Interactable = false;
            }
        }
    }
}
