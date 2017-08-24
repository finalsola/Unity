using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScipt : MonoBehaviour {
    public Transform target;
    float h;
    float v;
    float hkey;
    float vkey;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(target);
        h = Input.GetAxis("Mouse X");
        v = Input.GetAxis("Mouse Y");
        hkey = Input.GetAxis("Horizontal");
        vkey = Input.GetAxis("Vertical");

        transform.RotateAround(target.position, transform.right, -v);
        transform.RotateAround(target.position, transform.up, h);

        transform.Translate(target.TransformDirection(new Vector3(hkey, 0, vkey)), Space.World);
    }
}
