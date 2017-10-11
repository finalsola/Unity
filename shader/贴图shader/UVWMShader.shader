// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

Shader "LXM/UVWMShader"
{
	Properties
	{
		_WMWidht("WMWidht", Range(0.0,1.0)) = 1
		_WMMD("WMMD", Range(10, 100)) = 10
		_Gloss("Gloss", Range(5, 256)) = 5.0
	}

	SubShader
	{
		Pass
		{
			tags{"LightMode" = "ForwardBase"}

			
			cull off

			CGPROGRAM

			#pragma vertex vert
			#pragma fragment frag

			#include "Lighting.cginc"
			#include "UnityCG.cginc"

			fixed _WMWidht;
			float _WMMD;
			float _Gloss;

			struct appdata
			{
				float4 pos : POSITION;
				float2 uv : TEXCOORD0;
				float3 normal : NORMAL;
			};

			struct v2f
			{
				float4 pos : SV_POSITION;
				float2 uv : TEXCOORD0;
				float3 worldNormal : NORMAL;
				float3 viewDir : TEXCOORD1;
			};

			v2f vert(appdata v)
			{
				v2f o;
				o.pos = UnityObjectToClipPos(v.pos);
				o.uv = v.uv;
				o.worldNormal = mul(unity_ObjectToWorld, v.normal);
				float3 viewDir = _WorldSpaceCameraPos.xyz - mul(unity_ObjectToWorld, v.pos).xyz;
				o.viewDir = viewDir;
				return o;
			}

			fixed4 frag(v2f i) : SV_Target
			{
				fixed3 color;

				if((i.uv.x * _WMMD)% 2  > _WMWidht)
				{
					color = fixed3(0,0,0);
				}
				else
				{
					color = fixed3(0,1,0);
				}

				float3 norViewDir = normalize(i.viewDir);
				float3 norWorldNormal = normalize(i.worldNormal);
				fixed3 ambientColor = UNITY_LIGHTMODEL_AMBIENT.rgb;
				float3 lightColor = _LightColor0.rgb;
				float3 lightDir = normalize(_WorldSpaceLightPos0).xyz;
				float3 reflectDir = reflect(-lightDir, norWorldNormal);
				fixed3 diffuseColor = lightColor * color * (dot(norWorldNormal, lightDir) * 0.5 + 0.5);
				fixed3 specluarColor = lightColor * lightColor * pow(max(0, dot(norViewDir, reflectDir)), _Gloss);
				fixed3 finalColor = ambientColor + diffuseColor + specluarColor;

				return fixed4(finalColor, 1.0);
			}

			ENDCG
		}
	}
}
