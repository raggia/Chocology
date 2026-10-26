using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartPackPopup : MonoBehaviour
{
    public global::Rush.Chocology.Economy.ConfigPackData configPackData;
    public List<ItemPack> listItemPack;
    public static StartPackPopup instance;
    public BBUIButton btnClose, btnBuy;
    public GameObject popup;
    public Text txtPrice;
    public GameObject lockGroup;
    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        global::Rush.Chocology.Integrations.Purchasing.PurchaserManager.InitializeSucceeded += PurchaserManager_InitializeSucceeded;
        InitIAP();
        // InitPacks();
        btnClose.OnPointerClickCallBack_Completed.AddListener(TouchClose);
        btnBuy.OnPointerClickCallBack_Completed.AddListener(TouchBuy);
        Debug.Log("Config.IAP_ID.starter_pack.ToString()): " + global::Rush.Chocology.Economy.Config.IAP_ID.tilematch_starter_pack.ToString());
        popup.GetComponent<BBUIView>().HideBehavior.onCallback_Completed.AddListener(HidePopup_Finished);
    }

    private void OnDestroy()
    {
        global::Rush.Chocology.Integrations.Purchasing.PurchaserManager.InitializeSucceeded -= PurchaserManager_InitializeSucceeded;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void PurchaserManager_InitializeSucceeded()
    {
        InitIAP();
    }

    public void InitIAP()
    {
        if (global::Rush.Chocology.Integrations.Purchasing.PurchaserManager.Instance.IsInitialized())
        {
            txtPrice.text = global::Rush.Chocology.Integrations.Purchasing.PurchaserManager.Instance.ReadLocalizedPriceString(global::Rush.Chocology.Economy.Config.IAP_ID.tilematch_starter_pack.ToString());
            btnBuy.Interactable = true;
        }
        else
        {
            txtPrice.text = "";
            btnBuy.Interactable = false;
        }
    }

    public void InitPacks()
    {
        for (int i = 0; i < configPackData.ConfigItemShopDatas.Count; i++)
        {
            listItemPack[i].SetItemPack(configPackData.ConfigItemShopDatas[i]);
        }
    }

    public void ShowStartPack()
    {
        gameObject.SetActive(true);
        InitViews();
    }

    public void TouchClose()
    {
        lockGroup.gameObject.SetActive(true);
        popup.GetComponent<BBUIView>().HideView();
    }

    public void TouchBuy()
    {
        lockGroup.gameObject.SetActive(true);
#if UNITY_EDITOR
        btnBuy.Interactable = false;
        BuyStartPackSuccess();
        return;
#endif
        global::Rush.Chocology.Integrations.Purchasing.PurchaserManager.Instance.BuyConsumable(global::Rush.Chocology.Economy.Config.IAP_ID.tilematch_starter_pack, (string _iapID, global::Rush.Chocology.Integrations.Purchasing.PurchaserManager.IAP_CALLBACK_STATE _state) =>
        {
            if (_state == global::Rush.Chocology.Integrations.Purchasing.PurchaserManager.IAP_CALLBACK_STATE.SUCCESS)
            {
                lockGroup.gameObject.SetActive(false);
                if (_iapID.Equals(global::Rush.Chocology.Economy.Config.IAP_ID.tilematch_starter_pack.ToString()))
                {
                    //Buy
                    btnBuy.Interactable = false;
                    BuyStartPackSuccess();
                }
            }
            else
            {
                lockGroup.gameObject.SetActive(false);
                global::Rush.Chocology.Notifications.NotificationPopup.Instance.AddNotification("Buy Fail!");
            }
        });
    }

    public void BuyStartPackSuccess()
    {
        global::Rush.Chocology.Economy.Config.Runtime.SetRemoveAd();
        global::Rush.Chocology.Economy.Config.Runtime.SetBuyIAP(configPackData.IdPack);
        global::Rush.Chocology.Notifications.NotificationPopup.Instance.AddNotification("Buy Success!");
        if (global::Rush.Chocology.LevelMap.MenuManager.Instance != null && global::Rush.Chocology.LevelMap.MenuManager.Instance.isActiveAndEnabled)
        {
            global::Rush.Chocology.LevelMap.MenuManager.Instance.SetBuyStarterPackSuccess();
            global::Rush.Chocology.LevelMap.MenuManager.Instance.OpenRewardPopup(configPackData.ConfigItemShopDatas, false);
        }

        gameObject.SetActive(false);
    }

    public void HidePopup_Finished()
    {
        gameObject.SetActive(false);
    }

    public void InitViews()
    {
        global::Rush.Chocology.Audio.SoundManager.Instance.PlaySoundPopup();
        lockGroup.gameObject.SetActive(false);
        popup.gameObject.SetActive(false);
        btnBuy.gameObject.SetActive(false);
        btnClose.gameObject.SetActive(false);
        for (int i = 0; i < listItemPack.Count; i++)
        {
            listItemPack[i].itemPackView.SetActive(false);
        }

        InitView_ShowView();
    }

    public void InitView_ShowView()
    {
        Sequence sequenceShowView = DOTween.Sequence();
        sequenceShowView.InsertCallback(0.01f, () =>
        {
            popup.gameObject.SetActive(true);
            popup.GetComponent<BBUIView>().ShowView();
        });
        sequenceShowView.InsertCallback(0.2f, () =>
        {
            btnBuy.gameObject.SetActive(false);
            btnBuy.gameObject.GetComponent<BBUIView>().ShowView();
        });
        sequenceShowView.InsertCallback(1f, () =>
        {
            btnClose.gameObject.SetActive(false);
            btnClose.gameObject.GetComponent<BBUIView>().ShowView();
        });
    }
}
