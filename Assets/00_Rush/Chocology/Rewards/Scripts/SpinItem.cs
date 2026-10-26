using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Rush.Chocology.Rewards
{
    [UnityEngine.Scripting.APIUpdating.MovedFrom(true, "", "Assembly-CSharp", "SpinItem")]
    public class SpinItem : MonoBehaviour
    {
        [UnityEngine.Serialization.FormerlySerializedAs("txtCountItem")]
        [UnityEngine.SerializeField]
        private Text m_TxtCountItem;
        public global::UnityEngine.UI.Text TxtCountItem { get => m_TxtCountItem; set => m_TxtCountItem = value; }

        private global::Rush.Chocology.Economy.ConfigItemShopData m_ConfigItemShopData;
        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
        }

        public void InitSpinItem(global::Rush.Chocology.Economy.ConfigItemShopData _configItemShopData) => InitSpinItemInternal(_configItemShopData);
        private void InitSpinItemInternal(global::Rush.Chocology.Economy.ConfigItemShopData _configItemShopData)
        {
            m_ConfigItemShopData = _configItemShopData;
            m_TxtCountItem.text = $"+{(m_ConfigItemShopData.CountItem)}";
        }
    }
}
