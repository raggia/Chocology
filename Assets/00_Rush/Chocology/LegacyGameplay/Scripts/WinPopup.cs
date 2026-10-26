using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
using BsplabsMobileAds;

namespace Rush.Chocology.LegacyGameplay
{
    [UnityEngine.Scripting.APIUpdating.MovedFrom(true, "", "Assembly-CSharp", "WinPopup")]
    public class WinPopup : MonoBehaviour
    {
        [global::System.Serializable]
        private sealed class WinPopupField
        {
            [UnityEngine.Serialization.FormerlySerializedAs("popup")]
            [UnityEngine.SerializeField]
            private GameObject m_Popup;
            public global::UnityEngine.GameObject Popup { get => m_Popup; set => m_Popup = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("btnReward")]
            [UnityEngine.SerializeField]
            private BBUIButton m_BtnReward;
            public global::BBUIButton BtnReward { get => m_BtnReward; set => m_BtnReward = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("btnNext")]
            [UnityEngine.SerializeField]
            private BBUIButton m_BtnNext;
            public global::BBUIButton BtnNext { get => m_BtnNext; set => m_BtnNext = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("btnChest")]
            [UnityEngine.SerializeField]
            private BBUIButton m_BtnChest;
            public global::BBUIButton BtnChest { get => m_BtnChest; set => m_BtnChest = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("objLight")]
            [UnityEngine.SerializeField]
            private Image m_ObjLight;
            public global::UnityEngine.UI.Image ObjLight { get => m_ObjLight; set => m_ObjLight = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("listStars")]
            [UnityEngine.SerializeField]
            private List<GameObject> m_ListStars;
            public global::System.Collections.Generic.List<global::UnityEngine.GameObject> ListStars { get => m_ListStars; set => m_ListStars = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("bgStars")]
            [UnityEngine.SerializeField]
            private GameObject m_BgStars;
            public global::UnityEngine.GameObject BgStars { get => m_BgStars; set => m_BgStars = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("txtRewardCoin")]
            [UnityEngine.SerializeField]
            private Text m_TxtRewardCoin;
            public global::UnityEngine.UI.Text TxtRewardCoin { get => m_TxtRewardCoin; set => m_TxtRewardCoin = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("txtBtnReward")]
            [UnityEngine.SerializeField]
            private Text m_TxtBtnReward;
            public global::UnityEngine.UI.Text TxtBtnReward { get => m_TxtBtnReward; set => m_TxtBtnReward = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("txtBtnReward2")]
            [UnityEngine.SerializeField]
            private Text m_TxtBtnReward2;
            public global::UnityEngine.UI.Text TxtBtnReward2 { get => m_TxtBtnReward2; set => m_TxtBtnReward2 = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("lockGroup")]
            [UnityEngine.SerializeField]
            private GameObject m_LockGroup;
            public global::UnityEngine.GameObject LockGroup { get => m_LockGroup; set => m_LockGroup = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("logo")]
            [UnityEngine.SerializeField]
            private Image m_Logo;
            public global::UnityEngine.UI.Image Logo { get => m_Logo; set => m_Logo = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("bgPopup")]
            [UnityEngine.SerializeField]
            private Image m_BgPopup;
            public global::UnityEngine.UI.Image BgPopup { get => m_BgPopup; set => m_BgPopup = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("txtOffer")]
            [UnityEngine.SerializeField]
            private Text m_TxtOffer;
            public global::UnityEngine.UI.Text TxtOffer { get => m_TxtOffer; set => m_TxtOffer = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("txtOfferShadow")]
            [UnityEngine.SerializeField]
            private Text m_TxtOfferShadow;
            public global::UnityEngine.UI.Text TxtOfferShadow { get => m_TxtOfferShadow; set => m_TxtOfferShadow = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("itemShopRemoveAd")]
            [UnityEngine.SerializeField]
            private GameObject m_ItemShopRemoveAd;
            public global::UnityEngine.GameObject ItemShopRemoveAd { get => m_ItemShopRemoveAd; set => m_ItemShopRemoveAd = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("txtChestCountStar")]
            [UnityEngine.SerializeField]
            private Text m_TxtChestCountStar;
            public global::UnityEngine.UI.Text TxtChestCountStar { get => m_TxtChestCountStar; set => m_TxtChestCountStar = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("imgChestProgress")]
            [UnityEngine.SerializeField]
            private Image m_ImgChestProgress;
            public global::UnityEngine.UI.Image ImgChestProgress { get => m_ImgChestProgress; set => m_ImgChestProgress = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("listChest_EfxStars")]
            [UnityEngine.SerializeField]
            private List<Image> m_ListChestEfxStars = new List<Image>();
            public global::System.Collections.Generic.List<global::UnityEngine.UI.Image> ListChestEfxStars { get => m_ListChestEfxStars; set => m_ListChestEfxStars = value; }
        }

        [global::UnityEngine.SerializeField]
        private WinPopupField m_WinPopupFields = new WinPopupField();
        private static global::Rush.Chocology.LegacyGameplay.WinPopup s_Instance;
        public static global::Rush.Chocology.LegacyGameplay.WinPopup Instance { get => s_Instance; set => s_Instance = value; }
        public global::UnityEngine.GameObject Popup { get => m_WinPopupFields.Popup; set => m_WinPopupFields.Popup = value; }
        public global::BBUIButton BtnReward { get => m_WinPopupFields.BtnReward; set => m_WinPopupFields.BtnReward = value; }
        public global::BBUIButton BtnNext { get => m_WinPopupFields.BtnNext; set => m_WinPopupFields.BtnNext = value; }
        public global::BBUIButton BtnChest { get => m_WinPopupFields.BtnChest; set => m_WinPopupFields.BtnChest = value; }
        public global::UnityEngine.UI.Image ObjLight { get => m_WinPopupFields.ObjLight; set => m_WinPopupFields.ObjLight = value; }
        public global::System.Collections.Generic.List<global::UnityEngine.GameObject> ListStars { get => m_WinPopupFields.ListStars; set => m_WinPopupFields.ListStars = value; }
        public global::UnityEngine.GameObject BgStars { get => m_WinPopupFields.BgStars; set => m_WinPopupFields.BgStars = value; }
        public global::UnityEngine.UI.Text TxtRewardCoin { get => m_WinPopupFields.TxtRewardCoin; set => m_WinPopupFields.TxtRewardCoin = value; }
        public global::UnityEngine.UI.Text TxtBtnReward { get => m_WinPopupFields.TxtBtnReward; set => m_WinPopupFields.TxtBtnReward = value; }
        public global::UnityEngine.UI.Text TxtBtnReward2 { get => m_WinPopupFields.TxtBtnReward2; set => m_WinPopupFields.TxtBtnReward2 = value; }
        public global::UnityEngine.GameObject LockGroup { get => m_WinPopupFields.LockGroup; set => m_WinPopupFields.LockGroup = value; }
        public global::UnityEngine.UI.Image Logo { get => m_WinPopupFields.Logo; set => m_WinPopupFields.Logo = value; }
        public global::UnityEngine.UI.Image BgPopup { get => m_WinPopupFields.BgPopup; set => m_WinPopupFields.BgPopup = value; }

        private void Awake()
        {
            s_Instance = this;
        }

        // Start is called before the first frame update
        void Start()
        {
            //btnxReward.OnPointerClickCallBack_Completed.AddListener(TouchXReward);
            m_WinPopupFields.BtnChest.OnPointerClickCallBack_Completed.AddListener(TouchOpenChestInternal);
            m_WinPopupFields.BtnReward.OnPointerClickCallBack_Completed.AddListener(TouchXRewardInternal);
            m_WinPopupFields.BtnNext.OnPointerClickCallBack_Completed.AddListener(TouchNextInternal);
        }

        void OnEnable()
        {
        }

        public void BuyRemoveAd(global::Rush.Chocology.Economy.ConfigPackData configPackData) => BuyRemoveAdInternal(configPackData);
        private void BuyRemoveAdInternal(global::Rush.Chocology.Economy.ConfigPackData configPackData)
        {
            m_WinPopupFields.LockGroup.gameObject.SetActive(true);
            //#if UNITY_EDITOR
            //        btnBuy.Interactable = false;
            //        BuyStartPackSuccess();
            //        return;
            //#endif
            global::Rush.Chocology.Integrations.Purchasing.PurchaserManager.Instance.BuyConsumable(configPackData.IdPack, (string _iapID, global::Rush.Chocology.Integrations.Purchasing.PurchaserManager.IAP_CALLBACK_STATE _state) =>
            {
                if (_state == global::Rush.Chocology.Integrations.Purchasing.PurchaserManager.IAP_CALLBACK_STATE.SUCCESS)
                {
                    m_WinPopupFields.LockGroup.gameObject.SetActive(false);
                    if (_iapID.Equals(global::Rush.Chocology.Economy.Config.IAP_ID.removead.ToString()))
                    {
                        global::Rush.Chocology.Economy.Config.Runtime.SetRemoveAd();
                        global::Rush.Chocology.Notifications.NotificationPopup.Instance.AddNotification("RemoveAd Success!");
                        m_WinPopupFields.ItemShopRemoveAd.SetActive(false);
                    }

                    global::Rush.Chocology.Notifications.GlobalVar.Runtime.CallAnalytics($"payment_{(configPackData.IdPack)}_success");
                }
                else
                {
                    m_WinPopupFields.LockGroup.gameObject.SetActive(false);
                    global::Rush.Chocology.Notifications.NotificationPopup.Instance.AddNotification("Buy Fail!");
                    global::Rush.Chocology.Notifications.GlobalVar.Runtime.CallAnalytics($"payment_{(configPackData.IdPack)}_cancel");
                }

                global::Rush.Chocology.SceneFlow.LoadingManager.Instance.CloseLoading();
            });
        }

        public void TouchHome() => TouchHomeInternal();
        private void TouchHomeInternal()
        {
            m_WinPopupFields.LockGroup.gameObject.SetActive(true);
            SceneManager.LoadScene("Menu");
        }

        public void TouchNext() => TouchNextInternal();
        private void TouchNextInternal()
        {
            {
                global::Rush.Chocology.Gameplay.GamePlayManager.Instance.SetNextGame();
            }
        }

        public void TouchXReward() => TouchXRewardInternal();
        private void TouchXRewardInternal()
        {
        //        if (AdmobManager.instance.isRewardAds_Avaiable())
        //        {
        //            lockGroup.gameObject.SetActive(true);
        //            AdmobManager.instance.ShowRewardAd_CallBack((AdmobManager.ADS_CALLBACK_STATE state) => {
        //                if (state == AdmobManager.ADS_CALLBACK_STATE.SUCCESS)
        //                {
        //                    lockGroup.gameObject.SetActive(false);
        //                    btnReward.Interactable = false;
        //                    xReward_Finished();
        //                }
        //                else
        //                {
        //                    lockGroup.gameObject.SetActive(false);
        //                }
        //            });
        //        }
        //        else
        //        {
        //            GamePlayManager.instance.SetNextGame();
        //        }
        }

        IEnumerator WaitToNextGame(float x)
        {
            yield return new WaitForSeconds(x);
            global::Rush.Chocology.Gameplay.GamePlayManager.Instance.SetNextGame();
        }

        public void XRewardFinished() => XRewardFinishedInternal();
        private void XRewardFinishedInternal()
        {
            m_WinPopupFields.TxtRewardCoin.text = $"{(10 * m_CoinValue)}";
            m_WinPopupFields.TxtRewardCoin.transform.DOPunchScale(new Vector3(0.2f, 0.2f, 0.2f), 2f, 5, 1).SetEase(Ease.InQuart);
            global::Rush.Chocology.Economy.Config.Runtime.SetCoin(global::Rush.Chocology.Economy.Config.Runtime.Coin + 9 * m_CoinValue);
            StartCoroutine(WaitToNextGame(1.5f));
        }

        public void TouchOpenChest() => TouchOpenChestInternal();
        private void TouchOpenChestInternal()
        {
        /*lockGroup.gameObject.SetActive(true);
        AdmobManager.instance.ShowRewardAd_CallBack((AdmobManager.ADS_CALLBACK_STATE state) => {
            if (state == AdmobManager.ADS_CALLBACK_STATE.SUCCESS)
            {
                btnChest.GetComponent<Image>().color = new Color(200f / 255f, 200f / 255f, 200f / 255f, 1f);
                btnChest.Interactable = false;
                sequence_iconChestWatchVideo.Kill();
                iconChestWatchVideo.gameObject.SetActive(false);
                GamePlayManager.instance.OpenChestPopup(false);
            }
            else
            {
                lockGroup.gameObject.SetActive(false);
            }
        });*/
        }

        private int m_CountStar;
        private int m_CoinValue;
        private int m_AddStar;
        private int m_ThisLevel;
        public void ShowWinPopup(int _level, int _countStar, int _coinValue) => ShowWinPopupInternal(_level, _countStar, _coinValue);
        private void ShowWinPopupInternal(int _level, int _countStar, int _coinValue)
        {
            //AdmobManager.instance.Request_Banner();
            //if (_level < 2)
            //{
            //    AdmobManager.instance.HideBannerAd();
            //}
            global::Rush.Chocology.Audio.SoundManager.Instance.PlaySoundWin();
            m_ThisLevel = _level;
            global::Rush.Chocology.Economy.Config.Runtime.InterstitialAdCountWin++;
            Debug.Log("_countStar" + _countStar + "_" + global::Rush.Chocology.Economy.Config.Runtime.CurrSelectLevel + "_" + global::Rush.Chocology.Economy.Config.Runtime.LevelStar(global::Rush.Chocology.Economy.Config.Runtime.CurrSelectLevel));
            m_CountStar = _countStar;
            m_CoinValue = 4 * m_CountStar;
            gameObject.SetActive(true);
            m_WinPopupFields.TxtRewardCoin.text = $"{(m_CoinValue)}";
            global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::Rush.Chocology.Shop.ItemShopIAP>(m_WinPopupFields.ItemShopRemoveAd).InitIAP();
            global::Rush.Chocology.Economy.Config.Runtime.SetCoin(global::Rush.Chocology.Economy.Config.Runtime.Coin + m_CoinValue);
            m_AddStar = m_CountStar - global::Rush.Chocology.Economy.Config.Runtime.LevelStar(global::Rush.Chocology.Economy.Config.Runtime.CurrSelectLevel);
            if (m_AddStar < 0)
                m_AddStar = 0;
            Debug.Log("AddStar " + m_AddStar);
            global::Rush.Chocology.Economy.Config.Runtime.SetLevelStar(_level, _countStar);
            InitViews();
        }

        private void InitViews()
        {
            m_WinPopupFields.LockGroup.gameObject.SetActive(false);
            m_WinPopupFields.Popup.gameObject.SetActive(false);
            m_WinPopupFields.BtnNext.gameObject.SetActive(false);
            m_WinPopupFields.BtnReward.gameObject.SetActive(false);
            m_WinPopupFields.TxtOffer.text = $"{(10 * m_CoinValue)}";
            m_WinPopupFields.TxtOfferShadow.text = $"{(10 * m_CoinValue)}";
            for (int i = 0; i < m_WinPopupFields.ListStars.Count; i++)
            {
                m_WinPopupFields.ListStars[i].gameObject.SetActive(false);
            }

            //Debug.Log("AdmobManager.instance.nativeAd_iconTexture");
            //Debug.Log(AdmobManager.instance.nativeAd);
            //if (AdmobManager.instance.nativeAd != null)
            //{
            //    SetEnableNativeAd();
            //    logo.gameObject.SetActive(false);
            //    nativeAdPanel.SetInitNativeAd(AdmobManager.instance.nativeAd);
            //}
            //else
            //{
            //    SetDisableNativeAd();
            //    logo.gameObject.SetActive(true);
            //    nativeAdPanel.gameObject.SetActive(false);
            //}
            InitViewsShowViewInternal();
            InitChestStarInternal();
        }

        private Sequence m_SequenceShowView;
        public void InitViewsShowView() => InitViewsShowViewInternal();
        private void InitViewsShowViewInternal()
        {
            if (m_SequenceShowView != null)
            {
                m_SequenceShowView.Kill();
            }

            m_SequenceShowView = DOTween.Sequence();
            m_SequenceShowView.InsertCallback(0.01f, () =>
            {
                m_WinPopupFields.Popup.gameObject.SetActive(true);
                global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::BBUIView>(m_WinPopupFields.Popup).ShowView();
            });
            m_SequenceShowView.InsertCallback(0.4f, () =>
            {
                if (m_CountStar >= 1)
                {
                    global::Rush.Chocology.Audio.SoundManager.Instance.PlaySoundWinStarPop();
                    m_WinPopupFields.ListStars[0].gameObject.SetActive(true);
                    global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::BBUIView>(m_WinPopupFields.ListStars[0]).ShowView();
                }
            });
            m_SequenceShowView.InsertCallback(0.6f, () =>
            {
                if (m_CountStar >= 2)
                {
                    global::Rush.Chocology.Audio.SoundManager.Instance.PlaySoundWinStarPop();
                    m_WinPopupFields.ListStars[1].gameObject.SetActive(true);
                    global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::BBUIView>(m_WinPopupFields.ListStars[1]).ShowView();
                }
            });
            m_SequenceShowView.InsertCallback(0.8f, () =>
            {
                if (m_CountStar >= 3)
                {
                    global::Rush.Chocology.Audio.SoundManager.Instance.PlaySoundWinStarPop();
                    m_WinPopupFields.ListStars[2].gameObject.SetActive(true);
                    global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::BBUIView>(m_WinPopupFields.ListStars[2]).ShowView();
                }
            });
            m_SequenceShowView.InsertCallback(0.8f, () =>
            {
                SetRotateLight();
            });
            m_SequenceShowView.InsertCallback(1.5f, () =>
            {
                m_WinPopupFields.BtnReward.gameObject.SetActive(true);
                m_WinPopupFields.BtnReward.Interactable = true;
                if (!global::Rush.Chocology.Economy.Config.Runtime.RemoveAd)
                {
                    if (m_ThisLevel >= 4)
                        m_WinPopupFields.ItemShopRemoveAd.gameObject.SetActive(true);
                }
                else
                {
                    m_WinPopupFields.ItemShopRemoveAd.gameObject.SetActive(false);
                }

                global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::BBUIView>(m_WinPopupFields.BtnReward).ShowView();
            });
            float showBtnNext = 3.5f;
            if (m_ThisLevel == 1)
            {
                showBtnNext = 1.8f;
            }

            m_SequenceShowView.InsertCallback(showBtnNext, () =>
            {
                m_WinPopupFields.BtnNext.gameObject.SetActive(true);
                global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::BBUIView>(m_WinPopupFields.BtnNext).ShowView();
            });
            m_SequenceShowView.InsertCallback(1.61f, () =>
            {
                if (m_ThisLevel == 1)
                {
                    global::Rush.Chocology.Gameplay.GamePlayManager.Instance.ShowTutNextLevel(m_WinPopupFields.BtnNext.transform.position);
                }
            });
            m_SequenceShowView.OnComplete(() =>
            {
                ShowViewFinishedInternal();
            });
        }

        public void ShowViewFinished() => ShowViewFinishedInternal();
        private void ShowViewFinishedInternal()
        {
        }

        private void SetRotateLight()
        {
            //Debug.Log("SetRotateLightSetRotateLight");
            m_WinPopupFields.ObjLight.transform.DORotate(new Vector3(0f, 0f, -90f), 1f).SetRelative(true).SetEase(Ease.Linear).SetLoops(-1, LoopType.Incremental);
        }

        public global::UnityEngine.UI.Text TxtChestCountStar { get => m_WinPopupFields.TxtChestCountStar; set => m_WinPopupFields.TxtChestCountStar = value; }
        public global::UnityEngine.UI.Image ImgChestProgress { get => m_WinPopupFields.ImgChestProgress; set => m_WinPopupFields.ImgChestProgress = value; }
        public global::System.Collections.Generic.List<global::UnityEngine.UI.Image> ListChestEfxStars { get => m_WinPopupFields.ListChestEfxStars; set => m_WinPopupFields.ListChestEfxStars = value; }

        public void InitChestStar() => InitChestStarInternal();
        private void InitChestStarInternal()
        {
            m_WinPopupFields.TxtChestCountStar.text = $"{(global::Rush.Chocology.Economy.Config.Runtime.ChestCountStar)}/{(global::Rush.Chocology.Economy.Config.Runtime.ChestStarMax)}";
            m_WinPopupFields.ImgChestProgress.fillAmount = global::Rush.Chocology.Economy.Config.Runtime.ChestCountStar * 1f / global::Rush.Chocology.Economy.Config.Runtime.ChestStarMax;
            // iconChestWatchVideo.gameObject.SetActive(false);
            m_WinPopupFields.BtnChest.Interactable = false;
            StartCoroutine(AddChestStarFinishedInternal());
        }

        public void AddChestStar(int stars) => AddChestStarInternal(stars);
        private void AddChestStarInternal(int stars)
        {
            for (int i = 0; i < stars; i++)
            {
                m_WinPopupFields.ListChestEfxStars[i].gameObject.SetActive(true);
                global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::UnityEngine.RectTransform>(m_WinPopupFields.ListChestEfxStars[i]).DOAnchorPos(new Vector2(276f, 8f), 0.5f).OnComplete(() =>
                {
                    m_WinPopupFields.ListChestEfxStars[i].gameObject.SetActive(false);
                });
                global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::UnityEngine.RectTransform>(m_WinPopupFields.ListChestEfxStars[i]).DOScale(Vector3.one * 0.2f, 0.4f);
            }
        }

        public IEnumerator AddChestStarFinished() => AddChestStarFinishedInternal();
        private IEnumerator AddChestStarFinishedInternal()
        {
            yield return new WaitForSeconds(1.5f);
            AddChestStarInternal(m_AddStar);
            yield return new WaitForSeconds(0.45f);
            global::Rush.Chocology.Economy.Config.Runtime.SetChestCountStar(global::Rush.Chocology.Economy.Config.Runtime.ChestCountStar + m_AddStar);
            m_WinPopupFields.TxtChestCountStar.text = $"{(global::Rush.Chocology.Economy.Config.Runtime.ChestCountStar)}/{(global::Rush.Chocology.Economy.Config.Runtime.ChestStarMax)}";
            m_WinPopupFields.ImgChestProgress.DOFillAmount(global::Rush.Chocology.Economy.Config.Runtime.ChestCountStar * 1f / global::Rush.Chocology.Economy.Config.Runtime.ChestStarMax, 0.2f);
            if (global::Rush.Chocology.Economy.Config.Runtime.ChestCountStar >= global::Rush.Chocology.Economy.Config.Runtime.ChestStarMax)
            {
                global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::UnityEngine.UI.Image>(m_WinPopupFields.BtnChest).color = new Color(200f / 255f, 200f / 255f, 200f / 255f, 1f);
                global::Rush.Chocology.Economy.Config.Runtime.SetChestCountStar(0);
                global::Rush.Chocology.Gameplay.GamePlayManager.Instance.OpenChestPopup(true);
            //AdmobManager.instance.HideBannerAd();
            }
            else
            {
                global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::UnityEngine.UI.Image>(m_WinPopupFields.BtnChest).color = new Color(1f, 1f, 1f, 1f);
                if (BspLabsAdsMobile.Instance.IsRewardVideoAvailable())
                {
                    m_WinPopupFields.BtnChest.Interactable = true;
                    ShowChestButtonWathcVideoAvaiableInternal();
                }
                else
                {
                    m_WinPopupFields.BtnChest.Interactable = false;
                //iconChestWatchVideo.gameObject.SetActive(true);
                }
            }
        }

        private Sequence m_SequenceIconChestWatchVideo;
        public void ShowChestButtonWathcVideoAvaiable() => ShowChestButtonWathcVideoAvaiableInternal();
        private void ShowChestButtonWathcVideoAvaiableInternal()
        {
        /*iconChestWatchVideo.gameObject.SetActive(true);
        Debug.Log("ShowSpinButtonAvaiable");
        if (sequence_iconChestWatchVideo != null)
        {
            sequence_iconChestWatchVideo.Kill();
        }
        sequence_iconChestWatchVideo = DOTween.Sequence();
        //sequence_iconChestWatchVideo.Insert(0f, iconChestWatchVideo.transform.DOPunchPosition(new Vector3(5f, 5f, 0.1f), Random.Range(1f, 2f), 5, 1).SetEase(Ease.InBounce));
        sequence_iconChestWatchVideo.Insert(0f, iconChestWatchVideo.transform.DOPunchRotation(new Vector3(0f, 0f, 10f), Random.Range(1f, 2f), 5, 1).SetEase(Ease.InOutBack));
        sequence_iconChestWatchVideo.Insert(0f, iconChestWatchVideo.transform.DOPunchScale(new Vector3(0.1f, 0.1f, 0.1f), Random.Range(1f, 2f), 5, 1).SetEase(Ease.InBounce));
        sequence_iconChestWatchVideo.Insert(2f, iconChestWatchVideo.transform.DOScale(1.1f, Random.Range(0.5f, 1f)).SetEase(Ease.Linear).SetLoops(Random.Range(2, 4), LoopType.Yoyo));
        sequence_iconChestWatchVideo.SetLoops(-1, LoopType.Yoyo);*/
        }

        public void SetDisableNativeAd() => SetDisableNativeAdInternal();
        private void SetDisableNativeAdInternal()
        {
            m_WinPopupFields.BgPopup.raycastTarget = true;
        }

        public void SetEnableNativeAd() => SetEnableNativeAdInternal();
        private void SetEnableNativeAdInternal()
        {
            m_WinPopupFields.BgPopup.raycastTarget = false;
        }

        private void OnDestroy()
        {
        //AdmobManager.instance.HideBannerAd();
        }
    }
}
