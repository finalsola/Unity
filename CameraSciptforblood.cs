using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSciptforblood : MonoBehaviour
{
    public Transform target;
    float h;
    float v;
    float hkey;
    float vkey;
    #region 血条
    Vector3 Screenpos;
    public float width = 320;
    public float height = 50;
    public Texture bloodline;
    public float scaleparaforbloodline = 100;
    public float bloodliney = 2;
    public float bloodprecentage = 1;
    #endregion
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target);
        h = Input.GetAxis("Mouse X");
        v = Input.GetAxis("Mouse Y");
        hkey = Input.GetAxis("Horizontal");
        vkey = Input.GetAxis("Vertical");

        transform.RotateAround(target.position, transform.right, -v);
        transform.RotateAround(target.position, transform.up, h);

        transform.Translate(target.TransformDirection(new Vector3(hkey, 0, vkey)), Space.World);


        #region 血条

        Screenpos = Camera.main.WorldToScreenPoint(target.TransformPoint(new Vector3(0, bloodliney, 0)));

        //如果不希望血条会随着对象的转动而转动（头朝下，血条在下面），则按下面这样写。
        // Screenpos = Camera.main.WorldToScreenPoint(new Vector3(target.position.x, target.position.y+bloodliney, target.position.z));
        Debug.Log(Screenpos);
        if (bloodprecentage > 1)
            bloodprecentage = 1;
        else if (bloodprecentage < 0)
            bloodprecentage = 0;
        #endregion
    }
    #region 血条
    private void OnGUI()
    {
		float dotResult = Vector3.Dot(transform.forward, target.position - transform.position);//判断物体是否在摄像头前方
		if (dotResult > 0)
		{
			float bloodwith = bloodprecentage * width;
			float para = scaleparaforbloodline / Screenpos.z;
			GUI.DrawTexture(new Rect(Screenpos.x - width / 2 * para, Screen.height - Screenpos.y - height / 2 * para, width * para * bloodprecentage, height * para), bloodline);
		}
    #endregion
}
