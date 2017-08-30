using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AddScence : MonoBehaviour {
    float _progress = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(LoadScene());
        }
	}
    IEnumerator LoadScene()
    {
        AsyncOperation Plane= SceneManager.LoadSceneAsync(0);
        Plane.allowSceneActivation = false;
        while (Plane.progress < 0.9f)
        {
            _progress = Mathf.Lerp(_progress, Plane.progress, 1 / (Plane.progress-_progress));
            Debug.Log(Plane.progress);
            yield return null;
        }
        while (_progress < 1.0f)
        {
            _progress = Mathf.Lerp(_progress, 1.0f, 1/(1-_progress));
            Debug.Log(_progress);
			yield return null;
        }
        Plane.allowSceneActivation = true;
    }
    private void OnGUI()
    {
        GUI.skin.label.fontSize = 50;
        GUI.color = Color.black;
        GUI.skin.label.alignment = TextAnchor.MiddleCenter;
        GUI.Label(new Rect(0,0,Screen.width,Screen.height),(_progress*100).ToString("F2") + "%");//
	}
}
