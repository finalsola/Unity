using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ToggleGrouptest : MonoBehaviour
{
    public RectTransform Planet;
    float gap;
    public RectTransform[] Images;
    Pla pp;
    public Toggle[] TG;
    public Scrollbar sc;
    float targetValue;
    bool canscrolling = false;
    // Use this for initialization
    void Start()
    {
        TG[0].onValueChanged.AddListener(onValueChanged0);
        TG[1].onValueChanged.AddListener(onValueChanged1);
        TG[2].onValueChanged.AddListener(onValueChanged2);
        pp = Planet.GetComponent<Pla>();
        gap = (float)1 / Images.Length;
        for (int i = 0; i < Images.Length; i++)
        {
            Images[i].anchoredPosition = new Vector2(gap * (0.5f + i) * Planet.rect.width, 0);
        }

    }
    /// <summary>
    ///Toggle的事件函数
    /// </summary>
    /// <param name="bl">If set to <c>true</c> bl.</param>
    void onValueChanged0(bool bl)
    {
        if (bl)
        {
            targetValue = 0;
        }
    }
    void onValueChanged1(bool bl)
    {
        if (bl)
        {
            targetValue = 0.5f;
        }

    }
    void onValueChanged2(bool bl)
    {
        if (bl)
        {
            targetValue = 1;
        }
    }
    // Update is called once per frame
    void Update()
    {
        scrollAfter();
    }

    /// <summary>
    /// 当点击鼠标时候，只设定移动的目标值，但不移动，移动由鼠标拖动执行；当不点击鼠标时，由目标值来实现移动
    /// </summary>
    void scrollAfter()
    {
        if (!Input.GetKey((KeyCode.Mouse0)))
        {
            scrollmove();
            return;
        }
        if (Mathf.Approximately(sc.value, targetValue))
            return;
        if (sc.value < 0.166f)
        {
            TG[0].isOn = true;
        }
        else if (sc.value >= 0.166f && sc.value <= 0.834f)
        {
            TG[1].isOn = true;
        }
        else if (sc.value > 0.834f)
        {
            TG[2].isOn = true;
        }
        canscrolling = false;

    }
    void scrollmove()
    {
        sc.value = Mathf.Lerp(sc.value, targetValue, 0.1f);
        if (Mathf.Abs(sc.value - targetValue) < 0.01f)
        {
            sc.value = targetValue;
        }

    }

}
