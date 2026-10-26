using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
#if UNITY_ANDROID
using Unity.Notifications.Android;
#endif
using System;

namespace Rush.Chocology.Rewards
{
    [UnityEngine.Scripting.APIUpdating.MovedFrom(true, "", "Assembly-CSharp", "SpinButtonManager")]
    public class SpinButtonManager : MonoBehaviour
    {
        private BBUIButton m_ButtonSpin;
        [UnityEngine.Serialization.FormerlySerializedAs("icon")]
        [UnityEngine.SerializeField]
        private Image m_Icon;
        public global::UnityEngine.UI.Image Icon { get => m_Icon; set => m_Icon = value; }

        [UnityEngine.Serialization.FormerlySerializedAs("countDownTimeGroup")]
        [UnityEngine.SerializeField]
        private global::Rush.Chocology.Gameplay.CountDownTimeGroup m_CountDownTimeGroup;
        public global::Rush.Chocology.Gameplay.CountDownTimeGroup CountDownTimeGroup { get => m_CountDownTimeGroup; set => m_CountDownTimeGroup = value; }

        private void Awake()
        {
            m_ButtonSpin = global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::BBUIButton>(this);
        }

        // Start is called before the first frame update
        void Start()
        {
            m_CountDownTimeGroup.InitCallBack((global::Rush.Chocology.Economy.Config.COUNTDOWN_TIME_TYPE countDownTimeType) =>
            {
                CountDownTimeGroupCallBackInternal(countDownTimeType);
            });
            global::Rush.Chocology.Economy.Config.Runtime.OnChangeSpin_LastTime += OnChangeSpinLastTimeInternal;
            ShowSpinButtonInternal();
        }

        private void OnDestroy()
        {
            global::Rush.Chocology.Economy.Config.Runtime.OnChangeSpin_LastTime -= OnChangeSpinLastTimeInternal;
        }

        public void OnChangeSpinLastTime() => OnChangeSpinLastTimeInternal();
        private void OnChangeSpinLastTimeInternal()
        {
            ShowSpinButtonInternal();
        }

        public void ShowSpinButton() => ShowSpinButtonInternal();
        private void ShowSpinButtonInternal()
        {
            // long currTimeLastTime = Config.GetSpinLastTime();
            // if (currTimeLastTime + Config.TIME_SPIN > Config.GetTimeStamp())
            // {
            //     buttonSpin.Interactable = false;
            //     if (sequence_SpinButton != null)
            //     {
            //         sequence_SpinButton.Kill();
            //     }
            //     countDownTimeGroup.gameObject.SetActive(true);
            //     countDownTimeGroup.InitCountDownTimeGroup(currTimeLastTime + Config.TIME_SPIN - Config.GetTimeStamp());
            //     countDownTimeGroup.StartCountDownTime();
            //     icon.color = new Color(200f/255f, 200f / 255f, 200f / 255f, 200f / 255f);
            // }
            // else
            // {
            //     
            // }
            m_Icon.color = new Color(1f, 1f, 1f, 1f);
            m_CountDownTimeGroup.gameObject.SetActive(false);
            m_ButtonSpin.Interactable = true;
            long currTimeLastTime = global::Rush.Chocology.Economy.Config.Runtime.SpinLastTime;
            if (currTimeLastTime + global::Rush.Chocology.Economy.Config.TIME_SPIN > global::Rush.Chocology.Economy.Config.Runtime.TimeStamp)
            {
                if (m_SequenceSpinButton != null)
                {
                    m_SequenceSpinButton.Kill();
                }

                m_CountDownTimeGroup.gameObject.SetActive(true);
                m_CountDownTimeGroup.InitCountDownTimeGroup(currTimeLastTime + global::Rush.Chocology.Economy.Config.TIME_SPIN - global::Rush.Chocology.Economy.Config.Runtime.TimeStamp);
                m_CountDownTimeGroup.StartCountDownTime();
            }
            else
            {
                ShowSpinButtonAvaiableInternal();
                DateTime time = DateTime.FromBinary(currTimeLastTime + global::Rush.Chocology.Economy.Config.TIME_SPIN - global::Rush.Chocology.Economy.Config.Runtime.TimeStamp);
            }
        }

        // Update is called once per frame
        void Update()
        {
        }

        public void CountDownTimeGroupCallBack(global::Rush.Chocology.Economy.Config.COUNTDOWN_TIME_TYPE countDownTimeType) => CountDownTimeGroupCallBackInternal(countDownTimeType);
        private void CountDownTimeGroupCallBackInternal(global::Rush.Chocology.Economy.Config.COUNTDOWN_TIME_TYPE countDownTimeType)
        {
            ShowSpinButtonInternal();
        }

        private Sequence m_SequenceSpinButton;
        public void ShowSpinButtonAvaiable() => ShowSpinButtonAvaiableInternal();
        private void ShowSpinButtonAvaiableInternal()
        {
            //Debug.Log("ShowSpinButtonAvaiable");
            if (m_SequenceSpinButton != null)
            {
                m_SequenceSpinButton.Kill();
            }

            m_SequenceSpinButton = DOTween.Sequence();
            m_SequenceSpinButton.Insert(0f, m_Icon.transform.DOPunchPosition(new Vector3(5f, 5f, 0.1f), UnityEngine.Random.Range(1f, 2f), 5, 1).SetEase(Ease.InBounce));
            m_SequenceSpinButton.Insert(0f, m_Icon.transform.DOPunchRotation(new Vector3(0f, 0f, 10f), UnityEngine.Random.Range(1f, 2f), 5, 1).SetEase(Ease.InOutBack));
            m_SequenceSpinButton.Insert(0f, m_Icon.transform.DOPunchScale(new Vector3(0.1f, 0.1f, 0.1f), UnityEngine.Random.Range(1f, 2f), 5, 1).SetEase(Ease.InBounce));
            m_SequenceSpinButton.Insert(2f, m_Icon.transform.DOScale(1.1f, UnityEngine.Random.Range(0.5f, 1f)).SetEase(Ease.Linear).SetLoops(UnityEngine.Random.Range(2, 4), LoopType.Yoyo));
            m_SequenceSpinButton.SetLoops(-1, LoopType.Yoyo);
        }
    }
}
