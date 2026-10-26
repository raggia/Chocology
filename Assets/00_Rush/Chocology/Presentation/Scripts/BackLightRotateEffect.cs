using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Rush.Chocology.Presentation
{
    [UnityEngine.Scripting.APIUpdating.MovedFrom(true, "", "Assembly-CSharp", "BackLightRotateEffect")]
    public class BackLightRotateEffect : MonoBehaviour
    {
        [UnityEngine.Serialization.FormerlySerializedAs("view")]
        [UnityEngine.SerializeField]
        private BBUIView m_View;
        public global::BBUIView View { get => m_View; set => m_View = value; }

        [UnityEngine.Serialization.FormerlySerializedAs("objBackLight")]
        [UnityEngine.SerializeField]
        private GameObject m_ObjBackLight;
        public global::UnityEngine.GameObject ObjBackLight { get => m_ObjBackLight; set => m_ObjBackLight = value; }

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
            m_ObjBackLight.transform.DORotate(new Vector3(0f, 0f, 90f), 1f).SetRelative(true).SetEase(Ease.Linear).SetLoops(-1, LoopType.Incremental);
        }
    }
}
