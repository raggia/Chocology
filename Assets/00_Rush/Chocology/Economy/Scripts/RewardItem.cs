using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Rush.Chocology.Economy
{
    [UnityEngine.Scripting.APIUpdating.MovedFrom(true, "", "Assembly-CSharp", "RewardItem")]
    public class RewardItem : MonoBehaviour
    {
        [UnityEngine.Serialization.FormerlySerializedAs("txtCountItem")]
        [UnityEngine.SerializeField]
        private Text m_TxtCountItem;
        public global::UnityEngine.UI.Text TxtCountItem { get => m_TxtCountItem; set => m_TxtCountItem = value; }

        private global::Rush.Chocology.Economy.ConfigItemShopData m_ConfigItemShopData;
        [UnityEngine.Serialization.FormerlySerializedAs("view")]
        [UnityEngine.SerializeField]
        private BBUIView m_View;
        public global::BBUIView View { get => m_View; set => m_View = value; }

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
            m_View.gameObject.SetActive(false);
        }

        public void ShowView() => ShowViewInternal();
        private void ShowViewInternal()
        {
            m_View.gameObject.SetActive(true);
            m_View.ShowView();
        }
    }
}
