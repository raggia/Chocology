/*
 * Created on 2022
 *
 * Copyright (c) 2022 dotmobstudio
 * Support : dotmobstudio@gmail.com
 */
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Rush.Chocology.SceneFlow
{
    [UnityEngine.Scripting.APIUpdating.MovedFrom(true, "", "Assembly-CSharp", "LoadSceneManager")]
    public class LoadSceneManager : MonoBehaviour
    {
        private static global::Rush.Chocology.SceneFlow.LoadSceneManager s_Instance;
        public static global::Rush.Chocology.SceneFlow.LoadSceneManager Instance { get => s_Instance; set => s_Instance = value; }

        private void Awake()
        {
            s_Instance = this;
        }

        // Start is called before the first frame update
        void Start()
        {
            global::Rush.Chocology.Economy.Config.Runtime.LoadSound();
            global::Rush.Chocology.Economy.Config.Runtime.LoadMusic();
            global::Rush.Chocology.Economy.Config.Runtime.CurrCoin = global::Rush.Chocology.Economy.Config.Runtime.Coin;
            global::Rush.Chocology.Economy.Config.Runtime.LoadCurrLevel();
            global::Rush.Chocology.Economy.Config.Runtime.CurrPiggyBankCoin = global::Rush.Chocology.Economy.Config.Runtime.PiggyBank;
            global::Rush.Chocology.Economy.Config.Runtime.LoadLevelStar();
            if (global::Rush.Chocology.Economy.Config.Runtime.IsMusic)
            {
                global::Rush.Chocology.Audio.MusicManager.Instance.PlayMusicBG();
            }

            //TODO: Check Chest Star
            //Config.SetChestCountStar(15);
            StartCoroutine(LoadMenuSceneIEnumeratorInternal());
        }

        // Update is called once per frame
        void Update()
        {
        }

        public IEnumerator LoadMenuSceneIEnumerator() => LoadMenuSceneIEnumeratorInternal();
        private IEnumerator LoadMenuSceneIEnumeratorInternal()
        {
            yield return new WaitForSeconds(2f);
            LoadMenuSceneInternal();
        }

        private bool m_IsLoadMenu = false;
        public void LoadMenuScene() => LoadMenuSceneInternal();
        private void LoadMenuSceneInternal()
        {
            if (!m_IsLoadMenu)
            {
                //isLoadMenu = true;
                if (global::Rush.Chocology.Economy.Config.Runtime.CurrLevel == 1)
                {
                    SceneManager.LoadSceneAsync("Play");
                }
                else
                {
                    SceneManager.LoadSceneAsync("Menu");
                }
            //SceneManager.LoadSceneAsync("Menu");
            }
        }
    }
}
