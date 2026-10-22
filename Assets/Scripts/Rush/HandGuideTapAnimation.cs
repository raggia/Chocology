using System;
using DG.Tweening;
using UnityEngine;

namespace Rush
{
    /// <summary>
    /// One key of the hand tap loop: after <see cref="Duration"/> seconds the pivot should sit at
    /// <see cref="OffsetY"/> above its rest position, rotated <see cref="RotationZ"/> degrees from its rest rotation.
    /// </summary>
    [Serializable]
    public class HandTapKeyField
    {
        [SerializeField] private float m_Duration;
        [SerializeField] private float m_RotationZ;
        [SerializeField] private float m_OffsetY;

        public float Duration => m_Duration;
        public float RotationZ => m_RotationZ;
        public float OffsetY => m_OffsetY;
    }

    /// <summary>
    /// Loops a "tap" bob (move up, dip, settle) on a sprite hand pointer. Replaces the old Spine "Click" animation
    /// of the tutorial hand (HandGuide / HandGuide2 prefabs) so the project no longer needs the Spine runtime.
    /// </summary>
    public class HandGuideTapAnimation : MonoBehaviour
    {
        [SerializeField] private Transform m_Pivot;
        [SerializeField] private HandTapKeyField[] m_Keys;
        [SerializeField] private Ease m_Ease = Ease.InOutSine;
        [SerializeField] private LoopType m_LoopType = LoopType.Restart;
        [SerializeField] private int m_LoopCount = -1;

        private Sequence m_Sequence;
        private Vector3 m_RestPosition;
        private Quaternion m_RestRotation;

        private void OnEnable()
        {
            PlayTapLoop();
        }

        private void OnDisable()
        {
            StopTapLoop();
        }

        private void PlayTapLoop()
        {
            if (m_Pivot == null || m_Keys == null || m_Keys.Length == 0) return;

            m_RestPosition = m_Pivot.localPosition;
            m_RestRotation = m_Pivot.localRotation;
            Vector3 restEuler = m_RestRotation.eulerAngles;

            m_Sequence = DOTween.Sequence();
            foreach (HandTapKeyField key in m_Keys)
            {
                m_Sequence.Append(m_Pivot.DOLocalMoveY(m_RestPosition.y + key.OffsetY, key.Duration).SetEase(m_Ease));
                m_Sequence.Join(m_Pivot.DOLocalRotate(restEuler + Vector3.forward * key.RotationZ, key.Duration).SetEase(m_Ease));
            }
            m_Sequence.SetLoops(m_LoopCount, m_LoopType);
        }

        private void StopTapLoop()
        {
            if (m_Sequence == null) return;

            m_Sequence.Kill();
            m_Sequence = null;
            if (m_Pivot == null) return;

            m_Pivot.localPosition = m_RestPosition;
            m_Pivot.localRotation = m_RestRotation;
        }
    }
}
