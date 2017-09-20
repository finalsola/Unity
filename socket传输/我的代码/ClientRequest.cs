using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientRequest : MonoBehaviour {
    string url = "https://ss0.baidu.com/6ONWsjip0QIZ8tyhnq/it/u=3278764716,4211823333&fm=58&u_exp_0=2711731101,3878517923&fm_exp_0=86&bpow=640&bpoh=905";
    Texture texture1;
    Texture texture2;
	// Use this for initialization
    IEnumerator Start () {
        WWW www = new WWW(url);
        yield return www;
        texture1 = www.texture;
        WWW www2 = new WWW(url);
        yield return www2;
        texture2 = www2.texture;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnGUI()
    {
        GUI.DrawTexture(new Rect(50,0,100,100),texture1);
        //GUI.DrawTexture(new Rect(Screen.width-100,0,100,100),texture2);
    }
}
