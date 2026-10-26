using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Rush.Chocology.Economy
{
    [UnityEngine.Scripting.APIUpdating.MovedFrom(true, "", "Assembly-CSharp", "PiggyBank_CoinGroup")]
    public class PiggyBank_CoinGroup : MonoBehaviour
    {
        [UnityEngine.Serialization.FormerlySerializedAs("txtCoin")]
        [UnityEngine.SerializeField]
        private Text m_TxtCoin;
        public global::UnityEngine.UI.Text TxtCoin { get => m_TxtCoin; set => m_TxtCoin = value; }

        // Start is called before the first frame update
        void Start()
        {
            global::Rush.Chocology.Economy.Config.Runtime.OnChange_PiggyBank_Coin += OnChangePiggyBankCoinInternal;
            ShowCoinInternal();
        }

        private void OnDestroy()
        {
            global::Rush.Chocology.Economy.Config.Runtime.OnChange_PiggyBank_Coin -= OnChangePiggyBankCoinInternal;
        }

        // Update is called once per frame
        void Update()
        {
        }

        public void OnChangePiggyBankCoin() => OnChangePiggyBankCoinInternal();
        private void OnChangePiggyBankCoinInternal()
        {
            ShowCoinInternal();
        }

        public void ShowCoin() => ShowCoinInternal();
        private void ShowCoinInternal()
        {
            m_TxtCoin.text = $"{(global::Rush.Chocology.Economy.Config.Runtime.CurrPiggyBankCoin)}";
        }
    }
}
