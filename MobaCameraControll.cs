using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour {
    Vector3 mousePosition;
    float x;
    float y;
    public float speed = 5;
    // Use this for initialization
    void Start () {
        
    }
    
    // Update is called once per frame
    void Update () {
        mousScreenMove();

    }

    void mousScreenMove()
    {
        x = 0;
        y = 0;

        if(Input.mousePosition.x<0||Input.mousePosition.x>Screen.width)
		{
            x = Input.mousePosition.x / Mathf.Abs(Input.mousePosition.x);
            y = -Screen.height / 2 + Input.mousePosition.y;
            y = 2*y/Screen.height;
        }
        else if (Input.mousePosition.y < 0 || Input.mousePosition.y > Screen.height)
		{
            y = Input.mousePosition.y / Mathf.Abs(Input.mousePosition.y);
            x =- Screen.width / 2 +Input.mousePosition.x;
            x = 2 *x/ Screen.width;
		}
        x = Mathf.Clamp(x,-1, 1);
        y = Mathf.Clamp(y, -1, 1);

        transform.Translate(new Vector3(x*Time.deltaTime*speed,0,y*Time.deltaTime*speed));
    }
}
