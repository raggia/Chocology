using System;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

namespace Rush.Chocology.Sharing
{
    /// <summary>Owns the optional share action within the level-cleared panel.</summary>
    public sealed class LevelClearShareView : MonoBehaviour
    {
        private const string c_LevelFormat = "LEVEL {0} CLEARED!";

        [Serializable]
        private sealed class LevelClearShareControls
        {
            [SerializeField] private LevelClearShare m_Share;
            [SerializeField] private Button m_Button;
            [SerializeField] private Button m_SaveButton;
            [SerializeField] private Text m_LevelText;
            [SerializeField] private Text m_StatusText;

            public LevelClearShare Share => m_Share;
            public Button Button => m_Button;
            public Button SaveButton => m_SaveButton;
            public Text LevelText => m_LevelText;
            public Text StatusText => m_StatusText;
        }

        [SerializeField] private LevelClearShareControls m_Controls = new LevelClearShareControls();

        public int CompletedLevel => m_Controls.Share != null ? m_Controls.Share.CompletedLevel : 0;

        public void SetCompletedLevel(int completedLevel)
        {
            SetCompletedLevelInternal(completedLevel);
        }

        private void OnEnable()
        {
            if (m_Controls.Button != null)
                m_Controls.Button.onClick.AddListener(ShareInternal);
            if (m_Controls.SaveButton != null)
                m_Controls.SaveButton.onClick.AddListener(SaveForStoryInternal);
            if (m_Controls.Share != null)
                m_Controls.Share.OnStatusChanged.AddListener(SetStatusInternal);
            RefreshInternal();
        }

        private void OnDisable()
        {
            if (m_Controls.Button != null)
                m_Controls.Button.onClick.RemoveListener(ShareInternal);
            if (m_Controls.SaveButton != null)
                m_Controls.SaveButton.onClick.RemoveListener(SaveForStoryInternal);
            if (m_Controls.Share != null)
                m_Controls.Share.OnStatusChanged.RemoveListener(SetStatusInternal);
        }

        private void SetCompletedLevelInternal(int completedLevel)
        {
            if (m_Controls.Share == null)
                return;

            m_Controls.Share.SetCompletedLevel(completedLevel);
            RefreshInternal();
        }

        private void ShareInternal()
        {
            if (m_Controls.Share != null)
                m_Controls.Share.Share();
        }

        private void SaveForStoryInternal()
        {
            if (m_Controls.Share != null)
                m_Controls.Share.SaveForStory();
        }

        private void RefreshInternal()
        {
            bool ready = m_Controls.Share != null && m_Controls.Share.CanShare;
            if (m_Controls.Button != null)
                m_Controls.Button.interactable = ready;
            if (m_Controls.SaveButton != null)
                m_Controls.SaveButton.interactable = ready;
            if (m_Controls.LevelText != null)
                m_Controls.LevelText.text = CompletedLevel > 0
                    ? string.Format(CultureInfo.InvariantCulture, c_LevelFormat, CompletedLevel)
                    : string.Empty;
            SetStatusInternal(m_Controls.Share != null ? m_Controls.Share.LastShareStatus : string.Empty);
        }

        private void SetStatusInternal(string status)
        {
            if (m_Controls.StatusText != null)
                m_Controls.StatusText.text = status;
            if (m_Controls.Button != null)
                m_Controls.Button.interactable = m_Controls.Share != null && m_Controls.Share.CanShare;
            if (m_Controls.SaveButton != null)
                m_Controls.SaveButton.interactable = m_Controls.Share != null && m_Controls.Share.CanShare;
        }
    }
}
