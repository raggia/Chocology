/*
 * Created on 2022
 *
 * Copyright (c) 2022 dotmobstudio
 * Support : dotmobstudio@gmail.com
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
using BsplabsMobileAds;

namespace Rush.Chocology.Gameplay
{
    [UnityEngine.Scripting.APIUpdating.MovedFrom(true, "", "Assembly-CSharp", "GamePlayManager")]
    public class GamePlayManager : MonoBehaviour
    {
        [global::System.Serializable]
        private sealed class GamePlayManagerField
        {
            [UnityEngine.Serialization.FormerlySerializedAs("canvasScaler")]
            [UnityEngine.SerializeField]
            private CanvasScaler m_CanvasScaler;
            public global::UnityEngine.UI.CanvasScaler CanvasScaler { get => m_CanvasScaler; set => m_CanvasScaler = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("level")]
            [UnityEngine.SerializeField]
            private int m_Level = 1;
            public int Level { get => m_Level; set => m_Level = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("isTest")]
            [UnityEngine.SerializeField]
            private bool m_IsTest = false;
            public bool IsTest { get => m_IsTest; set => m_IsTest = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("btnPause")]
            [UnityEngine.SerializeField]
            private BBUIButton m_BtnPause;
            public global::BBUIButton BtnPause { get => m_BtnPause; set => m_BtnPause = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("btnUndo")]
            [UnityEngine.SerializeField]
            private BBUIButton m_BtnUndo;
            public global::BBUIButton BtnUndo { get => m_BtnUndo; set => m_BtnUndo = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("txtUndoCount")]
            [UnityEngine.SerializeField]
            private Text m_TxtUndoCount;
            public global::UnityEngine.UI.Text TxtUndoCount { get => m_TxtUndoCount; set => m_TxtUndoCount = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("txtUndoAdd")]
            [UnityEngine.SerializeField]
            private Text m_TxtUndoAdd;
            public global::UnityEngine.UI.Text TxtUndoAdd { get => m_TxtUndoAdd; set => m_TxtUndoAdd = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("objUndoBG")]
            [UnityEngine.SerializeField]
            private GameObject m_ObjUndoBG;
            public global::UnityEngine.GameObject ObjUndoBG { get => m_ObjUndoBG; set => m_ObjUndoBG = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("btnSuggest")]
            [UnityEngine.SerializeField]
            private BBUIButton m_BtnSuggest;
            public global::BBUIButton BtnSuggest { get => m_BtnSuggest; set => m_BtnSuggest = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("txtSuggestCount")]
            [UnityEngine.SerializeField]
            private Text m_TxtSuggestCount;
            public global::UnityEngine.UI.Text TxtSuggestCount { get => m_TxtSuggestCount; set => m_TxtSuggestCount = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("txtSuggestAdd")]
            [UnityEngine.SerializeField]
            private Text m_TxtSuggestAdd;
            public global::UnityEngine.UI.Text TxtSuggestAdd { get => m_TxtSuggestAdd; set => m_TxtSuggestAdd = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("objSuggestBG")]
            [UnityEngine.SerializeField]
            private GameObject m_ObjSuggestBG;
            public global::UnityEngine.GameObject ObjSuggestBG { get => m_ObjSuggestBG; set => m_ObjSuggestBG = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("btnShuffle")]
            [UnityEngine.SerializeField]
            private BBUIButton m_BtnShuffle;
            public global::BBUIButton BtnShuffle { get => m_BtnShuffle; set => m_BtnShuffle = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("txtShuffleCount")]
            [UnityEngine.SerializeField]
            private Text m_TxtShuffleCount;
            public global::UnityEngine.UI.Text TxtShuffleCount { get => m_TxtShuffleCount; set => m_TxtShuffleCount = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("txtShuffleAdd")]
            [UnityEngine.SerializeField]
            private Text m_TxtShuffleAdd;
            public global::UnityEngine.UI.Text TxtShuffleAdd { get => m_TxtShuffleAdd; set => m_TxtShuffleAdd = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("objShuffleBG")]
            [UnityEngine.SerializeField]
            private GameObject m_ObjShuffleBG;
            public global::UnityEngine.GameObject ObjShuffleBG { get => m_ObjShuffleBG; set => m_ObjShuffleBG = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("btnRemoveAds")]
            [UnityEngine.SerializeField]
            private BBUIButton m_BtnRemoveAds;
            public global::BBUIButton BtnRemoveAds { get => m_BtnRemoveAds; set => m_BtnRemoveAds = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("btnPigBank")]
            [UnityEngine.SerializeField]
            private BBUIButton m_BtnPigBank;
            public global::BBUIButton BtnPigBank { get => m_BtnPigBank; set => m_BtnPigBank = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("txtLevel")]
            [UnityEngine.SerializeField]
            private Text m_TxtLevel;
            public global::UnityEngine.UI.Text TxtLevel { get => m_TxtLevel; set => m_TxtLevel = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("bgFooter")]
            [UnityEngine.SerializeField]
            private GameObject m_BgFooter;
            public global::UnityEngine.GameObject BgFooter { get => m_BgFooter; set => m_BgFooter = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("starGroup")]
            [UnityEngine.SerializeField]
            private global::Rush.Chocology.Gameplay.StarGroup m_StarGroup;
            public global::Rush.Chocology.Gameplay.StarGroup StarGroup { get => m_StarGroup; set => m_StarGroup = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("isPlayTest")]
            [UnityEngine.SerializeField]
            private bool m_IsPlayTest = false;
            public bool IsPlayTest { get => m_IsPlayTest; set => m_IsPlayTest = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("lockGroup")]
            [UnityEngine.SerializeField]
            private GameObject m_LockGroup;
            public global::UnityEngine.GameObject LockGroup { get => m_LockGroup; set => m_LockGroup = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("pausePopup")]
            [UnityEngine.SerializeField]
            private global::Rush.Chocology.Gameplay.PausePopup2 m_PausePopup;
            public global::Rush.Chocology.Gameplay.PausePopup2 PausePopup { get => m_PausePopup; set => m_PausePopup = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("winPopup")]
            [UnityEngine.SerializeField]
            private global::Rush.Chocology.Gameplay.WinPopup2 m_WinPopup;
            public global::Rush.Chocology.Gameplay.WinPopup2 WinPopup { get => m_WinPopup; set => m_WinPopup = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("losePopup")]
            [UnityEngine.SerializeField]
            private global::Rush.Chocology.Gameplay.LosePopup2 m_LosePopup;
            public global::Rush.Chocology.Gameplay.LosePopup2 LosePopup { get => m_LosePopup; set => m_LosePopup = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("freeItemPopup")]
            [UnityEngine.SerializeField]
            private global::Rush.Chocology.Shop.FreeItemPopup m_FreeItemPopup;
            public global::Rush.Chocology.Shop.FreeItemPopup FreeItemPopup { get => m_FreeItemPopup; set => m_FreeItemPopup = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("buyItemPopup")]
            [UnityEngine.SerializeField]
            private global::Rush.Chocology.Shop.BuyItemPopup m_BuyItemPopup;
            public global::Rush.Chocology.Shop.BuyItemPopup BuyItemPopup { get => m_BuyItemPopup; set => m_BuyItemPopup = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("spinPopup")]
            [UnityEngine.SerializeField]
            private global::Rush.Chocology.Rewards.SpinPopup m_SpinPopup;
            public global::Rush.Chocology.Rewards.SpinPopup SpinPopup { get => m_SpinPopup; set => m_SpinPopup = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("chestPopup")]
            [UnityEngine.SerializeField]
            private global::Rush.Chocology.Rewards.ChestPopup m_ChestPopup;
            public global::Rush.Chocology.Rewards.ChestPopup ChestPopup { get => m_ChestPopup; set => m_ChestPopup = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("rewardPopup")]
            [UnityEngine.SerializeField]
            private global::Rush.Chocology.Economy.RewardPopup m_RewardPopup;
            public global::Rush.Chocology.Economy.RewardPopup RewardPopup { get => m_RewardPopup; set => m_RewardPopup = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("piggyBankPopup")]
            [UnityEngine.SerializeField]
            private global::Rush.Chocology.Rewards.PiggyBankPopup m_PiggyBankPopup;
            public global::Rush.Chocology.Rewards.PiggyBankPopup PiggyBankPopup { get => m_PiggyBankPopup; set => m_PiggyBankPopup = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("tut1Obj")]
            [UnityEngine.SerializeField]
            private GameObject m_Tut1Obj;
            public global::UnityEngine.GameObject Tut1Obj { get => m_Tut1Obj; set => m_Tut1Obj = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("tut2Obj")]
            [UnityEngine.SerializeField]
            private GameObject m_Tut2Obj;
            public global::UnityEngine.GameObject Tut2Obj { get => m_Tut2Obj; set => m_Tut2Obj = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("tut3Obj")]
            [UnityEngine.SerializeField]
            private GameObject m_Tut3Obj;
            public global::UnityEngine.GameObject Tut3Obj { get => m_Tut3Obj; set => m_Tut3Obj = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("tut4Obj")]
            [UnityEngine.SerializeField]
            private GameObject m_Tut4Obj;
            public global::UnityEngine.GameObject Tut4Obj { get => m_Tut4Obj; set => m_Tut4Obj = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("ratePopup")]
            [UnityEngine.SerializeField]
            private global::Rush.Chocology.Settings.RatePopup m_RatePopup;
            public global::Rush.Chocology.Settings.RatePopup RatePopup { get => m_RatePopup; set => m_RatePopup = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("slotBGTranform")]
            [UnityEngine.SerializeField]
            private Transform m_SlotBGTranform;
            public global::UnityEngine.Transform SlotBGTranform { get => m_SlotBGTranform; set => m_SlotBGTranform = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("shopPopup")]
            [UnityEngine.SerializeField]
            private global::Rush.Chocology.Shop.ShopPopup2 m_ShopPopup;
            public global::Rush.Chocology.Shop.ShopPopup2 ShopPopup { get => m_ShopPopup; set => m_ShopPopup = value; }
        }

        [global::UnityEngine.SerializeField]
        private GamePlayManagerField m_GamePlayManagerFields = new GamePlayManagerField();
        private static global::Rush.Chocology.Gameplay.GamePlayManager s_Instance;
        public static global::Rush.Chocology.Gameplay.GamePlayManager Instance { get => s_Instance; set => s_Instance = value; }
        public global::UnityEngine.UI.CanvasScaler CanvasScaler { get => m_GamePlayManagerFields.CanvasScaler; set => m_GamePlayManagerFields.CanvasScaler = value; }
        public int Level { get => m_GamePlayManagerFields.Level; set => m_GamePlayManagerFields.Level = value; }
        public bool IsTest { get => m_GamePlayManagerFields.IsTest; set => m_GamePlayManagerFields.IsTest = value; }
        public global::BBUIButton BtnPause { get => m_GamePlayManagerFields.BtnPause; set => m_GamePlayManagerFields.BtnPause = value; }
        public global::BBUIButton BtnUndo { get => m_GamePlayManagerFields.BtnUndo; set => m_GamePlayManagerFields.BtnUndo = value; }
        public global::UnityEngine.UI.Text TxtUndoCount { get => m_GamePlayManagerFields.TxtUndoCount; set => m_GamePlayManagerFields.TxtUndoCount = value; }
        public global::UnityEngine.UI.Text TxtUndoAdd { get => m_GamePlayManagerFields.TxtUndoAdd; set => m_GamePlayManagerFields.TxtUndoAdd = value; }
        public global::UnityEngine.GameObject ObjUndoBG { get => m_GamePlayManagerFields.ObjUndoBG; set => m_GamePlayManagerFields.ObjUndoBG = value; }
        public global::BBUIButton BtnSuggest { get => m_GamePlayManagerFields.BtnSuggest; set => m_GamePlayManagerFields.BtnSuggest = value; }
        public global::UnityEngine.UI.Text TxtSuggestCount { get => m_GamePlayManagerFields.TxtSuggestCount; set => m_GamePlayManagerFields.TxtSuggestCount = value; }
        public global::UnityEngine.UI.Text TxtSuggestAdd { get => m_GamePlayManagerFields.TxtSuggestAdd; set => m_GamePlayManagerFields.TxtSuggestAdd = value; }
        public global::UnityEngine.GameObject ObjSuggestBG { get => m_GamePlayManagerFields.ObjSuggestBG; set => m_GamePlayManagerFields.ObjSuggestBG = value; }
        public global::BBUIButton BtnShuffle { get => m_GamePlayManagerFields.BtnShuffle; set => m_GamePlayManagerFields.BtnShuffle = value; }
        public global::UnityEngine.UI.Text TxtShuffleCount { get => m_GamePlayManagerFields.TxtShuffleCount; set => m_GamePlayManagerFields.TxtShuffleCount = value; }
        public global::UnityEngine.UI.Text TxtShuffleAdd { get => m_GamePlayManagerFields.TxtShuffleAdd; set => m_GamePlayManagerFields.TxtShuffleAdd = value; }
        public global::UnityEngine.GameObject ObjShuffleBG { get => m_GamePlayManagerFields.ObjShuffleBG; set => m_GamePlayManagerFields.ObjShuffleBG = value; }
        public global::BBUIButton BtnRemoveAds { get => m_GamePlayManagerFields.BtnRemoveAds; set => m_GamePlayManagerFields.BtnRemoveAds = value; }
        public global::BBUIButton BtnPigBank { get => m_GamePlayManagerFields.BtnPigBank; set => m_GamePlayManagerFields.BtnPigBank = value; }
        public global::UnityEngine.UI.Text TxtLevel { get => m_GamePlayManagerFields.TxtLevel; set => m_GamePlayManagerFields.TxtLevel = value; }
        public global::UnityEngine.GameObject BgFooter { get => m_GamePlayManagerFields.BgFooter; set => m_GamePlayManagerFields.BgFooter = value; }
        public global::Rush.Chocology.Gameplay.StarGroup StarGroup { get => m_GamePlayManagerFields.StarGroup; set => m_GamePlayManagerFields.StarGroup = value; }
        public bool IsPlayTest { get => m_GamePlayManagerFields.IsPlayTest; set => m_GamePlayManagerFields.IsPlayTest = value; }
        public global::UnityEngine.GameObject LockGroup { get => m_GamePlayManagerFields.LockGroup; set => m_GamePlayManagerFields.LockGroup = value; }

        private void Awake()
        {
            s_Instance = this;
        //Input.multiTouchEnabled = false;
        //Config.SetCount_ItemHelp(Config.ITEMHELP_TYPE.UNDO, 10);
        //Config.SetCount_ItemHelp(Config.ITEMHELP_TYPE.SUGGEST, 10);
        //Config.SetCount_ItemHelp(Config.ITEMHELP_TYPE.SHUFFLE, 10);
        // if (Config.CheckWideScreen()) {
        //     canvasScaler.matchWidthOrHeight = 0.5f;
        // }
        }

        // Start is called before the first frame update
        void Start()
        {
            global::Rush.Chocology.Integrations.Analytics.AdjustManager.instance.PlayGame();
            Debug.Log("Play Game");
            BspLabsAdsMobile.Instance.ShowBanner(BannerPosition.BOTTOM, BannerType.Banner);
            m_GamePlayManagerFields.LockGroup.SetActive(true);
            m_IsRevive = false;
            m_GamePlayManagerFields.BtnPause.OnPointerClickCallBack_Completed.AddListener(TouchPauseInternal);
            m_GamePlayManagerFields.BtnUndo.OnPointerClickCallBack_Completed.AddListener(TouchUndoInternal);
            m_GamePlayManagerFields.BtnSuggest.OnPointerClickCallBack_Completed.AddListener(TouchSuggestInternal);
            m_GamePlayManagerFields.BtnShuffle.OnPointerClickCallBack_Completed.AddListener(TouchShuffleInternal);
            //btnWatchVideo.OnPointerClickCallBack_Completed.AddListener(TouchWatchVideo);
            m_GamePlayManagerFields.BtnPigBank.OnPointerClickCallBack_Completed.AddListener(TouchPiggyBankInternal);
            //AudioManager.instance.Play("Bmg");
            if (!m_GamePlayManagerFields.IsTest)
            {
                if (global::Rush.Chocology.Economy.Config.Runtime.IsSelectLevel)
                {
                    global::Rush.Chocology.Economy.Config.Runtime.IsSelectLevel = false;
                    m_GamePlayManagerFields.Level = global::Rush.Chocology.Economy.Config.Runtime.CurrSelectLevel;
                }
                else
                {
                    m_GamePlayManagerFields.Level = PlayerPrefs.GetInt(global::Rush.Chocology.Economy.Config.CURR_LEVEL);
                //level = Config.currLevel;
                }
            }

            if (m_GamePlayManagerFields.Level > global::Rush.Chocology.Economy.Config.MAX_LEVEL)
            {
                m_GamePlayManagerFields.Level = global::Rush.Chocology.Economy.Config.MAX_LEVEL;
            }

            if (m_GamePlayManagerFields.Level == 0)
                m_GamePlayManagerFields.Level = 1;
            m_GamePlayManagerFields.TxtLevel.text = $"Level: {(m_GamePlayManagerFields.Level)}";
            global::Rush.Chocology.Economy.Config.Runtime.GameState = global::Rush.Chocology.Economy.Config.GAME_STATE.START;
            LoadLevelGameInternal();
            InitViewsInternal();
        }

        // Update is called once per frame
        void Update()
        {
            if (global::Rush.Chocology.Economy.Config.Runtime.GameState == global::Rush.Chocology.Economy.Config.GAME_STATE.PLAYING)
            {
                if (m_GamePlayManagerFields.Level > 4 && !m_IsShowAutoSuggestShuffle)
                {
                    m_TimeAutoSuggestShuffle += Time.deltaTime;
                    if (m_TimeAutoSuggestShuffle >= global::Rush.Chocology.Economy.Config.Runtime.AutoTimeToSuggestShuffle)
                    {
                        ShowAutoSuggestShuffleInternal();
                    }
                }
            }
        }

        private GameObject m_LevelGame;
        public void LoadLevelGame() => LoadLevelGameInternal();
        private void LoadLevelGameInternal()
        {
            if (m_GamePlayManagerFields.Level == 0)
                m_GamePlayManagerFields.Level = 1;
            m_LevelGame = Instantiate(Resources.Load("DM_Level/Level" + m_GamePlayManagerFields.Level)) as GameObject;
            // levelGame.transform.position = new Vector3(0f,-0.5f,0f);
            // Debug.Log(slotBGTranform.position);
            global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::Rush.Chocology.Gameplay.GameLevelManager>( // levelGame.transform.position = new Vector3(0f,-0.5f,0f);
            // Debug.Log(slotBGTranform.position);
            m_LevelGame).InitSlotPosition(m_GamePlayManagerFields.SlotBGTranform.position);
            //levelGame.layer = LayerMask.NameToLayer("BG");
            m_GamePlayManagerFields.StarGroup.InitStarGroup(global::Rush.Chocology.Gameplay.GameLevelManager.Instance.ConfigLevelGame);
            StartCoroutine(LoadLevelGameIEnumerator());
        }

        private IEnumerator LoadLevelGameIEnumerator()
        {
            yield return new WaitForSeconds(0.02f);
            //        Debug.Log(slotBGTranform.position);
            global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::Rush.Chocology.Gameplay.GameLevelManager>( //        Debug.Log(slotBGTranform.position);
            m_LevelGame).InitSlotPosition(m_GamePlayManagerFields.SlotBGTranform.position);
        }

        public void InitViews() => InitViewsInternal();
        private void InitViewsInternal()
        {
            m_GamePlayManagerFields.BtnPause.gameObject.SetActive(false);
            m_GamePlayManagerFields.BtnUndo.gameObject.SetActive(false);
            m_GamePlayManagerFields.BtnSuggest.gameObject.SetActive(false);
            m_GamePlayManagerFields.BtnShuffle.gameObject.SetActive(false);
            m_GamePlayManagerFields.StarGroup.gameObject.SetActive(false);
            //btnWatchVideo.gameObject.SetActive(false);
            //btnRemoveAds.gameObject.SetActive(false);
            m_GamePlayManagerFields.TxtLevel.gameObject.SetActive(false);
            m_GamePlayManagerFields.BtnPigBank.gameObject.SetActive(false);
            m_GamePlayManagerFields.BgFooter.gameObject.SetActive(false);
            //txtUndoCount.text = $"{Config.GetCount_ItemHelp(Config.ITEMHELP_TYPE.UNDO)}";
            m_GamePlayManagerFields.ObjUndoBG.gameObject.SetActive(true);
            //txtSuggestCount.text = $"{Config.GetCount_ItemHelp(Config.ITEMHELP_TYPE.SUGGEST)}";
            m_GamePlayManagerFields.ObjSuggestBG.gameObject.SetActive(true);
            //txtShuffleCount.text = $"{Config.GetCount_ItemHelp(Config.ITEMHELP_TYPE.SHUFFLE)}";
            m_GamePlayManagerFields.ObjShuffleBG.gameObject.SetActive(true);
            if (m_GamePlayManagerFields.Level >= 2)
            {
                m_GamePlayManagerFields.BtnUndo.Interactable = true;
                global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::Rush.Chocology.Rewards.ButtonItemLockManager>(m_GamePlayManagerFields.BtnUndo).ShowButtonItemLock(false);
            }
            else
            {
                m_GamePlayManagerFields.BtnUndo.Interactable = false;
                global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::Rush.Chocology.Rewards.ButtonItemLockManager>(m_GamePlayManagerFields.BtnUndo).ShowButtonItemLock(true);
            }

            if (m_GamePlayManagerFields.Level >= 3)
            {
                m_GamePlayManagerFields.BtnSuggest.Interactable = true;
                global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::Rush.Chocology.Rewards.ButtonItemLockManager>(m_GamePlayManagerFields.BtnSuggest).ShowButtonItemLock(false);
            }
            else
            {
                m_GamePlayManagerFields.BtnSuggest.Interactable = false;
                global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::Rush.Chocology.Rewards.ButtonItemLockManager>(m_GamePlayManagerFields.BtnSuggest).ShowButtonItemLock(true);
            }

            if (m_GamePlayManagerFields.Level >= 4)
            {
                m_GamePlayManagerFields.BtnShuffle.Interactable = true;
                global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::Rush.Chocology.Rewards.ButtonItemLockManager>(m_GamePlayManagerFields.BtnShuffle).ShowButtonItemLock(false);
            }
            else
            {
                m_GamePlayManagerFields.BtnShuffle.Interactable = false;
                global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::Rush.Chocology.Rewards.ButtonItemLockManager>(m_GamePlayManagerFields.BtnShuffle).ShowButtonItemLock(true);
            }

            SetUpdateCountItemInternal();
            InitViewsShowViewInternal();
        }

        public void InitViewsShowView() => InitViewsShowViewInternal();
        private void InitViewsShowViewInternal()
        {
            Sequence sequenceShowView = DOTween.Sequence();
            sequenceShowView.InsertCallback(0.2f, () =>
            {
                global::Rush.Chocology.Audio.SoundManager.Instance.PlaySoundShowView();
                m_GamePlayManagerFields.BgFooter.gameObject.SetActive(true);
                global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::BBUIView>(m_GamePlayManagerFields.BgFooter).ShowView();
                m_GamePlayManagerFields.BtnPigBank.gameObject.SetActive(true);
                global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::BBUIView>(m_GamePlayManagerFields.BtnPigBank).ShowView();
                m_GamePlayManagerFields.BtnUndo.gameObject.SetActive(true);
                global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::BBUIView>(m_GamePlayManagerFields.BtnUndo).ShowView();
            });
            sequenceShowView.InsertCallback(0.5f, () =>
            {
                m_GamePlayManagerFields.TxtLevel.gameObject.SetActive(true);
                global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::BBUIView>(m_GamePlayManagerFields.TxtLevel).ShowView();
                m_GamePlayManagerFields.StarGroup.gameObject.SetActive(true);
                global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::BBUIView>(m_GamePlayManagerFields.StarGroup).ShowView();
                m_GamePlayManagerFields.BtnSuggest.gameObject.SetActive(true);
                global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::BBUIView>(m_GamePlayManagerFields.BtnSuggest).ShowView();
            });
            sequenceShowView.InsertCallback(0.7f, () =>
            {
                m_GamePlayManagerFields.BtnPause.gameObject.SetActive(true);
                global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::BBUIView>(m_GamePlayManagerFields.BtnPause).ShowView();
                //btnWatchVideo.gameObject.SetActive(true);
                //btnWatchVideo.GetComponent<BBUIView>().ShowView();
                //btnRemoveAds.gameObject.SetActive(true);
                //btnRemoveAds.GetComponent<BBUIView>().ShowView();
                m_GamePlayManagerFields.BtnShuffle.gameObject.SetActive(true);
                global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::BBUIView>(m_GamePlayManagerFields.BtnShuffle).ShowView();
            });
            sequenceShowView.InsertCallback(1.5f, () =>
            {
                InitViewsShowViewFinishedInternal();
            });
        }

        public void InitViewsShowViewFinished() => InitViewsShowViewFinishedInternal();
        private void InitViewsShowViewFinishedInternal()
        {
        }

        public void SetStartPlayingGame() => SetStartPlayingGameInternal();
        private void SetStartPlayingGameInternal()
        {
            Debug.Log("SetStartPlayingGameSetStartPlayingGame");
            global::Rush.Chocology.Economy.Config.Runtime.GameState = global::Rush.Chocology.Economy.Config.GAME_STATE.PLAYING;
            if (global::Rush.Chocology.Economy.Config.Runtime.CheckTutorial1())
            {
                ShowTut1Internal();
            }

            if (global::Rush.Chocology.Economy.Config.Runtime.CheckTutorial2())
            {
                Debug.LogError("Chay vao day ne");
                ShowTut2Internal();
            }

            if (global::Rush.Chocology.Economy.Config.Runtime.CheckTutorial3())
            {
                ShowTut3Internal();
            }

            if (global::Rush.Chocology.Economy.Config.Runtime.CheckTutorial4())
            {
                ShowTut4Internal();
            }

            //      Debug.Log("SetStartPlayingGame:"+level);
            //        Debug.Log("SetStartPlayingGame:"+ Config.GetTut_Finished(Config.TUT.TUT_TOUCHSPIN_LEVEL5));
            //if (level == 5 && !Config.GetTut_Finished(Config.TUT.TUT_TOUCHSPIN_LEVEL5) && Config.CheckSpinAvaiable())//
            //{
            //    Config.SetTut_Finished(Config.TUT.TUT_TOUCHSPIN_LEVEL5);
            //    //ShowTut_TouchSpin();
            //    OpenSpinPopup();
            //}
            m_GamePlayManagerFields.LockGroup.SetActive(false);
        // if (level >= 6) {
        //     if (Config.GetCount_ItemHelp(Config.ITEMHELP_TYPE.SUGGEST) == 0 || Config.GetCount_ItemHelp(Config.ITEMHELP_TYPE.SHUFFLE) == 0 || Config.GetCount_ItemHelp(Config.ITEMHELP_TYPE.UNDO) == 0)
        //     {
        //         Config.countShowFreeItem++;
        //     }
        //         
        //     if (Config.countShowFreeItem % Config.INTERVAL_SHOW_FREEITEM_POPUP == 1)
        //     {
        //         if (Config.GetCount_ItemHelp(Config.ITEMHELP_TYPE.SUGGEST) == 0)
        //         {
        //             OpenFreeItemPopup(Config.ITEMHELP_TYPE.SUGGEST);
        //         }
        //         else if (Config.GetCount_ItemHelp(Config.ITEMHELP_TYPE.SHUFFLE) == 0)
        //         {
        //             OpenFreeItemPopup(Config.ITEMHELP_TYPE.SHUFFLE);
        //         }
        //         else if (Config.GetCount_ItemHelp(Config.ITEMHELP_TYPE.UNDO) == 0)
        //         {
        //             OpenFreeItemPopup(Config.ITEMHELP_TYPE.UNDO);
        //         }
        //         
        //     }
        // }
        }

        public void TouchPause() => TouchPauseInternal();
        private void TouchPauseInternal()
        {
            //Debug.LogError("GAME PAUSE");
            if (global::Rush.Chocology.Economy.Config.Runtime.GameState == global::Rush.Chocology.Economy.Config.GAME_STATE.PLAYING)
            {
                global::Rush.Chocology.Economy.Config.Runtime.GameState = global::Rush.Chocology.Economy.Config.GAME_STATE.PAUSE;
                m_GamePlayManagerFields.PausePopup.OpenPausePopup(m_GamePlayManagerFields.Level);
                HideTutHandGuideInternal();
            }
        }

        public void SetUnPause() => SetUnPauseInternal();
        private void SetUnPauseInternal()
        {
            global::Rush.Chocology.Economy.Config.Runtime.GameState = global::Rush.Chocology.Economy.Config.GAME_STATE.PLAYING;
        }

        public global::Rush.Chocology.Gameplay.PausePopup2 PausePopup { get => m_GamePlayManagerFields.PausePopup; set => m_GamePlayManagerFields.PausePopup = value; }


        public void TouchUndo() => TouchUndoInternal();
        private void TouchUndoInternal()
        {
            //Debug.LogError("Touch Undo");
            if (global::Rush.Chocology.Gameplay.GameLevelManager.Instance.CheckUndoAvaiable() && global::Rush.Chocology.Economy.Config.Runtime.ReadCountItemHelp(global::Rush.Chocology.Economy.Config.ITEMHELP_TYPE.UNDO) > 0)
            {
                global::Rush.Chocology.Gameplay.GameLevelManager.Instance.SetUndo();
                global::Rush.Chocology.Economy.Config.Runtime.SetCountItemHelp(global::Rush.Chocology.Economy.Config.ITEMHELP_TYPE.UNDO, global::Rush.Chocology.Economy.Config.Runtime.ReadCountItemHelp(global::Rush.Chocology.Economy.Config.ITEMHELP_TYPE.UNDO) - 1);
                //txtUndoCount.text = $"{Config.GetCount_ItemHelp(Config.ITEMHELP_TYPE.UNDO)}";
                SetUpdateCountItemInternal();
                m_GamePlayManagerFields.ObjUndoBG.gameObject.SetActive(true);
                if (global::Rush.Chocology.Economy.Config.Runtime.CheckTutorial2() && global::Rush.Chocology.Economy.Config.Runtime.IsShowTut2)
                {
                    HideTut2Internal();
                }
            }
            else if (global::Rush.Chocology.Economy.Config.Runtime.ReadCountItemHelp(global::Rush.Chocology.Economy.Config.ITEMHELP_TYPE.UNDO) == 0)
            {
                if (global::Rush.Chocology.Economy.Config.Runtime.CurrCoin >= global::Rush.Chocology.Economy.Config.Runtime.CoinPriceItem)
                {
                    OpenBuyItemPopupInternal(global::Rush.Chocology.Economy.Config.ITEMHELP_TYPE.UNDO);
                }
                else
                {
                    OpenBuyItemPopupInternal(global::Rush.Chocology.Economy.Config.ITEMHELP_TYPE.UNDO);
                // OpenFreeItemPopup(Config.ITEMHELP_TYPE.UNDO);
                }
            }

            HideTutHandGuideInternal();
        }


        public void TouchSuggest() => TouchSuggestInternal();
        private void TouchSuggestInternal()
        {
            //Debug.LogError("Touch Suggest");
            if (global::Rush.Chocology.Economy.Config.Runtime.ReadCountItemHelp(global::Rush.Chocology.Economy.Config.ITEMHELP_TYPE.SUGGEST) > 0)
            {
                global::Rush.Chocology.Gameplay.GameLevelManager.Instance.SetSuggest();
                if (global::Rush.Chocology.Economy.Config.Runtime.CheckTutorial3() && global::Rush.Chocology.Economy.Config.Runtime.IsShowTut3)
                {
                    HideTut3Internal();
                }

                global::Rush.Chocology.Integrations.Analytics.AdjustManager.instance.Hint();
            }
            else
            {
                if (global::Rush.Chocology.Economy.Config.Runtime.CurrCoin >= global::Rush.Chocology.Economy.Config.Runtime.CoinPriceItem)
                {
                    OpenBuyItemPopupInternal(global::Rush.Chocology.Economy.Config.ITEMHELP_TYPE.SUGGEST);
                }
                else
                {
                    OpenBuyItemPopupInternal(global::Rush.Chocology.Economy.Config.ITEMHELP_TYPE.SUGGEST);
                // OpenFreeItemPopup(Config.ITEMHELP_TYPE.SUGGEST);
                }
            }

            HideTutHandGuideInternal();
        }

        public void SetSuggestSuccess() => SetSuggestSuccessInternal();
        private void SetSuggestSuccessInternal()
        {
            global::Rush.Chocology.Economy.Config.Runtime.SetCountItemHelp(global::Rush.Chocology.Economy.Config.ITEMHELP_TYPE.SUGGEST, global::Rush.Chocology.Economy.Config.Runtime.ReadCountItemHelp(global::Rush.Chocology.Economy.Config.ITEMHELP_TYPE.SUGGEST) - 1);
            //txtSuggestCount.text = $"{Config.GetCount_ItemHelp(Config.ITEMHELP_TYPE.SUGGEST)}";
            SetUpdateCountItemInternal();
            m_GamePlayManagerFields.ObjSuggestBG.gameObject.SetActive(true);
        }


        public void TouchShuffle() => TouchShuffleInternal();
        private void TouchShuffleInternal()
        {
            // Debug.LogError("Touch Shuffle");
            if (global::Rush.Chocology.Economy.Config.Runtime.ReadCountItemHelp(global::Rush.Chocology.Economy.Config.ITEMHELP_TYPE.SHUFFLE) > 0)
            {
                global::Rush.Chocology.Gameplay.GameLevelManager.Instance.SetShuffle();
                global::Rush.Chocology.Economy.Config.Runtime.SetCountItemHelp(global::Rush.Chocology.Economy.Config.ITEMHELP_TYPE.SHUFFLE, global::Rush.Chocology.Economy.Config.Runtime.ReadCountItemHelp(global::Rush.Chocology.Economy.Config.ITEMHELP_TYPE.SHUFFLE) - 1);
                //txtShuffleCount.text = $"{Config.GetCount_ItemHelp(Config.ITEMHELP_TYPE.SHUFFLE)}";
                SetUpdateCountItemInternal();
                m_GamePlayManagerFields.ObjShuffleBG.gameObject.SetActive(true);
                if (global::Rush.Chocology.Economy.Config.Runtime.CheckTutorial4() && global::Rush.Chocology.Economy.Config.Runtime.IsShowTut4)
                {
                    HideTut4Internal();
                }
            }
            else
            {
                if (global::Rush.Chocology.Economy.Config.Runtime.CurrCoin >= global::Rush.Chocology.Economy.Config.Runtime.CoinPriceItem)
                {
                    OpenBuyItemPopupInternal(global::Rush.Chocology.Economy.Config.ITEMHELP_TYPE.SHUFFLE);
                }
                else
                {
                    OpenBuyItemPopupInternal(global::Rush.Chocology.Economy.Config.ITEMHELP_TYPE.SHUFFLE);
                // OpenFreeItemPopup(Config.ITEMHELP_TYPE.SHUFFLE);
                }
            }

            HideTutHandGuideInternal();
        }

        public global::Rush.Chocology.Gameplay.WinPopup2 WinPopup { get => m_GamePlayManagerFields.WinPopup; set => m_GamePlayManagerFields.WinPopup = value; }

        public void SetGameWin() => SetGameWinInternal();
        private void SetGameWinInternal()
        {
            if (global::Rush.Chocology.Economy.Config.Runtime.GameState != global::Rush.Chocology.Economy.Config.GAME_STATE.WIN)
            {
                SetFinishedGame();
                global::Rush.Chocology.Economy.Config.Runtime.GameState = global::Rush.Chocology.Economy.Config.GAME_STATE.WIN;
                m_GamePlayManagerFields.WinPopup.ShowWinPopup(m_GamePlayManagerFields.Level, m_GamePlayManagerFields.StarGroup.CurrStar, global::Rush.Chocology.Gameplay.GameLevelManager.Instance.ConfigLevelGame.ListRewardsCoinValue[m_GamePlayManagerFields.StarGroup.CurrStar]);
                global::Rush.Chocology.Economy.Config.Runtime.SetCurrLevel(m_GamePlayManagerFields.Level + 1);
                global::Rush.Chocology.Economy.Config.Runtime.CurrSelectLevel = global::Rush.Chocology.Economy.Config.Runtime.CurrLevel;
                if (m_GamePlayManagerFields.Level >= 15 && m_GamePlayManagerFields.Level % 5 == 0 && !global::Rush.Chocology.Economy.Config.Runtime.Rate)
                {
                    OpenRatePopupInternal();
                }

                global::Rush.Chocology.Notifications.GlobalVar.Runtime.CallAnalytics("end_game");
            }
        }

        public void SetNextGame() => SetNextGameInternal();
        private void SetNextGameInternal()
        {
            SceneManager.LoadScene("Play");
        }

        private void SetFinishedGame()
        {
            m_GamePlayManagerFields.BtnPause.Interactable = false;
            m_GamePlayManagerFields.BtnPigBank.Interactable = false;
            //btnWatchVideo.Interactable = false;
            //btnRemoveAds.Interactable = false;
            m_GamePlayManagerFields.BtnShuffle.Interactable = false;
            m_GamePlayManagerFields.BtnUndo.Interactable = false;
            m_GamePlayManagerFields.BtnSuggest.Interactable = false;
        }

        public global::Rush.Chocology.Gameplay.LosePopup2 LosePopup { get => m_GamePlayManagerFields.LosePopup; set => m_GamePlayManagerFields.LosePopup = value; }

        public void SetGameLose() => SetGameLoseInternal();
        private void SetGameLoseInternal()
        {
            if (global::Rush.Chocology.Economy.Config.Runtime.GameState != global::Rush.Chocology.Economy.Config.GAME_STATE.LOSE)
            {
                SetFinishedGame();
                global::Rush.Chocology.Economy.Config.Runtime.GameState = global::Rush.Chocology.Economy.Config.GAME_STATE.LOSE;
                m_GamePlayManagerFields.LosePopup.ShowLosePopup(m_GamePlayManagerFields.Level, m_IsRevive);
            }
        }

        public void SetReplayGame() => SetReplayGameInternal();
        private void SetReplayGameInternal()
        {
            SceneManager.LoadScene("Play");
        }


        public void SetAddScore() => SetAddScoreInternal();
        private void SetAddScoreInternal()
        {
            m_GamePlayManagerFields.StarGroup.AddScore();
        }

        public global::Rush.Chocology.Shop.FreeItemPopup FreeItemPopup { get => m_GamePlayManagerFields.FreeItemPopup; set => m_GamePlayManagerFields.FreeItemPopup = value; }

        public void OpenFreeItemPopup(global::Rush.Chocology.Economy.Config.ITEMHELP_TYPE itemHelpType) => OpenFreeItemPopupInternal(itemHelpType);
        private void OpenFreeItemPopupInternal(global::Rush.Chocology.Economy.Config.ITEMHELP_TYPE itemHelpType)
        {
            global::Rush.Chocology.Economy.Config.Runtime.GameState = global::Rush.Chocology.Economy.Config.GAME_STATE.SHOP;
            m_GamePlayManagerFields.FreeItemPopup.OpenFreeItemPopup(itemHelpType);
        }

        public void SetFreeItemSuccess() => SetFreeItemSuccessInternal();
        private void SetFreeItemSuccessInternal()
        {
            global::Rush.Chocology.Economy.Config.Runtime.CountShowFreeItem = 0;
            Debug.Log("SetFreeItem_SuccessSetFreeItem_Success");
            SetUpdateCountItemInternal();
        }

        public global::Rush.Chocology.Shop.BuyItemPopup BuyItemPopup { get => m_GamePlayManagerFields.BuyItemPopup; set => m_GamePlayManagerFields.BuyItemPopup = value; }

        public void OpenBuyItemPopup(global::Rush.Chocology.Economy.Config.ITEMHELP_TYPE itemHelpType) => OpenBuyItemPopupInternal(itemHelpType);
        private void OpenBuyItemPopupInternal(global::Rush.Chocology.Economy.Config.ITEMHELP_TYPE itemHelpType)
        {
            global::Rush.Chocology.Economy.Config.Runtime.GameState = global::Rush.Chocology.Economy.Config.GAME_STATE.SHOP;
            m_GamePlayManagerFields.BuyItemPopup.OpenBuyItemPopup(itemHelpType);
        }

        public global::Rush.Chocology.Rewards.SpinPopup SpinPopup { get => m_GamePlayManagerFields.SpinPopup; set => m_GamePlayManagerFields.SpinPopup = value; }

        public void TouchWatchVideo() => TouchWatchVideoInternal();
        private void TouchWatchVideoInternal()
        {
            if (global::Rush.Chocology.Economy.Config.Runtime.GameState == global::Rush.Chocology.Economy.Config.GAME_STATE.PLAYING)
            {
                OpenSpinPopupInternal();
                HideTutHandGuideInternal();
            }
        }

        public void OpenSpinPopup() => OpenSpinPopupInternal();
        private void OpenSpinPopupInternal()
        {
            global::Rush.Chocology.Economy.Config.Runtime.GameState = global::Rush.Chocology.Economy.Config.GAME_STATE.SHOP;
            m_GamePlayManagerFields.SpinPopup.OpenSpinPopup();
        }

        public void SetUpdateCountItem() => SetUpdateCountItemInternal();
        private void SetUpdateCountItemInternal()
        {
            Debug.Log("SetFreeItem_SuccessSetFreeItem_Success");
            m_GamePlayManagerFields.TxtUndoCount.text = $"{(global::Rush.Chocology.Economy.Config.Runtime.ReadCountItemHelp(global::Rush.Chocology.Economy.Config.ITEMHELP_TYPE.UNDO))}";
            m_GamePlayManagerFields.TxtUndoCount.gameObject.SetActive(true);
            m_GamePlayManagerFields.TxtUndoAdd.gameObject.SetActive(false);
            if (global::Rush.Chocology.Economy.Config.Runtime.ReadCountItemHelp(global::Rush.Chocology.Economy.Config.ITEMHELP_TYPE.UNDO) == 0)
            {
                m_GamePlayManagerFields.TxtUndoAdd.gameObject.SetActive(true);
                m_GamePlayManagerFields.TxtUndoCount.gameObject.SetActive(false);
                //btnUndo.GetComponent<ButtonItemLockManager>().ShowAddIcon();
                m_GamePlayManagerFields.TxtUndoCount.text = $"+";
            }
            else
            {
                if (m_GamePlayManagerFields.Level >= 2)
                {
                    global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::Rush.Chocology.Rewards.ButtonItemLockManager>(m_GamePlayManagerFields.BtnUndo).ShowButtonItemLock(false);
                }
                else
                {
                    global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::Rush.Chocology.Rewards.ButtonItemLockManager>(m_GamePlayManagerFields.BtnUndo).ShowButtonItemLock(true);
                }
            }

            m_GamePlayManagerFields.TxtSuggestCount.text = $"{(global::Rush.Chocology.Economy.Config.Runtime.ReadCountItemHelp(global::Rush.Chocology.Economy.Config.ITEMHELP_TYPE.SUGGEST))}";
            m_GamePlayManagerFields.TxtSuggestCount.gameObject.SetActive(true);
            m_GamePlayManagerFields.TxtSuggestAdd.gameObject.SetActive(false);
            if (global::Rush.Chocology.Economy.Config.Runtime.ReadCountItemHelp(global::Rush.Chocology.Economy.Config.ITEMHELP_TYPE.SUGGEST) == 0)
            {
                m_GamePlayManagerFields.TxtSuggestAdd.gameObject.SetActive(true);
                m_GamePlayManagerFields.TxtSuggestCount.gameObject.SetActive(false);
                //btnSuggest.GetComponent<ButtonItemLockManager>().ShowAddIcon();
                m_GamePlayManagerFields.TxtSuggestCount.text = $"+";
            }
            else
            {
                if (m_GamePlayManagerFields.Level >= 3)
                {
                    global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::Rush.Chocology.Rewards.ButtonItemLockManager>(m_GamePlayManagerFields.BtnSuggest).ShowButtonItemLock(false);
                }
                else
                {
                    global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::Rush.Chocology.Rewards.ButtonItemLockManager>(m_GamePlayManagerFields.BtnSuggest).ShowButtonItemLock(true);
                }
            }

            m_GamePlayManagerFields.TxtShuffleCount.text = $"{(global::Rush.Chocology.Economy.Config.Runtime.ReadCountItemHelp(global::Rush.Chocology.Economy.Config.ITEMHELP_TYPE.SHUFFLE))}";
            m_GamePlayManagerFields.TxtShuffleCount.gameObject.SetActive(true);
            m_GamePlayManagerFields.TxtShuffleAdd.gameObject.SetActive(false);
            if (global::Rush.Chocology.Economy.Config.Runtime.ReadCountItemHelp(global::Rush.Chocology.Economy.Config.ITEMHELP_TYPE.SHUFFLE) == 0)
            {
                m_GamePlayManagerFields.TxtShuffleAdd.gameObject.SetActive(true);
                m_GamePlayManagerFields.TxtShuffleCount.gameObject.SetActive(false);
                //btnShuffle.GetComponent<ButtonItemLockManager>().ShowAddIcon();
                m_GamePlayManagerFields.TxtShuffleCount.text = $"+";
            }
            else
            {
                if (m_GamePlayManagerFields.Level >= 4)
                {
                    global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::Rush.Chocology.Rewards.ButtonItemLockManager>(m_GamePlayManagerFields.BtnShuffle).ShowButtonItemLock(false);
                }
                else
                {
                    global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::Rush.Chocology.Rewards.ButtonItemLockManager>(m_GamePlayManagerFields.BtnShuffle).ShowButtonItemLock(true);
                }
            }

            if (global::Rush.Chocology.Economy.Config.Runtime.ReadCountItemHelp(global::Rush.Chocology.Economy.Config.ITEMHELP_TYPE.SUGGEST) != 0 && global::Rush.Chocology.Economy.Config.Runtime.ReadCountItemHelp(global::Rush.Chocology.Economy.Config.ITEMHELP_TYPE.SHUFFLE) != 0 && global::Rush.Chocology.Economy.Config.Runtime.ReadCountItemHelp(global::Rush.Chocology.Economy.Config.ITEMHELP_TYPE.UNDO) != 0)
            {
                global::Rush.Chocology.Economy.Config.Runtime.CountShowFreeItem = 0;
            }
        }

        public void CloseShopSucces() => CloseShopSuccesInternal();
        private void CloseShopSuccesInternal()
        {
            global::Rush.Chocology.Economy.Config.Runtime.GameState = global::Rush.Chocology.Economy.Config.GAME_STATE.PLAYING;
        }

        public global::Rush.Chocology.Rewards.ChestPopup ChestPopup { get => m_GamePlayManagerFields.ChestPopup; set => m_GamePlayManagerFields.ChestPopup = value; }

        public void OpenChestPopup(bool isFullStar) => OpenChestPopupInternal(isFullStar);
        private void OpenChestPopupInternal(bool isFullStar)
        {
            m_GamePlayManagerFields.ChestPopup.OpenChestPopup(isFullStar);
            if (global::Rush.Chocology.LegacyGameplay.WinPopup.Instance.isActiveAndEnabled)
            {
                global::Rush.Chocology.LegacyGameplay.WinPopup.Instance.SetDisableNativeAd();
            }
        }

        public void CloseChestPopup() => CloseChestPopupInternal();
        private void CloseChestPopupInternal()
        {
            if (global::Rush.Chocology.LegacyGameplay.WinPopup.Instance.isActiveAndEnabled)
            {
                global::Rush.Chocology.LegacyGameplay.WinPopup.Instance.SetEnableNativeAd();
            }
        }

        public global::Rush.Chocology.Economy.RewardPopup RewardPopup { get => m_GamePlayManagerFields.RewardPopup; set => m_GamePlayManagerFields.RewardPopup = value; }

        public void OpenRewardPopup(List<global::Rush.Chocology.Economy.ConfigItemShopData> _listDatas, bool _isShowCollectx2 = true) => OpenRewardPopupInternal(_listDatas, _isShowCollectx2);
        private void OpenRewardPopupInternal(List<global::Rush.Chocology.Economy.ConfigItemShopData> _listDatas, bool _isShowCollectx2 = true)
        {
            global::Rush.Chocology.Economy.Config.Runtime.GameState = global::Rush.Chocology.Economy.Config.GAME_STATE.WIN;
            Debug.Log("OpenRewardPopup:" + _listDatas.Count);
            m_GamePlayManagerFields.RewardPopup.OpenRewardPopup(_listDatas, _isShowCollectx2);
        }

        public void SetRewardPpopupFinished() => SetRewardPpopupFinishedInternal();
        private void SetRewardPpopupFinishedInternal()
        {
            global::Rush.Chocology.Economy.Config.Runtime.GameState = global::Rush.Chocology.Economy.Config.GAME_STATE.PLAYING;
        }

        public global::Rush.Chocology.Rewards.PiggyBankPopup PiggyBankPopup { get => m_GamePlayManagerFields.PiggyBankPopup; set => m_GamePlayManagerFields.PiggyBankPopup = value; }

        public void TouchPiggyBank() => TouchPiggyBankInternal();
        private void TouchPiggyBankInternal()
        {
            if (global::Rush.Chocology.Economy.Config.Runtime.GameState == global::Rush.Chocology.Economy.Config.GAME_STATE.PLAYING)
            {
                OpenPiggyBankPopupInternal();
                global::Rush.Chocology.Integrations.Analytics.AdjustManager.instance.BreakPiggyBank();
                HideTutHandGuideInternal();
            }
        }

        public void OpenPiggyBankPopup() => OpenPiggyBankPopupInternal();
        private void OpenPiggyBankPopupInternal()
        {
            global::Rush.Chocology.Economy.Config.Runtime.GameState = global::Rush.Chocology.Economy.Config.GAME_STATE.SHOP;
            m_GamePlayManagerFields.PiggyBankPopup.OpenPiggyBank();
        }

        private 


        bool m_IsRevive = false;
        public void SetReviveSuccess() => SetReviveSuccessInternal();
        private void SetReviveSuccessInternal()
        {
            m_IsRevive = true;
            m_GamePlayManagerFields.StarGroup.ReviveInitStarGroup();
            global::Rush.Chocology.Economy.Config.Runtime.GameState = global::Rush.Chocology.Economy.Config.GAME_STATE.PLAYING;
            m_GamePlayManagerFields.BtnPause.Interactable = true;
            m_GamePlayManagerFields.BtnPigBank.Interactable = true;
            //btnWatchVideo.Interactable = true;
            //btnRemoveAds.Interactable = true;
            m_GamePlayManagerFields.BtnShuffle.Interactable = true;
            m_GamePlayManagerFields.BtnUndo.Interactable = true;
            m_GamePlayManagerFields.BtnSuggest.Interactable = true;
        }

        public global::UnityEngine.GameObject Tut1Obj { get => m_GamePlayManagerFields.Tut1Obj; set => m_GamePlayManagerFields.Tut1Obj = value; }

        private bool m_IsFisrtShowTut1 = true;
        public void ShowTut1() => ShowTut1Internal();
        private void ShowTut1Internal()
        {
            m_GamePlayManagerFields.Tut1Obj.gameObject.SetActive(true);
            //if (isFisrtShowTut1)
            //{
            //    isFisrtShowTut1 = false;
            //    GameLevelManager.instance.ShowTut1_HandGuild_First();
            //}
            //else {
            //    GameLevelManager.instance.ShowTut1_HandGuild();
            //}
            global::Rush.Chocology.Gameplay.GameLevelManager.Instance.ShowTut1HandGuild();
        }

        public void HideTut1() => HideTut1Internal();
        private void HideTut1Internal()
        {
            m_GamePlayManagerFields.Tut1Obj.gameObject.SetActive(false);
            global::Rush.Chocology.Economy.Config.Runtime.SetTut1Finished();
        }

        public global::UnityEngine.GameObject Tut2Obj { get => m_GamePlayManagerFields.Tut2Obj; set => m_GamePlayManagerFields.Tut2Obj = value; }

        private GameObject m_HandGuild;
        public void ShowTut2HandGuild() => ShowTut2HandGuildInternal();
        private void ShowTut2HandGuildInternal()
        {
            if (m_HandGuild == null)
            {
                m_HandGuild = Instantiate(Resources.Load("HandGuide2"), gameObject.transform) as GameObject;
            }

            float posX = m_GamePlayManagerFields.BtnUndo.transform.position.x;
            float posY = m_GamePlayManagerFields.BtnUndo.transform.position.y;
            m_HandGuild.transform.position = new Vector3(posX, posY, 0);
        }

        public void ShowTut2() => ShowTut2Internal();
        private void ShowTut2Internal()
        {
            global::Rush.Chocology.Economy.Config.Runtime.IsShowTut2 = true;
            global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::UnityEngine.RectTransform>(m_GamePlayManagerFields.BtnUndo.gameObject).SetAsLastSibling();
            m_GamePlayManagerFields.Tut2Obj.gameObject.SetActive(true);
            ShowTut2HandGuildInternal();
        }

        public void HideTut2() => HideTut2Internal();
        private void HideTut2Internal()
        {
            if (m_HandGuild != null)
                Destroy(m_HandGuild);
            m_GamePlayManagerFields.Tut2Obj.gameObject.SetActive(false);
            global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::UnityEngine.RectTransform>(m_GamePlayManagerFields.BtnUndo.gameObject).SetSiblingIndex(1);
            global::Rush.Chocology.Economy.Config.Runtime.IsShowTut2 = false;
            global::Rush.Chocology.Economy.Config.Runtime.SetTut2Finished();
        }

        public global::UnityEngine.GameObject Tut3Obj { get => m_GamePlayManagerFields.Tut3Obj; set => m_GamePlayManagerFields.Tut3Obj = value; }

        public void ShowTut3HandGuild() => ShowTut3HandGuildInternal();
        private void ShowTut3HandGuildInternal()
        {
            if (m_HandGuild == null)
            {
                m_HandGuild = Instantiate(Resources.Load("HandGuide2"), gameObject.transform) as GameObject;
            }

            float posX = m_GamePlayManagerFields.BtnSuggest.transform.position.x;
            float posY = m_GamePlayManagerFields.BtnSuggest.transform.position.y;
            m_HandGuild.transform.position = new Vector3(posX, posY, 0);
        }

        public void ShowTut3() => ShowTut3Internal();
        private void ShowTut3Internal()
        {
            global::Rush.Chocology.Economy.Config.Runtime.IsShowTut3 = true;
            global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::UnityEngine.RectTransform>(m_GamePlayManagerFields.BtnSuggest.gameObject).SetAsLastSibling();
            m_GamePlayManagerFields.Tut3Obj.gameObject.SetActive(true);
            ShowTut3HandGuildInternal();
        }

        public void HideTut3() => HideTut3Internal();
        private void HideTut3Internal()
        {
            HideTutHandGuideInternal();
            m_GamePlayManagerFields.Tut3Obj.gameObject.SetActive(false);
            global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::UnityEngine.RectTransform>(m_GamePlayManagerFields.BtnSuggest.gameObject).SetSiblingIndex(2);
            global::Rush.Chocology.Economy.Config.Runtime.IsShowTut3 = false;
            global::Rush.Chocology.Economy.Config.Runtime.SetTut3Finished();
        }

        public global::UnityEngine.GameObject Tut4Obj { get => m_GamePlayManagerFields.Tut4Obj; set => m_GamePlayManagerFields.Tut4Obj = value; }

        public void ShowTut4HandGuild() => ShowTut4HandGuildInternal();
        private void ShowTut4HandGuildInternal()
        {
            if (m_HandGuild == null)
            {
                m_HandGuild = Instantiate(Resources.Load("HandGuide2"), gameObject.transform) as GameObject;
            }

            float posX = m_GamePlayManagerFields.BtnShuffle.transform.position.x;
            float posY = m_GamePlayManagerFields.BtnShuffle.transform.position.y;
            m_HandGuild.transform.position = new Vector3(posX, posY, 0);
        }

        public void ShowTut4() => ShowTut4Internal();
        private void ShowTut4Internal()
        {
            global::Rush.Chocology.Economy.Config.Runtime.IsShowTut4 = true;
            global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::UnityEngine.RectTransform>(m_GamePlayManagerFields.BtnShuffle.gameObject).SetAsLastSibling();
            m_GamePlayManagerFields.Tut4Obj.gameObject.SetActive(true);
            ShowTut4HandGuildInternal();
        }

        public void HideTut4() => HideTut4Internal();
        private void HideTut4Internal()
        {
            HideTutHandGuideInternal();
            m_GamePlayManagerFields.Tut4Obj.gameObject.SetActive(false);
            global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::UnityEngine.RectTransform>(m_GamePlayManagerFields.BtnShuffle.gameObject).SetSiblingIndex(3);
            global::Rush.Chocology.Economy.Config.Runtime.IsShowTut4 = false;
            global::Rush.Chocology.Economy.Config.Runtime.SetTut4Finished();
        }

        public void HideTutHandGuide() => HideTutHandGuideInternal();
        private void HideTutHandGuideInternal()
        {
            if (m_HandGuild != null)
                Destroy(m_HandGuild);
            ResetTimeAutoSuggestInternal();
        }

        public void ShowTutNextLevel(Vector3 pos) => ShowTutNextLevelInternal(pos);
        private void ShowTutNextLevelInternal(Vector3 pos)
        {
            if (!global::Rush.Chocology.Economy.Config.Runtime.ReadTutFinished(global::Rush.Chocology.Economy.Config.TUT.TUT_NEXTLEVEL_LEVEL1))
            {
                global::Rush.Chocology.Economy.Config.Runtime.SetTutFinished(global::Rush.Chocology.Economy.Config.TUT.TUT_NEXTLEVEL_LEVEL1);
                if (m_HandGuild == null)
                {
                    m_HandGuild = Instantiate(Resources.Load("HandGuide"), gameObject.transform) as GameObject;
                    m_HandGuild.transform.position = pos;
                }
            }
        }

        public void ShowTutTouchSpin() => ShowTutTouchSpinInternal();
        private void ShowTutTouchSpinInternal()
        {
            if (m_HandGuild == null)
            {
                m_HandGuild = Instantiate(Resources.Load("HandGuide"), gameObject.transform) as GameObject;
            // handGuild.transform.position = btnWatchVideo.transform.position;
            }
        }

        public global::Rush.Chocology.Settings.RatePopup RatePopup { get => m_GamePlayManagerFields.RatePopup; set => m_GamePlayManagerFields.RatePopup = value; }

        public void OpenRatePopup() => OpenRatePopupInternal();
        private void OpenRatePopupInternal()
        {
            StartCoroutine(OpenRatePopupIEnumeratorInternal());
        }

        public IEnumerator OpenRatePopupIEnumerator() => OpenRatePopupIEnumeratorInternal();
        private IEnumerator OpenRatePopupIEnumeratorInternal()
        {
            yield return new WaitForSeconds(0.5f);
            m_GamePlayManagerFields.RatePopup.OpenRatePopup();
        }

        public global::UnityEngine.Transform SlotBGTranform { get => m_GamePlayManagerFields.SlotBGTranform; set => m_GamePlayManagerFields.SlotBGTranform = value; }

        public void SetSlotBGPos() => SetSlotBGPosInternal();
        private void SetSlotBGPosInternal()
        {
            Debug.Log(m_GamePlayManagerFields.SlotBGTranform.position);
        }

        private float m_TimeAutoSuggestShuffle = 0;
        private bool m_IsShowAutoSuggestShuffle = false;
        public void ResetTimeAutoSuggest() => ResetTimeAutoSuggestInternal();
        private void ResetTimeAutoSuggestInternal()
        {
            m_TimeAutoSuggestShuffle = 0;
            m_IsShowAutoSuggestShuffle = false;
        }

        public void ShowAutoSuggestShuffle() => ShowAutoSuggestShuffleInternal();
        private void ShowAutoSuggestShuffleInternal()
        {
            m_IsShowAutoSuggestShuffle = true;
            m_TimeAutoSuggestShuffle = 0;
            if (global::Rush.Chocology.Rewards.SpinPopup.Instance != null && global::Rush.Chocology.Rewards.SpinPopup.Instance.isActiveAndEnabled)
            {
                return;
            }

            if (global::Rush.Chocology.Rewards.PiggyBankPopup.Instance != null && global::Rush.Chocology.Rewards.PiggyBankPopup.Instance.isActiveAndEnabled)
            {
                return;
            }

            if (global::Rush.Chocology.Shop.FreeItemPopup.Instance != null && global::Rush.Chocology.Shop.FreeItemPopup.Instance.isActiveAndEnabled)
            {
                return;
            }

            if (global::Rush.Chocology.Shop.ShopPopup2.Instance != null && global::Rush.Chocology.Shop.ShopPopup2.Instance.isActiveAndEnabled)
            {
                return;
            }

            if (global::Rush.Chocology.Gameplay.GameLevelManager.Instance.CheckSuggestAvaiable() && global::Rush.Chocology.Economy.Config.Runtime.ReadCountItemHelp(global::Rush.Chocology.Economy.Config.ITEMHELP_TYPE.SUGGEST) > 0)
            {
                ShowTut3HandGuildInternal();
                return;
            }

            if (global::Rush.Chocology.Economy.Config.Runtime.ReadCountItemHelp(global::Rush.Chocology.Economy.Config.ITEMHELP_TYPE.SHUFFLE) > 0)
            {
                ShowTut4HandGuildInternal();
                return;
            }

            ShowTut3HandGuildInternal();
        }

        public global::Rush.Chocology.Shop.ShopPopup2 ShopPopup { get => m_GamePlayManagerFields.ShopPopup; set => m_GamePlayManagerFields.ShopPopup = value; }

        public void OpenShopPopup() => OpenShopPopupInternal();
        private void OpenShopPopupInternal()
        {
            m_GamePlayManagerFields.ShopPopup.OpenPopup();
        }

    }
}
