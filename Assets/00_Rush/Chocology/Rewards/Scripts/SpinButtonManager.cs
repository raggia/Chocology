using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Config = Rush.Chocology.Economy.Config;

namespace Rush.Chocology.Rewards
{
    [UnityEngine.Scripting.APIUpdating.MovedFrom(true, "", "Assembly-CSharp", "SpinButtonManager")]
    public class SpinButtonManager : MonoBehaviour
    {
        private const float c_RefreshInterval = 1f;
        private const float c_PunchDuration = 1.5f;
        private const int c_PunchVibrato = 5;
        private const float c_PunchElasticity = 1f;
        private const float c_PulseDelay = 2f;
        private const float c_PulseScale = 1.1f;
        private const float c_PulseDuration = 0.75f;
        private const int c_PulseLoops = 2;
        private static readonly Vector3 s_PunchPosition = new Vector3(5f, 5f, 0.1f);
        private static readonly Vector3 s_PunchRotation = new Vector3(0f, 0f, 10f);
        private static readonly Vector3 s_PunchScale = new Vector3(0.1f, 0.1f, 0.1f);
        private BBUIButton m_ButtonSpin;
        [UnityEngine.Serialization.FormerlySerializedAs("icon")]
        [SerializeField] private Image m_Icon;
        public Image Icon { get => m_Icon; set => m_Icon = value; }
        [UnityEngine.Serialization.FormerlySerializedAs("countDownTimeGroup")]
        [SerializeField] private global::Rush.Chocology.Gameplay.CountDownTimeGroup m_CountDownTimeGroup;
        public global::Rush.Chocology.Gameplay.CountDownTimeGroup CountDownTimeGroup { get => m_CountDownTimeGroup; set => m_CountDownTimeGroup = value; }
        private Sequence m_SequenceSpinButton;
        private Config m_Config;
        private Vector3 m_IconPosition;
        private Quaternion m_IconRotation;
        private Vector3 m_IconScale;
        private bool m_Started;
        private float m_NextRefresh;

        private void Awake()
        {
            m_ButtonSpin = global::Rush.Chocology.Core.RushComponentAccess.Resolve<BBUIButton>(this);
            m_IconPosition = m_Icon.transform.localPosition;
            m_IconRotation = m_Icon.transform.localRotation;
            m_IconScale = m_Icon.transform.localScale;
        }

        private void Start()
        {
            m_Config = Config.Runtime;
            m_CountDownTimeGroup.InitCallBack(CountDownTimeGroupCallBackInternal);
            m_Config.OnChangeSpin_LastTime += OnChangeSpinLastTimeInternal;
            m_Started = true;
            ShowSpinButtonInternal();
        }

        private void OnEnable()
        {
            if (m_Started)
                ShowSpinButtonInternal();
        }

        private void Update()
        {
            if (m_Started && Time.unscaledTime >= m_NextRefresh)
            {
                m_NextRefresh = Time.unscaledTime + c_RefreshInterval;
                ShowSpinButtonInternal();
            }
        }

        private void OnDisable()
        {
            StopAnimationInternal();
            m_CountDownTimeGroup.StopCountDownTime();
        }

        private void OnDestroy()
        {
            if (m_Config != null)
                m_Config.OnChangeSpin_LastTime -= OnChangeSpinLastTimeInternal;
        }

        public void OnChangeSpinLastTime() => OnChangeSpinLastTimeInternal();
        private void OnChangeSpinLastTimeInternal() => ShowSpinButtonInternal();
        public void ShowSpinButton() => ShowSpinButtonInternal();
        private void ShowSpinButtonInternal()
        {
            if (!isActiveAndEnabled || m_Config == null)
                return;
            m_Icon.color = Color.white;
            m_ButtonSpin.Interactable = true;
            long remaining = m_Config.SpinCooldownRemaining;
            m_CountDownTimeGroup.gameObject.SetActive(remaining > 0);
            if (remaining > 0)
            {
                StopAnimationInternal();
                m_CountDownTimeGroup.InitCountDownTimeGroup(remaining);
                m_CountDownTimeGroup.StartCountDownTime();
            }
            else
            {
                m_CountDownTimeGroup.StopCountDownTime();
                if (m_SequenceSpinButton == null)
                    ShowSpinButtonAvaiableInternal();
            }
        }

        public void CountDownTimeGroupCallBack(Config.COUNTDOWN_TIME_TYPE type) => CountDownTimeGroupCallBackInternal(type);
        private void CountDownTimeGroupCallBackInternal(Config.COUNTDOWN_TIME_TYPE type) => ShowSpinButtonInternal();
        public void ShowSpinButtonAvaiable() => ShowSpinButtonAvaiableInternal();
        private void ShowSpinButtonAvaiableInternal()
        {
            if (!isActiveAndEnabled)
                return;
            StopAnimationInternal();
            m_SequenceSpinButton = DOTween.Sequence().SetUpdate(true).SetLink(gameObject);
            m_SequenceSpinButton.Insert(0f, m_Icon.transform.DOPunchPosition(s_PunchPosition, c_PunchDuration, c_PunchVibrato, c_PunchElasticity).SetEase(Ease.InBounce));
            m_SequenceSpinButton.Insert(0f, m_Icon.transform.DOPunchRotation(s_PunchRotation, c_PunchDuration, c_PunchVibrato, c_PunchElasticity).SetEase(Ease.InOutBack));
            m_SequenceSpinButton.Insert(0f, m_Icon.transform.DOPunchScale(s_PunchScale, c_PunchDuration, c_PunchVibrato, c_PunchElasticity).SetEase(Ease.InBounce));
            m_SequenceSpinButton.Insert(c_PulseDelay, m_Icon.transform.DOScale(m_IconScale * c_PulseScale, c_PulseDuration).SetEase(Ease.Linear).SetLoops(c_PulseLoops, LoopType.Yoyo));
            m_SequenceSpinButton.SetLoops(-1, LoopType.Yoyo);
        }

        private void StopAnimationInternal()
        {
            m_SequenceSpinButton?.Kill();
            m_SequenceSpinButton = null;
            m_Icon.transform.localPosition = m_IconPosition;
            m_Icon.transform.localRotation = m_IconRotation;
            m_Icon.transform.localScale = m_IconScale;
        }
    }
}
