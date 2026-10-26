/*
 * Created on 2022
 *
 * Copyright (c) 2022 dotmobstudio
 * Support : dotmobstudio@gmail.com
 */
using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using BsplabsMobileAds;

namespace Rush.Chocology.Shop
{
    [UnityEngine.Scripting.APIUpdating.MovedFrom(true, "", "Assembly-CSharp", "ItemShop_VideoCoin")]
    public class ItemShop_VideoCoin : MonoBehaviour
    {
        [global::System.Serializable]
        private sealed class ItemShop_VideoCoinField
        {
            [UnityEngine.Serialization.FormerlySerializedAs("itemShopData")]
            [UnityEngine.SerializeField]
            private global::Rush.Chocology.Economy.ConfigItemShopData m_ItemShopData;
            public global::Rush.Chocology.Economy.ConfigItemShopData ItemShopData { get => m_ItemShopData; set => m_ItemShopData = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("txtCounItem")]
            [UnityEngine.SerializeField]
            private Text m_TxtCounItem;
            public global::UnityEngine.UI.Text TxtCounItem { get => m_TxtCounItem; set => m_TxtCounItem = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("txtCountVideo")]
            [UnityEngine.SerializeField]
            private Text m_TxtCountVideo;
            public global::UnityEngine.UI.Text TxtCountVideo { get => m_TxtCountVideo; set => m_TxtCountVideo = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("btnBuy")]
            [UnityEngine.SerializeField]
            private BBUIButton m_BtnBuy;
            public global::BBUIButton BtnBuy { get => m_BtnBuy; set => m_BtnBuy = value; }

            [UnityEngine.Serialization.FormerlySerializedAs("lockGroup")]
            [UnityEngine.SerializeField]
            private GameObject m_LockGroup;
            public global::UnityEngine.GameObject LockGroup { get => m_LockGroup; set => m_LockGroup = value; }
        }

        [global::UnityEngine.SerializeField]
        private ItemShop_VideoCoinField m_ItemShop_VideoCoinFields = new ItemShop_VideoCoinField();
        public global::Rush.Chocology.Economy.ConfigItemShopData ItemShopData { get => m_ItemShop_VideoCoinFields.ItemShopData; set => m_ItemShop_VideoCoinFields.ItemShopData = value; }
        public global::UnityEngine.UI.Text TxtCounItem { get => m_ItemShop_VideoCoinFields.TxtCounItem; set => m_ItemShop_VideoCoinFields.TxtCounItem = value; }
        public global::UnityEngine.UI.Text TxtCountVideo { get => m_ItemShop_VideoCoinFields.TxtCountVideo; set => m_ItemShop_VideoCoinFields.TxtCountVideo = value; }
        public global::BBUIButton BtnBuy { get => m_ItemShop_VideoCoinFields.BtnBuy; set => m_ItemShop_VideoCoinFields.BtnBuy = value; }
        public global::UnityEngine.GameObject LockGroup { get => m_ItemShop_VideoCoinFields.LockGroup; set => m_ItemShop_VideoCoinFields.LockGroup = value; }

        // Start is called before the first frame update
        void Start()
        {
            m_ItemShop_VideoCoinFields.BtnBuy.OnPointerClickCallBack_Completed.AddListener(TouchBuy);
            m_ItemShop_VideoCoinFields.TxtCounItem.text = $"x{(m_ItemShop_VideoCoinFields.ItemShopData.CountItem)}";
        }

        private void OnEnable()
        {
            InitItemShop();
        }

        // Update is called once per frame
        void Update()
        {
        }

        private void TouchBuy()
        {
            m_ItemShop_VideoCoinFields.LockGroup.SetActive(true);
            if (BspLabsAdsMobile.Instance.IsRewardVideoAvailable())
            {
                new global::Rush.Integrations.Ads.RewardedAdRequest().Show(CompleteMethod);
            }
            else
            {
                m_ItemShop_VideoCoinFields.LockGroup.gameObject.SetActive(false);
                global::Rush.Chocology.Notifications.NotificationPopup.Instance.AddNotification("No Video Available!");
            }
        }

        private void CompleteMethod(bool completed)
        {
            if (completed == true)
            {
                m_ItemShop_VideoCoinFields.LockGroup.SetActive(false);
                global::Rush.Chocology.Audio.SoundManager.Instance.PlaySoundCash();
                global::Rush.Chocology.Economy.Config.Runtime.SetDailyFreeCoin();
                global::Rush.Chocology.Economy.Config.Runtime.SetDailyVideoCoinAddCount();
                global::Rush.Chocology.Economy.Config.Runtime.BuySuccesItemShop(m_ItemShop_VideoCoinFields.ItemShopData);
                if (global::Rush.Chocology.Economy.Config.Runtime.DailyVideoCoinCount > 0)
                {
                    m_ItemShop_VideoCoinFields.TxtCountVideo.text = $"{(global::Rush.Chocology.Economy.Config.Runtime.DailyVideoCoinCount)}";
                    m_ItemShop_VideoCoinFields.BtnBuy.Interactable = true;
                }
                else
                {
                    m_ItemShop_VideoCoinFields.TxtCountVideo.text = $"0";
                    m_ItemShop_VideoCoinFields.BtnBuy.Interactable = false;
                }
            }
            else
            {
                m_ItemShop_VideoCoinFields.LockGroup.gameObject.SetActive(false);
                global::Rush.Chocology.Notifications.NotificationPopup.Instance.AddNotification("Claim Reward Fail!");
            }
        }

        private void InitItemShop()
        {
            if (global::Rush.Chocology.Economy.Config.Runtime.CheckDailyVideoCoin())
            {
                global::Rush.Chocology.Economy.Config.Runtime.SetDailyVideoCoin();
                global::Rush.Chocology.Economy.Config.Runtime.SetDailyVideoCoinCount(global::Rush.Chocology.Economy.Config.DAILY_VIDEOCOIN_MAX);
                m_ItemShop_VideoCoinFields.TxtCountVideo.text = $"{(global::Rush.Chocology.Economy.Config.Runtime.DailyVideoCoinCount)}";
                m_ItemShop_VideoCoinFields.BtnBuy.Interactable = true;
            }
            else
            {
                if (global::Rush.Chocology.Economy.Config.Runtime.DailyVideoCoinCount > 0)
                {
                    m_ItemShop_VideoCoinFields.TxtCountVideo.text = $"{(global::Rush.Chocology.Economy.Config.Runtime.DailyVideoCoinCount)}";
                    m_ItemShop_VideoCoinFields.BtnBuy.Interactable = true;
                }
                else
                {
                    m_ItemShop_VideoCoinFields.TxtCountVideo.text = $"0";
                    m_ItemShop_VideoCoinFields.BtnBuy.Interactable = false;
                }
            }
        }
    }
}
