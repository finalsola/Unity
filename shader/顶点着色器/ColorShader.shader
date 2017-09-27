// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "LXM/ColorShader"
{
//	Properties
//	{
//		//_Color("MainColor", Color) = (0,0,1,1)
//		//_ScaleFactor("ScaleFactor", Range(0.0, 5.0)) = 0.0
//	}

	SubShader
	{
		Pass
		{
			CGPROGRAM

			#pragma vertex vert
			#pragma fragment frag

			//是需要从MeshRenderer组建中传入特定的参数，而声明的结构体
			struct m2v
			{
				float4 pos : POSITION; //需要模型空间中的顶点坐标
				float3 nor : NORMAL; //需要每一个顶点的法线
			};

			//是需要从顶点着色器函数中输出到片段着色器中的结构而声明的结构体
			struct v2f
			{
				float4 pos : SV_POSITION; //需要一个必须的齐次空间下的坐标
				fixed3 color : COLOR0; //需要一个颜色
			};

			//fixed4 _Color; //如果想要在SubShader中使用在Properties中定义的变量，就需要在此定义一个变量名一模一样的变量。
			//float _ScaleFactor;

			v2f vert(m2v v)
			{
				v2f f;
				f.pos = UnityObjectToClipPos(v.pos);
				f.color = v.nor * 0.5 + fixed3(0.5,0.5,0.5); //通过每一个顶点的法线计算该顶点所要呈现的颜色，因为是球体，所以法线的方向是任意的，三个分量的取值范围是-1~1，但是颜色的取值范围是0~1，所以*0.5+0.5
				return f;
			}

			//在片段着色器中需要v2f对象，所以就接收一下，从顶点着色器中传过来的，最后通过这个参数输出SV_Target
			fixed4 frag(v2f f) : SV_Target
			{
				return fixed4(f.color, 1.0);
			}

			ENDCG	
		}
	}
}
