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
            UnityWebRequest request;
#if UNITY_EDITOR || UNITY_ANDROID
            request = UnityWebRequest.Get(m_NewUpdatePopUpUiFields.AndroidJsonDataURL);
#elif UNITY_IOS
        request = UnityWebRequest.Get(iosJsonDataURL);
#endif
            request.chunkedTransfer = false;
            request.disposeDownloadHandlerOnDispose = true;
            request.timeout = 60;
            Debug.Log("[Request] Try to request");
            yield return request.Send();
            if (request.isDone)
            {
                s_IsAlreadyCheckedForUpdates = true;
                Debug.Log("[Request] Done");
                Debug.Log($"[Request] result : {(request.isNetworkError)}, {(request.isHttpError)}, {(request.isNetworkError)} ");
                if (!request.isNetworkError)
                {
                    Debug.Log($"[Request] Succes with : {(request.downloadHandler.text)}");
                    m_LatestGameVersion = Newtonsoft.Json.JsonConvert.DeserializeObject<global::Rush.Chocology.AppUpdate.GameVersionData>(request.downloadHandler.text);
                    if (!string.IsNullOrEmpty(m_LatestGameVersion.Version) && !Application.version.Equals(m_LatestGameVersion.Version))
                    {
                        m_NewUpdatePopUpUiFields.UiDescription.text = m_LatestGameVersion.Description;
                        Debug.Log($"[Request] Ui Description : {(m_NewUpdatePopUpUiFields.UiDescription.text)}");
                        Debug.Log($"[Request] Description : {(m_LatestGameVersion.Description)}");
                        ShowPopUp();
                    }

                    if (!string.IsNullOrEmpty(m_LatestGameVersion.Version) && Application.version.Equals(m_LatestGameVersion.Version))
                    {
                        HidePopUp();
                    }
                }
            }

            request.Dispose();
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
