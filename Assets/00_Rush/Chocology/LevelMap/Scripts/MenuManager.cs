/*
 * Created on 2022
 *
 * Copyright (c) 2022 dotmobstudio
 * Support : dotmobstudio@gmail.com
 */
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Rush.Chocology.LevelMap
{
    [UnityEngine.Scripting.APIUpdating.MovedFrom(true, "", "Assembly-CSharp", "MenuManager")]
    public class MenuManager : MonoBehaviour
    {
        [global::System.Serializable]
        private sealed class MenuManagerField
        {
            [UnityEngine.Serialization.FormerlySerializedAs("canvasScaler")]
            [UnityEngine.SerializeField]
            private CanvasScaler m_CanvasScaler;
            public global::UnityEngine.UI.CanvasScaler CanvasScaler { get => m_CanvasScaler; set => m_CanvasScaler = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("btnSetting")]
            [UnityEngine.SerializeField]
            private BBUIButton m_BtnSetting;
            public global::BBUIButton BtnSetting { get => m_BtnSetting; set => m_BtnSetting = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("btnGift")]
            [UnityEngine.SerializeField]
            private BBUIButton m_BtnGift;
            public global::BBUIButton BtnGift { get => m_BtnGift; set => m_BtnGift = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("btnShop")]
            [UnityEngine.SerializeField]
            private BBUIButton m_BtnShop;
            public global::BBUIButton BtnShop { get => m_BtnShop; set => m_BtnShop = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("btnSpin")]
            [UnityEngine.SerializeField]
            private BBUIButton m_BtnSpin;
            public global::BBUIButton BtnSpin { get => m_BtnSpin; set => m_BtnSpin = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("btnLeaderboard")]
            [UnityEngine.SerializeField]
            private BBUIButton m_BtnLeaderboard;
            public global::BBUIButton BtnLeaderboard { get => m_BtnLeaderboard; set => m_BtnLeaderboard = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("btnPlay")]
            [UnityEngine.SerializeField]
            private BBUIButton m_BtnPlay;
            public global::BBUIButton BtnPlay { get => m_BtnPlay; set => m_BtnPlay = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("btnParty")]
            [UnityEngine.SerializeField]
            private BBUIButton m_BtnParty;
            public global::BBUIButton BtnParty { get => m_BtnParty; set => m_BtnParty = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("btnLevel")]
            [UnityEngine.SerializeField]
            private BBUIButton m_BtnLevel;
            public global::BBUIButton BtnLevel { get => m_BtnLevel; set => m_BtnLevel = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("txtLevel")]
            [UnityEngine.SerializeField]
            private Text m_TxtLevel;
            public global::UnityEngine.UI.Text TxtLevel { get => m_TxtLevel; set => m_TxtLevel = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("coinGroup")]
            [UnityEngine.SerializeField]
            private global::Rush.Chocology.Economy.Menu_CoinGroup m_CoinGroup;
            public global::Rush.Chocology.Economy.Menu_CoinGroup CoinGroup { get => m_CoinGroup; set => m_CoinGroup = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("btnRemoveAd")]
            [UnityEngine.SerializeField]
            private BBUIButton m_BtnRemoveAd;
            public global::BBUIButton BtnRemoveAd { get => m_BtnRemoveAd; set => m_BtnRemoveAd = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("btnChest")]
            [UnityEngine.SerializeField]
            private BBUIButton m_BtnChest;
            public global::BBUIButton BtnChest { get => m_BtnChest; set => m_BtnChest = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("logo")]
            [UnityEngine.SerializeField]
            private Image m_Logo;
            public global::UnityEngine.UI.Image Logo { get => m_Logo; set => m_Logo = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("lockGroup")]
            [UnityEngine.SerializeField]
            private GameObject m_LockGroup;
            public global::UnityEngine.GameObject LockGroup { get => m_LockGroup; set => m_LockGroup = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("mapMaker")]
            [UnityEngine.SerializeField]
            private Mkey.MapMaker m_MapMaker;
            public global::Mkey.MapMaker MapMaker { get => m_MapMaker; set => m_MapMaker = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("shopPopup")]
            [UnityEngine.SerializeField]
            private global::Rush.Chocology.Shop.ShopPopup2 m_ShopPopup;
            public global::Rush.Chocology.Shop.ShopPopup2 ShopPopup { get => m_ShopPopup; set => m_ShopPopup = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("spinPopup")]
            [UnityEngine.SerializeField]
            private global::Rush.Chocology.Rewards.SpinPopup m_SpinPopup;
            public global::Rush.Chocology.Rewards.SpinPopup SpinPopup { get => m_SpinPopup; set => m_SpinPopup = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("settingPopup")]
            [UnityEngine.SerializeField]
            private global::Rush.Chocology.Settings.SettingPopup m_SettingPopup;
            public global::Rush.Chocology.Settings.SettingPopup SettingPopup { get => m_SettingPopup; set => m_SettingPopup = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("ratePopup")]
            [UnityEngine.SerializeField]
            private global::Rush.Chocology.Settings.RatePopup m_RatePopup;
            public global::Rush.Chocology.Settings.RatePopup RatePopup { get => m_RatePopup; set => m_RatePopup = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("levelPopup")]
            [UnityEngine.SerializeField]
            private global::Rush.Chocology.LevelMap.LevelPopup m_LevelPopup;
            public global::Rush.Chocology.LevelMap.LevelPopup LevelPopup { get => m_LevelPopup; set => m_LevelPopup = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("rewardPopup")]
            [UnityEngine.SerializeField]
            private global::Rush.Chocology.Economy.RewardPopup m_RewardPopup;
            public global::Rush.Chocology.Economy.RewardPopup RewardPopup { get => m_RewardPopup; set => m_RewardPopup = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("chestPopup")]
            [UnityEngine.SerializeField]
            private global::Rush.Chocology.Rewards.ChestPopup m_ChestPopup;
            public global::Rush.Chocology.Rewards.ChestPopup ChestPopup { get => m_ChestPopup; set => m_ChestPopup = value; }
        }

        [global::UnityEngine.SerializeField]
        private MenuManagerField m_MenuManagerFields = new MenuManagerField();
        private static global::Rush.Chocology.LevelMap.MenuManager s_Instance;
        public static global::Rush.Chocology.LevelMap.MenuManager Instance { get => s_Instance; set => s_Instance = value; }
        public global::UnityEngine.UI.CanvasScaler CanvasScaler { get => m_MenuManagerFields.CanvasScaler; set => m_MenuManagerFields.CanvasScaler = value; }
        public global::BBUIButton BtnSetting { get => m_MenuManagerFields.BtnSetting; set => m_MenuManagerFields.BtnSetting = value; }
        public global::BBUIButton BtnGift { get => m_MenuManagerFields.BtnGift; set => m_MenuManagerFields.BtnGift = value; }
        public global::BBUIButton BtnShop { get => m_MenuManagerFields.BtnShop; set => m_MenuManagerFields.BtnShop = value; }
        public global::BBUIButton BtnSpin { get => m_MenuManagerFields.BtnSpin; set => m_MenuManagerFields.BtnSpin = value; }
        public global::BBUIButton BtnLeaderboard { get => m_MenuManagerFields.BtnLeaderboard; set => m_MenuManagerFields.BtnLeaderboard = value; }
        public global::BBUIButton BtnPlay { get => m_MenuManagerFields.BtnPlay; set => m_MenuManagerFields.BtnPlay = value; }
        public global::BBUIButton BtnParty { get => m_MenuManagerFields.BtnParty; set => m_MenuManagerFields.BtnParty = value; }
        public global::BBUIButton BtnLevel { get => m_MenuManagerFields.BtnLevel; set => m_MenuManagerFields.BtnLevel = value; }
        public global::UnityEngine.UI.Text TxtLevel { get => m_MenuManagerFields.TxtLevel; set => m_MenuManagerFields.TxtLevel = value; }
        public global::Rush.Chocology.Economy.Menu_CoinGroup CoinGroup { get => m_MenuManagerFields.CoinGroup; set => m_MenuManagerFields.CoinGroup = value; }
        public global::BBUIButton BtnRemoveAd { get => m_MenuManagerFields.BtnRemoveAd; set => m_MenuManagerFields.BtnRemoveAd = value; }
        public global::BBUIButton BtnChest { get => m_MenuManagerFields.BtnChest; set => m_MenuManagerFields.BtnChest = value; }
        public global::UnityEngine.UI.Image Logo { get => m_MenuManagerFields.Logo; set => m_MenuManagerFields.Logo = value; }
        public global::UnityEngine.GameObject LockGroup { get => m_MenuManagerFields.LockGroup; set => m_MenuManagerFields.LockGroup = value; }
        public global::Mkey.MapMaker MapMaker { get => m_MenuManagerFields.MapMaker; set => m_MenuManagerFields.MapMaker = value; }

        private void Awake()
        {
            s_Instance = this;
        // if (Config.CheckWideScreen())
        // {
        //     canvasScaler.matchWidthOrHeight = 0.5f;
        // }
        }

        // Start is called before the first frame update
        void Start()
        {
            // Debug.Log("Chay vao day dau tien ne");
            m_MenuManagerFields.BtnSetting.OnPointerClickCallBack_Completed.AddListener(TouchSettingInternal);
            //btnGift.OnPointerClickCallBack_Completed.AddListener(TouchGift);
            m_MenuManagerFields.BtnShop.OnPointerClickCallBack_Completed.AddListener(TouchShopInternal);
            m_MenuManagerFields.BtnPlay.OnPointerClickCallBack_Completed.AddListener(TouchPlayInternal);
            m_MenuManagerFields.BtnParty.OnPointerClickCallBack_Completed.AddListener(TouchPartyInternal);
            m_MenuManagerFields.BtnLevel.OnPointerClickCallBack_Completed.AddListener(TouchLevelInternal);
            m_MenuManagerFields.BtnSpin.OnPointerClickCallBack_Completed.AddListener(TouchSpinInternal);
            m_MenuManagerFields.TxtLevel.text = $"Level: {(global::Rush.Chocology.Economy.Config.Runtime.CurrLevel)}";
            InitViewsInternal();
        // if (Config.isShowStarterPack)
        // {
        //     startPackPopup.ShowStartPack();
        //     Config.isShowStarterPack = false;
        // }
        //        AdmobManager.instance.Request_Banner();
        }

        // Update is called once per frame
        void Update()
        {
        }

        public void TouchSetting() => TouchSettingInternal();
        private void TouchSettingInternal()
        {
            OpenSettingPopupInternal();
        }

        public void TouchGift() => TouchGiftInternal();
        private void TouchGiftInternal()
        {
        //  startPackPopup.ShowStartPack();
        }

        public void SetBuyStarterPackSuccess() => SetBuyStarterPackSuccessInternal();
        private void SetBuyStarterPackSuccessInternal()
        {
            m_MenuManagerFields.BtnRemoveAd.gameObject.SetActive(!global::Rush.Chocology.Economy.Config.Runtime.RemoveAd);
            m_MenuManagerFields.BtnGift.gameObject.SetActive(!global::Rush.Chocology.Economy.Config.Runtime.ReadBuyIAP(global::Rush.Chocology.Economy.Config.IAP_ID.tilematch_starter_pack));
        }

        public void TouchShop() => TouchShopInternal();
        private void TouchShopInternal()
        {
            m_MenuManagerFields.ShopPopup.OpenPopup();
            global::Rush.Chocology.Integrations.Analytics.AdjustManager.instance.ShopOpen();
        }

        public void TouchSpin() => TouchSpinInternal();
        private void TouchSpinInternal()
        {
            m_MenuManagerFields.SpinPopup.OpenSpinPopup();
        }

        public void OpenShopCoin() => OpenShopCoinInternal();
        private void OpenShopCoinInternal()
        {
            m_MenuManagerFields.ShopPopup.OpenPopup();
        }

        public void CloseShopSucces() => CloseShopSuccesInternal();
        private void CloseShopSuccesInternal()
        {
            global::Rush.Chocology.Economy.Config.Runtime.GameState = global::Rush.Chocology.Economy.Config.GAME_STATE.PLAYING;
        }

        public void TouchPlay() => TouchPlayInternal();
        private void TouchPlayInternal()
        {
            //SceneManager.LoadScene("Play");
            HideViewInternal();
            Debug.Log("Click Play Game");
        //AdjustManager.instance.PlayGame();
        }

        private int m_CountHack = 0;
        public void TouchParty() => TouchPartyInternal();
        private void TouchPartyInternal()
        {
            m_CountHack++;
            if (m_CountHack == 10)
            {
                global::Rush.Chocology.Economy.Config.Runtime.IsHackMode = true;
            }
        }

        public void TouchLevel() => TouchLevelInternal();
        private void TouchLevelInternal()
        {
            OpenPopupLevelInternal();
        }

        public void InitViews() => InitViewsInternal();
        private void InitViewsInternal()
        {
            m_MenuManagerFields.LockGroup.gameObject.SetActive(false);
            m_MenuManagerFields.BtnSetting.gameObject.SetActive(false);
            //btnGift.gameObject.SetActive(false);
            m_MenuManagerFields.BtnShop.gameObject.SetActive(false);
            m_MenuManagerFields.CoinGroup.gameObject.SetActive(false);
            m_MenuManagerFields.BtnPlay.gameObject.SetActive(false);
            m_MenuManagerFields.BtnParty.gameObject.SetActive(false);
            m_MenuManagerFields.BtnLevel.gameObject.SetActive(false);
            m_MenuManagerFields.BtnChest.gameObject.SetActive(false);
            m_MenuManagerFields.BtnSpin.gameObject.SetActive(false);
            m_MenuManagerFields.BtnLeaderboard.gameObject.SetActive(false);
            m_MenuManagerFields.BtnRemoveAd.gameObject.SetActive(false);
            m_MenuManagerFields.Logo.gameObject.SetActive(false);
            InitViewsShowViewInternal();
            if (global::Rush.Chocology.Economy.Config.Runtime.CurrLevel > 1)
            {
            // startPackPopup.ShowStartPack();
            }
        }

        public void InitViewsShowView() => InitViewsShowViewInternal();
        private void InitViewsShowViewInternal()
        {
            Sequence sequenceShowView = DOTween.Sequence();
            sequenceShowView.InsertCallback(0.1f, () =>
            {
                global::Rush.Chocology.Audio.SoundManager.Instance.PlaySoundShowView();
                m_MenuManagerFields.BtnSetting.gameObject.SetActive(true);
                global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::BBUIView>(m_MenuManagerFields.BtnSetting).ShowView();
                m_MenuManagerFields.CoinGroup.gameObject.SetActive(true);
                global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::BBUIView>(m_MenuManagerFields.CoinGroup).ShowView();
            });
            sequenceShowView.InsertCallback(0.3f, () =>
            {
                m_MenuManagerFields.BtnShop.gameObject.SetActive(true);
                global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::BBUIView>(m_MenuManagerFields.BtnShop).ShowView();
                m_MenuManagerFields.BtnChest.gameObject.SetActive(true);
                global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::BBUIView>(m_MenuManagerFields.BtnChest).ShowView();
                m_MenuManagerFields.BtnSpin.gameObject.SetActive(true);
                global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::BBUIView>(m_MenuManagerFields.BtnSpin).ShowView();
                m_MenuManagerFields.BtnLeaderboard.gameObject.SetActive(true);
                global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::BBUIView>(m_MenuManagerFields.BtnLeaderboard).ShowView();
            });
            sequenceShowView.InsertCallback(1f, () =>
            {
                global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::Rush.Chocology.Rewards.StarChestButton>(m_MenuManagerFields.BtnChest).SetAnimation();
            });
            sequenceShowView.InsertCallback(0.4f, () =>
            {
                if (!global::Rush.Chocology.Economy.Config.Runtime.ReadBuyIAP(global::Rush.Chocology.Economy.Config.IAP_ID.tilematch_starter_pack))
                {
                //btnGift.gameObject.SetActive(true);
                //btnGift.GetComponent<BBUIView>().ShowView();
                }

                if (!global::Rush.Chocology.Economy.Config.Runtime.RemoveAd)
                {
                    // btnRemoveAd.gameObject.SetActive(true);
                    global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::BBUIView>( // btnRemoveAd.gameObject.SetActive(true);
                    m_MenuManagerFields.BtnRemoveAd).ShowView();
                }
            });
            sequenceShowView.InsertCallback(0.45f, () =>
            {
                m_MenuManagerFields.Logo.gameObject.SetActive(true);
                global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::BBUIView>(m_MenuManagerFields.Logo).ShowView();
            });
            sequenceShowView.InsertCallback(0.5f, () =>
            {
                m_MenuManagerFields.BtnLevel.gameObject.SetActive(true);
                global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::BBUIView>(m_MenuManagerFields.BtnLevel).ShowView();
            });
            sequenceShowView.InsertCallback(0.75f, () =>
            {
                m_MenuManagerFields.BtnPlay.gameObject.SetActive(true);
                global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::BBUIView>(m_MenuManagerFields.BtnPlay).ShowView();
            });
            // sequenceShowView.InsertCallback(1f, () =>
            // {
            //     btnParty.gameObject.SetActive(true);
            //     btnParty.GetComponent<BBUIView>().ShowView();
            //
            // });
            sequenceShowView.InsertCallback(1f, () =>
            {
                //btnGift.transform.DOPunchPosition(new Vector3(5f, 5f, 0.1f), 2f, 5, 1).SetEase(Ease.InQuart).SetLoops(-1,LoopType.Yoyo);
                // Sequence sequence = DOTween.Sequence();
                // sequence.Insert(0f, btnGift.transform.DOScale(Vector3.one * 1.1f,0.4f).SetEase(Ease.Linear).SetLoops(5, LoopType.Yoyo));
                // sequence.Insert(2f,btnGift.transform.DOPunchRotation(new Vector3(0f, 0f, 20f), 1f, 6, 2).SetEase(Ease.OutQuart));
                // sequence.Insert(2f,btnGift.transform.DOPunchScale(new Vector3(0.1f, 0.1f,0.1f), 1f, 2, 1).SetEase(Ease.OutQuart));
                // //sequence.Insert(2f,btnGift.gameObject.GetComponent<RectTransform>().DOAnchorPosY(-10f, 1f).SetRelative(true).SetEase(Ease.Linear));
                // sequence.SetLoops(-1, LoopType.Yoyo);
                global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::UnityEngine.RectTransform>( //btnGift.transform.DOPunchPosition(new Vector3(5f, 5f, 0.1f), 2f, 5, 1).SetEase(Ease.InQuart).SetLoops(-1,LoopType.Yoyo);
                // Sequence sequence = DOTween.Sequence();
                // sequence.Insert(0f, btnGift.transform.DOScale(Vector3.one * 1.1f,0.4f).SetEase(Ease.Linear).SetLoops(5, LoopType.Yoyo));
                // sequence.Insert(2f,btnGift.transform.DOPunchRotation(new Vector3(0f, 0f, 20f), 1f, 6, 2).SetEase(Ease.OutQuart));
                // sequence.Insert(2f,btnGift.transform.DOPunchScale(new Vector3(0.1f, 0.1f,0.1f), 1f, 2, 1).SetEase(Ease.OutQuart));
                // //sequence.Insert(2f,btnGift.gameObject.GetComponent<RectTransform>().DOAnchorPosY(-10f, 1f).SetRelative(true).SetEase(Ease.Linear));
                // sequence.SetLoops(-1, LoopType.Yoyo);
                m_MenuManagerFields.Logo.gameObject).DOAnchorPosY(-30f, 1f).SetRelative(true).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
            });
        }

        public void HideView() => HideViewInternal();
        private void HideViewInternal()
        {
            global::Rush.Chocology.Audio.SoundManager.Instance.PlaySoundHideView();
            m_MenuManagerFields.LockGroup.gameObject.SetActive(true);
            //Sequence sequenceShowView = DOTween.Sequence();
            //sequenceShowView.InsertCallback(0.01f, () =>
            //{
            //    btnSetting.GetComponent<BBUIView>().HideView();
            //    btnGift.GetComponent<BBUIView>().HideView();
            //    btnShop.GetComponent<BBUIView>().HideView();
            //    coinGroup.GetComponent<BBUIView>().HideView();
            //    btnPlay.GetComponent<BBUIView>().HideView();
            //    btnParty.GetComponent<BBUIView>().HideView();
            //    btnLevel.GetComponent<BBUIView>().HideView();
            //    logo.GetComponent<BBUIView>().HideView();
            //});
            //sequenceShowView.InsertCallback(0.3f, () =>
            //{
            //    SceneManager.LoadScene("Play");
            //});
            SceneManager.LoadSceneAsync("Play");
            global::Rush.Chocology.Notifications.GlobalVar.Runtime.CallAnalytics("start_game");
        }

        public global::Rush.Chocology.Shop.ShopPopup2 ShopPopup { get => m_MenuManagerFields.ShopPopup; set => m_MenuManagerFields.ShopPopup = value; }
        public global::Rush.Chocology.Rewards.SpinPopup SpinPopup { get => m_MenuManagerFields.SpinPopup; set => m_MenuManagerFields.SpinPopup = value; }
        public global::Rush.Chocology.Settings.SettingPopup SettingPopup { get => m_MenuManagerFields.SettingPopup; set => m_MenuManagerFields.SettingPopup = value; }

        public void OpenSettingPopup() => OpenSettingPopupInternal();
        private void OpenSettingPopupInternal()
        {
            m_MenuManagerFields.SettingPopup.OpenSettingPopup();
        }

        public global::Rush.Chocology.Settings.RatePopup RatePopup { get => m_MenuManagerFields.RatePopup; set => m_MenuManagerFields.RatePopup = value; }

        public void OpenRatePopup() => OpenRatePopupInternal();
        private void OpenRatePopupInternal()
        {
            m_MenuManagerFields.RatePopup.OpenRatePopup();
        }

        public global::Rush.Chocology.LevelMap.LevelPopup LevelPopup { get => m_MenuManagerFields.LevelPopup; set => m_MenuManagerFields.LevelPopup = value; }

        public void OpenPopupLevel() => OpenPopupLevelInternal();
        private void OpenPopupLevelInternal()
        {
            Debug.Log("OpenPopupLevel");
            m_MenuManagerFields.LevelPopup.ShowLevelPopup();
        }

        public void SelectLevel(int _levelSelect) => SelectLevelInternal(_levelSelect);
        private void SelectLevelInternal(int _levelSelect)
        {
            global::Rush.Chocology.Economy.Config.Runtime.IsSelectLevel = true;
            global::Rush.Chocology.Economy.Config.Runtime.CurrSelectLevel = _levelSelect;
            Debug.Log(_levelSelect);
            HideViewInternal();
        }

        public global::Rush.Chocology.Economy.RewardPopup RewardPopup { get => m_MenuManagerFields.RewardPopup; set => m_MenuManagerFields.RewardPopup = value; }

        public void OpenRewardPopup(List<global::Rush.Chocology.Economy.ConfigItemShopData> _listDatas, bool _isShowCollectx2 = true) => OpenRewardPopupInternal(_listDatas, _isShowCollectx2);
        private void OpenRewardPopupInternal(List<global::Rush.Chocology.Economy.ConfigItemShopData> _listDatas, bool _isShowCollectx2 = true)
        {
            global::Rush.Chocology.Economy.Config.Runtime.GameState = global::Rush.Chocology.Economy.Config.GAME_STATE.WIN;
            m_MenuManagerFields.RewardPopup.OpenRewardPopup(_listDatas, _isShowCollectx2);
        }

        public void SetRewardPpopupFinished() => SetRewardPpopupFinishedInternal();
        private void SetRewardPpopupFinishedInternal()
        {
        }

        public global::Rush.Chocology.Rewards.ChestPopup ChestPopup { get => m_MenuManagerFields.ChestPopup; set => m_MenuManagerFields.ChestPopup = value; }

        public void OpenChestPopup(bool isFullStar) => OpenChestPopupInternal(isFullStar);
        private void OpenChestPopupInternal(bool isFullStar)
        {
            m_MenuManagerFields.ChestPopup.OpenChestPopup(isFullStar);
        }

        public void CloseChestPopup() => CloseChestPopupInternal();
        private void CloseChestPopupInternal()
        {
        }

        [ContextMenu("Reset SCENE")]
        public void TouchResetScene() => TouchResetSceneInternal();
        private void TouchResetSceneInternal()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
