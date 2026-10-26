using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rush.Chocology.GameplayData
{
    [CreateAssetMenu(fileName = "ItemData", menuName = "ScriptableObjects/ItemData", order = 1)]
    [UnityEngine.Scripting.APIUpdating.MovedFrom(true, "", "Assembly-CSharp", "ItemData")]
    public class ItemData : ScriptableObject
    {
        [UnityEngine.Serialization.FormerlySerializedAs("itemType")]
        [UnityEngine.SerializeField]
        private global::Rush.Chocology.Economy.Config.ITEM_TYPE m_ItemType;
        public global::Rush.Chocology.Economy.Config.ITEM_TYPE ItemType { get => m_ItemType; set => m_ItemType = value; }
    }
}
