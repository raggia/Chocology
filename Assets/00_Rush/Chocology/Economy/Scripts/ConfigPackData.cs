using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Rush.Chocology.Economy
{
    [Serializable]
    [UnityEngine.Scripting.APIUpdating.MovedFrom(true, "", "Assembly-CSharp", "ConfigPackData")]
    public class ConfigPackData
    {
        [UnityEngine.Serialization.FormerlySerializedAs("idPack")]
        [UnityEngine.SerializeField]
        private global::Rush.Chocology.Economy.Config.IAP_ID m_IdPack;
        public global::Rush.Chocology.Economy.Config.IAP_ID IdPack { get => m_IdPack; set => m_IdPack = value; }

        [UnityEngine.Serialization.FormerlySerializedAs("configItemShopDatas")]
        [UnityEngine.SerializeField]
        private List<global::Rush.Chocology.Economy.ConfigItemShopData> m_ConfigItemShopDatas;
        public global::System.Collections.Generic.List<global::Rush.Chocology.Economy.ConfigItemShopData> ConfigItemShopDatas { get => m_ConfigItemShopDatas; set => m_ConfigItemShopDatas = value; }
    }
}
