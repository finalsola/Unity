Shader "LXM/SpecularVertexShader"
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
				fixed3 color : COLOR;
			};


			v2f vert (appdata v)
			{
				v2f o;

				o.pos = UnityObjectToClipPos(v.pos); //模型空间转换到齐次空间
				fixed3 lightColor = _LightColor0.rgb;
				float3 worldNormal = normalize(mul((float3x3)_Object2World, v.normal)); //将法线从模型空间转到世界坐标系下
				float3 lightDir = normalize(_WorldSpaceLightPos0.xyz);
				float3 reflectDir = normalize(reflect(-lightDir, worldNormal));
				float3 cameraDir = normalize(_WorldSpaceCameraPos.xyz - mul(_Object2World, v.pos).xyz);
				fixed3 SpecluarColor = lightColor * _SpecularColor.rgb * pow(saturate(dot(cameraDir, reflectDir)), _Gloss);

				fixed3 diffuseColor = lightColor * _DiffuseColor.rgb * (dot(v.normal, lightDir) * 0.5 + 0.5);

				o.color = SpecluarColor + diffuseColor + UNITY_LIGHTMODEL_AMBIENT.rgb;
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				return fixed4(i.color, 1.0);
			}

			ENDCG
		}
	}
}
