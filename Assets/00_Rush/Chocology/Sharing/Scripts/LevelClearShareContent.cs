using System.Globalization;

namespace Rush.Chocology.Sharing
{
    /// <summary>A snapshot of the level that was cleared, independent of saved progression.</summary>
    public readonly struct LevelClearShareContent
    {
        private const string c_StoreUrl = "https://play.google.com/store/apps/details?id=com.gameson.chocology";
        private const string c_SubjectFormat = "Chocology - Level {0} Cleared!";
        private const string c_MessageFormat = "I just cleared Level {0} in Chocology! 🍫✨\nCan you beat me?\n#Chocology\n{1}";

        private readonly int m_CompletedLevel;

        public LevelClearShareContent(int completedLevel)
        {
            m_CompletedLevel = completedLevel > 0 ? completedLevel : 0;
        }

        public int CompletedLevel => m_CompletedLevel;
        public bool CanShare => m_CompletedLevel > 0;
        public string StoreUrl => c_StoreUrl;
        public string Subject => CanShare
            ? string.Format(CultureInfo.InvariantCulture, c_SubjectFormat, m_CompletedLevel)
            : string.Empty;
        public string Text => CanShare
            ? string.Format(CultureInfo.InvariantCulture, c_MessageFormat, m_CompletedLevel, c_StoreUrl)
            : string.Empty;
    }
}
