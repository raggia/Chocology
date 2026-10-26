using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Rush.Chocology.Economy
{
    [Serializable]
    [UnityEngine.Scripting.APIUpdating.MovedFrom(true, "", "Assembly-CSharp", "ConfigItemShopData")]
    public class ConfigItemShopData
    {
        [global::System.Serializable]
        private sealed class ConfigItemShopDataField
        {
            [UnityEngine.Serialization.FormerlySerializedAs("shopItemType")]
            [UnityEngine.SerializeField]
            private global::Rush.Chocology.Economy.Config.SHOPITEM m_ShopItemType;
            public global::Rush.Chocology.Economy.Config.SHOPITEM ShopItemType { get => m_ShopItemType; set => m_ShopItemType = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("countItem")]
            [UnityEngine.SerializeField]
            private int m_CountItem;
            public int CountItem { get => m_CountItem; set => m_CountItem = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("price")]
            [UnityEngine.SerializeField]
            private int m_Price;
            public int Price { get => m_Price; set => m_Price = value; }
        }

        [global::UnityEngine.SerializeField]
        private ConfigItemShopDataField m_ConfigItemShopDataFields = new ConfigItemShopDataField();
        public global::Rush.Chocology.Economy.Config.SHOPITEM ShopItemType { get => m_ConfigItemShopDataFields.ShopItemType; set => m_ConfigItemShopDataFields.ShopItemType = value; }
        public int CountItem { get => m_ConfigItemShopDataFields.CountItem; set => m_ConfigItemShopDataFields.CountItem = value; }
        public int Price { get => m_ConfigItemShopDataFields.Price; set => m_ConfigItemShopDataFields.Price = value; }

        public ConfigItemShopData()
        {
        }
    }
}
