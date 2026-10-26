using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace Rush.Chocology.Settings
{
    [UnityEngine.Scripting.APIUpdating.MovedFrom(true, "", "Assembly-CSharp", "SettingPopup")]
    public class SettingPopup : MonoBehaviour
    {
        [global::System.Serializable]
        private sealed class SettingPopupField
        {
            [UnityEngine.Serialization.FormerlySerializedAs("popup")]
            [UnityEngine.SerializeField]
            private GameObject m_Popup;
            public global::UnityEngine.GameObject Popup { get => m_Popup; set => m_Popup = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("btnClose")]
            [UnityEngine.SerializeField]
            private BBUIButton m_BtnClose;
            public global::BBUIButton BtnClose { get => m_BtnClose; set => m_BtnClose = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("btnRate")]
            [UnityEngine.SerializeField]
            private BBUIButton m_BtnRate;
            public global::BBUIButton BtnRate { get => m_BtnRate; set => m_BtnRate = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("btnSound")]
            [UnityEngine.SerializeField]
            private BBUIButton m_BtnSound;
            public global::BBUIButton BtnSound { get => m_BtnSound; set => m_BtnSound = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("icon_Sound")]
            [UnityEngine.SerializeField]
            private Image m_IconSound;
            public global::UnityEngine.UI.Image IconSound { get => m_IconSound; set => m_IconSound = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("sprite_SoundOn")]
            [UnityEngine.SerializeField]
            private Sprite m_SpriteSoundOn;
            public global::UnityEngine.Sprite SpriteSoundOn { get => m_SpriteSoundOn; set => m_SpriteSoundOn = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("sprite_SoundOff")]
            [UnityEngine.SerializeField]
            private Sprite m_SpriteSoundOff;
            public global::UnityEngine.Sprite SpriteSoundOff { get => m_SpriteSoundOff; set => m_SpriteSoundOff = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("btnMusic")]
            [UnityEngine.SerializeField]
            private BBUIButton m_BtnMusic;
            public global::BBUIButton BtnMusic { get => m_BtnMusic; set => m_BtnMusic = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("icon_Music")]
            [UnityEngine.SerializeField]
            private Image m_IconMusic;
            public global::UnityEngine.UI.Image IconMusic { get => m_IconMusic; set => m_IconMusic = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("sprite_MusicOn")]
            [UnityEngine.SerializeField]
            private Sprite m_SpriteMusicOn;
            public global::UnityEngine.Sprite SpriteMusicOn { get => m_SpriteMusicOn; set => m_SpriteMusicOn = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("sprite_MusicOff")]
            [UnityEngine.SerializeField]
            private Sprite m_SpriteMusicOff;
            public global::UnityEngine.Sprite SpriteMusicOff { get => m_SpriteMusicOff; set => m_SpriteMusicOff = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("lockGroup")]
            [UnityEngine.SerializeField]
            private GameObject m_LockGroup;
            public global::UnityEngine.GameObject LockGroup { get => m_LockGroup; set => m_LockGroup = value; }
        }

        [global::UnityEngine.SerializeField]
        private SettingPopupField m_SettingPopupFields = new SettingPopupField();
        private static global::Rush.Chocology.Settings.SettingPopup s_Instance;
        public static global::Rush.Chocology.Settings.SettingPopup Instance { get => s_Instance; set => s_Instance = value; }
        public global::UnityEngine.GameObject Popup { get => m_SettingPopupFields.Popup; set => m_SettingPopupFields.Popup = value; }
        public global::BBUIButton BtnClose { get => m_SettingPopupFields.BtnClose; set => m_SettingPopupFields.BtnClose = value; }
        public global::BBUIButton BtnRate { get => m_SettingPopupFields.BtnRate; set => m_SettingPopupFields.BtnRate = value; }
        public global::BBUIButton BtnSound { get => m_SettingPopupFields.BtnSound; set => m_SettingPopupFields.BtnSound = value; }
        public global::UnityEngine.UI.Image IconSound { get => m_SettingPopupFields.IconSound; set => m_SettingPopupFields.IconSound = value; }
        public global::UnityEngine.Sprite SpriteSoundOn { get => m_SettingPopupFields.SpriteSoundOn; set => m_SettingPopupFields.SpriteSoundOn = value; }
        public global::UnityEngine.Sprite SpriteSoundOff { get => m_SettingPopupFields.SpriteSoundOff; set => m_SettingPopupFields.SpriteSoundOff = value; }
        public global::BBUIButton BtnMusic { get => m_SettingPopupFields.BtnMusic; set => m_SettingPopupFields.BtnMusic = value; }
        public global::UnityEngine.UI.Image IconMusic { get => m_SettingPopupFields.IconMusic; set => m_SettingPopupFields.IconMusic = value; }
        public global::UnityEngine.Sprite SpriteMusicOn { get => m_SettingPopupFields.SpriteMusicOn; set => m_SettingPopupFields.SpriteMusicOn = value; }
        public global::UnityEngine.Sprite SpriteMusicOff { get => m_SettingPopupFields.SpriteMusicOff; set => m_SettingPopupFields.SpriteMusicOff = value; }
        public global::UnityEngine.GameObject LockGroup { get => m_SettingPopupFields.LockGroup; set => m_SettingPopupFields.LockGroup = value; }

        enum STATE_CLOSEPOPUP
        {
            CLOSE,
            RATE
        }

        private global::Rush.Chocology.Settings.SettingPopup.STATE_CLOSEPOPUP m_StateClosePopup = global::Rush.Chocology.Settings.SettingPopup.STATE_CLOSEPOPUP.CLOSE;
        // Start is called before the first frame update
        void Start()
        {
            m_SettingPopupFields.BtnClose.OnPointerClickCallBack_Completed.AddListener(TouchClose);
            m_SettingPopupFields.BtnSound.OnPointerClickCallBack_Completed.AddListener(TouchSound);
            m_SettingPopupFields.BtnMusic.OnPointerClickCallBack_Completed.AddListener(TouchMusic);
            m_SettingPopupFields.BtnRate.OnPointerClickCallBack_Completed.AddListener(TouchRate);
            global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::BBUIView>(m_SettingPopupFields.Popup).HideBehavior.onCallback_Completed.AddListener(PopupHideViewFinished);
        }

        // Update is called once per frame
        void Update()
        {
        }

        private void TouchClose()
        {
            m_StateClosePopup = global::Rush.Chocology.Settings.SettingPopup.STATE_CLOSEPOPUP.CLOSE;
            m_SettingPopupFields.LockGroup.gameObject.SetActive(true);
            global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::BBUIView>(m_SettingPopupFields.Popup).HideView();
        }

        private void TouchSound()
        {
            global::Rush.Chocology.Economy.Config.Runtime.SetSound(!global::Rush.Chocology.Economy.Config.Runtime.IsSound);
            ShowButtonSound();
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

            ShowButtonMusic();
        }

        private void TouchRate()
        {
            m_StateClosePopup = global::Rush.Chocology.Settings.SettingPopup.STATE_CLOSEPOPUP.RATE;
            m_SettingPopupFields.LockGroup.gameObject.SetActive(true);
            global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::BBUIView>(m_SettingPopupFields.Popup).HideView();
        }

        public void TouchContactus() => TouchContactusInternal();
        private void TouchContactusInternal()
        {
            Application.OpenURL("https://www.google.com/");
        }

        public void TouchFollowUS() => TouchFollowUSInternal();
        private void TouchFollowUSInternal()
        {
            Application.OpenURL("https://www.facebook.com/");
        }

        private void PopupHideViewFinished()
        {
            if (m_StateClosePopup == global::Rush.Chocology.Settings.SettingPopup.STATE_CLOSEPOPUP.RATE)
            {
                global::Rush.Chocology.LevelMap.MenuManager.Instance.OpenRatePopup();
            }

            gameObject.SetActive(false);
        }

        public void OpenSettingPopup() => OpenSettingPopupInternal();
        private void OpenSettingPopupInternal()
        {
            gameObject.SetActive(true);
            InitViews();
        }

        private void InitViews()
        {
            global::Rush.Chocology.Audio.SoundManager.Instance.PlaySoundPopup();
            m_SettingPopupFields.LockGroup.gameObject.SetActive(false);
            m_SettingPopupFields.Popup.gameObject.SetActive(false);
            m_SettingPopupFields.BtnClose.gameObject.SetActive(false);
            m_SettingPopupFields.BtnSound.gameObject.SetActive(true);
            m_SettingPopupFields.BtnMusic.gameObject.SetActive(true);
            m_SettingPopupFields.BtnRate.gameObject.SetActive(true);
            ShowButtonSound();
            ShowButtonMusic();
            InitViewsShowViewInternal();
        }

        private void ShowButtonMusic()
        {
            if (global::Rush.Chocology.Economy.Config.Runtime.IsMusic)
            {
                m_SettingPopupFields.IconMusic.sprite = m_SettingPopupFields.SpriteMusicOn;
            }
            else
            {
                m_SettingPopupFields.IconMusic.sprite = m_SettingPopupFields.SpriteMusicOff;
            }
        // icon_Music.SetNativeSize();
        }

        private void ShowButtonSound()
        {
            if (global::Rush.Chocology.Economy.Config.Runtime.IsSound)
            {
                m_SettingPopupFields.IconSound.sprite = m_SettingPopupFields.SpriteSoundOn;
            }
            else
            {
                m_SettingPopupFields.IconSound.sprite = m_SettingPopupFields.SpriteSoundOff;
            }
        //icon_Music.SetNativeSize();
        }

        public void InitViewsShowView() => InitViewsShowViewInternal();
        private void InitViewsShowViewInternal()
        {
            Sequence sequenceShowView = DOTween.Sequence();
            sequenceShowView.InsertCallback(0.01f, () =>
            {
                m_SettingPopupFields.Popup.gameObject.SetActive(true);
                global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::BBUIView>(m_SettingPopupFields.Popup).ShowView();
            });
            //sequenceShowView.InsertCallback(0.6f, () =>
            //{
            //    btnMusic.gameObject.SetActive(true);
            //    btnMusic.GetComponent<BBUIView>().ShowView();
            //});
            //sequenceShowView.InsertCallback(0.8f, () =>
            //{
            //    btnSound.gameObject.SetActive(true);
            //    btnSound.GetComponent<BBUIView>().ShowView();
            //});
            //sequenceShowView.InsertCallback(1f, () =>
            //{
            //    btnRate.gameObject.SetActive(true);
            //    btnRate.GetComponent<BBUIView>().ShowView();
            //});
            sequenceShowView.InsertCallback(0.4f, () =>
            {
                m_SettingPopupFields.BtnClose.gameObject.SetActive(true);
                global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::BBUIView>(m_SettingPopupFields.BtnClose).ShowView();
            });
        }
    }
}
