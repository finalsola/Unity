using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagUI : Singleton<BagUI> {
    Dictionary<int, ItemUI> itemUIList = new Dictionary<int, ItemUI>();//存储背包所有格子的键值对<pos,ItemUI>
	// Use this for initialization
	void Start () {
        CreatItemUIList();
        AddDelegate();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    /// <summary>
    /// Creats the itemUIList.通过读表，创建itemUIList
    /// </summary>
    void CreatItemUIList()
    {
        
    }
    /// <summary>
    /// Updatas the itemUIList.更新存储背包格子信息的List
    /// </summary>
    void UpdataItemUIList()
    {
        
    }

    /// <summary>
    /// Adds the delegate.初始化各种委托
    /// </summary>
    void AddDelegate()
    {
        BagCtrl.Instance.switchBagItemUI += switchItemUI;
        BagCtrl.Instance.itemUseUI += UseItem;
        BagCtrl.Instance.addItemUI += AddItem;
    }
    /// <summary>
    /// 交换两个背包
    /// </summary>
    /// <param name="itemUI1">Item user interface.</param>
    /// <param name="itemUI2">Item user interface.</param>
    void switchItemUI(ItemUI itemUI1,ItemUI itemUI2)
    {
        itemUI1.UpdataImage();
        itemUI2.UpdataImage();
    }

    /// <summary>
    /// Actives the item panel.激活物品信息面板
    /// </summary>
    /// <param name="itemUI">ItemUI.</param>
    public void ActiveItemPanel(ItemUI itemUI)
    {
        ItemPanel.Instance.gameObject.SetActive(true);
        ItemPanel.Instance.UpdataPanel(itemUI);
    }

    /// <summary>
    /// Uses the item.使用道具，更新面板
    /// </summary>
    void UseItem(ItemUI itemUI)
    {
        itemUI.UpdataImage();
    }

    int AddItem(ItemBase itembase)
    {
        int pos=-1;//如果直接返回-1，则表示没有空位置
        //遍历itemUIList，找到第一个itembase为空的引用，将itembase赋值给他，并获取其位置
        return pos;
    }
}
