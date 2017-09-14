using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Canvas1 : MonoBehaviour ,IDragHandler{
    RectTransform rectTransform;
    Camera mainCamera;
    RectTransform canvas;
    Vector3 mousepos;
    CanvasScaler canvasscaler;
	// Use this for initialization
	void Start () {
        rectTransform = transform as RectTransform;
        mainCamera = Camera.main;
        canvas = transform.parent as RectTransform;
        canvasscaler = canvas.GetComponent<CanvasScaler>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnDrag(PointerEventData eventData)
    {
        mousepos = Input.mousePosition;
        rectTransform.anchoredPosition = new Vector2(mousepos.x * canvas.rect.width / Screen.width, mousepos.y * canvas.rect.height / Screen.height);
        //更快速的方法
        //transform.position = Input.mousePosition / canvasscaler.scaleFactor;
    }
}
