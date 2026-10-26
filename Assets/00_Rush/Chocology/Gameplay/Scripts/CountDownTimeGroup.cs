using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Rush.Chocology.Gameplay
{
    [UnityEngine.Scripting.APIUpdating.MovedFrom(true, "", "Assembly-CSharp", "CountDownTimeGroup")]
    public class CountDownTimeGroup : MonoBehaviour
    {
        [global::System.Serializable]
        private sealed class CountDownTimeGroupField
        {
            [UnityEngine.Serialization.FormerlySerializedAs("UseText")]
            [UnityEngine.SerializeField]
            private bool m_UseText;
            public bool UseText { get => m_UseText; set => m_UseText = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("isRound")]
            [UnityEngine.SerializeField]
            private bool m_IsRound;
            public bool IsRound { get => m_IsRound; set => m_IsRound = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("isUse_S")]
            [UnityEngine.SerializeField]
            private bool m_IsUseS;
            public bool IsUseS { get => m_IsUseS; set => m_IsUseS = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("timeTxt")]
            [UnityEngine.SerializeField]
            private Text m_TimeTxt;
            public global::UnityEngine.UI.Text TimeTxt { get => m_TimeTxt; set => m_TimeTxt = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("UseImage")]
            [UnityEngine.SerializeField]
            private bool m_UseImage;
            public bool UseImage { get => m_UseImage; set => m_UseImage = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("timeImg")]
            [UnityEngine.SerializeField]
            private Image m_TimeImg;
            public global::UnityEngine.UI.Image TimeImg { get => m_TimeImg; set => m_TimeImg = value; }
        }

        [global::UnityEngine.SerializeField]
        private CountDownTimeGroupField m_CountDownTimeGroupFields = new CountDownTimeGroupField();
        private float m_InitTime;
        private float m_CountTime;
        private float m_LastCountDownTime;
        private bool m_IsStartCountTime = false;
        private Action<global::Rush.Chocology.Economy.Config.COUNTDOWN_TIME_TYPE> m_CountDownTimeGroupCallback = delegate (global::Rush.Chocology.Economy.Config.COUNTDOWN_TIME_TYPE countDownTimeType)
        {
        };
        // Start is called before the first frame update
        void Start()
        {
        }

        public void InitCallBack(Action<global::Rush.Chocology.Economy.Config.COUNTDOWN_TIME_TYPE> _countDownTimeGroup_Callback) => InitCallBackInternal(_countDownTimeGroup_Callback);
        private void InitCallBackInternal(Action<global::Rush.Chocology.Economy.Config.COUNTDOWN_TIME_TYPE> _countDownTimeGroup_Callback)
        {
            m_CountDownTimeGroupCallback = _countDownTimeGroup_Callback;
        }

        // Update is called once per frame
        void Update()
        {
            if (m_IsStartCountTime)
            {
                //Debug.Log("isStartCountTime"+ isStartCountTime);
                m_CountTime = m_CountTime - Time.deltaTime;
                if (m_CountDownTimeGroupFields.UseText)
                {
                    if (m_LastCountDownTime - m_CountTime >= 0.1f)
                    {
                        m_LastCountDownTime = m_CountTime;
                        ShowTime();
                    }
                }

                if (m_CountDownTimeGroupFields.UseImage)
                {
                    ShowTime();
                }

                if (m_CountTime <= 0)
                {
                    m_CountTime = 0;
                    ShowTime();
                    m_IsStartCountTime = false;
                    Debug.Log("AAAAAAAAAAAAAAAAAA:" + m_IsStartCountTime);
                    m_CountDownTimeGroupCallback(global::Rush.Chocology.Economy.Config.COUNTDOWN_TIME_TYPE.END);
                }
            }
        }

        public void InitCountDownTimeGroup(float _initTime) => InitCountDownTimeGroupInternal(_initTime);
        private void InitCountDownTimeGroupInternal(float _initTime)
        {
            m_InitTime = _initTime;
            m_CountTime = m_InitTime;
            ShowTime();
        }

        public void StartCountDownTime() => StartCountDownTimeInternal();
        private void StartCountDownTimeInternal()
        {
            m_IsStartCountTime = true;
            m_LastCountDownTime = m_CountTime;
        }

        public void StopCountDownTime() => StopCountDownTimeInternal();
        private void StopCountDownTimeInternal()
        {
            m_IsStartCountTime = false;
        }

        private void ShowTime()
        {
            if (m_CountDownTimeGroupFields.UseText)
            {
                int hours = Mathf.FloorToInt(m_CountTime / 3600);
                int countMinustes = Mathf.FloorToInt(m_CountTime - hours * 3600);
                int minutes = Mathf.FloorToInt(countMinustes / 60);
                int seconds = Mathf.FloorToInt(countMinustes % 60);
                m_CountDownTimeGroupFields.TimeTxt.text = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);
            //string textTime = countTime.ToString("0.0");
            //if (isRound) {
            //    textTime = Mathf.Round(countTime).ToString();
            //}
            //if (isUse_S)
            //{
            //    timeTxt.text = textTime + "s";
            //}
            //else {
            //    timeTxt.text = textTime + "";
            //}
            }

            if (m_CountDownTimeGroupFields.UseImage)
            {
                m_CountDownTimeGroupFields.TimeImg.fillAmount = m_CountTime / m_InitTime;
            }
        }
    }
}
