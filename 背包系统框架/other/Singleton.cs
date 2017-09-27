using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T:MonoBehaviour{
    private static T instance;
    //Return the instance of this singleton

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
				instance = (T)FindObjectOfType(typeof(T));

                if(instance==null)
                {
                    Debug.LogError("An Instance of"+typeof(T)+"is needed in the scene, but there is none");
                }
            }

            return instance;
        }
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
