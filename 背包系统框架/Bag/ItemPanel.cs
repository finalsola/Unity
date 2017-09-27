using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPanel : Singleton<ItemPanel> {
    ItemBase itembase;
    ItemUI itemUI;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// Updatas the panel.根据持有的itembase信息，更新面板信息
    /// </summary>
    public void UpdataPanel(ItemUI itemUI)
    {
        this.itembase = itemUI.itembase;
        this.itemUI = itemUI;
    }

    /// <summary>
    /// Uses the item.点击使用物品
    /// </summary>
    void UseItem()
    {
        itembase.UseItem(itemUI);
    }

    /// <summary>
    /// Closes the panel.关闭信息面板
    /// </summary>
    void ClosePanel()
    {
        
    }
}
