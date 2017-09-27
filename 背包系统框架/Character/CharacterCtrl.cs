using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCtrl : Singleton<CharacterCtrl> {

    public delegate void EquipCharacterUI(ItemBase itembase);
    public delegate void EquipCharacterData(ItemBase itembase);
	public delegate void UnloadCharacterUI(ItemBase itembase);
	public delegate void UnloadCharacterData(ItemBase itembase);

    public EquipCharacterUI equipCharacterUI;
    public EquipCharacterData equipCharacterData;
	public UnloadCharacterUI unloadCharacterUI;
	public UnloadCharacterData unloadCharacterData;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// 穿装备
    /// </summary>
    public void Equip(ItemBase itembase)
    {
        equipCharacterUI(itembase);
        equipCharacterData(itembase);
    }

    /// <summary>
    /// 脱装备
    /// </summary>
    public void UnLoad(ItemBase itembase)
    {
        unloadCharacterUI(itembase);
        unloadCharacterData(itembase);
        if(BagCtrl.Instance.AddItem(itembase))
        {
            //提示背包已满
        }
    }

    /// <summary>
    /// 吃药，可以把不同药派生成不同的类，不同类的useitem()，引用CharacterCtrl的方法不同
    /// </summary>
    public void UseMedicine(ItemBase itembase)
    {
        
    }
}
