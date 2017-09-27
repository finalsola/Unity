using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllItemList : Singleton<AllItemList> {
    List<ItemdataElement> Itemlist = new List<ItemdataElement>();
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	/// <summary>
	/// 通过读ItemList表，生成Itemlist动态数组
	/// </summary>
	void readItemList()
	{

	}
}

/// <summary>
/// 讲item表的每一行信息生成
/// </summary>
public class ItemdataElement
{
    //ID、物品名、描述、图片路径、物品类型等
}


