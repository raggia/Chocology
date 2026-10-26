using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Rush.Chocology.Economy
{
    [UnityEngine.Scripting.APIUpdating.MovedFrom(true, "", "Assembly-CSharp", "CoinGroup")]
    public class CoinGroup : MonoBehaviour
    {
        [UnityEngine.Serialization.FormerlySerializedAs("txtCoin")]
        [UnityEngine.SerializeField]
        private Text m_TxtCoin;
        public global::UnityEngine.UI.Text TxtCoin { get => m_TxtCoin; set => m_TxtCoin = value; }

        // Start is called before the first frame update
        void Start()
        {
            global::Rush.Chocology.Economy.Config.Runtime.OnChangeCoin += OnChangeCoinInternal;
            ShowCoinInternal();
        }

        private void OnDestroy()
        {
            global::Rush.Chocology.Economy.Config.Runtime.OnChangeCoin -= OnChangeCoinInternal;
        }

        // Update is called once per frame
        void Update()
        {
        }

        public void OnChangeCoin(int coinValue) => OnChangeCoinInternal(coinValue);
        private void OnChangeCoinInternal(int coinValue)
        {
            ShowCoinInternal();
        }

        public void ShowCoin() => ShowCoinInternal();
        private void ShowCoinInternal()
        {
            DOTween.Kill(m_TxtCoin.transform);
            m_TxtCoin.text = $"{(global::Rush.Chocology.Economy.Config.Runtime.CurrCoin)}";
            m_TxtCoin.transform.localScale = Vector3.one;
            m_TxtCoin.transform.DOPunchScale(Vector3.one * 0.3f, 0.2f, 10, 2f).SetEase(Ease.InOutBack).SetRelative(true).SetLoops(3, LoopType.Restart);
        }
    }
}
