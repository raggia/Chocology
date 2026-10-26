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
    [UnityEngine.Scripting.APIUpdating.MovedFrom(true, "", "Assembly-CSharp", "ItemShop_FreeCoin")]
    public class ItemShop_FreeCoin : MonoBehaviour
    {
        [global::System.Serializable]
        private sealed class ItemShop_FreeCoinField
        {
            [UnityEngine.Serialization.FormerlySerializedAs("itemShopData")]
            [UnityEngine.SerializeField]
            private global::Rush.Chocology.Economy.ConfigItemShopData m_ItemShopData;
            public global::Rush.Chocology.Economy.ConfigItemShopData ItemShopData { get => m_ItemShopData; set => m_ItemShopData = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("txtCounItem")]
            [UnityEngine.SerializeField]
            private Text m_TxtCounItem;
            public global::UnityEngine.UI.Text TxtCounItem { get => m_TxtCounItem; set => m_TxtCounItem = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("btnBuy")]
            [UnityEngine.SerializeField]
            private BBUIButton m_BtnBuy;
            public global::BBUIButton BtnBuy { get => m_BtnBuy; set => m_BtnBuy = value; }
        }

        [global::UnityEngine.SerializeField]
        private ItemShop_FreeCoinField m_ItemShop_FreeCoinFields = new ItemShop_FreeCoinField();
        public global::Rush.Chocology.Economy.ConfigItemShopData ItemShopData { get => m_ItemShop_FreeCoinFields.ItemShopData; set => m_ItemShop_FreeCoinFields.ItemShopData = value; }
        public global::UnityEngine.UI.Text TxtCounItem { get => m_ItemShop_FreeCoinFields.TxtCounItem; set => m_ItemShop_FreeCoinFields.TxtCounItem = value; }
        public global::BBUIButton BtnBuy { get => m_ItemShop_FreeCoinFields.BtnBuy; set => m_ItemShop_FreeCoinFields.BtnBuy = value; }

        // Start is called before the first frame update
        void Start()
        {
            m_ItemShop_FreeCoinFields.BtnBuy.OnPointerClickCallBack_Completed.AddListener(TouchBuy);
            m_ItemShop_FreeCoinFields.TxtCounItem.text = $"{(m_ItemShop_FreeCoinFields.ItemShopData.CountItem)}";
        }

        private void OnEnable()
        {
            InitItemShop();
        }

        // Update is called once per frame
        void Update()
        {
        }

        private void TouchBuy()
        {
            m_ItemShop_FreeCoinFields.BtnBuy.Interactable = false;
            global::Rush.Chocology.Economy.Config.Runtime.SetDailyFreeCoin();
            global::Rush.Chocology.Audio.SoundManager.Instance.PlaySoundCash();
            global::Rush.Chocology.Economy.Config.Runtime.BuySuccesItemShop(m_ItemShop_FreeCoinFields.ItemShopData);
        }

        private void InitItemShop()
        {
            if (global::Rush.Chocology.Economy.Config.Runtime.CheckDailyFreeCoin())
            {
                m_ItemShop_FreeCoinFields.BtnBuy.Interactable = true;
            }
            else
            {
                m_ItemShop_FreeCoinFields.BtnBuy.Interactable = false;
            }
        }
    }
}
