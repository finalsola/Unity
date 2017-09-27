using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagCtrl : Singleton<BagCtrl> {

    public delegate void SwitchBagItemData(BagData bagData1, BagData bagData2);
    public delegate void SwitchBagItemUI(ItemUI itemUI1,ItemUI itemUI2);
    public delegate void ItemUseData(BagData bagData);
    public delegate void ItemUseUI(ItemUI itemUI);
    public delegate void AddItemData(ItemBase itembase,int Position);
    public delegate int AddItemUI(ItemBase itembase);

    public SwitchBagItemData switchBagItemData;    
    public SwitchBagItemUI switchBagItemUI;
    public ItemUseData itemUseData;
    public ItemUseUI itemUseUI;
	public AddItemData addItemData;
	public AddItemUI addItemUI;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    /// <summary>
    /// Switchs the bag item.交换物品位置
    /// </summary>
    public void switchBagItem(BagData bagData1,BagData bagData2,ItemUI itemUI1, ItemUI itemUI2)
    {
        if (switchBagItemData != null)
        switchBagItemData(bagData1, bagData2);
        if(switchBagItemUI!=null)
        switchBagItemUI(itemUI1, itemUI2);
    }

    /// <summary>
    /// Actives the item panel.激活物品面板
    /// </summary>
    /// <param name="itemUI">Item user interface.</param>
    public void ActiveItemPanel(ItemUI itemUI)
    {
        BagUI.Instance.ActiveItemPanel(itemUI);
    }

    /// <summary>
    /// Uses the item.使用物品
    /// </summary>
    /// <param name="itemUI">ItemUI.</param>
    public void UseItem(ItemUI  itemUI)
    {
        if (itemUseData != null)
            itemUseData(itemUI.itembase.bagData);
        if (itemUseUI != null)
            itemUseUI(itemUI);
    }

    /// <summary>
    /// 增加物品
    /// </summary>
    public bool AddItem(ItemBase itembase)
    {
        int pos=addItemUI(itembase);
        if(pos==-1)
        {
            return false;
        }
        addItemData(itembase,pos);
        return true;
    }

}
