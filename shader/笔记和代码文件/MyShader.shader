Shader "LXM/MyShader"
{
	Properties
	{
		_Color("MainColor", Color) = (1,0,0,1)
		_SpecularColor("SpecularColor", Color) = (1,0,0,1)
		_AmbientColor("AmbientColor", Color) = (1,0,0,1)
	}

	SubShader
	{
		Pass
		{
			Lighting on
			Separatespecular on

			Material
			{
				Diffuse[_Color]
				Specular[_SpecularColor]
				Ambient[_AmbientColor]
			}
		}
	}
}
