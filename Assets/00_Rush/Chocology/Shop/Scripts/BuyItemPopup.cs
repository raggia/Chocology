using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

namespace Rush.Chocology.Shop
{
    [UnityEngine.Scripting.APIUpdating.MovedFrom(true, "", "Assembly-CSharp", "BuyItemPopup")]
    public class BuyItemPopup : MonoBehaviour
    {
        [global::System.Serializable]
        private sealed class BuyItemPopupField
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

            [UnityEngine.Serialization.FormerlySerializedAs("txtDes")]
            [UnityEngine.SerializeField]
            private Text m_TxtDes;
            public global::UnityEngine.UI.Text TxtDes { get => m_TxtDes; set => m_TxtDes = value; }

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
        private BuyItemPopupField m_BuyItemPopupFields = new BuyItemPopupField();
        private static global::Rush.Chocology.Shop.BuyItemPopup s_Instance;
        public static global::Rush.Chocology.Shop.BuyItemPopup Instance { get => s_Instance; set => s_Instance = value; }
        public global::BBUIButton BtnClose { get => m_BuyItemPopupFields.BtnClose; set => m_BuyItemPopupFields.BtnClose = value; }
        public global::BBUIButton BtnWatchAds { get => m_BuyItemPopupFields.BtnWatchAds; set => m_BuyItemPopupFields.BtnWatchAds = value; }
        public global::UnityEngine.GameObject Popup { get => m_BuyItemPopupFields.Popup; set => m_BuyItemPopupFields.Popup = value; }
        public global::UnityEngine.GameObject LockGroup { get => m_BuyItemPopupFields.LockGroup; set => m_BuyItemPopupFields.LockGroup = value; }
        public global::UnityEngine.UI.Image Icon { get => m_BuyItemPopupFields.Icon; set => m_BuyItemPopupFields.Icon = value; }
        public global::UnityEngine.UI.Text TxtCount { get => m_BuyItemPopupFields.TxtCount; set => m_BuyItemPopupFields.TxtCount = value; }
        public global::UnityEngine.UI.Text TxtDes { get => m_BuyItemPopupFields.TxtDes; set => m_BuyItemPopupFields.TxtDes = value; }
        public global::UnityEngine.Sprite SpriteUndo { get => m_BuyItemPopupFields.SpriteUndo; set => m_BuyItemPopupFields.SpriteUndo = value; }
        public global::UnityEngine.Sprite SpriteSuggest { get => m_BuyItemPopupFields.SpriteSuggest; set => m_BuyItemPopupFields.SpriteSuggest = value; }
        public global::UnityEngine.Sprite SpriteShuffle { get => m_BuyItemPopupFields.SpriteShuffle; set => m_BuyItemPopupFields.SpriteShuffle = value; }

        private void Awake()
        {
            s_Instance = this;
        }

        // Start is called before the first frame update
        void Start()
        {
            m_BuyItemPopupFields.BtnClose.OnPointerClickCallBack_Completed.AddListener(TouchCloseInternal);
            m_BuyItemPopupFields.BtnWatchAds.OnPointerClickCallBack_Completed.AddListener(TouchBuyItemInternal);
            global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::BBUIView>(m_BuyItemPopupFields.Popup).HideBehavior.onCallback_Completed.AddListener(HidePopupFinishedInternal);
        }

        // Update is called once per frame
        void Update()
        {
        }

        private global::Rush.Chocology.Economy.ConfigItemShopData m_ConfigItemShop;
        public void OpenBuyItemPopup(global::Rush.Chocology.Economy.Config.ITEMHELP_TYPE itemType) => OpenBuyItemPopupInternal(itemType);
        private void OpenBuyItemPopupInternal(global::Rush.Chocology.Economy.Config.ITEMHELP_TYPE itemType)
        {
            m_ConfigItemShop = new global::Rush.Chocology.Economy.ConfigItemShopData();
            m_ConfigItemShop.ShopItemType = global::Rush.Chocology.Economy.Config.Runtime.ConvertItemHelpTypeToShopItem(itemType);
            m_ConfigItemShop.CountItem = 1;
            m_ConfigItemShop.Price = global::Rush.Chocology.Economy.Config.Runtime.CoinPriceItem;
            ShowRewardItem();
            gameObject.SetActive(true);
            InitViewsInternal();
        }

        private void ShowRewardItem()
        {
            if (m_ConfigItemShop.ShopItemType == global::Rush.Chocology.Economy.Config.SHOPITEM.UNDO)
            {
                m_BuyItemPopupFields.Icon.sprite = m_BuyItemPopupFields.SpriteUndo;
                m_BuyItemPopupFields.TxtDes.text = "Tap to recall the first tile in the Display Bar";
            }
            else if (m_ConfigItemShop.ShopItemType == global::Rush.Chocology.Economy.Config.SHOPITEM.SUGGEST)
            {
                m_BuyItemPopupFields.Icon.sprite = m_BuyItemPopupFields.SpriteSuggest;
                m_BuyItemPopupFields.TxtDes.text = "Can automatically clear a group of tile one tapped";
            }
            else if (m_ConfigItemShop.ShopItemType == global::Rush.Chocology.Economy.Config.SHOPITEM.SHUFFLE)
            {
                m_BuyItemPopupFields.Icon.sprite = m_BuyItemPopupFields.SpriteShuffle;
                m_BuyItemPopupFields.TxtDes.text = "Tap to rearrange the order of tiles on the map";
            }

            // icon.SetNativeSize();
            m_BuyItemPopupFields.TxtCount.text = $"x{(m_ConfigItemShop.CountItem)} ";
        }

        public void TouchClose() => TouchCloseInternal();
        private void TouchCloseInternal()
        {
            m_BuyItemPopupFields.LockGroup.gameObject.SetActive(true);
            global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::BBUIView>(m_BuyItemPopupFields.Popup).HideView();
        }

        public void TouchBuyItem() => TouchBuyItemInternal();
        private void TouchBuyItemInternal()
        {
            if (global::Rush.Chocology.Economy.Config.Runtime.CurrCoin >= m_ConfigItemShop.Price)
            {
                global::Rush.Chocology.Economy.Config.Runtime.SetCoin(global::Rush.Chocology.Economy.Config.Runtime.CurrCoin - m_ConfigItemShop.Price);
                global::Rush.Chocology.Economy.Config.Runtime.BuySuccesItemShop(m_ConfigItemShop);
                global::Rush.Chocology.Gameplay.GamePlayManager.Instance.SetFreeItemSuccess();
                global::Rush.Chocology.Notifications.NotificationPopup.Instance.AddNotification("Buy Success!");
            }
            else
            {
                global::Rush.Chocology.Notifications.NotificationPopup.Instance.AddNotification("Not enough Coin!");
                global::Rush.Chocology.Gameplay.GamePlayManager.Instance.OpenShopPopup();
            }
        }

        public void HidePopupFinished() => HidePopupFinishedInternal();
        private void HidePopupFinishedInternal()
        {
            global::Rush.Chocology.Gameplay.GamePlayManager.Instance.SetUnPause();
            gameObject.SetActive(false);
        }

        public void InitViews() => InitViewsInternal();
        private void InitViewsInternal()
        {
            global::Rush.Chocology.Audio.SoundManager.Instance.PlaySoundPopup();
            m_BuyItemPopupFields.LockGroup.gameObject.SetActive(false);
            m_BuyItemPopupFields.Popup.gameObject.SetActive(false);
            m_BuyItemPopupFields.BtnWatchAds.gameObject.SetActive(false);
            //if (AdmobManager.instance.isRewardAds_Avaiable())
            //{
            //    btnWatchAds.Interactable = true;
            //}
            //else
            //{
            //    btnWatchAds.Interactable = false;
            //}
            m_BuyItemPopupFields.BtnClose.gameObject.SetActive(false);
            InitViewShowViewInternal();
        }

        public void InitViewShowView() => InitViewShowViewInternal();
        private void InitViewShowViewInternal()
        {
            Sequence sequenceShowView = DOTween.Sequence();
            sequenceShowView.InsertCallback(0.01f, () =>
            {
                m_BuyItemPopupFields.Popup.gameObject.SetActive(true);
                global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::BBUIView>(m_BuyItemPopupFields.Popup).ShowView();
            });
            sequenceShowView.InsertCallback(0.4f, () =>
            {
                m_BuyItemPopupFields.BtnWatchAds.gameObject.SetActive(false);
                global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::BBUIView>(m_BuyItemPopupFields.BtnWatchAds.gameObject).ShowView();
            });
            sequenceShowView.InsertCallback(1.2f, () =>
            {
                m_BuyItemPopupFields.BtnClose.gameObject.SetActive(false);
                global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::BBUIView>(m_BuyItemPopupFields.BtnClose.gameObject).ShowView();
            });
        }
    }
}
