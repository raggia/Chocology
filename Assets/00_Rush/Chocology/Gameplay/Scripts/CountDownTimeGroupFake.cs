using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Rush.Chocology.Gameplay
{
    [UnityEngine.Scripting.APIUpdating.MovedFrom(true, "", "Assembly-CSharp", "CountDownTimeGroupFake")]
    public class CountDownTimeGroupFake : MonoBehaviour
    {
        [UnityEngine.Serialization.FormerlySerializedAs("txtTime")]
        [UnityEngine.SerializeField]
        private Text m_TxtTime;
        public global::UnityEngine.UI.Text TxtTime { get => m_TxtTime; set => m_TxtTime = value; }

        [UnityEngine.Serialization.FormerlySerializedAs("TIME_START")]
        [UnityEngine.SerializeField]
        private int m_TimeStart = 47 * 60 * 60 + 40 * 60;
        public int TimeStart { get => m_TimeStart; set => m_TimeStart = value; }

        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
        }

        private void OnEnable()
        {
            StartCoroutine(UpdateTimeIEnumeratorInternal());
        }

        public IEnumerator UpdateTimeIEnumerator() => UpdateTimeIEnumeratorInternal();
        private IEnumerator UpdateTimeIEnumeratorInternal()
        {
            while (true)
            {
                int time = Mathf.FloorToInt(m_TimeStart - Time.realtimeSinceStartup);
                if (time <= 0)
                {
                    time = m_TimeStart;
                }

                m_TxtTime.text = global::Rush.Chocology.Economy.Config.Runtime.FormatTime(time);
                yield return new WaitForSecondsRealtime(1f);
            }
        }
    }
}
