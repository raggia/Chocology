using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemShopIAP_Item : global::Rush.Chocology.Shop.ItemShopIAP
{
    [SerializeField]
    private bool HasItemCoin;
    public Text txtCount_ItemCoin;
    [SerializeField]
    private bool HasItemUndo;
    public Text txtCount_ItemUndo;
    [SerializeField]
    private bool HasItemSuggest;
    public Text txtCount_ItemSuggest;
    [SerializeField]
    private bool HasItemShuffle;
    public Text txtCount_ItemShuffle;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        InitPackIAP();
    }

    public void InitPackIAP()
    {
        if (HasItemCoin)
        {
            txtCount_ItemCoin.text = "x" + global::Rush.Chocology.Economy.Config.Runtime.ReadCountItemPackItemType(global::Rush.Chocology.Economy.Config.SHOPITEM.COIN, ConfigPackData).ToString();
        }

        if (HasItemUndo)
        {
            txtCount_ItemUndo.text = "x" + global::Rush.Chocology.Economy.Config.Runtime.ReadCountItemPackItemType(global::Rush.Chocology.Economy.Config.SHOPITEM.UNDO, ConfigPackData).ToString();
        }

        if (HasItemSuggest)
        {
            txtCount_ItemSuggest.text = "x" + global::Rush.Chocology.Economy.Config.Runtime.ReadCountItemPackItemType(global::Rush.Chocology.Economy.Config.SHOPITEM.SUGGEST, ConfigPackData).ToString();
        }

        if (HasItemShuffle)
        {
            txtCount_ItemShuffle.text = "x" + global::Rush.Chocology.Economy.Config.Runtime.ReadCountItemPackItemType(global::Rush.Chocology.Economy.Config.SHOPITEM.SHUFFLE, ConfigPackData).ToString();
        }
    }
}
