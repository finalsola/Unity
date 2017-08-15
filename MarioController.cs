using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioController : MonoBehaviour {
	float h = 0;
	float v = 0;
	public float speedMove = 5.0f;
	public float jumpHeight =10.0f;
	Animation anim;
	Rigidbody rig;
	bool isJump;
	// Use this for initialization
	void Start () {
		anim =transform.GetComponent<Animation> ();
		rig = transform.GetComponent<Rigidbody> ();
		isJump = false;
	}
	
	// Update is called once per frame
	void Update () {
		h = Input.GetAxis ("Horizontal");
		v = Input.GetAxis ("Vertical");

		transform.position += new Vector3(h,0,v) * speedMove * Time.deltaTime;
		transform.LookAt (new Vector3 (h, 0, v) + transform.position);
		if (!Mathf.Approximately(h,0)|| !Mathf.Approximately(v,0)) {
			anim.CrossFade ("Run");
		} 
//		else if(!anim.IsPlaying("Jump")){
//			anim.CrossFade ("Idle");
//		}
		if (Input.GetKeyDown (KeyCode.Space)  && !isJump) {
			isJump = true;
			anim.Play ("Jump");

			rig.AddForce (new Vector3 (h, 1, v) * jumpHeight, ForceMode.Impulse);
		}
		//Debug.Log (rig.velocity.y);
		if (rig.velocity.y < 0 && isJump) {
			anim.CrossFade ("Foll");
		}
		//什么时候执行跳跃动画
		//什么时候从跳跃动画变到待机动画


	}

	void OnTriggerEnter(Collider col){
		Debug.Log ("Enter");
		if (isJump) {
			isJump = false;
			anim.CrossFade ("Idle",0.1f);
		}
	}

	void OnGUI(){
		GUILayout.Label ("rig.velocity.y:" + rig.velocity.y);
	}
}
