Shader "LXM/VertexBigShader"
{
	Properties
	{
		_Color("MainColor", Color) = (1,1,1,1)
		_ScaleFactor("ScaleFactor", Range(0.0,1.0)) = 0.5
	}
	SubShader
	{
		
		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"

			fixed4 _Color;
			fixed  _ScaleFactor;

			struct appdata
			{
				float4 vertex : POSITION;
				float3 normal : NORMAL;
			};

			float4 vert (appdata v) : SV_POSITION
			{
				float4 viewPos = mul(UNITY_MATRIX_MV, v.vertex);
				float3 viewNormal = mul(UNITY_MATRIX_IT_MV, v.normal);
				viewPos = float4(viewPos.xyz + viewNormal * _ScaleFactor, viewPos.w);
				return mul(UNITY_MATRIX_P, viewPos);
			}
			
			fixed4 frag () : SV_Target
			{
				return _Color;
			}
			ENDCG
		}
	}
}
