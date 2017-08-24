using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {
    public float v = 10;
    const float g = -9.8f;
    float vertical;
    float horizontal;
    float vv;
    float hv;
    float a;
    float b;
    float c;
    float hv1;
    float hv2;
    float delta;
    float t;
    Vector3 Hforward;
    public  Transform target;
	// Use this for initialization
	void Start () {
        vertical = -transform.position.y + target.position.y;//垂直方向上的距离
        float tmpx = transform.position.x - target.position.x;//水平方向上X分量的距离
        float tmpy = transform.position.z - target.position.z;//水平方向上Z分量的距离
        horizontal = Mathf.Sqrt(tmpx * tmpx + tmpy * tmpy);//用上面两个数据，计算水平方向上的距离

        //t=horizontal/hv;          垂直方向上，垂直速度分量、时间、垂直距离的关系
        //vv*t+g*t*t/2=vertical;    水平方向上，水平速度分量、时间、水平距离的关系
        //hv*hv+vv*vv=v*v;          水平速度的分量、垂直速度的分量、总速度之间的关系

        //以上三个公式联立解出关于hv的1元4次方程组，形式大致为a*hv^4+b*hv^2+c=0;
        //根据1元二次方程的解法，可以解的hv^2的值
        //注意三种情况，①无解    ②有两解，但两解都为负数    ③至少有一个正数解，直接用大的解即可。原因为省去判断小的解是否为正；用大的解，水平方向速度更大，抛物线更好看。小的解很可能会出现高抛现象
        a = Vector3.Distance(transform.position, target.position) * Vector3.Distance(transform.position, target.position);
        b = -horizontal * horizontal * v * v - g * horizontal * horizontal * vertical;
        c = g * g * horizontal * horizontal * horizontal * horizontal / 4;
        Hforward = new Vector3(transform.forward.x, 0, transform.forward.z);
        if (b * b - 4 * a * c < 0)//①hv^2无解
		{
			vv = Mathf.Sqrt(2) * v / 2;
			hv = Mathf.Sqrt(2) * v / 2;
            Debug.Log("敌人太远，无法击中");
        }
        else
        {
            delta = b * b - 4 * a * c;
            if (-b + Mathf.Sqrt(delta) < 0)//②有两解，但两解都为负数
			{
                vv = Mathf.Sqrt(2)*v/2;
                hv = Mathf.Sqrt(2) * v / 2;
                Debug.Log("敌人太远，无法击中");
            }
            else//③至少有一个正数解，直接用大的解即可。
			{
                //hv1 = (-b + Mathf.Sqrt(delta)) / (2 * a);
                //hv2 = (-b - Mathf.Sqrt(delta)) / (2 * a);
                //if (hv1 < 0 && hv2 < 0)
                //{
                //    vv = Mathf.Sqrt(2) * v / 2;
                //    hv = Mathf.Sqrt(2) * v / 2;
                //    Debug.Log("敌人太远，无法击中");
                //}
                //else
                //{

                    hv = Mathf.Sqrt((-b + Mathf.Sqrt(delta)) / (2 * a)); //直接选取较大速度

                    t = horizontal / hv;
                    vv = (vertical - g * t * t / 2) / t;
                //}
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
        vv += g * Time.deltaTime;
        transform.Translate(Vector3.up*vv*Time.deltaTime, Space.World);
        transform.Translate(Hforward * hv * Time.deltaTime, Space.World);
	}
}
