Shader "LXM/VertexTransformShader"
{
	Properties
	{
		_OffsetFactor("OffsetFactor", Range(-1.0, 1.0)) = 0.0
	}

	SubShader
	{
		Pass
		{
		CGPROGRAM

		#pragma vertex vert
		#pragma fragment frag

		struct v2f
		{
			float4 pos : SV_POSITION;
			fixed3 color : COLOR;
		};

		float _OffsetFactor;

		v2f vert(float4 pos : POSITION)
		{
			v2f v;
			float4 viewPos = mul(UNITY_MATRIX_MV, pos);
			viewPos = float4(viewPos.x + viewPos.z * viewPos.z * _OffsetFactor, viewPos.y, viewPos.z, viewPos.w);
			v.color = fixed3(cos(viewPos.z),sin(viewPos.z),cos(viewPos.z));
			float4 clipPos = mul(UNITY_MATRIX_P, viewPos);
			v.pos = clipPos;
			return v;
		}

		fixed4 frag(v2f v) : SV_Target
		{
			return fixed4(v.color, 1.0);
		}

		ENDCG

		}
	}
}
