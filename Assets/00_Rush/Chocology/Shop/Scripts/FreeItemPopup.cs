using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using BsplabsMobileAds;

namespace Rush.Chocology.Shop
{
    [UnityEngine.Scripting.APIUpdating.MovedFrom(true, "", "Assembly-CSharp", "FreeItemPopup")]
    public class FreeItemPopup : MonoBehaviour
    {
        [global::System.Serializable]
        private sealed class FreeItemPopupField
        {
            [UnityEngine.Serialization.FormerlySerializedAs("btnClose")]
            [UnityEngine.SerializeField]
            private BBUIButton m_BtnClose;
            public global::BBUIButton BtnClose { get => m_BtnClose; set => m_BtnClose = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("btnWatchAds")]
            [UnityEngine.SerializeField]
            private BBUIButton m_BtnWatchAds;
            public global::BBUIButton BtnWatchAds { get => m_BtnWatchAds; set => m_BtnWatchAds = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("popup")]
            [UnityEngine.SerializeField]
            private GameObject m_Popup;
            public global::UnityEngine.GameObject Popup { get => m_Popup; set => m_Popup = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("lockGroup")]
            [UnityEngine.SerializeField]
            private GameObject m_LockGroup;
            public global::UnityEngine.GameObject LockGroup { get => m_LockGroup; set => m_LockGroup = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("icon")]
            [UnityEngine.SerializeField]
            private Image m_Icon;
            public global::UnityEngine.UI.Image Icon { get => m_Icon; set => m_Icon = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("txtCount")]
            [UnityEngine.SerializeField]
            private Text m_TxtCount;
            public global::UnityEngine.UI.Text TxtCount { get => m_TxtCount; set => m_TxtCount = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("sprite_Undo")]
            [UnityEngine.SerializeField]
            private Sprite m_SpriteUndo;
            public global::UnityEngine.Sprite SpriteUndo { get => m_SpriteUndo; set => m_SpriteUndo = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("sprite_Suggest")]
            [UnityEngine.SerializeField]
            private Sprite m_SpriteSuggest;
            public global::UnityEngine.Sprite SpriteSuggest { get => m_SpriteSuggest; set => m_SpriteSuggest = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("sprite_Shuffle")]
            [UnityEngine.SerializeField]
            private Sprite m_SpriteShuffle;
            public global::UnityEngine.Sprite SpriteShuffle { get => m_SpriteShuffle; set => m_SpriteShuffle = value; }
        }

        [global::UnityEngine.SerializeField]
        private FreeItemPopupField m_FreeItemPopupFields = new FreeItemPopupField();
        private static global::Rush.Chocology.Shop.FreeItemPopup s_Instance;
        public static global::Rush.Chocology.Shop.FreeItemPopup Instance { get => s_Instance; set => s_Instance = value; }
        public global::BBUIButton BtnClose { get => m_FreeItemPopupFields.BtnClose; set => m_FreeItemPopupFields.BtnClose = value; }
        public global::BBUIButton BtnWatchAds { get => m_FreeItemPopupFields.BtnWatchAds; set => m_FreeItemPopupFields.BtnWatchAds = value; }
        public global::UnityEngine.GameObject Popup { get => m_FreeItemPopupFields.Popup; set => m_FreeItemPopupFields.Popup = value; }
        public global::UnityEngine.GameObject LockGroup { get => m_FreeItemPopupFields.LockGroup; set => m_FreeItemPopupFields.LockGroup = value; }
        public global::UnityEngine.UI.Image Icon { get => m_FreeItemPopupFields.Icon; set => m_FreeItemPopupFields.Icon = value; }
        public global::UnityEngine.UI.Text TxtCount { get => m_FreeItemPopupFields.TxtCount; set => m_FreeItemPopupFields.TxtCount = value; }
        public global::UnityEngine.Sprite SpriteUndo { get => m_FreeItemPopupFields.SpriteUndo; set => m_FreeItemPopupFields.SpriteUndo = value; }
        public global::UnityEngine.Sprite SpriteSuggest { get => m_FreeItemPopupFields.SpriteSuggest; set => m_FreeItemPopupFields.SpriteSuggest = value; }
        public global::UnityEngine.Sprite SpriteShuffle { get => m_FreeItemPopupFields.SpriteShuffle; set => m_FreeItemPopupFields.SpriteShuffle = value; }

        private void Awake()
        {
            s_Instance = this;
        }

        // Start is called before the first frame update
        void Start()
        {
            m_FreeItemPopupFields.BtnClose.OnPointerClickCallBack_Completed.AddListener(TouchCloseInternal);
            m_FreeItemPopupFields.BtnWatchAds.OnPointerClickCallBack_Completed.AddListener(TouchWatchAdsInternal);
            global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::BBUIView>(m_FreeItemPopupFields.Popup).HideBehavior.onCallback_Completed.AddListener(HidePopupFinishedInternal);
        }

        // Update is called once per frame
        void Update()
        {
        }

        private global::Rush.Chocology.Economy.ConfigItemShopData m_ConfigItemShop;
        public void OpenFreeItemPopup(global::Rush.Chocology.Economy.Config.ITEMHELP_TYPE itemType) => OpenFreeItemPopupInternal(itemType);
        private void OpenFreeItemPopupInternal(global::Rush.Chocology.Economy.Config.ITEMHELP_TYPE itemType)
        {
            m_IsSuccess = false;
            m_ConfigItemShop = new global::Rush.Chocology.Economy.ConfigItemShopData();
            m_ConfigItemShop.ShopItemType = global::Rush.Chocology.Economy.Config.Runtime.ConvertItemHelpTypeToShopItem(itemType);
            m_ConfigItemShop.CountItem = 1;
            ShowRewardItem();
            gameObject.SetActive(true);
            InitViewsInternal();
        }

        private void ShowRewardItem()
        {
            if (m_ConfigItemShop.ShopItemType == global::Rush.Chocology.Economy.Config.SHOPITEM.UNDO)
            {
                m_FreeItemPopupFields.Icon.sprite = m_FreeItemPopupFields.SpriteUndo;
            }
            else if (m_ConfigItemShop.ShopItemType == global::Rush.Chocology.Economy.Config.SHOPITEM.SUGGEST)
            {
                m_FreeItemPopupFields.Icon.sprite = m_FreeItemPopupFields.SpriteSuggest;
            }
            else if (m_ConfigItemShop.ShopItemType == global::Rush.Chocology.Economy.Config.SHOPITEM.SHUFFLE)
            {
                m_FreeItemPopupFields.Icon.sprite = m_FreeItemPopupFields.SpriteShuffle;
            }

            m_FreeItemPopupFields.Icon.SetNativeSize();
            m_FreeItemPopupFields.TxtCount.text = $"{(m_ConfigItemShop.CountItem)}";
        }

        public void TouchClose() => TouchCloseInternal();
        private void TouchCloseInternal()
        {
            m_FreeItemPopupFields.LockGroup.gameObject.SetActive(true);
            global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::BBUIView>(m_FreeItemPopupFields.Popup).HideView();
        }

        public void TouchWatchAds() => TouchWatchAdsInternal();
        private void TouchWatchAdsInternal()
        {
            m_FreeItemPopupFields.LockGroup.gameObject.SetActive(true);
            m_FreeItemPopupFields.BtnWatchAds.Interactable = false;
            new global::Rush.Integrations.Ads.RewardedAdRequest().Show(completed =>
            {
                m_FreeItemPopupFields.LockGroup.SetActive(false);
                m_FreeItemPopupFields.BtnWatchAds.Interactable = true;
                if (completed)
                    WatchAdsFinishedInternal();
            });
        }

        private bool m_IsSuccess = false;
        public void WatchAdsFinished() => WatchAdsFinishedInternal();
        private void WatchAdsFinishedInternal()
        {
            global::Rush.Chocology.Audio.SoundManager.Instance.PlaySoundCash();
            m_IsSuccess = true;
            Debug.Log("WatchAds_FinishedWatchAds_Finished");
            Debug.Log(m_ConfigItemShop.CountItem);
            Debug.Log(m_ConfigItemShop.ShopItemType.ToString());
            global::Rush.Chocology.Economy.Config.Runtime.BuySuccesItemShop(m_ConfigItemShop);
            m_FreeItemPopupFields.BtnWatchAds.Interactable = true;
            m_FreeItemPopupFields.LockGroup.gameObject.SetActive(true);
            global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::BBUIView>(m_FreeItemPopupFields.Popup).HideView();
        }

        public void HidePopupFinished() => HidePopupFinishedInternal();
        private void HidePopupFinishedInternal()
        {
            if (m_IsSuccess)
            {
                global::Rush.Chocology.Gameplay.GamePlayManager.Instance.SetFreeItemSuccess();
            }

            global::Rush.Chocology.Gameplay.GamePlayManager.Instance.SetUnPause();
            gameObject.SetActive(false);
        }

        public void InitViews() => InitViewsInternal();
        private void InitViewsInternal()
        {
            global::Rush.Chocology.Audio.SoundManager.Instance.PlaySoundPopup();
            m_FreeItemPopupFields.LockGroup.gameObject.SetActive(false);
            m_FreeItemPopupFields.Popup.gameObject.SetActive(false);
            m_FreeItemPopupFields.BtnWatchAds.gameObject.SetActive(false);
            if (BspLabsAdsMobile.Instance.IsRewardVideoAvailable())
            {
                m_FreeItemPopupFields.BtnWatchAds.Interactable = true;
            }
            else
            {
                m_FreeItemPopupFields.BtnWatchAds.Interactable = false;
            }

            m_FreeItemPopupFields.BtnClose.gameObject.SetActive(false);
            InitViewShowViewInternal();
        }

        public void InitViewShowView() => InitViewShowViewInternal();
        private void InitViewShowViewInternal()
        {
            Sequence sequenceShowView = DOTween.Sequence();
            sequenceShowView.InsertCallback(0.01f, () =>
            {
                m_FreeItemPopupFields.Popup.gameObject.SetActive(true);
                global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::BBUIView>(m_FreeItemPopupFields.Popup).ShowView();
            });
            sequenceShowView.InsertCallback(0.4f, () =>
            {
                m_FreeItemPopupFields.BtnWatchAds.gameObject.SetActive(false);
                global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::BBUIView>(m_FreeItemPopupFields.BtnWatchAds.gameObject).ShowView();
            });
            sequenceShowView.InsertCallback(1.2f, () =>
            {
                m_FreeItemPopupFields.BtnClose.gameObject.SetActive(false);
                global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::BBUIView>(m_FreeItemPopupFields.BtnClose.gameObject).ShowView();
            });
        }
    }
}
