using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneScript : MonoBehaviour {
    float h;
    float v;
    public  Transform ammo;
    public float MaxAngle;
    public float MinAngle;
    public float GapAngle;
    public float Frequency;
    public float CurrentAngle;
    float TmpAngle=0;
    public int LoopTimes;
    bool canSpShoot = true;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        move();
        if(Input.GetKey(KeyCode.Space))
        shoot();

        if(Input.GetKey(KeyCode.M))
        {
            if (canSpShoot)
            StartCoroutine(spShoot()); 
        }
	}


    void move()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(h,0,v),Space.World);
    }

    void shoot()
    {
        Instantiate(ammo,new Vector3(transform.position.x,transform.position.y,transform.position.z+1.685774f / 2) ,transform.rotation); 
    }
    IEnumerator spShoot(){
        canSpShoot = false;
        while(TmpAngle<(MaxAngle-MinAngle)*LoopTimes)
        {
            CurrentAngle = Mathf.PingPong(TmpAngle, MaxAngle - MinAngle) + MinAngle;
			TmpAngle += GapAngle;
            Instantiate(ammo, new Vector3(transform.position.x, transform.position.y, transform.position.z + 1.685774f / 2), transform.rotation*Quaternion.AngleAxis(CurrentAngle,Vector3.up));
			yield return new WaitForSeconds(Frequency);
        }
        canSpShoot = true;
    }

}
