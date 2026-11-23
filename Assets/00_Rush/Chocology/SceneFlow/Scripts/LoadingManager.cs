using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rush.Chocology.SceneFlow
{
    [UnityEngine.Scripting.APIUpdating.MovedFrom(true, "", "Assembly-CSharp", "LoadingManager")]
    public class LoadingManager : MonoBehaviour
    {

        public static global::Rush.Chocology.SceneFlow.LoadingManager Instance { get; private set; }

        void SingletonSetup()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        [UnityEngine.Serialization.FormerlySerializedAs("panelLoading")]
        [UnityEngine.SerializeField]
        private GameObject m_PanelLoading;
        private Coroutine m_RoutineOpenLoading;
        private const float c_LoadingTimeoutSeconds = 30f;
        private void Awake()
        {
            SingletonSetup();
        }

        public void SpawnLoading() => SpawnLoadingInternal();
        private void SpawnLoadingInternal()
        {
            if (m_RoutineOpenLoading != null)
                StopCoroutine(m_RoutineOpenLoading);
            if (m_PanelLoading != null)
                m_PanelLoading.SetActive(true);
            m_RoutineOpenLoading = StartCoroutine(CloseLoadingRoutine());
        }

        public void CloseLoading() => CloseLoadingInternal();
        private void CloseLoadingInternal()
        {
            if (m_RoutineOpenLoading != null)
                StopCoroutine(m_RoutineOpenLoading);
            m_RoutineOpenLoading = null;
            if (m_PanelLoading != null)
                m_PanelLoading.SetActive(false);
        }

        IEnumerator CloseLoadingRoutine()
        {
            yield return new WaitForSecondsRealtime(c_LoadingTimeoutSeconds);
            m_RoutineOpenLoading = null;
            if (m_PanelLoading != null)
                m_PanelLoading.SetActive(false);
        }

        private void OnDestroy()
        {
            if (Instance == this)
                Instance = null;
        }
    }
}
