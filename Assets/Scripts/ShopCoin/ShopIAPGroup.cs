using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopIAPGroup : MonoBehaviour
{
    public List<global::Rush.Chocology.Shop.ItemShopIAP> listItemShopIAPs;
    public global::Rush.Chocology.Shop.ItemShopIAP itemShopRemoveAd;
    public global::Rush.Chocology.Shop.ItemShopIAP itemShopRemoveAd_And_Combo10;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void InitShopIAP()
    {
        if (global::Rush.Chocology.Economy.Config.Runtime.RemoveAd)
        {
            itemShopRemoveAd.gameObject.SetActive(false);
            itemShopRemoveAd_And_Combo10.gameObject.SetActive(false);
        }

        for (int i = 0; i < listItemShopIAPs.Count; i++)
        {
            listItemShopIAPs[i].InitIAP();
        }
    }
}
