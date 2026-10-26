/*
 * Created on 2022
 *
 * Copyright (c) 2022 dotmobstudio
 * Support : dotmobstudio@gmail.com
 */
using LitJson;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BsplabsMobileAds;
using CloudOnce;

namespace Rush.Chocology.Economy
{
    [UnityEngine.Scripting.APIUpdating.MovedFrom(true, "", "Assembly-CSharp", "Config")]
    public class Config : UnityEngine.ScriptableObject
    {
        private static Config s_Runtime;
        public static Config Runtime => s_Runtime;

        public enum THEME_TYPE
        {
            fruits,
            test
        }

        private bool m_IsShowStarterPack = true;
        public bool IsShowStarterPack { get => m_IsShowStarterPack; set => m_IsShowStarterPack = value; }

        private global::Rush.Chocology.Economy.Config.THEME_TYPE m_CurrTheme = global::Rush.Chocology.Economy.Config.THEME_TYPE.fruits;
        public global::Rush.Chocology.Economy.Config.THEME_TYPE CurrTheme { get => m_CurrTheme; set => m_CurrTheme = value; }

        public enum ITEM_TYPE
        {
            ITEM_1 = 1,
            ITEM_2 = 2,
            ITEM_3 = 3,
            ITEM_4 = 4,
            ITEM_5 = 5,
            ITEM_6 = 6,
            ITEM_7 = 7,
            ITEM_8 = 8,
            ITEM_9 = 9,
            ITEM_10 = 10,
            ITEM_11 = 11,
            ITEM_12 = 12,
            ITEM_13 = 13,
            ITEM_14 = 14,
            ITEM_15 = 15,
            ITEM_16 = 16,
            ITEM_17 = 17,
            ITEM_18 = 18,
            ITEM_19 = 19,
            ITEM_20 = 20
        }

        public enum START_MOVE_TYPE
        {
            TOP,
            LEFT,
            RIGHT,
            BOTTOM
        }

        public enum ITEMTILE_STATE
        {
            START,
            START_TO_FLOOR,
            FLOOR,
            HOVER,
            MOVE_TO_SLOT,
            SLOT
        }

        private List<global::Rush.Chocology.Economy.Config.START_MOVE_TYPE> m_ListStartMoveType = new List<global::Rush.Chocology.Economy.Config.START_MOVE_TYPE>();
        public global::System.Collections.Generic.List<global::Rush.Chocology.Economy.Config.START_MOVE_TYPE> ListStartMoveType { get => m_ListStartMoveType; set => m_ListStartMoveType = value; }

        public enum GAME_STATE
        {
            START,
            PLAYING,
            SHOP,
            PAUSE,
            END,
            WIN,
            LOSE,
            REWARD
        }

        private global::Rush.Chocology.Economy.Config.GAME_STATE m_GameState = global::Rush.Chocology.Economy.Config.GAME_STATE.START;
        public global::Rush.Chocology.Economy.Config.GAME_STATE GameState { get => m_GameState; set => m_GameState = value; }

        public enum ITEMHELP_TYPE
        {
            UNDO,
            SUGGEST,
            SHUFFLE
        }

        public void SetCountItemHelp(global::Rush.Chocology.Economy.Config.ITEMHELP_TYPE itemHelpType, int count) => SetCountItemHelpInternal(itemHelpType, count);
        private void SetCountItemHelpInternal(global::Rush.Chocology.Economy.Config.ITEMHELP_TYPE itemHelpType, int count)
        {
            PlayerPrefs.SetInt(itemHelpType.ToString(), count);
            PlayerPrefs.Save();
        }

        public int ReadCountItemHelp(global::Rush.Chocology.Economy.Config.ITEMHELP_TYPE itemHelpType) => ReadCountItemHelpInternal(itemHelpType);
        private int ReadCountItemHelpInternal(global::Rush.Chocology.Economy.Config.ITEMHELP_TYPE itemHelpType)
        {
            if (itemHelpType == global::Rush.Chocology.Economy.Config.ITEMHELP_TYPE.UNDO)
                return PlayerPrefs.GetInt(itemHelpType.ToString(), 3);
            if (itemHelpType == global::Rush.Chocology.Economy.Config.ITEMHELP_TYPE.SHUFFLE)
                return PlayerPrefs.GetInt(itemHelpType.ToString(), 4);
            else
                return PlayerPrefs.GetInt(itemHelpType.ToString(), 4);
        }

        public const string COIN = "coin";
        public event Action<int> OnChangeCoin = delegate (int _coin)
        {
        };
        private int m_CurrCoin;
        public int CurrCoin { get => m_CurrCoin; set => m_CurrCoin = value; }

        public void SetCoin(int coinValue) => SetCoinInternal(coinValue);
        private void SetCoinInternal(int coinValue)
        {
            PlayerPrefs.SetInt(COIN, coinValue);
            PlayerPrefs.Save();
            m_CurrCoin = coinValue;
            OnChangeCoin(coinValue);
        }

        public int Coin
        {
            get
            {
                return PlayerPrefs.GetInt(COIN, 100);
            }
        }


        public enum SHOPITEM
        {
            COIN,
            UNDO,
            SUGGEST,
            SHUFFLE
        }

        public void BuySuccesItemShop(global::Rush.Chocology.Economy.ConfigItemShopData itemShopData) => BuySuccesItemShopInternal(itemShopData);
        private void BuySuccesItemShopInternal(global::Rush.Chocology.Economy.ConfigItemShopData itemShopData)
        {
            if (itemShopData.ShopItemType == global::Rush.Chocology.Economy.Config.SHOPITEM.UNDO)
            {
                SetCountItemHelpInternal(global::Rush.Chocology.Economy.Config.ITEMHELP_TYPE.UNDO, ReadCountItemHelpInternal(global::Rush.Chocology.Economy.Config.ITEMHELP_TYPE.UNDO) + itemShopData.CountItem);
            }
            else if (itemShopData.ShopItemType == global::Rush.Chocology.Economy.Config.SHOPITEM.SHUFFLE)
            {
                SetCountItemHelpInternal(global::Rush.Chocology.Economy.Config.ITEMHELP_TYPE.SHUFFLE, ReadCountItemHelpInternal(global::Rush.Chocology.Economy.Config.ITEMHELP_TYPE.SHUFFLE) + itemShopData.CountItem);
            }
            else if (itemShopData.ShopItemType == global::Rush.Chocology.Economy.Config.SHOPITEM.SUGGEST)
            {
                SetCountItemHelpInternal(global::Rush.Chocology.Economy.Config.ITEMHELP_TYPE.SUGGEST, ReadCountItemHelpInternal(global::Rush.Chocology.Economy.Config.ITEMHELP_TYPE.SUGGEST) + itemShopData.CountItem);
            }
            else if (itemShopData.ShopItemType == global::Rush.Chocology.Economy.Config.SHOPITEM.COIN)
            {
                SetCoinInternal(m_CurrCoin + itemShopData.CountItem);
            }
        }

        public global::Rush.Chocology.Economy.Config.SHOPITEM ConvertItemHelpTypeToShopItem(global::Rush.Chocology.Economy.Config.ITEMHELP_TYPE itemHelpType) => ConvertItemHelpTypeToShopItemInternal(itemHelpType);
        private global::Rush.Chocology.Economy.Config.SHOPITEM ConvertItemHelpTypeToShopItemInternal(global::Rush.Chocology.Economy.Config.ITEMHELP_TYPE itemHelpType)
        {
            if (itemHelpType == global::Rush.Chocology.Economy.Config.ITEMHELP_TYPE.UNDO)
            {
                return global::Rush.Chocology.Economy.Config.SHOPITEM.UNDO;
            }
            else if (itemHelpType == global::Rush.Chocology.Economy.Config.ITEMHELP_TYPE.SUGGEST)
            {
                return global::Rush.Chocology.Economy.Config.SHOPITEM.SUGGEST;
            }
            else
            {
                return global::Rush.Chocology.Economy.Config.SHOPITEM.SHUFFLE;
            }
        }

        public int ReadCountItemPackItemType(global::Rush.Chocology.Economy.Config.SHOPITEM shopItemType, global::Rush.Chocology.Economy.ConfigPackData configPackData) => ReadCountItemPackItemTypeInternal(shopItemType, configPackData);
        private int ReadCountItemPackItemTypeInternal(global::Rush.Chocology.Economy.Config.SHOPITEM shopItemType, global::Rush.Chocology.Economy.ConfigPackData configPackData)
        {
            for (int i = 0; i < configPackData.ConfigItemShopDatas.Count; i++)
            {
                if (configPackData.ConfigItemShopDatas[i].ShopItemType == shopItemType)
                {
                    return configPackData.ConfigItemShopDatas[i].CountItem;
                }
            }

            return 0;
        }

        public const string SOUND = "sound";
        private bool m_IsSound = true;
        public bool IsSound { get => m_IsSound; set => m_IsSound = value; }

        public void SetSound(bool _isSound) => SetSoundInternal(_isSound);
        private void SetSoundInternal(bool _isSound)
        {
            m_IsSound = _isSound;
            if (_isSound)
            {
                PlayerPrefs.SetInt(SOUND, 1);
            }
            else
            {
                PlayerPrefs.SetInt(SOUND, 0);
            }

            PlayerPrefs.Save();
        }

        public void LoadSound() => LoadSoundInternal();
        private void LoadSoundInternal()
        {
            int soundInt = PlayerPrefs.GetInt(SOUND, 1);
            if (soundInt == 1)
            {
                m_IsSound = true;
            }
            else
            {
                m_IsSound = false;
            }
        }

        public const string MUSIC = "music";
        private bool m_IsMusic = true;
        public bool IsMusic { get => m_IsMusic; set => m_IsMusic = value; }

        public void SetMusic(bool _isMusic) => SetMusicInternal(_isMusic);
        private void SetMusicInternal(bool _isMusic)
        {
            m_IsMusic = _isMusic;
            if (_isMusic)
            {
                PlayerPrefs.SetInt(MUSIC, 1);
            }
            else
            {
                PlayerPrefs.SetInt(MUSIC, 0);
            }

            PlayerPrefs.Save();
        }

        public void LoadMusic() => LoadMusicInternal();
        private void LoadMusicInternal()
        {
            int musicInt = PlayerPrefs.GetInt(MUSIC, 1);
            if (musicInt == 1)
            {
                m_IsMusic = true;
            }
            else
            {
                m_IsMusic = false;
            }
        }

        private int m_SpinPrice = 150;
        public int SpinPrice { get => m_SpinPrice; set => m_SpinPrice = value; }

        public long TimeStamp
        {
            get
            {
                Debug.Log(global::Rush.Chocology.Notifications.TimerFromServer.Instance.DateTimeNowOnServer.Subtract(new DateTime(2020, 1, 1)).TotalSeconds + " THIS UTC NOW : " + DateTime.UtcNow.Subtract(new DateTime(2020, 1, 1)).TotalSeconds);
                return (long)(global::Rush.Chocology.Notifications.TimerFromServer.Instance.DateTimeNowOnServer.Subtract(new DateTime(2020, 1, 1))).TotalSeconds;
            }
        }

        public const int TIME_SPIN = 24 * 60 * 60; //1 * 60 * 60;
        public const string SPIN_LASTTIME = "spin_lastTime";
        public event Action OnChangeSpin_LastTime = delegate ()
        {
        };
        public void SetSpinLastTime() => SetSpinLastTimeInternal();
        private void SetSpinLastTimeInternal()
        {
            long timeStamp = TimeStamp;
            PlayerPrefs.SetString(SPIN_LASTTIME, timeStamp + "");
            PlayerPrefs.Save();
            OnChangeSpin_LastTime();
        }

        public long SpinLastTime
        {
            get
            {
                string lastTime = PlayerPrefs.GetString(SPIN_LASTTIME, "0");
                return long.Parse(lastTime);
            }
        }

        public bool CheckSpinAvaiable() => CheckSpinAvaiableInternal();
        private bool CheckSpinAvaiableInternal()
        {
            long currTimeLastTime = global::Rush.Chocology.Economy.Config.Runtime.SpinLastTime;
            if (currTimeLastTime + global::Rush.Chocology.Economy.Config.TIME_SPIN < global::Rush.Chocology.Economy.Config.Runtime.TimeStamp)
            {
                return true;
            }

            return false;
        }


        public enum COUNTDOWN_TIME_TYPE
        {
            END
        }


        public const string PIGGYBANK = "piggyBank";
        private int m_CurrPiggyBankCoin = 0;
        public int CurrPiggyBankCoin { get => m_CurrPiggyBankCoin; set => m_CurrPiggyBankCoin = value; }

        private int m_AddPiggybankCoin = 5;
        public int AddPiggybankCoin { get => m_AddPiggybankCoin; set => m_AddPiggybankCoin = value; }

        private int m_PiggybankCoinMax = 100;
        public int PiggybankCoinMax { get => m_PiggybankCoinMax; set => m_PiggybankCoinMax = value; }

        private int m_PiggybankCoinMin = 0;
        public int PiggybankCoinMin { get => m_PiggybankCoinMin; set => m_PiggybankCoinMin = value; }

        private int m_PiggybankCoinXVALUE = 1;
        public int PiggybankCoinXVALUE { get => m_PiggybankCoinXVALUE; set => m_PiggybankCoinXVALUE = value; }

        public event Action OnChange_PiggyBank_Coin = delegate ()
        {
        };
        public void AddPiggyBankCoin() => AddPiggyBankCoinInternal();
        private void AddPiggyBankCoinInternal()
        {
            if (m_CurrPiggyBankCoin <= m_PiggybankCoinMax)
            {
                m_CurrPiggyBankCoin += m_AddPiggybankCoin;
                SetPiggyBankInternal(m_CurrPiggyBankCoin);
            }
        }

        public void SetPiggyBank(int piggyBankCoin) => SetPiggyBankInternal(piggyBankCoin);
        private void SetPiggyBankInternal(int piggyBankCoin)
        {
            m_CurrPiggyBankCoin = piggyBankCoin;
            PlayerPrefs.SetInt(PIGGYBANK, piggyBankCoin);
            PlayerPrefs.Save();
            OnChange_PiggyBank_Coin();
        }

        public int PiggyBank
        {
            get
            {
                return PlayerPrefs.GetInt(PIGGYBANK, 0);
            }
        }


        public const string CHEST_STAR = "chest_countStar";
        private int m_ChestStarMax = 15;
        public int ChestStarMax { get => m_ChestStarMax; set => m_ChestStarMax = value; }

        public void SetChestCountStar(int _countStar) => SetChestCountStarInternal(_countStar);
        private void SetChestCountStarInternal(int _countStar)
        {
            if (_countStar >= m_ChestStarMax)
                _countStar = m_ChestStarMax;
            PlayerPrefs.SetInt(CHEST_STAR, _countStar);
            PlayerPrefs.Save();
        }

        public int ChestCountStar
        {
            get
            {
                return PlayerPrefs.GetInt(CHEST_STAR, 0);
            }
        }


        public const string LEVEL_STAR = "levelStar";
        private Dictionary<int, int> m_CurrDicLevelStars = new Dictionary<int, int>();
        public global::System.Collections.Generic.Dictionary<int, int> CurrDicLevelStars { get => m_CurrDicLevelStars; set => m_CurrDicLevelStars = value; }

        public void SetLevelStar(int level, int star) => SetLevelStarInternal(level, star);
        private void SetLevelStarInternal(int level, int star)
        {
            if (m_CurrDicLevelStars.ContainsKey(level))
            {
                if (m_CurrDicLevelStars[level] < star)
                {
                    m_CurrDicLevelStars[level] = star;
                }
            }
            else
            {
                m_CurrDicLevelStars.Add(level, star);
            }

            List<string> listStrLevel = new List<string>();
            foreach (KeyValuePair<int, int> kvp in m_CurrDicLevelStars)
            {
                listStrLevel.Add(kvp.Key + "_" + kvp.Value);
            }

            Debug.Log(JsonMapper.ToJson(listStrLevel));
            PlayerPrefs.SetString(LEVEL_STAR, JsonMapper.ToJson(listStrLevel));
            PlayerPrefs.Save();
        }

        public void LoadLevelStar() => LoadLevelStarInternal();
        private void LoadLevelStarInternal()
        {
            m_CurrDicLevelStars.Clear();
            if (PlayerPrefs.HasKey(LEVEL_STAR))
            {
                string strlevelStar = PlayerPrefs.GetString(LEVEL_STAR);
                JsonData jsonData = JsonMapper.ToObject(strlevelStar);
                for (int i = 0; i < jsonData.Count; i++)
                {
                    string str = jsonData[i].ToString();
                    string[] strLevelStar = str.Split('_');
                    m_CurrDicLevelStars.Add(int.Parse(strLevelStar[0]), int.Parse(strLevelStar[1]));
                }
            }
        }

        public int LevelStar(int level) => LevelStarInternal(level);
        private int LevelStarInternal(int level)
        {
            int stars = 0;
            if (!m_CurrDicLevelStars.TryGetValue(level, out stars))
            {
                stars = 0;
            }

            return stars;
        }

        public int CountStars
        {
            get
            {
                int countStar = 0;
                foreach (KeyValuePair<int, int> kvp in m_CurrDicLevelStars)
                {
                    countStar += kvp.Value;
                }

                return countStar;
            }
        }

        private bool m_IsHackMode = false;
        public bool IsHackMode { get => m_IsHackMode; set => m_IsHackMode = value; }

        public const int MAX_LEVEL = 1000;
        private bool m_IsSelectLevel = false;
        public bool IsSelectLevel { get => m_IsSelectLevel; set => m_IsSelectLevel = value; }

        private int m_CurrSelectLevel = 1;
        public int CurrSelectLevel { get => m_CurrSelectLevel; set => m_CurrSelectLevel = value; }

        public const string CURR_LEVEL = "CURR_LEVEL";
        private int m_CurrLevel = 1;
        public int CurrLevel { get => m_CurrLevel; set => m_CurrLevel = value; }

        public void SetCurrLevel(int _currLevel) => SetCurrLevelInternal(_currLevel);
        private void SetCurrLevelInternal(int _currLevel)
        {
            if (_currLevel > m_CurrLevel)
            {
                m_CurrLevel = _currLevel;
                PlayerPrefs.SetInt(CURR_LEVEL, _currLevel);
                PlayerPrefs.Save();
                //set leaderboard
                Leaderboards.ChocologyLeaderboard.SubmitScore(m_CurrLevel);
            }
        }

        public void LoadCurrLevel() => LoadCurrLevelInternal();
        private void LoadCurrLevelInternal()
        {
            m_CurrLevel = PlayerPrefs.GetInt(CURR_LEVEL, 1);
        }


        public const string TUT_1 = "tut_1";
        public void SetTut1Finished() => SetTut1FinishedInternal();
        private void SetTut1FinishedInternal()
        {
            PlayerPrefs.SetInt(TUT_1, 1);
            PlayerPrefs.Save();
        }

        public bool Tut1Finished
        {
            get
            {
                if (PlayerPrefs.GetInt(TUT_1, 0) == 1)
                {
                    return true;
                }

                return false;
            }
        }

        public bool CheckTutorial1() => CheckTutorial1Internal();
        private bool CheckTutorial1Internal()
        {
            if (global::Rush.Chocology.Gameplay.GamePlayManager.Instance.Level == 1 && !Tut1Finished)
            {
                return true;
            }

            return false;
        }

        private bool m_IsShowTut2 = false;
        public bool IsShowTut2 { get => m_IsShowTut2; set => m_IsShowTut2 = value; }

        public const string TUT_2 = "tut_2";
        public void SetTut2Finished() => SetTut2FinishedInternal();
        private void SetTut2FinishedInternal()
        {
            PlayerPrefs.SetInt(TUT_2, 1);
            PlayerPrefs.Save();
        }

        public bool Tut2Finished
        {
            get
            {
                if (PlayerPrefs.GetInt(TUT_2, 1) == 1)
                {
                    return true;
                }

                return false;
            }
        }

        public bool CheckTutorial2() => CheckTutorial2Internal();
        private bool CheckTutorial2Internal()
        {
            if (global::Rush.Chocology.Gameplay.GamePlayManager.Instance.Level == 2 && !Tut2Finished)
            {
                return true;
            }

            return false;
        }

        private bool m_IsShowTut3 = false;
        public bool IsShowTut3 { get => m_IsShowTut3; set => m_IsShowTut3 = value; }

        public const string TUT_3 = "tut_3";
        public void SetTut3Finished() => SetTut3FinishedInternal();
        private void SetTut3FinishedInternal()
        {
            PlayerPrefs.SetInt(TUT_3, 1);
            PlayerPrefs.Save();
        }

        public bool Tut3Finished
        {
            get
            {
                if (PlayerPrefs.GetInt(TUT_3, 0) == 1)
                {
                    return true;
                }

                return false;
            }
        }

        public bool CheckTutorial3() => CheckTutorial3Internal();
        private bool CheckTutorial3Internal()
        {
            if (global::Rush.Chocology.Gameplay.GamePlayManager.Instance.Level == 3 && !Tut3Finished)
            {
                return true;
            }

            return false;
        }

        private bool m_IsShowTut4 = false;
        public bool IsShowTut4 { get => m_IsShowTut4; set => m_IsShowTut4 = value; }

        public const string TUT_4 = "tut_4";
        public void SetTut4Finished() => SetTut4FinishedInternal();
        private void SetTut4FinishedInternal()
        {
            PlayerPrefs.SetInt(TUT_4, 1);
            PlayerPrefs.Save();
        }

        public bool Tut4Finished
        {
            get
            {
                if (PlayerPrefs.GetInt(TUT_4, 0) == 1)
                {
                    return true;
                }

                return false;
            }
        }

        public bool CheckTutorial4() => CheckTutorial4Internal();
        private bool CheckTutorial4Internal()
        {
            if (global::Rush.Chocology.Gameplay.GamePlayManager.Instance.Level == 4 && !Tut4Finished)
            {
                return true;
            }

            return false;
        }

        public enum TUT
        {
            TUT_NEXTLEVEL_LEVEL1,
            TUT_TOUCHSPIN_LEVEL5
        }

        public void SetTutFinished(global::Rush.Chocology.Economy.Config.TUT tut) => SetTutFinishedInternal(tut);
        private void SetTutFinishedInternal(global::Rush.Chocology.Economy.Config.TUT tut)
        {
            PlayerPrefs.SetInt(tut.ToString(), 1);
            PlayerPrefs.Save();
        }

        public bool ReadTutFinished(global::Rush.Chocology.Economy.Config.TUT tut) => ReadTutFinishedInternal(tut);
        private bool ReadTutFinishedInternal(global::Rush.Chocology.Economy.Config.TUT tut)
        {
            if (PlayerPrefs.GetInt(tut.ToString(), 0) == 1)
            {
                return true;
            }

            return false;
        }


        public const int interstitialAd_levelShowAd = 2;
        public const int interstitialAd_SHOW_WIN_INTERVAL = 2;
        public const int interstitialAd_SHOW_LOSE_INTERVAL = 2;
        private int m_InterstitialAdCountWin = 0;
        public int InterstitialAdCountWin { get => m_InterstitialAdCountWin; set => m_InterstitialAdCountWin = value; }

        private int m_InterstitialAdCountLose = 0;
        public int InterstitialAdCountLose { get => m_InterstitialAdCountLose; set => m_InterstitialAdCountLose = value; }

        private int m_InterstitialAdCountRestart = 0;
        public int InterstitialAdCountRestart { get => m_InterstitialAdCountRestart; set => m_InterstitialAdCountRestart = value; }

        public const int interstitialAd_SHOW_PAUSE_INTERVAL = 1;
        private int m_InterstitialAdCountPause = 0;
        public int InterstitialAdCountPause { get => m_InterstitialAdCountPause; set => m_InterstitialAdCountPause = value; }


        public enum IAP_ID
        {
            tilematch_starter_pack,
            piggy_bank,
            removead,
            removead_and_combo10,
            combo_10,
            undo_10,
            suggest_10,
            shuffle_10,
            coin_1000,
            growth_bundle,
            deluxe_bundle,
            premium_bundle,
            coin_2000,
            coin_5000,
            tile_special_offer,
        }

        public const string IAP = "iap_";
        public void SetBuyIAP(global::Rush.Chocology.Economy.Config.IAP_ID idPack) => SetBuyIAPInternal(idPack);
        private void SetBuyIAPInternal(global::Rush.Chocology.Economy.Config.IAP_ID idPack)
        {
            PlayerPrefs.SetInt(IAP + idPack.ToString(), 1);
            PlayerPrefs.Save();
        }

        public bool ReadBuyIAP(global::Rush.Chocology.Economy.Config.IAP_ID idPack) => ReadBuyIAPInternal(idPack);
        private bool ReadBuyIAPInternal(global::Rush.Chocology.Economy.Config.IAP_ID idPack)
        {
            int buyed = PlayerPrefs.GetInt(IAP + idPack.ToString(), 0);
            if (buyed == 1)
                return true;
            return false;
        }


        public bool CheckWideScreen() => CheckWideScreenInternal();
        private bool CheckWideScreenInternal()
        {
            if (Screen.width * 1f / Screen.height > 1242f / 2208f)
            {
                return true;
            }

            return false;
        }

        public const string RATE = "rate";
        public void SetRate() => SetRateInternal();
        private void SetRateInternal()
        {
            PlayerPrefs.SetInt(RATE, 1);
            PlayerPrefs.Save();
        }

        public bool Rate
        {
            get
            {
                if (PlayerPrefs.GetInt(RATE, 0) == 1)
                    return true;
                return false;
            }
        }


        public const string REMOVE_AD = "remove_Ad";
        public void SetRemoveAd() => SetRemoveAdInternal();
        private void SetRemoveAdInternal()
        {
            BspLabsAdsMobile.Instance.RemoveAds(true);
            PlayerPrefs.SetInt(REMOVE_AD, 1);
            PlayerPrefs.Save();
        }

        public bool RemoveAd
        {
            get
            {
                if (PlayerPrefs.GetInt(REMOVE_AD, 0) == 1)
                    return true;
                return false;
            }
        }

        private float m_AutoTimeToSuggestShuffle = 10f;
        public float AutoTimeToSuggestShuffle { get => m_AutoTimeToSuggestShuffle; set => m_AutoTimeToSuggestShuffle = value; }

        private int m_CoinPriceItem = 100;
        public int CoinPriceItem { get => m_CoinPriceItem; set => m_CoinPriceItem = value; }

        private int m_CountShowFreeItem = 0;
        public int CountShowFreeItem { get => m_CountShowFreeItem; set => m_CountShowFreeItem = value; }

        private int m_IntervalShowFreeitemPopup = 3;
        public int IntervalShowFreeitemPopup { get => m_IntervalShowFreeitemPopup; set => m_IntervalShowFreeitemPopup = value; }

        public string FormatTime(int time) => FormatTimeInternal(time);
        private string FormatTimeInternal(int time)
        {
            int hour = time / 3600;
            int minus = (time - hour * 3600) / 60;
            int second = time - hour * 3600 - minus * 60;
            return String.Format("{0:00}:{1:00}:{2:00}", hour, minus, second);
        }

        public const string DAILY_FREECOIN = "daily_freecoin";
        public void SetDailyFreeCoin() => SetDailyFreeCoinInternal();
        private void SetDailyFreeCoinInternal()
        {
            PlayerPrefs.SetInt(DAILY_FREECOIN, global::Rush.Chocology.Economy.Config.Runtime.CurrDayTime);
            PlayerPrefs.Save();
        }

        public int DailyFreeCoin
        {
            get
            {
                return PlayerPrefs.GetInt(DAILY_FREECOIN, 0);
            }
        }

        public bool CheckDailyFreeCoin() => CheckDailyFreeCoinInternal();
        private bool CheckDailyFreeCoinInternal()
        {
            return global::Rush.Chocology.Economy.Config.Runtime.CurrDayTime > DailyFreeCoin;
        }


        public const string DAILY_VIDEOCOIN = "daily_videocoin";
        public const string DAILY_VIDEOCOIN_COUNT = "daily_videocoin_count";
        public const int DAILY_VIDEOCOIN_MAX = 10;
        public void SetDailyVideoCoin() => SetDailyVideoCoinInternal();
        private void SetDailyVideoCoinInternal()
        {
            PlayerPrefs.SetInt(DAILY_VIDEOCOIN, global::Rush.Chocology.Economy.Config.Runtime.CurrDayTime);
            PlayerPrefs.Save();
        }

        public int DailyVideoCoin
        {
            get
            {
                return PlayerPrefs.GetInt(DAILY_VIDEOCOIN, 0);
            }
        }

        public bool CheckDailyVideoCoin() => CheckDailyVideoCoinInternal();
        private bool CheckDailyVideoCoinInternal()
        {
            return global::Rush.Chocology.Economy.Config.Runtime.CurrDayTime > DailyVideoCoin;
        }

        public void SetDailyVideoCoinAddCount() => SetDailyVideoCoinAddCountInternal();
        private void SetDailyVideoCoinAddCountInternal()
        {
            int currCount = DailyVideoCoinCount;
            if (currCount > 0)
            {
                SetDailyVideoCoinCountInternal(currCount - 1);
            }
        }

        public void SetDailyVideoCoinCount(int count) => SetDailyVideoCoinCountInternal(count);
        private void SetDailyVideoCoinCountInternal(int count)
        {
            PlayerPrefs.SetInt(DAILY_VIDEOCOIN_COUNT, count);
            PlayerPrefs.Save();
        }

        public int DailyVideoCoinCount
        {
            get
            {
                return PlayerPrefs.GetInt(DAILY_VIDEOCOIN_COUNT, DAILY_VIDEOCOIN_MAX);
            }
        }

        public int CurrDayTime
        {
            get
            {
                int currDayTime = DateTime.Now.DayOfYear + DateTime.Now.Year * 10000;
                return currDayTime;
            }
        }

        public const int PRICE_COIN_REVIVE = 100;

        public const string DAILY_FREEREVIVE = "daily_freerevive";
        public void SetDailyFreeRevive() => SetDailyFreeReviveInternal();
        private void SetDailyFreeReviveInternal()
        {
            PlayerPrefs.SetInt(DAILY_FREEREVIVE, global::Rush.Chocology.Economy.Config.Runtime.CurrDayTime);
            PlayerPrefs.Save();
        }

        public int DailyFreeRevive
        {
            get
            {
                return PlayerPrefs.GetInt(DAILY_FREEREVIVE, 0);
            }
        }

        public bool CheckDailyFreeRevive() => CheckDailyFreeReviveInternal();
        private bool CheckDailyFreeReviveInternal()
        {
            // return Config.GetCurrDayTime() > GetDaily_FreeRevive();
            return true;
        }

        private void OnEnable()
        {
            s_Runtime = this;
        }

        public void ActivateRuntime() => ActivateRuntimeInternal();
        private void ActivateRuntimeInternal()
        {
            s_Runtime = this;
        }

    // #region DAILY_FREESPIN
    //
    // public const string DAILY_FREEREVIVE = "daily_freerevive";
    //
    // public static void SetDaily_FreeRevive()
    // {
    //     PlayerPrefs.SetInt(DAILY_FREEREVIVE,Config.GetCurrDayTime());
    //     PlayerPrefs.Save();
    // }
    //
    // public static int GetDaily_FreeRevive()
    // {
    //     return PlayerPrefs.GetInt(DAILY_FREEREVIVE, 0);
    // }
    //
    // public static bool CheckDaily_FreeRevive()
    // {
    //     // return Config.GetCurrDayTime() > GetDaily_FreeRevive();
    //     return true;
    // }
    //
    // #endregion
    }
}
