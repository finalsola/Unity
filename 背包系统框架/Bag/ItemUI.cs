using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemUI : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler,IPointerClickHandler {
    public ItemBase itembase;
    public int position;
    bool isLocked;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// Updatas the image.更新图标
    /// </summary>
    public void UpdataImage()
    {
        
    }

    /// <summary>
    /// 拖拽前关闭Raycast
    /// </summary>
    /// <param name="eventData">Event data.</param>
    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        
    }

    /// <summary>
    /// 更新图片位置
    /// </summary>
    /// <param name="eventData">Event data.</param>
    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        
    }
    /// <summary>
    /// 交换两个图片的itembase，并且更新itembase的位置信息
    /// </summary>
    /// <param name="eventData">Event data.</param>
    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        ItemUI itemUI2=eventData.pointerEnter.GetComponent<ItemUI>();
        BagCtrl.Instance.switchBagItem(itembase.bagData,itemUI2.itembase.bagData,this,itemUI2);
    }

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        if (itembase != null)
            ActiveItemPanel();
    }

    /// <summary>
    /// Items the panel.点击图标后，调用该函数，呼出物品信息面板
    /// </summary>
    void ActiveItemPanel()
    {
        BagCtrl.Instance.ActiveItemPanel(this);
    }
}
