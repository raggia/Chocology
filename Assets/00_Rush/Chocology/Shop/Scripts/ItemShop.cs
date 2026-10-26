/*
 * Created on 2022
 *
 * Copyright (c) 2022 dotmobstudio
 * Support : dotmobstudio@gmail.com
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Rush.Chocology.Shop
{
    [UnityEngine.Scripting.APIUpdating.MovedFrom(true, "", "Assembly-CSharp", "ItemShop")]
    public class ItemShop : MonoBehaviour
    {
        [global::System.Serializable]
        private sealed class ItemShopField
        {
            [UnityEngine.Serialization.FormerlySerializedAs("itemShopData")]
            [UnityEngine.SerializeField]
            private global::Rush.Chocology.Economy.ConfigItemShopData m_ItemShopData;
            public global::Rush.Chocology.Economy.ConfigItemShopData ItemShopData { get => m_ItemShopData; set => m_ItemShopData = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("txtCounItem")]
            [UnityEngine.SerializeField]
            private Text m_TxtCounItem;
            public global::UnityEngine.UI.Text TxtCounItem { get => m_TxtCounItem; set => m_TxtCounItem = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("txtPrice")]
            [UnityEngine.SerializeField]
            private Text m_TxtPrice;
            public global::UnityEngine.UI.Text TxtPrice { get => m_TxtPrice; set => m_TxtPrice = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("btnBuy")]
            [UnityEngine.SerializeField]
            private BBUIButton m_BtnBuy;
            public global::BBUIButton BtnBuy { get => m_BtnBuy; set => m_BtnBuy = value; }
        }

        [global::UnityEngine.SerializeField]
        private ItemShopField m_ItemShopFields = new ItemShopField();
        public global::Rush.Chocology.Economy.ConfigItemShopData ItemShopData { get => m_ItemShopFields.ItemShopData; set => m_ItemShopFields.ItemShopData = value; }
        public global::UnityEngine.UI.Text TxtCounItem { get => m_ItemShopFields.TxtCounItem; set => m_ItemShopFields.TxtCounItem = value; }
        public global::UnityEngine.UI.Text TxtPrice { get => m_ItemShopFields.TxtPrice; set => m_ItemShopFields.TxtPrice = value; }
        public global::BBUIButton BtnBuy { get => m_ItemShopFields.BtnBuy; set => m_ItemShopFields.BtnBuy = value; }

        // Start is called before the first frame update
        void Start()
        {
            m_ItemShopFields.BtnBuy.OnPointerClickCallBack_Completed.AddListener(TouchBuyInternal);
            m_ItemShopFields.TxtCounItem.text = $"x{(m_ItemShopFields.ItemShopData.CountItem)}";
            m_ItemShopFields.TxtPrice.text = $"{(m_ItemShopFields.ItemShopData.Price)}";
        }

        // Update is called once per frame
        void Update()
        {
        }

        public void TouchBuy() => TouchBuyInternal();
        private void TouchBuyInternal()
        {
            if (global::Rush.Chocology.Economy.Config.Runtime.CurrCoin >= m_ItemShopFields.ItemShopData.Price)
            {
                global::Rush.Chocology.Audio.SoundManager.Instance.PlaySoundCash();
                global::Rush.Chocology.Economy.Config.Runtime.SetCoin(global::Rush.Chocology.Economy.Config.Runtime.CurrCoin - m_ItemShopFields.ItemShopData.Price);
                global::Rush.Chocology.Economy.Config.Runtime.BuySuccesItemShop(m_ItemShopFields.ItemShopData);
                global::Rush.Chocology.Notifications.NotificationPopup.Instance.AddNotification("Buy Success!");
            }
            else
            {
                global::Rush.Chocology.Notifications.NotificationPopup.Instance.AddNotification("Not enough Coin!");
                Debug.LogError("Not enough Coin!");
            }
        }
    }
}
