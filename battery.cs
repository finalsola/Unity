using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class battery : MonoBehaviour {
    public Transform target;
    public Transform ammor;
    public float v=10;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(target);
		if(Input.GetKeyDown(KeyCode.Space ))
        {
            ammor=Instantiate(ammor, transform.position, transform.rotation);
            bullet bullettmp = ammor.GetComponent<bullet>();
            bullettmp.target = target;
            bullettmp.v = v;
        }
	}
}
