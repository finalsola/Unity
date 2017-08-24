using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour {
    float hkey;
    float vkey;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        hkey = Input.GetAxis("Horizontal");
        vkey = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(hkey, 0, vkey));
    }
}
