using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rush.Chocology.Audio
{
    [UnityEngine.Scripting.APIUpdating.MovedFrom(true, "", "Assembly-CSharp", "SoundManager")]
    public class SoundManager : MonoBehaviour
    {
        [global::System.Serializable]
        private sealed class SoundManagerField
        {
            [UnityEngine.Serialization.FormerlySerializedAs("click1")]
            [UnityEngine.SerializeField]
            private AudioClip m_Click1;
            public global::UnityEngine.AudioClip Click1 { get => m_Click1; set => m_Click1 = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("click2")]
            [UnityEngine.SerializeField]
            private AudioClip m_Click2;
            public global::UnityEngine.AudioClip Click2 { get => m_Click2; set => m_Click2 = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("click3")]
            [UnityEngine.SerializeField]
            private AudioClip m_Click3;
            public global::UnityEngine.AudioClip Click3 { get => m_Click3; set => m_Click3 = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("block_click")]
            [UnityEngine.SerializeField]
            private AudioClip m_BlockClick;
            public global::UnityEngine.AudioClip BlockClick { get => m_BlockClick; set => m_BlockClick = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("blockMoveFinish")]
            [UnityEngine.SerializeField]
            private AudioClip m_BlockMoveFinish;
            public global::UnityEngine.AudioClip BlockMoveFinish { get => m_BlockMoveFinish; set => m_BlockMoveFinish = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("blockCash")]
            [UnityEngine.SerializeField]
            private AudioClip m_BlockCash;
            public global::UnityEngine.AudioClip BlockCash { get => m_BlockCash; set => m_BlockCash = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("blockClear")]
            [UnityEngine.SerializeField]
            private AudioClip m_BlockClear;
            public global::UnityEngine.AudioClip BlockClear { get => m_BlockClear; set => m_BlockClear = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("voice")]
            [UnityEngine.SerializeField]
            private AudioClip m_Voice;
            public global::UnityEngine.AudioClip Voice { get => m_Voice; set => m_Voice = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("free_block")]
            [UnityEngine.SerializeField]
            private AudioClip m_FreeBlock;
            public global::UnityEngine.AudioClip FreeBlock { get => m_FreeBlock; set => m_FreeBlock = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("game_over")]
            [UnityEngine.SerializeField]
            private AudioClip m_GameOver;
            public global::UnityEngine.AudioClip GameOver { get => m_GameOver; set => m_GameOver = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("gold")]
            [UnityEngine.SerializeField]
            private AudioClip m_Gold;
            public global::UnityEngine.AudioClip Gold { get => m_Gold; set => m_Gold = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("horeo")]
            [UnityEngine.SerializeField]
            private AudioClip m_Horeo;
            public global::UnityEngine.AudioClip Horeo { get => m_Horeo; set => m_Horeo = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("no_more_move")]
            [UnityEngine.SerializeField]
            private AudioClip m_NoMoreMove;
            public global::UnityEngine.AudioClip NoMoreMove { get => m_NoMoreMove; set => m_NoMoreMove = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("phaogiay")]
            [UnityEngine.SerializeField]
            private AudioClip m_Phaogiay;
            public global::UnityEngine.AudioClip Phaogiay { get => m_Phaogiay; set => m_Phaogiay = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("sfx_popup")]
            [UnityEngine.SerializeField]
            private AudioClip m_SfxPopup;
            public global::UnityEngine.AudioClip SfxPopup { get => m_SfxPopup; set => m_SfxPopup = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("sfx_wind")]
            [UnityEngine.SerializeField]
            private AudioClip m_SfxWind;
            public global::UnityEngine.AudioClip SfxWind { get => m_SfxWind; set => m_SfxWind = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("showBoard")]
            [UnityEngine.SerializeField]
            private AudioClip m_ShowBoard;
            public global::UnityEngine.AudioClip ShowBoard { get => m_ShowBoard; set => m_ShowBoard = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("win")]
            [UnityEngine.SerializeField]
            private AudioClip m_Win;
            public global::UnityEngine.AudioClip Win { get => m_Win; set => m_Win = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("showView")]
            [UnityEngine.SerializeField]
            private AudioClip m_ShowView;
            public global::UnityEngine.AudioClip ShowView { get => m_ShowView; set => m_ShowView = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("hideView")]
            [UnityEngine.SerializeField]
            private AudioClip m_HideView;
            public global::UnityEngine.AudioClip HideView { get => m_HideView; set => m_HideView = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("winstarPop")]
            [UnityEngine.SerializeField]
            private AudioClip m_WinstarPop;
            public global::UnityEngine.AudioClip WinstarPop { get => m_WinstarPop; set => m_WinstarPop = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("notification")]
            [UnityEngine.SerializeField]
            private AudioClip m_Notification;
            public global::UnityEngine.AudioClip Notification { get => m_Notification; set => m_Notification = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("reward")]
            [UnityEngine.SerializeField]
            private AudioClip m_Reward;
            public global::UnityEngine.AudioClip Reward { get => m_Reward; set => m_Reward = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("spin")]
            [UnityEngine.SerializeField]
            private AudioClip m_Spin;
            public global::UnityEngine.AudioClip Spin { get => m_Spin; set => m_Spin = value; }
        }

        [global::UnityEngine.SerializeField]
        private SoundManagerField m_SoundManagerFields = new SoundManagerField();
        private static global::Rush.Chocology.Audio.SoundManager s_Instance;
        public static global::Rush.Chocology.Audio.SoundManager Instance { get => s_Instance; set => s_Instance = value; }

        private AudioSource m_AudioSound;
        private void Awake()
        {
            s_Instance = this;
            DontDestroyOnLoad(this);
            m_AudioSound = global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::UnityEngine.AudioSource>(this);
        }

        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
        }

        public global::UnityEngine.AudioClip Click1 { get => m_SoundManagerFields.Click1; set => m_SoundManagerFields.Click1 = value; }
        public global::UnityEngine.AudioClip Click2 { get => m_SoundManagerFields.Click2; set => m_SoundManagerFields.Click2 = value; }
        public global::UnityEngine.AudioClip Click3 { get => m_SoundManagerFields.Click3; set => m_SoundManagerFields.Click3 = value; }

        public void PlaySoundClick() => PlaySoundClickInternal();
        private void PlaySoundClickInternal()
        {
            if (global::Rush.Chocology.Economy.Config.Runtime.IsSound)
            {
                m_AudioSound.PlayOneShot(m_SoundManagerFields.Click2);
            }
        }

        public global::UnityEngine.AudioClip BlockClick { get => m_SoundManagerFields.BlockClick; set => m_SoundManagerFields.BlockClick = value; }

        public void PlaySoundBlockClick() => PlaySoundBlockClickInternal();
        private void PlaySoundBlockClickInternal()
        {
            if (global::Rush.Chocology.Economy.Config.Runtime.IsSound)
            {
                m_AudioSound.PlayOneShot(m_SoundManagerFields.BlockClick);
            }
        }

        public global::UnityEngine.AudioClip BlockMoveFinish { get => m_SoundManagerFields.BlockMoveFinish; set => m_SoundManagerFields.BlockMoveFinish = value; }

        public void PlaySoundBlockMoveFinish() => PlaySoundBlockMoveFinishInternal();
        private void PlaySoundBlockMoveFinishInternal()
        {
            if (global::Rush.Chocology.Economy.Config.Runtime.IsSound)
            {
                m_AudioSound.PlayOneShot(m_SoundManagerFields.BlockMoveFinish);
            }
        }

        public global::UnityEngine.AudioClip BlockCash { get => m_SoundManagerFields.BlockCash; set => m_SoundManagerFields.BlockCash = value; }

        public void PlaySoundCash() => PlaySoundCashInternal();
        private void PlaySoundCashInternal()
        {
            if (global::Rush.Chocology.Economy.Config.Runtime.IsSound)
            {
                m_AudioSound.PlayOneShot(m_SoundManagerFields.BlockCash);
            }
        }

        public global::UnityEngine.AudioClip BlockClear { get => m_SoundManagerFields.BlockClear; set => m_SoundManagerFields.BlockClear = value; }

        public void PlaySoundClear() => PlaySoundClearInternal();
        private void PlaySoundClearInternal()
        {
            if (global::Rush.Chocology.Economy.Config.Runtime.IsSound)
            {
                m_AudioSound.PlayOneShot(m_SoundManagerFields.BlockClear);
            }
        }

        public global::UnityEngine.AudioClip Voice { get => m_SoundManagerFields.Voice; set => m_SoundManagerFields.Voice = value; }

        public void PlaySoundVoice() => PlaySoundVoiceInternal();
        private void PlaySoundVoiceInternal()
        {
            if (global::Rush.Chocology.Economy.Config.Runtime.IsSound)
            {
                m_AudioSound.PlayOneShot(m_SoundManagerFields.Voice);
            }
        }

        public global::UnityEngine.AudioClip FreeBlock { get => m_SoundManagerFields.FreeBlock; set => m_SoundManagerFields.FreeBlock = value; }

        public void PlaySoundFreeBlock() => PlaySoundFreeBlockInternal();
        private void PlaySoundFreeBlockInternal()
        {
            if (global::Rush.Chocology.Economy.Config.Runtime.IsSound)
            {
                m_AudioSound.PlayOneShot(m_SoundManagerFields.FreeBlock);
            }
        }

        public global::UnityEngine.AudioClip GameOver { get => m_SoundManagerFields.GameOver; set => m_SoundManagerFields.GameOver = value; }

        public void PlaySoundGameOver() => PlaySoundGameOverInternal();
        private void PlaySoundGameOverInternal()
        {
            if (global::Rush.Chocology.Economy.Config.Runtime.IsSound)
            {
                m_AudioSound.PlayOneShot(m_SoundManagerFields.GameOver);
            }
        }

        public global::UnityEngine.AudioClip Gold { get => m_SoundManagerFields.Gold; set => m_SoundManagerFields.Gold = value; }

        public void PlaySoundGold() => PlaySoundGoldInternal();
        private void PlaySoundGoldInternal()
        {
            if (global::Rush.Chocology.Economy.Config.Runtime.IsSound)
            {
                m_AudioSound.PlayOneShot(m_SoundManagerFields.Gold);
            }
        }

        public global::UnityEngine.AudioClip Horeo { get => m_SoundManagerFields.Horeo; set => m_SoundManagerFields.Horeo = value; }

        public void PlaySoundHoreo() => PlaySoundHoreoInternal();
        private void PlaySoundHoreoInternal()
        {
            if (global::Rush.Chocology.Economy.Config.Runtime.IsSound)
            {
                m_AudioSound.PlayOneShot(m_SoundManagerFields.Horeo);
            }
        }

        public global::UnityEngine.AudioClip NoMoreMove { get => m_SoundManagerFields.NoMoreMove; set => m_SoundManagerFields.NoMoreMove = value; }

        public void PlaySoundNoMoreMove() => PlaySoundNoMoreMoveInternal();
        private void PlaySoundNoMoreMoveInternal()
        {
            if (global::Rush.Chocology.Economy.Config.Runtime.IsSound)
            {
                m_AudioSound.PlayOneShot(m_SoundManagerFields.NoMoreMove);
            }
        }

        public global::UnityEngine.AudioClip Phaogiay { get => m_SoundManagerFields.Phaogiay; set => m_SoundManagerFields.Phaogiay = value; }

        public void PlaySoundPhaoGiay() => PlaySoundPhaoGiayInternal();
        private void PlaySoundPhaoGiayInternal()
        {
            if (global::Rush.Chocology.Economy.Config.Runtime.IsSound)
            {
                m_AudioSound.PlayOneShot(m_SoundManagerFields.Phaogiay);
            }
        }

        public global::UnityEngine.AudioClip SfxPopup { get => m_SoundManagerFields.SfxPopup; set => m_SoundManagerFields.SfxPopup = value; }

        public void PlaySoundPopup() => PlaySoundPopupInternal();
        private void PlaySoundPopupInternal()
        {
            if (global::Rush.Chocology.Economy.Config.Runtime.IsSound)
            {
                m_AudioSound.PlayOneShot(m_SoundManagerFields.SfxPopup);
            }
        }

        public global::UnityEngine.AudioClip SfxWind { get => m_SoundManagerFields.SfxWind; set => m_SoundManagerFields.SfxWind = value; }

        public void PlaySoundWind() => PlaySoundWindInternal();
        private void PlaySoundWindInternal()
        {
            if (global::Rush.Chocology.Economy.Config.Runtime.IsSound)
            {
                m_AudioSound.PlayOneShot(m_SoundManagerFields.SfxWind);
            }
        }

        public global::UnityEngine.AudioClip ShowBoard { get => m_SoundManagerFields.ShowBoard; set => m_SoundManagerFields.ShowBoard = value; }

        public void PlaySoundShowBoard() => PlaySoundShowBoardInternal();
        private void PlaySoundShowBoardInternal()
        {
            if (global::Rush.Chocology.Economy.Config.Runtime.IsSound)
            {
                m_AudioSound.PlayOneShot(m_SoundManagerFields.ShowBoard);
            }
        }

        public global::UnityEngine.AudioClip Win { get => m_SoundManagerFields.Win; set => m_SoundManagerFields.Win = value; }

        public void PlaySoundWin() => PlaySoundWinInternal();
        private void PlaySoundWinInternal()
        {
            if (global::Rush.Chocology.Economy.Config.Runtime.IsSound)
            {
                m_AudioSound.PlayOneShot(m_SoundManagerFields.Win);
            }
        }

        public global::UnityEngine.AudioClip ShowView { get => m_SoundManagerFields.ShowView; set => m_SoundManagerFields.ShowView = value; }

        public void PlaySoundShowView() => PlaySoundShowViewInternal();
        private void PlaySoundShowViewInternal()
        {
            if (global::Rush.Chocology.Economy.Config.Runtime.IsSound)
            {
                m_AudioSound.PlayOneShot(m_SoundManagerFields.ShowView);
            }
        }

        public global::UnityEngine.AudioClip HideView { get => m_SoundManagerFields.HideView; set => m_SoundManagerFields.HideView = value; }

        public void PlaySoundHideView() => PlaySoundHideViewInternal();
        private void PlaySoundHideViewInternal()
        {
            if (global::Rush.Chocology.Economy.Config.Runtime.IsSound)
            {
                m_AudioSound.PlayOneShot(m_SoundManagerFields.HideView);
            }
        }

        public global::UnityEngine.AudioClip WinstarPop { get => m_SoundManagerFields.WinstarPop; set => m_SoundManagerFields.WinstarPop = value; }

        public void PlaySoundWinStarPop() => PlaySoundWinStarPopInternal();
        private void PlaySoundWinStarPopInternal()
        {
            if (global::Rush.Chocology.Economy.Config.Runtime.IsSound)
            {
                m_AudioSound.PlayOneShot(m_SoundManagerFields.WinstarPop);
            }
        }

        public global::UnityEngine.AudioClip Notification { get => m_SoundManagerFields.Notification; set => m_SoundManagerFields.Notification = value; }

        public void PlaySoundNotification() => PlaySoundNotificationInternal();
        private void PlaySoundNotificationInternal()
        {
            if (global::Rush.Chocology.Economy.Config.Runtime.IsSound)
            {
                m_AudioSound.PlayOneShot(m_SoundManagerFields.Notification);
            }
        }

        public global::UnityEngine.AudioClip Reward { get => m_SoundManagerFields.Reward; set => m_SoundManagerFields.Reward = value; }

        public void PlaySoundReward() => PlaySoundRewardInternal();
        private void PlaySoundRewardInternal()
        {
            if (global::Rush.Chocology.Economy.Config.Runtime.IsSound)
            {
                m_AudioSound.PlayOneShot(m_SoundManagerFields.Reward);
            }
        }

        public global::UnityEngine.AudioClip Spin { get => m_SoundManagerFields.Spin; set => m_SoundManagerFields.Spin = value; }

        public void PlaySoundSpin() => PlaySoundSpinInternal();
        private void PlaySoundSpinInternal()
        {
            if (global::Rush.Chocology.Economy.Config.Runtime.IsSound)
            {
                m_AudioSound.PlayOneShot(m_SoundManagerFields.Spin);
            }
        }
    }
}
