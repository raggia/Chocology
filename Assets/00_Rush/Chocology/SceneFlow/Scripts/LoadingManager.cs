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
        private void Awake()
        {
            SingletonSetup();
        }

        public void SpawnLoading() => SpawnLoadingInternal();
        private void SpawnLoadingInternal()
        {
            Debug.Log("Spawn loading");
            m_RoutineOpenLoading = StartCoroutine(CloseLoadingRoutine());
            m_PanelLoading.SetActive(true);
        }

        public void CloseLoading() => CloseLoadingInternal();
        private void CloseLoadingInternal()
        {
            Debug.Log("Close loading");
            StopCoroutine(m_RoutineOpenLoading);
            m_PanelLoading.SetActive(false);
        }

        IEnumerator CloseLoadingRoutine()
        {
            int i = 10;
            while (i > 0)
            {
                i--;
                yield return new WaitForSeconds(1f);
            }

            m_PanelLoading.SetActive(false);
        }
    }
}
