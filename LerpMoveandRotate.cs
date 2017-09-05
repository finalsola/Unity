using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpMoveandRotate : MonoBehaviour {
    Transform target;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //平滑移动
        transform.position = Vector3.Lerp(transform.position, target.position,1/Vector3.Distance(transform.position,target.position));
        //平滑旋转
        Quaternion targetQ = Quaternion.LookRotation(target.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetQ, 1 / Quaternion.Angle(transform.rotation, targetQ) * 0.1f);

	}
}
