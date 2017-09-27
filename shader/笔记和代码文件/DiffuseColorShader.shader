Shader "LXM/DiffuseColorShader"
{
	SubShader
	{
		Pass
		{
			CGPROGRAM //用来描述CG语言的起始点

			#pragma vertex vert //用来告诉shader编译器这个叫vert的函数是顶点着色器
			#pragma fragment frag //用来告诉shader编译器这个叫frag的函数是片段着色器

			float4 vert(float4 v : POSITION, float4 n : NORMAL) : SV_POSITION  //顶点着色器的输出结果是坐标 SV_表示从函数中输出出去的
			{
				//return mul(UNITY_MATRIX_MVP, v);
				return UnityObjectToClipPos(v); //和上面一行都是代表MVP矩阵，转换坐标系用的
			}

			fixed4 frag() : SV_Target
			{
				return fixed4(1,0,0,1); //最后结果返回一个Fixed4存储的最终颜色。
			}

			ENDCG //用来描述CG语言到此为止
		}
	}
}
