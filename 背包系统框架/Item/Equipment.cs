using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : ItemBase {
    public override void UseItem(ItemUI itemUI)
    {
        //让BagCtrl更新背包数据和背包面板
        BagCtrl.Instance.UseItem(itemUI);
		//这里的功能实现放在哪里好？？？
		CharacterCtrl.Instance.Equip(itemUI.itembase);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
