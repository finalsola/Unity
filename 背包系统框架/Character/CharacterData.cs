using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterData : Singleton<CharacterData> {
    List<ItemBase> Equipments = new List<ItemBase>();
	// Use this for initialization
	void Start () {
        AddDelegate();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// 初始化委托
    /// </summary>
    void AddDelegate()
    {
        CharacterCtrl.Instance.equipCharacterData+=AddEquipment;
    }

    /// <summary>
    /// 读表，更新装备数据
    /// </summary>
    void readEquipments()
    {
        
    }

    /// <summary>
    /// 写表，保存装备数据
    /// </summary>
    void writeEquipments()
    {
        
    }

    /// <summary>
    /// 穿装备
    /// </summary>
    /// <param name="itembase">Itembase.</param>
    void AddEquipment(ItemBase itembase)
    {
        //穿装备，检查Equipments中是否有相同类型的装备，有的话就进行替换
    }

    /// <summary>
    /// 脱装备
    /// </summary>
    /// <returns>The unload.</returns>
    /// <param name="itembase">Itembase.</param>
    void Unload(ItemBase itembase)
    {
        Equipments.Remove(itembase);
    }
}
