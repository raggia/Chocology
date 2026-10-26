/*
 * Created on 2022
 *
 * Copyright (c) 2022 dotmobstudio
 * Support : dotmobstudio@gmail.com
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using BsplabsMobileAds;

namespace Rush.Chocology.Gameplay
{
    [UnityEngine.Scripting.APIUpdating.MovedFrom(true, "", "Assembly-CSharp", "LosePopup2")]
    public class LosePopup2 : MonoBehaviour
    {
        [global::System.Serializable]
        private sealed class LosePopup2Field
        {
            [UnityEngine.Serialization.FormerlySerializedAs("popupReward")]
            [UnityEngine.SerializeField]
            private BBUIView m_PopupReward;
            public global::BBUIView PopupReward { get => m_PopupReward; set => m_PopupReward = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("txtCleanAllBoxs")]
            [UnityEngine.SerializeField]
            private RectTransform m_TxtCleanAllBoxs;
            public global::UnityEngine.RectTransform TxtCleanAllBoxs { get => m_TxtCleanAllBoxs; set => m_TxtCleanAllBoxs = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("btnContinue_Video")]
            [UnityEngine.SerializeField]
            private BBUIButton m_BtnContinueVideo;
            public global::BBUIButton BtnContinueVideo { get => m_BtnContinueVideo; set => m_BtnContinueVideo = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("btnContinue_Coin")]
            [UnityEngine.SerializeField]
            private BBUIButton m_BtnContinueCoin;
            public global::BBUIButton BtnContinueCoin { get => m_BtnContinueCoin; set => m_BtnContinueCoin = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("btnNoThanks")]
            [UnityEngine.SerializeField]
            private BBUIButton m_BtnNoThanks;
            public global::BBUIButton BtnNoThanks { get => m_BtnNoThanks; set => m_BtnNoThanks = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("popupAction")]
            [UnityEngine.SerializeField]
            private BBUIView m_PopupAction;
            public global::BBUIView PopupAction { get => m_PopupAction; set => m_PopupAction = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("btnRestart")]
            [UnityEngine.SerializeField]
            private BBUIButton m_BtnRestart;
            public global::BBUIButton BtnRestart { get => m_BtnRestart; set => m_BtnRestart = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("btnHome")]
            [UnityEngine.SerializeField]
            private BBUIButton m_BtnHome;
            public global::BBUIButton BtnHome { get => m_BtnHome; set => m_BtnHome = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("lockGroup")]
            [UnityEngine.SerializeField]
            private GameObject m_LockGroup;
            public global::UnityEngine.GameObject LockGroup { get => m_LockGroup; set => m_LockGroup = value; }
        }

        [global::UnityEngine.SerializeField]
        private LosePopup2Field m_LosePopup2Fields = new LosePopup2Field();
        private static global::Rush.Chocology.Gameplay.LosePopup2 s_Instance;
        public static global::Rush.Chocology.Gameplay.LosePopup2 Instance { get => s_Instance; set => s_Instance = value; }
        public global::BBUIView PopupReward { get => m_LosePopup2Fields.PopupReward; set => m_LosePopup2Fields.PopupReward = value; }
        public global::UnityEngine.RectTransform TxtCleanAllBoxs { get => m_LosePopup2Fields.TxtCleanAllBoxs; set => m_LosePopup2Fields.TxtCleanAllBoxs = value; }
        public global::BBUIButton BtnContinueVideo { get => m_LosePopup2Fields.BtnContinueVideo; set => m_LosePopup2Fields.BtnContinueVideo = value; }
        public global::BBUIButton BtnContinueCoin { get => m_LosePopup2Fields.BtnContinueCoin; set => m_LosePopup2Fields.BtnContinueCoin = value; }
        public global::BBUIButton BtnNoThanks { get => m_LosePopup2Fields.BtnNoThanks; set => m_LosePopup2Fields.BtnNoThanks = value; }
        public global::BBUIView PopupAction { get => m_LosePopup2Fields.PopupAction; set => m_LosePopup2Fields.PopupAction = value; }
        public global::BBUIButton BtnRestart { get => m_LosePopup2Fields.BtnRestart; set => m_LosePopup2Fields.BtnRestart = value; }
        public global::BBUIButton BtnHome { get => m_LosePopup2Fields.BtnHome; set => m_LosePopup2Fields.BtnHome = value; }
        public global::UnityEngine.GameObject LockGroup { get => m_LosePopup2Fields.LockGroup; set => m_LosePopup2Fields.LockGroup = value; }

        enum REWARD_ACTION
        {
            REVIVE,
            CLOSE
        }

        private global::Rush.Chocology.Gameplay.LosePopup2.REWARD_ACTION m_RewardAction = global::Rush.Chocology.Gameplay.LosePopup2.REWARD_ACTION.CLOSE;
        private void Awake()
        {
            s_Instance = this;
        }

        void Start()
        {
            m_LosePopup2Fields.PopupReward.ShowBehavior.onCallback_Completed.AddListener(PopupRewardShowViewFinished);
            m_LosePopup2Fields.PopupReward.HideBehavior.onCallback_Completed.AddListener(PopupRewardHideViewFinished);
            m_LosePopup2Fields.PopupAction.ShowBehavior.onCallback_Completed.AddListener(PopupActionShowViewFinished);
            m_LosePopup2Fields.PopupAction.HideBehavior.onCallback_Completed.AddListener(PopupActionHideViewFinished);
            m_LosePopup2Fields.BtnContinueVideo.OnPointerClickCallBack_Completed.AddListener(TouchContinueVideo);
            m_LosePopup2Fields.BtnContinueCoin.OnPointerClickCallBack_Completed.AddListener(TouchContinueCoin);
            m_LosePopup2Fields.BtnNoThanks.OnPointerClickCallBack_Completed.AddListener(TouchNoThank);
            m_LosePopup2Fields.BtnRestart.OnPointerClickCallBack_Completed.AddListener(TouchRestart);
            m_LosePopup2Fields.BtnHome.OnPointerClickCallBack_Completed.AddListener(TouchHome);
            global::Rush.Chocology.Economy.Config.Runtime.InterstitialAdCountLose++;
            Debug.Log("COUNT LOSE = " + global::Rush.Chocology.Economy.Config.Runtime.InterstitialAdCountLose);
            Debug.Log("Level Failed");
            global::Rush.Chocology.Integrations.Analytics.AdjustManager.instance.LevelFailed();
            if (global::Rush.Chocology.Economy.Config.Runtime.InterstitialAdCountLose == 2)
            {
                global::Rush.Chocology.Economy.Config.Runtime.InterstitialAdCountLose = 0;
                BspLabsAdsMobile.Instance.ShowInterstitial();
            }
        }

        private int m_Level;
        private bool m_IsRevive;
        public void ShowLosePopup(int _level, bool _isRevive) => ShowLosePopupInternal(_level, _isRevive);
        private void ShowLosePopupInternal(int _level, bool _isRevive)
        {
            if (_level < 2)
            {
            // AdmobManager.instance.HideBannerAd();
            }
            else
            {
            // AdmobManager.instance.Request_Banner();
            }

            global::Rush.Chocology.Audio.SoundManager.Instance.PlaySoundGameOver();
            m_Level = _level;
            m_IsRevive = _isRevive;
            gameObject.SetActive(true);
            m_LosePopup2Fields.LockGroup.SetActive(true);
            m_LosePopup2Fields.PopupReward.gameObject.SetActive(false);
            m_LosePopup2Fields.BtnContinueVideo.gameObject.SetActive(false);
            m_LosePopup2Fields.BtnContinueCoin.gameObject.SetActive(false);
            m_LosePopup2Fields.BtnNoThanks.gameObject.SetActive(false);
            m_LosePopup2Fields.PopupAction.gameObject.SetActive(false);
            m_LosePopup2Fields.BtnRestart.gameObject.SetActive(false);
            m_LosePopup2Fields.BtnHome.gameObject.SetActive(false);
            if (m_IsRevive)
            {
                StartCoroutine(OpenPopupAction());
            }
            else
            {
                ShowViews();
            }
        }

        private void ShowViews()
        {
            StartCoroutine(ShowViewsIEnumerator());
        }

        private IEnumerator ShowViewsIEnumerator()
        {
            yield return new WaitForSeconds(0.1f);
            m_LosePopup2Fields.PopupReward.gameObject.SetActive(true);
            global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::BBUIView>(m_LosePopup2Fields.PopupReward).ShowView();
            if (global::Rush.Chocology.Economy.Config.Runtime.CheckDailyFreeRevive())
            {
                yield return new WaitForSeconds(0.1f);
                m_LosePopup2Fields.BtnContinueVideo.gameObject.SetActive(true);
                global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::BBUIView>(m_LosePopup2Fields.BtnContinueVideo).ShowView();
            // txtCleanAllBoxs.DOAnchorPosY(95f, 0.2f);
            }
            else
            {
            // txtCleanAllBoxs.DOAnchorPosY(-44f, 0.2f);
            }

            yield return new WaitForSeconds(0.1f);
            m_LosePopup2Fields.BtnContinueCoin.gameObject.SetActive(true);
            global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::BBUIView>(m_LosePopup2Fields.BtnContinueCoin).ShowView();
            m_LosePopup2Fields.LockGroup.SetActive(false);
            yield return new WaitForSeconds(2.5f);
            m_LosePopup2Fields.BtnNoThanks.gameObject.SetActive(true);
            global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::BBUIView>(m_LosePopup2Fields.BtnNoThanks).ShowView();
        }

        // Update is called once per frame
        void Update()
        {
        }

        private void PopupRewardShowViewFinished()
        {
        }

        private void PopupRewardHideViewFinished()
        {
            //Debug.Log("PopupReward_HideView_FinishedPopupReward_HideView_Finished");
            if (m_RewardAction == global::Rush.Chocology.Gameplay.LosePopup2.REWARD_ACTION.REVIVE)
            {
                gameObject.SetActive(false);
            }
            else if (m_RewardAction == global::Rush.Chocology.Gameplay.LosePopup2.REWARD_ACTION.CLOSE)
            {
                StartCoroutine(OpenPopupAction());
            }
        }

        private void PopupActionShowViewFinished()
        {
        }

        private void PopupActionHideViewFinished()
        {
        }

        private void TouchContinueVideo()
        {
            m_LosePopup2Fields.LockGroup.gameObject.SetActive(true);
            if (BspLabsAdsMobile.Instance.IsRewardVideoAvailable())
            {
                new global::Rush.Integrations.Ads.RewardedAdRequest().Show(CompleteMethod);
                global::Rush.Chocology.Integrations.Analytics.AdjustManager.instance.ContinueWithAds();
            }
            else
            {
                m_LosePopup2Fields.LockGroup.gameObject.SetActive(false);
                global::Rush.Chocology.Notifications.NotificationPopup.Instance.AddNotification("No Video Available!");
            }
        }

        private void CompleteMethod(bool completed)
        {
            if (completed == true)
            {
                // Debug.Log("111111111111111111111111111");
                m_RewardAction = global::Rush.Chocology.Gameplay.LosePopup2.REWARD_ACTION.REVIVE;
                m_LosePopup2Fields.PopupReward.HideView();
                global::Rush.Chocology.Gameplay.GameLevelManager.Instance.Revive();
                global::Rush.Chocology.Gameplay.GamePlayManager.Instance.SetReviveSuccess();
                global::Rush.Chocology.Economy.Config.Runtime.SetDailyFreeRevive();
            }
            else
            {
                m_LosePopup2Fields.LockGroup.gameObject.SetActive(false);
                global::Rush.Chocology.Notifications.NotificationPopup.Instance.AddNotification("Revive Fail!");
            }
        }

        private void TouchContinueCoin()
        {
            if (global::Rush.Chocology.Economy.Config.Runtime.CurrCoin >= global::Rush.Chocology.Economy.Config.PRICE_COIN_REVIVE)
            {
                global::Rush.Chocology.Economy.Config.Runtime.SetCoin(global::Rush.Chocology.Economy.Config.Runtime.CurrCoin - global::Rush.Chocology.Economy.Config.PRICE_COIN_REVIVE);
                m_RewardAction = global::Rush.Chocology.Gameplay.LosePopup2.REWARD_ACTION.REVIVE;
                m_LosePopup2Fields.PopupReward.HideView();
                global::Rush.Chocology.Gameplay.GameLevelManager.Instance.Revive();
                global::Rush.Chocology.Integrations.Analytics.AdjustManager.instance.ContinueWith100Coin();
                global::Rush.Chocology.Gameplay.GamePlayManager.Instance.SetReviveSuccess();
            }
            else
            {
                global::Rush.Chocology.Gameplay.GamePlayManager.Instance.OpenShopPopup();
            }
        }

        private void TouchNoThank()
        {
            m_LosePopup2Fields.LockGroup.SetActive(true);
            m_RewardAction = global::Rush.Chocology.Gameplay.LosePopup2.REWARD_ACTION.CLOSE;
            m_LosePopup2Fields.PopupReward.HideView();
        }

        private IEnumerator OpenPopupAction()
        {
            m_LosePopup2Fields.LockGroup.SetActive(true);
            m_LosePopup2Fields.PopupAction.gameObject.SetActive(true);
            m_LosePopup2Fields.PopupAction.ShowView();
            yield return new WaitForSeconds(0.1f);
            m_LosePopup2Fields.BtnRestart.gameObject.SetActive(true);
            global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::BBUIView>(m_LosePopup2Fields.BtnRestart).ShowView();
            m_LosePopup2Fields.LockGroup.SetActive(false);
            yield return new WaitForSeconds(0.1f);
            m_LosePopup2Fields.BtnHome.gameObject.SetActive(true);
            global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::BBUIView>(m_LosePopup2Fields.BtnHome).ShowView();
        }

        private void TouchHome()
        {
            m_LosePopup2Fields.LockGroup.gameObject.SetActive(true);
            global::Rush.Chocology.Integrations.Analytics.AdjustManager.instance.BackToHome();
            SceneManager.LoadScene("Menu");
        }

        private void TouchRestart()
        {
            m_LosePopup2Fields.LockGroup.gameObject.SetActive(true);
            global::Rush.Chocology.Integrations.Analytics.AdjustManager.instance.RestartGame();
            global::Rush.Chocology.Gameplay.GamePlayManager.Instance.SetReplayGame();
        }
    }
}
