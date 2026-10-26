using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace Rush.Chocology.Notifications
{
    [UnityEngine.Scripting.APIUpdating.MovedFrom(true, "", "Assembly-CSharp", "ItemNotification")]
    public class ItemNotification : MonoBehaviour
    {
        [UnityEngine.Serialization.FormerlySerializedAs("bg")]
        [UnityEngine.SerializeField]
        private Image m_Bg;
        public global::UnityEngine.UI.Image Bg { get => m_Bg; set => m_Bg = value; }

        [UnityEngine.Serialization.FormerlySerializedAs("txtContent")]
        [UnityEngine.SerializeField]
        private Text m_TxtContent;
        public global::UnityEngine.UI.Text TxtContent { get => m_TxtContent; set => m_TxtContent = value; }

        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
        }

        public void ShowNotification(string content) => ShowNotificationInternal(content);
        private void ShowNotificationInternal(string content)
        {
            m_TxtContent.text = $"{(content)}";
            AutoHideViewInternal();
        }

        public void AutoHideView() => AutoHideViewInternal();
        private void AutoHideViewInternal()
        {
            Sequence sequence = DOTween.Sequence();
            sequence.Insert(0.1f, m_Bg.DOFade(0f, 0.5f).SetEase(Ease.InExpo));
            sequence.Insert(0.1f, global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::UnityEngine.RectTransform>(m_Bg).DOAnchorPosY(300f, 0.5f).SetEase(Ease.OutQuad).SetRelative(true));
            sequence.Insert(0.1f, m_TxtContent.DOFade(0f, 0.5f).SetEase(Ease.InExpo));
            sequence.OnComplete(() =>
            {
                Destroy(gameObject);
            });
        }
    }
}
