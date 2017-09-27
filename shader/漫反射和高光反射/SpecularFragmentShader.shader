// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

Shader "LXM/SpecularFragmentShader"
{
	Properties
	{
		_DiffuseColor("DiffuseColor", Color) = (1,1,1,1)
		_SpecularColor("SpecularColor", Color) = (1,1,1,1)
		_Gloss("Gloss", Range(1,500)) = 1
	}
	SubShader
	{
		Tags { "LightModel"="ForwardBase" }

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			#include "Lighting.cginc"

			fixed4 _DiffuseColor;
			fixed4 _SpecularColor;
			float _Gloss;

			struct appdata
			{
				float4 pos : POSITION;
				float3 normal : NORMAL;
			};

			struct v2f
			{
				float4 pos : SV_POSITION;
				fixed3 worldNormal : NORMAL;
				float3 cameraDir : TEXCOORD;
			};


			v2f vert (appdata v)
			{
				v2f o;

				o.pos = UnityObjectToClipPos(v.pos); //模型空间转换到齐次空间
				o.worldNormal = normalize(mul((float3x3)unity_ObjectToWorld, v.normal)); //将法线从模型空间转到世界坐标系下
				o.cameraDir = normalize(_WorldSpaceCameraPos.xyz - mul(unity_ObjectToWorld, v.pos).xyz); //通过摄像机的世界坐标位置和顶点在世界坐标系下的位置得到从顶点指向摄像机的方向向量

				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				fixed3 lightColor = _LightColor0.rgb; //获取平行光的颜色和强度，同漫反射
				float3 lightDir = normalize(_WorldSpaceLightPos0.xyz); //获取平行光的颜色
				float3 reflectDir = normalize(reflect(-lightDir, i.worldNormal)); //得到光线通过法线反射得到的反射向量。
				fixed3 SpecluarColor = lightColor * _SpecularColor.rgb * pow(saturate(dot(i.cameraDir, reflectDir)), _Gloss); //高光颜色的光照模型

				fixed3 diffuseColor = lightColor * _DiffuseColor.rgb * (dot(i.worldNormal, lightDir) * 0.5 + 0.5); //漫反射光照模型

				return fixed4(SpecluarColor + diffuseColor + UNITY_LIGHTMODEL_AMBIENT.rgb, 1.0); //最终的结果是高光颜色+漫反射颜色+环境光颜色
			}

			ENDCG
		}
	}
}
