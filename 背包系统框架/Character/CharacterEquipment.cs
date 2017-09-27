using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class CharacterEquipment : MonoBehaviour,IPointerClickHandler {
    ItemBase itembase;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// 更新图片
    /// </summary>
    public void UpdataImage(ItemBase itembase)
    {
        
    }

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        if(itembase!=null)
        CharacterCtrl.Instance.UnLoad(itembase);
    }
}
