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
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
using BsplabsMobileAds;

namespace Rush.Chocology.Gameplay
{
    [UnityEngine.Scripting.APIUpdating.MovedFrom(true, "", "Assembly-CSharp", "WinPopup2")]
    public class WinPopup2 : MonoBehaviour
    {
        [global::System.Serializable]
        private sealed class WinPopup2Field
        {
            [UnityEngine.Serialization.FormerlySerializedAs("listStars")]
            [UnityEngine.SerializeField]
            private List<GameObject> m_ListStars;
            public global::System.Collections.Generic.List<global::UnityEngine.GameObject> ListStars { get => m_ListStars; set => m_ListStars = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("bgStars")]
            [UnityEngine.SerializeField]
            private GameObject m_BgStars;
            public global::UnityEngine.GameObject BgStars { get => m_BgStars; set => m_BgStars = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("popupReward")]
            [UnityEngine.SerializeField]
            private BBUIView m_PopupReward;
            public global::BBUIView PopupReward { get => m_PopupReward; set => m_PopupReward = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("sliderReward")]
            [UnityEngine.SerializeField]
            private Slider m_SliderReward;
            public global::UnityEngine.UI.Slider SliderReward { get => m_SliderReward; set => m_SliderReward = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("btnClaim")]
            [UnityEngine.SerializeField]
            private BBUIButton m_BtnClaim;
            public global::BBUIButton BtnClaim { get => m_BtnClaim; set => m_BtnClaim = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("txtClaimCoin")]
            [UnityEngine.SerializeField]
            private Text m_TxtClaimCoin;
            public global::UnityEngine.UI.Text TxtClaimCoin { get => m_TxtClaimCoin; set => m_TxtClaimCoin = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("btnClaimxReward")]
            [UnityEngine.SerializeField]
            private BBUIButton m_BtnClaimxReward;
            public global::BBUIButton BtnClaimxReward { get => m_BtnClaimxReward; set => m_BtnClaimxReward = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("txtClaimxRewardCoin")]
            [UnityEngine.SerializeField]
            private Text m_TxtClaimxRewardCoin;
            public global::UnityEngine.UI.Text TxtClaimxRewardCoin { get => m_TxtClaimxRewardCoin; set => m_TxtClaimxRewardCoin = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("popupAction")]
            [UnityEngine.SerializeField]
            private BBUIView m_PopupAction;
            public global::BBUIView PopupAction { get => m_PopupAction; set => m_PopupAction = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("btnNextLevel")]
            [UnityEngine.SerializeField]
            private BBUIButton m_BtnNextLevel;
            public global::BBUIButton BtnNextLevel { get => m_BtnNextLevel; set => m_BtnNextLevel = value; }

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
        private WinPopup2Field m_WinPopup2Fields = new WinPopup2Field();
        private static global::Rush.Chocology.Gameplay.WinPopup2 s_Instance;
        public static global::Rush.Chocology.Gameplay.WinPopup2 Instance { get => s_Instance; set => s_Instance = value; }
        public global::System.Collections.Generic.List<global::UnityEngine.GameObject> ListStars { get => m_WinPopup2Fields.ListStars; set => m_WinPopup2Fields.ListStars = value; }
        public global::UnityEngine.GameObject BgStars { get => m_WinPopup2Fields.BgStars; set => m_WinPopup2Fields.BgStars = value; }
        public global::BBUIView PopupReward { get => m_WinPopup2Fields.PopupReward; set => m_WinPopup2Fields.PopupReward = value; }
        public global::UnityEngine.UI.Slider SliderReward { get => m_WinPopup2Fields.SliderReward; set => m_WinPopup2Fields.SliderReward = value; }

        private int m_XReward = 2;
        public global::BBUIButton BtnClaim { get => m_WinPopup2Fields.BtnClaim; set => m_WinPopup2Fields.BtnClaim = value; }
        public global::UnityEngine.UI.Text TxtClaimCoin { get => m_WinPopup2Fields.TxtClaimCoin; set => m_WinPopup2Fields.TxtClaimCoin = value; }
        public global::BBUIButton BtnClaimxReward { get => m_WinPopup2Fields.BtnClaimxReward; set => m_WinPopup2Fields.BtnClaimxReward = value; }
        public global::UnityEngine.UI.Text TxtClaimxRewardCoin { get => m_WinPopup2Fields.TxtClaimxRewardCoin; set => m_WinPopup2Fields.TxtClaimxRewardCoin = value; }
        public global::BBUIView PopupAction { get => m_WinPopup2Fields.PopupAction; set => m_WinPopup2Fields.PopupAction = value; }
        public global::BBUIButton BtnNextLevel { get => m_WinPopup2Fields.BtnNextLevel; set => m_WinPopup2Fields.BtnNextLevel = value; }
        public global::BBUIButton BtnHome { get => m_WinPopup2Fields.BtnHome; set => m_WinPopup2Fields.BtnHome = value; }
        public global::UnityEngine.GameObject LockGroup { get => m_WinPopup2Fields.LockGroup; set => m_WinPopup2Fields.LockGroup = value; }

        private void Awake()
        {
            s_Instance = this;
        }

        // Start is called before the first frame update
        void Start()
        {
            m_WinPopup2Fields.PopupReward.ShowBehavior.onCallback_Completed.AddListener(PopupRewardShowViewFinished);
            // popupReward.HideBehavior.onCallback_Completed.AddListener(PopupReward_HideView_Finished);
            //popupAction.ShowBehavior.onCallback_Completed.AddListener(PopupAction_ShowView_Finished);
            //popupAction.HideBehavior.onCallback_Completed.AddListener(PopupAction_HideView_Finished);
            //btnClaim.OnPointerClickCallBack_Completed.AddListener(TouchClaim);
            m_WinPopup2Fields.BtnClaimxReward.OnPointerClickCallBack_Completed.AddListener(TouchClaimxReward);
            m_WinPopup2Fields.BtnClaimxReward.OnPointerClickCallBack_Start.AddListener(TouchClaimxRewardStart);
            m_WinPopup2Fields.BtnNextLevel.OnPointerClickCallBack_Completed.AddListener(TouchNextLevel);
            m_WinPopup2Fields.BtnHome.OnPointerClickCallBack_Completed.AddListener(TouchHome);
        }

        private void OnDestroy()
        {
            m_WinPopup2Fields.PopupReward.ShowBehavior.onCallback_Completed.RemoveAllListeners();
            m_WinPopup2Fields.PopupReward.HideBehavior.onCallback_Completed.RemoveAllListeners();
            m_WinPopup2Fields.PopupAction.ShowBehavior.onCallback_Completed.RemoveAllListeners();
            m_WinPopup2Fields.PopupAction.HideBehavior.onCallback_Completed.RemoveAllListeners();
            m_WinPopup2Fields.BtnClaim.OnPointerClickCallBack_Completed.RemoveAllListeners();
            m_WinPopup2Fields.BtnClaimxReward.OnPointerClickCallBack_Completed.RemoveAllListeners();
            m_WinPopup2Fields.BtnClaimxReward.OnPointerClickCallBack_Start.RemoveAllListeners();
            m_WinPopup2Fields.BtnNextLevel.OnPointerClickCallBack_Completed.RemoveAllListeners();
            m_WinPopup2Fields.BtnHome.OnPointerClickCallBack_Completed.RemoveAllListeners();
        // AdmobManager.instance.HideBannerAd();
        }

        // Update is called once per frame
        void Update()
        {
        }

        private int m_CountStar;
        private int m_CoinValue;
        private int m_AddStar;
        private int m_Level;
        public void ShowWinPopup(int _level, int _countStar, int _coinValue) => ShowWinPopupInternal(_level, _countStar, _coinValue);
        private void ShowWinPopupInternal(int _level, int _countStar, int _coinValue)
        {
            m_Level = _level;
            m_CountStar = _countStar;
            if (m_CountStar == 3)
            {
                m_CoinValue = 5;
            }

            if (m_CountStar == 2)
            {
                m_CoinValue = 3;
            }

            if (m_CountStar == 1)
            {
                m_CoinValue = 2;
            }

            //        Debug.Log("coinValue " + coinValue);
            m_XReward = 2;
            if (_level < 2)
            {
            //AdmobManager.instance.HideBannerAd();
            }
            else
            {
            // AdmobManager.instance.Request_Banner();
            }

            m_AddStar = m_CountStar - global::Rush.Chocology.Economy.Config.Runtime.LevelStar(global::Rush.Chocology.Economy.Config.Runtime.CurrSelectLevel);
            global::Rush.Chocology.Economy.Config.Runtime.SetLevelStar(_level, _countStar);
            global::Rush.Chocology.Economy.Config.Runtime.SetChestCountStar(global::Rush.Chocology.Economy.Config.Runtime.ChestCountStar + m_AddStar);
            m_WinPopup2Fields.TxtClaimCoin.text = $"+{(m_CoinValue)}";
            m_WinPopup2Fields.TxtClaimxRewardCoin.text = $"+{(m_CoinValue * m_XReward)}";
            ShowViews();
        }

        private void ShowViews()
        {
            gameObject.SetActive(true);
            m_WinPopup2Fields.LockGroup.SetActive(true);
            m_WinPopup2Fields.PopupReward.gameObject.SetActive(false);
            m_WinPopup2Fields.BtnClaim.gameObject.SetActive(false);
            m_WinPopup2Fields.BtnClaimxReward.gameObject.SetActive(false);
            m_WinPopup2Fields.PopupAction.gameObject.SetActive(false);
            m_WinPopup2Fields.BtnNextLevel.gameObject.SetActive(false);
            m_WinPopup2Fields.BtnHome.gameObject.SetActive(false);
            // bgStars.SetActive(false);
            for (int i = 0; i < m_WinPopup2Fields.ListStars.Count; i++)
            {
                m_WinPopup2Fields.ListStars[i].gameObject.SetActive(false);
            }

            m_WinPopup2Fields.SliderReward.value = 0f;
            StartCoroutine(ShowViewsIEnumerator());
        }

        private IEnumerator ShowViewsIEnumerator()
        {
            yield return new WaitForSeconds(0.1f);
            m_WinPopup2Fields.PopupReward.gameObject.SetActive(true);
            global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::BBUIView>(m_WinPopup2Fields.PopupReward).ShowView();
            yield return new WaitForSeconds(0.4f);
            if (m_CountStar >= 1)
            {
                global::Rush.Chocology.Audio.SoundManager.Instance.PlaySoundWin();
                m_WinPopup2Fields.ListStars[0].gameObject.SetActive(true);
                global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::BBUIView>(m_WinPopup2Fields.ListStars[0]).ShowView();
            }

            if (m_CountStar >= 2)
            {
                yield return new WaitForSeconds(0.1f);
                global::Rush.Chocology.Audio.SoundManager.Instance.PlaySoundWin();
                m_WinPopup2Fields.ListStars[1].gameObject.SetActive(true);
                global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::BBUIView>(m_WinPopup2Fields.ListStars[1]).ShowView();
            }

            if (m_CountStar >= 3)
            {
                yield return new WaitForSeconds(0.1f);
                global::Rush.Chocology.Audio.SoundManager.Instance.PlaySoundWin();
                m_WinPopup2Fields.ListStars[2].gameObject.SetActive(true);
                global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::BBUIView>(m_WinPopup2Fields.ListStars[2]).ShowView();
            }

            yield return new WaitForSeconds(0.1f);
            m_WinPopup2Fields.BtnClaimxReward.gameObject.SetActive(true);
            global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::BBUIView>(m_WinPopup2Fields.BtnClaimxReward).ShowView();
            InitSliderReward();
            m_WinPopup2Fields.LockGroup.SetActive(false);
            //yield return new WaitForSeconds(0.3f);
            //btnClaim.gameObject.SetActive(true);
            //btnClaim.GetComponent<BBUIView>().ShowView();
            yield return new WaitForSeconds(0.1f);
            m_WinPopup2Fields.BtnNextLevel.gameObject.SetActive(true);
            global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::BBUIView>(m_WinPopup2Fields.BtnNextLevel).ShowView();
            m_WinPopup2Fields.LockGroup.SetActive(false);
            yield return new WaitForSeconds(0.1f);
            m_WinPopup2Fields.BtnHome.gameObject.SetActive(true);
            global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::BBUIView>(m_WinPopup2Fields.BtnHome).ShowView();
        }

        private void InitSliderReward()
        {
            m_WinPopup2Fields.SliderReward.DOValue(1f, 1f).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo).OnUpdate(() =>
            {
                SliderUpdateValue();
            });
        }

        private void SliderUpdateValue()
        {
            if (m_WinPopup2Fields.SliderReward.value < 0.114f)
            {
                m_XReward = 2;
            }
            else if (m_WinPopup2Fields.SliderReward.value < 0.24f)
            {
                m_XReward = 3;
            }
            else if (m_WinPopup2Fields.SliderReward.value < 0.4f)
            {
                m_XReward = 4;
            }
            else if (m_WinPopup2Fields.SliderReward.value < 0.6f)
            {
                m_XReward = 5;
            }
            else if (m_WinPopup2Fields.SliderReward.value < 0.76f)
            {
                m_XReward = 4;
            }
            else if (m_WinPopup2Fields.SliderReward.value < 0.886f)
            {
                m_XReward = 3;
            }
            else
            {
                m_XReward = 2;
            }

            m_WinPopup2Fields.TxtClaimxRewardCoin.text = $"+{(m_CoinValue * m_XReward)}";
        }

        private void PopupRewardShowViewFinished()
        {
        }

        private void PopupRewardHideViewFinished()
        {
            StartCoroutine(OpenPopupAction());
        }

        private void PopupActionShowViewFinished()
        {
        }

        private void PopupActionHideViewFinished()
        {
        }

        private void TouchClaim()
        {
            m_WinPopup2Fields.LockGroup.SetActive(true);
            global::Rush.Chocology.Economy.Config.Runtime.SetCoin(global::Rush.Chocology.Economy.Config.Runtime.CurrCoin + m_CoinValue);
            DOTween.Kill(m_WinPopup2Fields.SliderReward);
            StartCoroutine(ClaimFinished());
        }

        private void TouchClaimxRewardStart()
        {
            m_WinPopup2Fields.LockGroup.SetActive(true);
            DOTween.Kill(m_WinPopup2Fields.SliderReward);
        }

        private void TouchClaimxReward()
        {
            m_WinPopup2Fields.LockGroup.SetActive(true);
            DOTween.Kill(m_WinPopup2Fields.SliderReward);
            if (BspLabsAdsMobile.Instance.IsRewardVideoAvailable())
            {
                new global::Rush.Integrations.Ads.RewardedAdRequest().Show(CompleteMethod);
                Debug.Log("Bonus Level Clear Reward Claimed");
                global::Rush.Chocology.Integrations.Analytics.AdjustManager.instance.BonusLevelClearRewardClaimed();
            }
            else
            {
                m_WinPopup2Fields.LockGroup.gameObject.SetActive(false);
                global::Rush.Chocology.Notifications.NotificationPopup.Instance.AddNotification("No Video Available!");
            }
        }

        private void CompleteMethod(bool completed)
        {
            if (completed == true)
            {
                global::Rush.Chocology.Economy.Config.Runtime.SetCoin(global::Rush.Chocology.Economy.Config.Runtime.CurrCoin + m_CoinValue * m_XReward);
                StartCoroutine(ClaimFinished());
            }
            else
            {
                m_WinPopup2Fields.LockGroup.SetActive(false);
                global::Rush.Chocology.Notifications.NotificationPopup.Instance.AddNotification("Claim Reward Fail!");
            }
        }

        private IEnumerator ClaimFinished()
        {
            yield return new WaitForSeconds(0.2f);
            //popupReward.HideView();
            m_WinPopup2Fields.LockGroup.SetActive(false);
            m_WinPopup2Fields.BtnClaimxReward.gameObject.SetActive(false);
        }

        private IEnumerator OpenPopupAction()
        {
            m_WinPopup2Fields.LockGroup.SetActive(true);
            m_WinPopup2Fields.PopupAction.gameObject.SetActive(true);
            m_WinPopup2Fields.PopupAction.ShowView();
            yield return new WaitForSeconds(0.1f);
            m_WinPopup2Fields.BtnNextLevel.gameObject.SetActive(true);
            global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::BBUIView>(m_WinPopup2Fields.BtnNextLevel).ShowView();
            m_WinPopup2Fields.LockGroup.SetActive(false);
            yield return new WaitForSeconds(2f);
            m_WinPopup2Fields.BtnHome.gameObject.SetActive(true);
            global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::BBUIView>(m_WinPopup2Fields.BtnHome).ShowView();
        }

        private void TouchNextLevel()
        {
            m_WinPopup2Fields.LockGroup.gameObject.SetActive(true);
            {
                global::Rush.Chocology.Gameplay.GamePlayManager.Instance.SetNextGame();
                global::Rush.Chocology.Integrations.Analytics.AdjustManager.instance.NextLevel();
            }
        }

        private void TouchHome()
        {
            m_WinPopup2Fields.LockGroup.gameObject.SetActive(true);
            {
                SceneManager.LoadScene("Menu");
                global::Rush.Chocology.Integrations.Analytics.AdjustManager.instance.BackToHome();
            }
        }
    }
}
