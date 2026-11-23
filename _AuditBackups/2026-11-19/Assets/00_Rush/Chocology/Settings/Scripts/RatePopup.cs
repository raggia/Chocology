using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Rush.Chocology.Settings
{
    [UnityEngine.Scripting.APIUpdating.MovedFrom(true, "", "Assembly-CSharp", "RatePopup")]
    public class RatePopup : MonoBehaviour
    {
        [global::System.Serializable]
        private sealed class RatePopupField
        {
            [UnityEngine.Serialization.FormerlySerializedAs("popup")]
            [UnityEngine.SerializeField]
            private GameObject m_Popup;
            public global::UnityEngine.GameObject Popup { get => m_Popup; set => m_Popup = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("btnClose")]
            [UnityEngine.SerializeField]
            private BBUIButton m_BtnClose;
            public global::BBUIButton BtnClose { get => m_BtnClose; set => m_BtnClose = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("btnLike")]
            [UnityEngine.SerializeField]
            private BBUIButton m_BtnLike;
            public global::BBUIButton BtnLike { get => m_BtnLike; set => m_BtnLike = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("lockGroup")]
            [UnityEngine.SerializeField]
            private GameObject m_LockGroup;
            public global::UnityEngine.GameObject LockGroup { get => m_LockGroup; set => m_LockGroup = value; }
        }

        [global::UnityEngine.SerializeField]
        private RatePopupField m_RatePopupFields = new RatePopupField();
        private string m_RateLinkAndorid = "https://play.google.com/store/apps/details?id=com.gameson.chocology";
        private string m_RateLinkIOS = "https://www.google.com/";
        private static global::Rush.Chocology.Settings.RatePopup s_Instance;
        public static global::Rush.Chocology.Settings.RatePopup Instance { get => s_Instance; set => s_Instance = value; }
        public global::UnityEngine.GameObject Popup { get => m_RatePopupFields.Popup; set => m_RatePopupFields.Popup = value; }
        public global::BBUIButton BtnClose { get => m_RatePopupFields.BtnClose; set => m_RatePopupFields.BtnClose = value; }
        public global::BBUIButton BtnLike { get => m_RatePopupFields.BtnLike; set => m_RatePopupFields.BtnLike = value; }
        public global::UnityEngine.GameObject LockGroup { get => m_RatePopupFields.LockGroup; set => m_RatePopupFields.LockGroup = value; }

        // Start is called before the first frame update
        void Start()
        {
            m_RatePopupFields.BtnClose.OnPointerClickCallBack_Completed.AddListener(TouchClose);
            m_RatePopupFields.BtnLike.OnPointerClickCallBack_Completed.AddListener(TouchLikeInternal);
            global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::BBUIView>(m_RatePopupFields.Popup).HideBehavior.onCallback_Completed.AddListener(PopupHideViewFinished);
        }

        // Update is called once per frame
        void Update()
        {
        }

        public void OpenRatePopup() => OpenRatePopupInternal();
        private void OpenRatePopupInternal()
        {
            gameObject.SetActive(true);
            InitViews();
        }

        private void InitViews()
        {
            m_RatePopupFields.LockGroup.gameObject.SetActive(false);
            m_RatePopupFields.Popup.gameObject.SetActive(false);
            m_RatePopupFields.BtnClose.gameObject.SetActive(false);
            m_RatePopupFields.BtnLike.gameObject.SetActive(false);
            // AdmobManager.instance.HideBannerAd();
            InitViewsShowViewInternal();
        }

        public void InitViewsShowView() => InitViewsShowViewInternal();
        private void InitViewsShowViewInternal()
        {
            Sequence sequenceShowView = DOTween.Sequence();
            sequenceShowView.InsertCallback(0.01f, () =>
            {
                m_RatePopupFields.Popup.gameObject.SetActive(true);
                global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::BBUIView>(m_RatePopupFields.Popup).ShowView();
            });
            sequenceShowView.InsertCallback(0.4f, () =>
            {
                m_RatePopupFields.BtnClose.gameObject.SetActive(true);
                global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::BBUIView>(m_RatePopupFields.BtnClose).ShowView();
            });
            sequenceShowView.InsertCallback(0.5f, () =>
            {
                m_RatePopupFields.BtnLike.gameObject.SetActive(true);
                global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::BBUIView>(m_RatePopupFields.BtnLike).ShowView();
            });
        }

        private void TouchClose()
        {
            m_RatePopupFields.LockGroup.gameObject.SetActive(true);
            global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::BBUIView>(m_RatePopupFields.Popup).HideView();
        }

        public void TouchLike() => TouchLikeInternal();
        private void TouchLikeInternal()
        {
            global::Rush.Chocology.Economy.Config.Runtime.SetRate();
#if UNITY_ANDROID
            Application.OpenURL(m_RateLinkAndorid);
#else
        Application.OpenURL(rateLinkIOS);
#endif
            gameObject.SetActive(false);
        }

        private void PopupHideViewFinished()
        {
            gameObject.SetActive(false);
        }
    }
}
