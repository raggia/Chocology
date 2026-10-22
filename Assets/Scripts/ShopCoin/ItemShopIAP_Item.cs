using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemShopIAP_Item : ItemShopIAP
{
    [SerializeField] private bool HasItemCoin;
    public Text txtCount_ItemCoin;
    [SerializeField] private bool HasItemUndo;
    public Text txtCount_ItemUndo;
    [SerializeField] private bool HasItemSuggest;
    public Text txtCount_ItemSuggest;
    [SerializeField] private bool HasItemShuffle;
    public Text txtCount_ItemShuffle;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();

        InitPackIAP();
    }

    public void InitPackIAP() {
        if (HasItemCoin) {
            txtCount_ItemCoin.text = "x"+Config.GetCountItem_Pack_ItemType(Config.SHOPITEM.COIN, configPackData).ToString();
        }
        if (HasItemUndo)
        {
            txtCount_ItemUndo.text = "x" + Config.GetCountItem_Pack_ItemType(Config.SHOPITEM.UNDO, configPackData).ToString();
        }
        if (HasItemSuggest)
        {
            txtCount_ItemSuggest.text = "x" + Config.GetCountItem_Pack_ItemType(Config.SHOPITEM.SUGGEST, configPackData).ToString();
        }
        if (HasItemShuffle)
        {
            txtCount_ItemShuffle.text = "x" + Config.GetCountItem_Pack_ItemType(Config.SHOPITEM.SHUFFLE, configPackData).ToString();
        }
    }
}
