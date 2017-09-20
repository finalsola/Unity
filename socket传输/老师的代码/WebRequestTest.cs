using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using UnityEngine;

public class WebRequestTest : MonoBehaviour {

    string url = "http://img1.gamersky.com/image2017/09/20170919_ls_141_2/gamersky_013origin_025_201791918148EB.jpg";
    Texture texture;
    Texture texture_2;

	// Use this for initialization
    IEnumerator Start () {
        //WebRequest request = WebRequest.Create(url);
        //WebResponse response = request.GetResponse();
        //Stream stream = response.GetResponseStream();
        //StreamReader sr = new StreamReader(stream, System.Text.Encoding.UTF8);
        //string str = sr.ReadToEnd();
        //Debug.Log(str);

        WWW www = new WWW(url);
        yield return www;
        texture = www.texture;

        WWW www_2 = new WWW(url);
        yield return www_2;
        texture_2 = www_2.texture;

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnGUI()
    {
        if(texture)
            GUI.DrawTexture(new Rect(0,0, 100, 100), texture);
		if (texture_2)
            GUI.DrawTexture(new Rect(Screen.width - 100, 0, 100, 100), texture_2);
    }
}
