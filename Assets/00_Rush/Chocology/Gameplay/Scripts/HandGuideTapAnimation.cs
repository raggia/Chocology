using System;
using DG.Tweening;
using UnityEngine;

namespace Rush.Chocology.Gameplay
{
    /// <summary>
    /// One key of the hand tap loop: after <see cref = "Duration"/> seconds the pivot should sit at
    /// <see cref = "OffsetY"/> above its rest position, rotated <see cref = "RotationZ"/> degrees from its rest rotation.
    /// </summary>
    [Serializable]
    [UnityEngine.Scripting.APIUpdating.MovedFrom(true, "Rush", "Assembly-CSharp", "HandTapKeyField")]
    public class HandTapKeyField
    {
        [global::System.Serializable]
        private sealed class HandTapKeyFieldField
        {
            [UnityEngine.Serialization.FormerlySerializedAs("m_Duration")]
            [UnityEngine.SerializeField]
            private float m_Duration;
            public float DurationValue { get => m_Duration; set => m_Duration = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("m_RotationZ")]
            [UnityEngine.SerializeField]
            private float m_RotationZ;
            public float RotationZValue { get => m_RotationZ; set => m_RotationZ = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("m_OffsetY")]
            [UnityEngine.SerializeField]
            private float m_OffsetY;
            public float OffsetYValue { get => m_OffsetY; set => m_OffsetY = value; }
        }

        [global::UnityEngine.SerializeField]
        private HandTapKeyFieldField m_HandTapKeyFieldFields = new HandTapKeyFieldField();
        public float Duration => m_HandTapKeyFieldFields.DurationValue;
        public float RotationZ => m_HandTapKeyFieldFields.RotationZValue;
        public float OffsetY => m_HandTapKeyFieldFields.OffsetYValue;
    }

    [UnityEngine.Scripting.APIUpdating.MovedFrom(true, "Rush", "Assembly-CSharp", "HandGuideTapAnimation")]
    /// <summary>
    /// Loops a "tap" bob (move up, dip, settle) on a sprite hand pointer. Replaces the old Spine "Click" animation
    /// of the tutorial hand (HandGuide / HandGuide2 prefabs) so the project no longer needs the Spine runtime.
    /// </summary>
    public class HandGuideTapAnimation : MonoBehaviour
    {
        [global::System.Serializable]
        private sealed class HandGuideTapAnimationField
        {
            [UnityEngine.Serialization.FormerlySerializedAs("m_Pivot")]
            [UnityEngine.SerializeField]
            private Transform m_Pivot;
            public global::UnityEngine.Transform Pivot { get => m_Pivot; set => m_Pivot = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("m_Keys")]
            [UnityEngine.SerializeField]
            private global::Rush.Chocology.Gameplay.HandTapKeyField[] m_Keys;
            public global::Rush.Chocology.Gameplay.HandTapKeyField[] Keys { get => m_Keys; set => m_Keys = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("m_Ease")]
            [UnityEngine.SerializeField]
            private Ease m_Ease = Ease.InOutSine;
            public global::DG.Tweening.Ease Ease { get => m_Ease; set => m_Ease = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("m_LoopType")]
            [UnityEngine.SerializeField]
            private LoopType m_LoopType = LoopType.Restart;
            public global::DG.Tweening.LoopType LoopType { get => m_LoopType; set => m_LoopType = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("m_LoopCount")]
            [UnityEngine.SerializeField]
            private int m_LoopCount = -1;
            public int LoopCount { get => m_LoopCount; set => m_LoopCount = value; }
        }

        [global::UnityEngine.SerializeField]
        private HandGuideTapAnimationField m_HandGuideTapAnimationFields = new HandGuideTapAnimationField();
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
            if (m_HandGuideTapAnimationFields.Pivot == null || m_HandGuideTapAnimationFields.Keys == null || m_HandGuideTapAnimationFields.Keys.Length == 0)
                return;
            m_RestPosition = m_HandGuideTapAnimationFields.Pivot.localPosition;
            m_RestRotation = m_HandGuideTapAnimationFields.Pivot.localRotation;
            Vector3 restEuler = m_RestRotation.eulerAngles;
            m_Sequence = DOTween.Sequence();
            foreach (global::Rush.Chocology.Gameplay.HandTapKeyField key in m_HandGuideTapAnimationFields.Keys)
            {
                m_Sequence.Append(m_HandGuideTapAnimationFields.Pivot.DOLocalMoveY(m_RestPosition.y + key.OffsetY, key.Duration).SetEase(m_HandGuideTapAnimationFields.Ease));
                m_Sequence.Join(m_HandGuideTapAnimationFields.Pivot.DOLocalRotate(restEuler + Vector3.forward * key.RotationZ, key.Duration).SetEase(m_HandGuideTapAnimationFields.Ease));
            }

            m_Sequence.SetLoops(m_HandGuideTapAnimationFields.LoopCount, m_HandGuideTapAnimationFields.LoopType);
        }

        private void StopTapLoop()
        {
            if (m_Sequence == null)
                return;
            m_Sequence.Kill();
            m_Sequence = null;
            if (m_HandGuideTapAnimationFields.Pivot == null)
                return;
            m_HandGuideTapAnimationFields.Pivot.localPosition = m_RestPosition;
            m_HandGuideTapAnimationFields.Pivot.localRotation = m_RestRotation;
        }
    }
}
