using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Random = UnityEngine.Random;

namespace Rush.Chocology.Notifications
{
    [UnityEngine.Scripting.APIUpdating.MovedFrom(true, "", "Assembly-CSharp", "IconNotification")]
    public class IconNotification : MonoBehaviour
    {
        private Image m_IconNotify;
        private void Awake()
        {
            m_IconNotify = global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::UnityEngine.UI.Image>(this);
        }

        // Start is called before the first frame update
        void Start()
        {
            ShowAnimation();
        }

        // Update is called once per frame
        void Update()
        {
        }

        private Sequence m_Sequence;
        private void ShowAnimation()
        {
            if (m_Sequence != null)
            {
                m_Sequence.Kill();
            }

            m_Sequence = DOTween.Sequence();
            float timeDelayStart = Random.Range(0.2f, 2f);
            float timePunchScale = Random.Range(1f, 1.5f);
            float timeNormalScale = 0.2f;
            m_Sequence.Insert(timeDelayStart, m_IconNotify.transform.DOPunchScale(Vector3.one * 0.2f, timePunchScale, 10, 2f).SetRelative(true));
            m_Sequence.Insert(timeDelayStart + timePunchScale, m_IconNotify.transform.DOScale(Vector3.one * 0.2f, timeNormalScale).SetEase(Ease.Linear).SetRelative(true).SetLoops(Random.Range(3, 6), LoopType.Yoyo));
            m_Sequence.SetLoops(-1, LoopType.Restart);
        }
    }
}
