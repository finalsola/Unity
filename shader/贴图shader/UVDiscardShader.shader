Shader "LXM/UVDiscardShader"
{
	Properties
	{
		_MaskFactor("MaskFactor", Range(0.0,1.0)) = 1
	}

	SubShader
	{
		Pass
		{
			cull off

			CGPROGRAM

			#pragma vertex vert
			#pragma fragment frag

			fixed _MaskFactor;

			struct appdata
			{
				float4 pos : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float4 pos : SV_POSITION;
				float2 uv : TEXCOORD0;
			};

			v2f vert(appdata v)
			{
				v2f o;
				o.pos = UnityObjectToClipPos(v.pos);
				o.uv = v.uv;
				return o;
			}

			fixed4 frag(v2f i) : SV_Target
			{
				if(i.uv.y > _MaskFactor)
				{
					discard;
				}
				return fixed4(0,i.uv.y,0,1);
			}

			ENDCG
		}
	}
}
