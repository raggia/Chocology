/*
 * Created on 2022
 *
 * Copyright (c) 2022 dotmobstudio
 * Support : dotmobstudio@gmail.com
 */
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Rush.Chocology.Gameplay
{
    [UnityEngine.Scripting.APIUpdating.MovedFrom(true, "", "Assembly-CSharp", "PausePopup2")]
    public class PausePopup2 : MonoBehaviour
    {
        [global::System.Serializable]
        private sealed class PausePopup2Field
        {
            [UnityEngine.Serialization.FormerlySerializedAs("popup")]
            [UnityEngine.SerializeField]
            private BBUIView m_Popup;
            public global::BBUIView Popup { get => m_Popup; set => m_Popup = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("btnMusic")]
            [UnityEngine.SerializeField]
            private BBUIButton m_BtnMusic;
            public global::BBUIButton BtnMusic { get => m_BtnMusic; set => m_BtnMusic = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("btnSound")]
            [UnityEngine.SerializeField]
            private BBUIButton m_BtnSound;
            public global::BBUIButton BtnSound { get => m_BtnSound; set => m_BtnSound = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("btnRate")]
            [UnityEngine.SerializeField]
            private BBUIButton m_BtnRate;
            public global::BBUIButton BtnRate { get => m_BtnRate; set => m_BtnRate = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("iconSound")]
            [UnityEngine.SerializeField]
            private Image m_IconSound;
            public global::UnityEngine.UI.Image IconSound { get => m_IconSound; set => m_IconSound = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("soundOn")]
            [UnityEngine.SerializeField]
            private Sprite m_SoundOn;
            public global::UnityEngine.Sprite SoundOn { get => m_SoundOn; set => m_SoundOn = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("soundOff")]
            [UnityEngine.SerializeField]
            private Sprite m_SoundOff;
            public global::UnityEngine.Sprite SoundOff { get => m_SoundOff; set => m_SoundOff = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("iconMusic")]
            [UnityEngine.SerializeField]
            private Image m_IconMusic;
            public global::UnityEngine.UI.Image IconMusic { get => m_IconMusic; set => m_IconMusic = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("musicOn")]
            [UnityEngine.SerializeField]
            private Sprite m_MusicOn;
            public global::UnityEngine.Sprite MusicOn { get => m_MusicOn; set => m_MusicOn = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("musicOff")]
            [UnityEngine.SerializeField]
            private Sprite m_MusicOff;
            public global::UnityEngine.Sprite MusicOff { get => m_MusicOff; set => m_MusicOff = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("btnHome")]
            [UnityEngine.SerializeField]
            private BBUIButton m_BtnHome;
            public global::BBUIButton BtnHome { get => m_BtnHome; set => m_BtnHome = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("btnRestart")]
            [UnityEngine.SerializeField]
            private BBUIButton m_BtnRestart;
            public global::BBUIButton BtnRestart { get => m_BtnRestart; set => m_BtnRestart = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("btnContinue")]
            [UnityEngine.SerializeField]
            private BBUIButton m_BtnContinue;
            public global::BBUIButton BtnContinue { get => m_BtnContinue; set => m_BtnContinue = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("btnClose")]
            [UnityEngine.SerializeField]
            private BBUIButton m_BtnClose;
            public global::BBUIButton BtnClose { get => m_BtnClose; set => m_BtnClose = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("lockGroup")]
            [UnityEngine.SerializeField]
            private GameObject m_LockGroup;
            public global::UnityEngine.GameObject LockGroup { get => m_LockGroup; set => m_LockGroup = value; }
        }

        [global::UnityEngine.SerializeField]
        private PausePopup2Field m_PausePopup2Fields = new PausePopup2Field();
        public global::BBUIView Popup { get => m_PausePopup2Fields.Popup; set => m_PausePopup2Fields.Popup = value; }
        public global::BBUIButton BtnMusic { get => m_PausePopup2Fields.BtnMusic; set => m_PausePopup2Fields.BtnMusic = value; }
        public global::BBUIButton BtnSound { get => m_PausePopup2Fields.BtnSound; set => m_PausePopup2Fields.BtnSound = value; }
        public global::BBUIButton BtnRate { get => m_PausePopup2Fields.BtnRate; set => m_PausePopup2Fields.BtnRate = value; }
        public global::UnityEngine.UI.Image IconSound { get => m_PausePopup2Fields.IconSound; set => m_PausePopup2Fields.IconSound = value; }
        public global::UnityEngine.Sprite SoundOn { get => m_PausePopup2Fields.SoundOn; set => m_PausePopup2Fields.SoundOn = value; }
        public global::UnityEngine.Sprite SoundOff { get => m_PausePopup2Fields.SoundOff; set => m_PausePopup2Fields.SoundOff = value; }
        public global::UnityEngine.UI.Image IconMusic { get => m_PausePopup2Fields.IconMusic; set => m_PausePopup2Fields.IconMusic = value; }
        public global::UnityEngine.Sprite MusicOn { get => m_PausePopup2Fields.MusicOn; set => m_PausePopup2Fields.MusicOn = value; }
        public global::UnityEngine.Sprite MusicOff { get => m_PausePopup2Fields.MusicOff; set => m_PausePopup2Fields.MusicOff = value; }
        public global::BBUIButton BtnHome { get => m_PausePopup2Fields.BtnHome; set => m_PausePopup2Fields.BtnHome = value; }
        public global::BBUIButton BtnRestart { get => m_PausePopup2Fields.BtnRestart; set => m_PausePopup2Fields.BtnRestart = value; }
        public global::BBUIButton BtnContinue { get => m_PausePopup2Fields.BtnContinue; set => m_PausePopup2Fields.BtnContinue = value; }
        public global::BBUIButton BtnClose { get => m_PausePopup2Fields.BtnClose; set => m_PausePopup2Fields.BtnClose = value; }
        public global::UnityEngine.GameObject LockGroup { get => m_PausePopup2Fields.LockGroup; set => m_PausePopup2Fields.LockGroup = value; }

        // Start is called before the first frame update
        void Start()
        {
            m_PausePopup2Fields.Popup.ShowBehavior.onCallback_Completed.AddListener(ShowViewFinished);
            m_PausePopup2Fields.Popup.HideBehavior.onCallback_Completed.AddListener(HideViewFinished);
            m_PausePopup2Fields.BtnHome.OnPointerClickCallBack_Completed.AddListener(TouchHome);
            m_PausePopup2Fields.BtnRestart.OnPointerClickCallBack_Completed.AddListener(TouchRestart);
            m_PausePopup2Fields.BtnClose.OnPointerClickCallBack_Completed.AddListener(TouchClose);
            m_PausePopup2Fields.BtnContinue.OnPointerClickCallBack_Completed.AddListener(TouchContinue);
            m_PausePopup2Fields.BtnSound.OnPointerClickCallBack_Completed.AddListener(TouchSound);
            m_PausePopup2Fields.BtnMusic.OnPointerClickCallBack_Completed.AddListener(TouchMusic);
            m_PausePopup2Fields.BtnRate.OnPointerClickCallBack_Completed.AddListener(TouchRate);
            ShowIconMusic();
            ShowIconSound();
        }

        private void TouchContinue()
        {
            m_StateClosePopup = global::Rush.Chocology.Gameplay.PausePopup2.STATE_CLOSEPOPUP.CONTINNUE;
            m_PausePopup2Fields.LockGroup.gameObject.SetActive(true);
            global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::BBUIView>(m_PausePopup2Fields.Popup).HideView();
        }

        enum STATE_CLOSEPOPUP
        {
            CONTINNUE,
            RESTART,
            HOME,
            LEVELSELECT
        }

        private global::Rush.Chocology.Gameplay.PausePopup2.STATE_CLOSEPOPUP m_StateClosePopup = global::Rush.Chocology.Gameplay.PausePopup2.STATE_CLOSEPOPUP.CONTINNUE;
        // Update is called once per frame
        void Update()
        {
        }

        private int m_Level = 1;
        public void OpenPausePopup(int _level) => OpenPausePopupInternal(_level);
        private void OpenPausePopupInternal(int _level)
        {
            global::Rush.Chocology.Economy.Config.Runtime.InterstitialAdCountPause++;
            m_Level = _level;
            gameObject.SetActive(true);
            ShowViews();
        }

        private void ShowViews()
        {
            global::Rush.Chocology.Audio.SoundManager.Instance.PlaySoundPopup();
            m_PausePopup2Fields.LockGroup.SetActive(true);
            StartCoroutine(ShowViewsIEnumerator());
        }

        private IEnumerator ShowViewsIEnumerator()
        {
            m_PausePopup2Fields.Popup.gameObject.SetActive(false);
            m_PausePopup2Fields.BtnClose.gameObject.SetActive(false);
            yield return new WaitForSeconds(0.1f);
            m_PausePopup2Fields.Popup.gameObject.SetActive(true);
            m_PausePopup2Fields.Popup.ShowView();
            yield return new WaitForSeconds(0.2f);
            m_PausePopup2Fields.BtnClose.gameObject.SetActive(true);
            global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::BBUIView>(m_PausePopup2Fields.BtnClose).ShowView();
        }

        private void ShowIconSound()
        {
            m_PausePopup2Fields.IconSound.sprite = global::Rush.Chocology.Economy.Config.Runtime.IsSound ? m_PausePopup2Fields.SoundOn : m_PausePopup2Fields.SoundOff;
        }

        private void ShowIconMusic()
        {
            m_PausePopup2Fields.IconMusic.sprite = global::Rush.Chocology.Economy.Config.Runtime.IsMusic ? m_PausePopup2Fields.MusicOn : m_PausePopup2Fields.MusicOff;
        }

        private void ShowViewFinished()
        {
            m_PausePopup2Fields.LockGroup.SetActive(false);
        }

        private void HideViewFinished()
        {
            if (m_StateClosePopup == global::Rush.Chocology.Gameplay.PausePopup2.STATE_CLOSEPOPUP.CONTINNUE)
            {
                Time.timeScale = 1f;
                global::Rush.Chocology.Gameplay.GamePlayManager.Instance.SetUnPause();
            }
            else if (m_StateClosePopup == global::Rush.Chocology.Gameplay.PausePopup2.STATE_CLOSEPOPUP.RESTART)
            {
                SceneManager.LoadScene("Play");
            }
            else if (m_StateClosePopup == global::Rush.Chocology.Gameplay.PausePopup2.STATE_CLOSEPOPUP.HOME)
            {
                SceneManager.LoadScene("Menu");
            }

            gameObject.SetActive(false);
            Time.timeScale = 1f;
        }

        private void TouchHome()
        {
            m_StateClosePopup = global::Rush.Chocology.Gameplay.PausePopup2.STATE_CLOSEPOPUP.HOME;
            m_PausePopup2Fields.LockGroup.gameObject.SetActive(true);
            {
                Time.timeScale = 1f;
                SceneManager.LoadScene("Menu");
                global::Rush.Chocology.Notifications.GlobalVar.Runtime.CallAnalytics("end_game_not_finished");
            }
        }

        private void TouchRestart()
        {
            m_StateClosePopup = global::Rush.Chocology.Gameplay.PausePopup2.STATE_CLOSEPOPUP.RESTART;
            m_PausePopup2Fields.LockGroup.gameObject.SetActive(true);
            {
                // popup.GetComponent<BBUIView>().HideView();
                Time.timeScale = 1f;
                SceneManager.LoadScene("Play");
            }
        }

        private void TouchClose()
        {
            m_StateClosePopup = global::Rush.Chocology.Gameplay.PausePopup2.STATE_CLOSEPOPUP.CONTINNUE;
            m_PausePopup2Fields.LockGroup.gameObject.SetActive(true);
            global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::BBUIView>(m_PausePopup2Fields.Popup).HideView();
        }

        private void TouchSound()
        {
            global::Rush.Chocology.Economy.Config.Runtime.SetSound(!global::Rush.Chocology.Economy.Config.Runtime.IsSound);
            ShowIconSound();
        }

        private void TouchMusic()
        {
            global::Rush.Chocology.Economy.Config.Runtime.SetMusic(!global::Rush.Chocology.Economy.Config.Runtime.IsMusic);
            if (global::Rush.Chocology.Economy.Config.Runtime.IsMusic)
            {
                global::Rush.Chocology.Audio.MusicManager.Instance.PlayMusicBG();
            }
            else
            {
                global::Rush.Chocology.Audio.MusicManager.Instance.StopMusicBG();
            }

            ShowIconMusic();
        }

        private void TouchRate()
        {
            global::Rush.Chocology.Gameplay.GamePlayManager.Instance.OpenRatePopup();
        }
    }
}
