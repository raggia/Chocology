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

namespace Rush.Chocology.Shop
{
    [UnityEngine.Scripting.APIUpdating.MovedFrom(true, "", "Assembly-CSharp", "RemoveAdButton")]
    public class RemoveAdButton : MonoBehaviour
    {
        [UnityEngine.Serialization.FormerlySerializedAs("btnRemoveAd")]
        [UnityEngine.SerializeField]
        private BBUIButton m_BtnRemoveAd;
        public global::BBUIButton BtnRemoveAd { get => m_BtnRemoveAd; set => m_BtnRemoveAd = value; }

        [UnityEngine.Serialization.FormerlySerializedAs("lockGroup")]
        [UnityEngine.SerializeField]
        private GameObject m_LockGroup;
        public global::UnityEngine.GameObject LockGroup { get => m_LockGroup; set => m_LockGroup = value; }

        // Start is called before the first frame update
        void Start()
        {
            m_BtnRemoveAd.OnPointerClickCallBack_Completed.AddListener(TouchRemoveAd);
            InitButton();
        }

        private void OnDestroy()
        {
            m_BtnRemoveAd.OnPointerClickCallBack_Completed.RemoveAllListeners();
        }

        // Update is called once per frame
        void Update()
        {
        }

        private void InitButton()
        {
            m_BtnRemoveAd.gameObject.SetActive(!global::Rush.Chocology.Economy.Config.Runtime.RemoveAd);
        }

        private void TouchRemoveAd()
        {
            global::Rush.Chocology.Integrations.Purchasing.PurchaserManager.Instance.BuyConsumable(global::Rush.Chocology.Economy.Config.IAP_ID.removead, (string _iapID, global::Rush.Chocology.Integrations.Purchasing.PurchaserManager.IAP_CALLBACK_STATE _state) =>
            {
                if (_state == global::Rush.Chocology.Integrations.Purchasing.PurchaserManager.IAP_CALLBACK_STATE.SUCCESS)
                {
                    Debug.Log("SUCCESSSUCCESS " + _iapID);
                    m_LockGroup.gameObject.SetActive(false);
                    if (_iapID.Equals(global::Rush.Chocology.Economy.Config.IAP_ID.removead.ToString()))
                    {
                        global::Rush.Chocology.Economy.Config.Runtime.SetRemoveAd();
                        global::Rush.Chocology.Economy.Config.Runtime.SetBuyIAP(global::Rush.Chocology.Economy.Config.IAP_ID.removead);
                        global::Rush.Chocology.Notifications.NotificationPopup.Instance.AddNotification("RemoveAd Success!");
                        InitButton();
                    }

                    global::Rush.Chocology.Notifications.GlobalVar.Runtime.CallAnalytics($"removeadd_success");
                }
                else
                {
                    Debug.Log("Buy Fail!Buy Fail!Buy Fail!Buy Fail!Buy Fail!");
                    m_LockGroup.gameObject.SetActive(false);
                    global::Rush.Chocology.Notifications.NotificationPopup.Instance.AddNotification("Buy Fail!");
                    global::Rush.Chocology.Notifications.GlobalVar.Runtime.CallAnalytics($"removeadd_cancel");
                }
            });
        }
    }
}
