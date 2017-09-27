// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

Shader "LXM/DiffuseFragmentShader"
{
	Properties
	{
		_DiffuseColor("DiffuseColor", Color) = (1,1,1,1)
	}
	SubShader
	{
		
		Pass
		{
			tags{"LightMode" = "ForwardBase"}
			
			CGPROGRAM

			#include "Lighting.cginc" //引入Lighting的头文件，在Unity安装目录下能找到这个文件，建议多看看，包括 "UnityCG.cginc"

			#pragma vertex vert
			#pragma fragment frag

			fixed4 _DiffuseColor;

			struct appdata
			{
				float4 pos : POSITION;
				float3 normal : NORMAL;
			};

			struct v2f
			{
				float4 pos : SV_POSITION;
				fixed3 normal : NORMAL;
			};
			
			v2f vert (appdata v)
			{
				v2f o;
				o.pos = UnityObjectToClipPos(v.pos); //模型空间转换到齐次空间
				o.normal = normalize(mul((float3x3)unity_ObjectToWorld, v.normal)); //将法线从模型空间转到世界坐标系下
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				fixed3 ambientColor = UNITY_LIGHTMODEL_AMBIENT.rgb;   //可以获取场景中环境光的颜色和强度
				float3 lightDir = normalize(_WorldSpaceLightPos0.xyz); //获取世界中平行光源光线的入射向量。但是这个向量是从顶点指向光源方向的。
				fixed3 diffuseColor = _DiffuseColor.rgb * _LightColor0.rgb * saturate(dot(i.normal, lightDir)); //漫反射光照模型公式,其中_DiffuseColor是自己在properties中设置好的。
				return fixed4(ambientColor + diffuseColor, 1.0); //最后将环境光叠加上去，注意不是混合，否则越混越暗
			}
			ENDCG
		}
	}
}
