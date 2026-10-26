using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Rush.Chocology.Presentation
{
    [UnityEngine.Scripting.APIUpdating.MovedFrom(true, "", "Assembly-CSharp", "IconButtonEffect")]
    public class IconButtonEffect : MonoBehaviour
    {
        [UnityEngine.Serialization.FormerlySerializedAs("view")]
        [UnityEngine.SerializeField]
        private BBUIView m_View;
        public global::BBUIView View { get => m_View; set => m_View = value; }

        [UnityEngine.Serialization.FormerlySerializedAs("iconEffect")]
        [UnityEngine.SerializeField]
        private GameObject m_IconEffect;
        public global::UnityEngine.GameObject IconEffect { get => m_IconEffect; set => m_IconEffect = value; }

        // Start is called before the first frame update
        void Start()
        {
            m_View.ShowBehavior.onCallback_Completed.AddListener(ShowViewFinished);
        }

        private void OnDestroy()
        {
            m_View.ShowBehavior.onCallback_Completed.RemoveAllListeners();
        }

        // Update is called once per frame
        void Update()
        {
        }

        private void ShowViewFinished()
        {
            Sequence sequence = DOTween.Sequence();
            sequence.Insert(0f, m_IconEffect.transform.DOScale(Vector3.one * 1.1f, 0.4f).SetEase(Ease.Linear).SetLoops(5, LoopType.Yoyo));
            sequence.Insert(2f, m_IconEffect.transform.DOPunchRotation(new Vector3(0f, 0f, 20f), 1f, 6, 2).SetEase(Ease.OutQuart));
            sequence.Insert(2f, m_IconEffect.transform.DOPunchScale(new Vector3(0.1f, 0.1f, 0.1f), 1f, 2, 1).SetEase(Ease.OutQuart));
            sequence.SetLoops(-1, LoopType.Yoyo);
        }
    }
}
