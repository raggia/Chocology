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

public class ItemPack : MonoBehaviour
{
    public Text txtCountItem;
    public GameObject itemPackView;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SetItemPack(global::Rush.Chocology.Economy.ConfigItemShopData configItemShopData)
    {
        txtCountItem.text = $"x{(configItemShopData.CountItem)}";
    }

    public void ShowItemPack()
    {
        itemPackView.GetComponent<BBUIView>().ShowView();
    }
}
