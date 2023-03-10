Shader "RM Shaders/ Car Shading" {
	Properties {
		_Color ("Color", Vector) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_SpecTex ("Specular Map (A)", 2D) = "white" {}
		_BumpMap ("Bumpmap", 2D) = "bump" {}
		_AOTexture ("AO Texture (RGB)", 2D) = "white" {}
		_Glossiness ("Smoothness", Range(0, 1)) = 0.5
		_Metallic ("Metallic", Range(0, 1)) = 0
		_RimColor ("Rim Color", Vector) = (0.26,0.19,0.16,0)
		_RimPower ("Rim Power", Range(-2, 10)) = 0
		_RimLight ("Rim Light", Range(0, 5)) = 1
		_Cube ("Cubemap", Cube) = "" {}
	}
	//DummyShaderTextExporter
	SubShader{
		Tags { "RenderType"="Opaque" }
		LOD 200
		CGPROGRAM
#pragma surface surf Standard
#pragma target 3.0

		sampler2D _MainTex;
		fixed4 _Color;
		struct Input
		{
			float2 uv_MainTex;
		};
		
		void surf(Input IN, inout SurfaceOutputStandard o)
		{
			fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
			o.Albedo = c.rgb;
			o.Alpha = c.a;
		}
		ENDCG
	}
	Fallback "Diffuse"
}