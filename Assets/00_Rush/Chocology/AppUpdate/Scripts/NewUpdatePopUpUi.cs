using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace Rush.Chocology.AppUpdate
{
    struct GameVersionData
    {
        [UnityEngine.Serialization.FormerlySerializedAs("Title")]
        [UnityEngine.SerializeField]
        private string m_Title;
        [Newtonsoft.Json.JsonProperty("Title")]
        public string Title { get => m_Title; set => m_Title = value; }

        [UnityEngine.Serialization.FormerlySerializedAs("Description")]
        [UnityEngine.SerializeField]
        private string m_Description;
        [Newtonsoft.Json.JsonProperty("Description")]
        public string Description { get => m_Description; set => m_Description = value; }

        [UnityEngine.Serialization.FormerlySerializedAs("Version")]
        [UnityEngine.SerializeField]
        private string m_Version;
        [Newtonsoft.Json.JsonProperty("Version")]
        public string Version { get => m_Version; set => m_Version = value; }

        [UnityEngine.Serialization.FormerlySerializedAs("Url")]
        [UnityEngine.SerializeField]
        private string m_Url;
        [Newtonsoft.Json.JsonProperty("Url")]
        public string Url { get => m_Url; set => m_Url = value; }
    }

    [UnityEngine.Scripting.APIUpdating.MovedFrom(true, "", "Assembly-CSharp", "NewUpdatePopUpUi")]
    public class NewUpdatePopUpUi : MonoBehaviour
    {
        [global::System.Serializable]
        private sealed class NewUpdatePopUpUiField
        {
            [UnityEngine.Serialization.FormerlySerializedAs("uiCanvas")]
            [UnityEngine.SerializeField]
            private GameObject m_UiCanvas;
            public global::UnityEngine.GameObject UiCanvas { get => m_UiCanvas; set => m_UiCanvas = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("notNowBtn")]
            [UnityEngine.SerializeField]
            private Button m_NotNowBtn;
            public global::UnityEngine.UI.Button NotNowBtn { get => m_NotNowBtn; set => m_NotNowBtn = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("updateBtn")]
            [UnityEngine.SerializeField]
            private Button m_UpdateBtn;
            public global::UnityEngine.UI.Button UpdateBtn { get => m_UpdateBtn; set => m_UpdateBtn = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("uiDescription")]
            [UnityEngine.SerializeField]
            private TextMeshProUGUI m_UiDescription;
            public global::TMPro.TextMeshProUGUI UiDescription { get => m_UiDescription; set => m_UiDescription = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("androidJsonDataURL")]
            [UnityEngine.SerializeField]
            [Space(29f)]
            [TextArea(2, 5)]
            private string m_AndroidJsonDataURL;
            public string AndroidJsonDataURL { get => m_AndroidJsonDataURL; set => m_AndroidJsonDataURL = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("iosJsonDataURL")]
            [UnityEngine.SerializeField]
            [TextArea(2, 5)]
            private string m_IosJsonDataURL;
            public string IosJsonDataURL { get => m_IosJsonDataURL; set => m_IosJsonDataURL = value; }
        }

        [global::UnityEngine.SerializeField]
        private NewUpdatePopUpUiField m_NewUpdatePopUpUiFields = new NewUpdatePopUpUiField();
        private static bool s_IsAlreadyCheckedForUpdates = false;
        private const int c_RequestTimeoutSeconds = 10;
        private global::Rush.Chocology.AppUpdate.GameVersionData m_LatestGameVersion;
        // Start is called before the first frame update
        void Start()
        {
            HidePopUp();
            if (!s_IsAlreadyCheckedForUpdates)
            {
                StopAllCoroutines();
                StartCoroutine(CheckforUpdate());
            }
        }

        IEnumerator CheckforUpdate()
        {
#if UNITY_IOS && !UNITY_EDITOR
            string url = m_NewUpdatePopUpUiFields.IosJsonDataURL;
#else
            string url = m_NewUpdatePopUpUiFields.AndroidJsonDataURL;
#endif
            if (!Uri.TryCreate(url, UriKind.Absolute, out var endpoint) || endpoint.Scheme != Uri.UriSchemeHttps)
                yield break;
            using (var request = UnityWebRequest.Get(url))
            {
                request.timeout = c_RequestTimeoutSeconds;
                yield return request.SendWebRequest();
                s_IsAlreadyCheckedForUpdates = true;
                if (request.result != UnityWebRequest.Result.Success)
                    yield break;
                GameVersionData latest;
                try
                {
                    latest = Newtonsoft.Json.JsonConvert.DeserializeObject<GameVersionData>(request.downloadHandler.text);
                }
                catch (Newtonsoft.Json.JsonException)
                {
                    Debug.LogWarning("Update information is temporarily unavailable.", this);
                    yield break;
                }
                if (!HasNewerVersion(Application.version, latest.Version))
                    yield break;
                // Only offer the official store destination for this app.
#if UNITY_IOS && !UNITY_EDITOR
                if (!Uri.TryCreate(latest.Url, UriKind.Absolute, out var store) || store.Scheme != Uri.UriSchemeHttps || store.Host != "apps.apple.com")
                    yield break;
#else
                if (!Uri.TryCreate(latest.Url, UriKind.Absolute, out var store) || store.Scheme != Uri.UriSchemeHttps || store.Host != "play.google.com" || store.AbsolutePath != "/store/apps/details" || store.Query != "?id=" + Application.identifier)
                    yield break;
#endif
                m_LatestGameVersion = latest;
                m_NewUpdatePopUpUiFields.UiDescription.text = latest.Description;
                ShowPopUp();
            }
        }

        internal static bool HasNewerVersion(string current, string latest)
        {
            if (!Version.TryParse(current != null && !current.Contains(".") ? current + ".0" : current, out var installed) || !Version.TryParse(latest != null && !latest.Contains(".") ? latest + ".0" : latest, out var available))
                return false;
            // Normalize omitted minor/build/revision numbers (2, 2.0, 2.0.0).
            var normalizedInstalled = new Version(installed.Major, Math.Max(0, installed.Minor), Math.Max(0, installed.Build), Math.Max(0, installed.Revision));
            var normalizedAvailable = new Version(available.Major, Math.Max(0, available.Minor), Math.Max(0, available.Build), Math.Max(0, available.Revision));
            return normalizedAvailable > normalizedInstalled;
        }

        void ShowPopUp()
        {
            m_NewUpdatePopUpUiFields.NotNowBtn.onClick.AddListener(() =>
            {
                HidePopUp();
            });
            m_NewUpdatePopUpUiFields.UpdateBtn.onClick.AddListener(() =>
            {
                Application.OpenURL(m_LatestGameVersion.Url);
                HidePopUp();
            });
            m_NewUpdatePopUpUiFields.UiCanvas.gameObject.SetActive(true);
        }

        void HidePopUp()
        {
            m_NewUpdatePopUpUiFields.UiCanvas.gameObject.SetActive(false);
            m_NewUpdatePopUpUiFields.NotNowBtn.onClick.RemoveAllListeners();
            m_NewUpdatePopUpUiFields.UpdateBtn.onClick.RemoveAllListeners();
        }

        private void OnDestroy()
        {
            StopAllCoroutines();
        }
    }
}
