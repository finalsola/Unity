using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Canvas2 : MonoBehaviour,IDragHandler {
	RectTransform rectTransform;
	Camera mainCamera;
	RectTransform canvas;
	Vector3 mousepos;
    Canvas canvasScript;
    float canvasDepth;
    // Use this for initialization
    void Start()
    {
        rectTransform = transform as RectTransform;
        mainCamera = Camera.main;
        canvas = transform.parent as RectTransform;
        canvasScript = canvas.GetComponent<Canvas>();
        canvasDepth = canvasScript.planeDistance;
    }

    
    // Update is called once per frame
    void Update () {
        
    }
	public void OnDrag(PointerEventData eventData)
	{
        mousepos = Input.mousePosition;
        mousepos = mainCamera.ScreenToWorldPoint(new Vector3(mousepos.x, mousepos.y, canvasDepth));
        rectTransform.position = mousepos;
   //     if (transform.localPosition.x > canvas.rect.width / 2-rectTransform.rect.width/2)
   //         transform.localPosition = new Vector3(canvas.rect.width / 2- rectTransform.rect.width / 2, transform.localPosition.y, 0);
   //     else if(transform.localPosition.x<-canvas.rect.width/2+ rectTransform.rect.width / 2)
			//transform.localPosition = new Vector3(-canvas.rect.width / 2+ rectTransform.rect.width / 2, transform.localPosition.y, 0);
        //if(transform.localPosition.y>canvas.rect.height/2-rectTransform.rect.height/2)
        //    transform.localPosition = new Vector3(transform.localPosition.x, canvas.rect.height/2- rectTransform.rect.height / 2, 0);
        //else if(transform.localPosition.y < -canvas.rect.height / 2+rectTransform.rect.height / 2)
            //transform.localPosition = new Vector3(transform.localPosition.x, -canvas.rect.height / 2+ rectTransform.rect.height / 2, 0);
        //避免出界；
        rectTransform.localPosition = new Vector3(Mathf.Clamp(transform.localPosition.x, -canvas.rect.width / 2 + rectTransform.rect.width / 2, canvas.rect.width / 2 - rectTransform.rect.width / 2),
                                                Mathf.Clamp(transform.localPosition.y, -canvas.rect.height / 2 + rectTransform.rect.height / 2, canvas.rect.height / 2 - rectTransform.rect.height / 2));
	}
}
