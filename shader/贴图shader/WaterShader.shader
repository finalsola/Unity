// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

Shader "LXM/WaterShader"
{
	Properties
	{
		_Raduis("Raduis", Range(1, 50)) = 5
		_LogFactor("LogFactor", Range(0.5, 3)) = 3
		_Gloss("Gloss", Range(0,2)) = 2
	}
	SubShader
	{
		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"

			float _Raduis;
			float _LogFactor;
			float _Gloss;

			struct appdata
			{
				float4 pos : POSITION;
			};

			struct v2f
			{
				float4 pos : SV_POSITION;
				float3 worldPos : NORMAL;
				float3 origPos : TEXCOORD0;
			};

			v2f vert (appdata v)
			{
				v2f o;
				float4 worldPos = mul(unity_ObjectToWorld, v.pos);
				float3 origPos = mul(unity_ObjectToWorld, float4(0,0,0,1)).xyz;
				o.worldPos = worldPos.xyz;
				o.origPos = origPos;
				float dis = distance(worldPos.xyz, origPos);

				if(dis < _Raduis && dis > _Raduis - _LogFactor)
				{
					//color = fixed3(0,1,0);
					worldPos.y += _Gloss;
				}

				o.pos = mul(UNITY_MATRIX_VP, worldPos);
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				fixed3 color = fixed3(0,1,1);
				float dis = distance(i.worldPos, i.origPos);
				if(dis < _Raduis && dis > _Raduis - _LogFactor)
				{
					color = fixed3(0,1,0);
				}
				else
				{
					color = fixed3(0,1,1);
				}
				return fixed4(color, 1.0);
			}
			ENDCG
		}
	}
}
