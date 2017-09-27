using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagData : Singleton<BagData> {
    List<BagDataElement> BagDataList = new List<BagDataElement>();    //背包基础数据
    List<ItemBase> BagDataItemBaseList = new List<ItemBase>();          //背包itembase数据集合
	// Use this for initialization
	void Start () {
        readBagData();
        initializeBagDataItemBaseList();

        //初始化委托
        AddDelegateOfBagCtrl();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    /// <summary>
    /// Reads the bag data.
    /// </summary>
    public void readBagData()
    {
        //读表，然后赋值给BagDataList<BagDataElement>
    }
    /// <summary>
    /// Writes the bag data.
    /// </summary>
    public void writeBagData()
    {
		//BagDataList<BagDataElement>输出到txt中
	}

	/// <summary>
	/// add the itembase.根据BagData和AllitemList,new一个itembase，并将其加入到BagDataItemBaseList中
	/// </summary>
	public void AddItembase(BagData bagdata, ItemdataElement itemdataelement)
    {
        
    }

    /// <summary>
    /// 初始化itembase的动态数组
    /// </summary>
    void initializeBagDataItemBaseList()
    {
        //根据bagdatalist和alltimelist，循环调用AddItembase;
    }

    /// <summary>
    /// Adds the delegate of bag ctrl.初始化各种委托
    /// </summary>
    void AddDelegateOfBagCtrl()
    {
        BagCtrl.Instance.switchBagItemData+=switchBagData;
        BagCtrl.Instance.itemUseData += ItemUse;
        BagCtrl.Instance.addItemData += AddItem;
    }

    /// <summary>
    /// Switchs the bag data.交换背包的位置数据
    /// </summary>
    /// <param name="bagData1">Bag data1.</param>
    /// <param name="bagData2">Bag data2.</param>
    void switchBagData(BagData bagData1,BagData bagData2)
    {

        //最后更新表格
        writeBagData();
    }


    /// <summary>
    /// Items the use.使用物品后，更新背包数据
    /// </summary>
    void ItemUse(BagData bagData)
    {
        
    }

    /// <summary>
    /// 增加物品
    /// </summary>
    /// <param name="itembase">Itembase.</param>
    void AddItem(ItemBase itembase,int position)
    {
        //UI层返还给控制层的位置，再传给数据层
        //为两个List添加元素；
    }
}

/// <summary>
/// Bag data list.
/// </summary>
public class BagDataElement
{
    //ID、position、count
}
