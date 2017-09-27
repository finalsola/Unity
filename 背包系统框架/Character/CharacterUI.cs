using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterUI : Singleton<CharacterUI> {
    CharacterEquipment[] Equipments;//各个装备格子的脚本
	// Use this for initialization
	void Start () {
		Adddelegate();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// 初始化委托
    /// </summary>
    void Adddelegate()
    {
        CharacterCtrl.Instance.equipCharacterUI += Equip;
        CharacterCtrl.Instance.unloadCharacterUI += Unload;
    }

    /// <summary>
    /// 穿戴装备
    /// </summary>
    /// <returns>The equip.</returns>
    /// <param name="itembase">Itembase.</param>
    void Equip(ItemBase itembase)
    {
        int i = 0;//只是为了下面那句话不报错，记得删除
        //根据装备的类型，选择对应的装备格子
        Equipments[i].UpdataImage(itembase);

    }

    /// <summary>
    /// 脱装备
    /// </summary>
    void Unload(ItemBase itembase)
    {
		int i = 0;//只是为了下面那句话不报错，记得删除
				  //根据装备的类型，选择对应的装备格子
        Equipments[i].UpdataImage(null);
    }
}
