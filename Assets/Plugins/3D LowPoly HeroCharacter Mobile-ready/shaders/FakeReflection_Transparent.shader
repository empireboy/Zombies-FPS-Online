
Shader "FakeReflection/Transparent/Transparent Diffuse" {
Properties {
	_Color ("Main Color", Color) = (1,1,1,1)
	_ReflectColor ("Reflection Color", Color) = (1,1,1,0.5)
	_MainTex ("Base (RGB) Transparency (A)", 2D) = "white" {}
	_Cube ("Reflection Cubemap", Cube) = "_Skybox" { }
	_Cube2 ("Reflection Cubemap #2", Cube) = "_Skybox" { }
	_Blend ("Blend", Range (0, 1) ) = 0.0 
	_Blur ("Blur", Range (0.1,1)) = 1.0
	_RimPower("Rim Power", Range(0.0, 10)) = 1.5
}

SubShader {
	LOD 300
	Tags {"Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent"}
		
CGPROGRAM
#pragma surface surf BlinnPhong alpha
#pragma glsl
#pragma target 3.0

sampler2D _MainTex;
samplerCUBE _Cube, _Cube2;
float _Blend, _Blur, _RimPower;
fixed4 _Color;
fixed4 _ReflectColor;

struct Input {
	float2 uv_MainTex;
	float3 worldRefl;
	float3 viewDir;
};

void surf (Input IN, inout SurfaceOutput o) 
{
	const int NumMipmap = 7;
	fixed Blur = (1 - _Blur) * NumMipmap; 

	fixed4 tex = tex2D(_MainTex, IN.uv_MainTex);
	o.Albedo = tex.rgb * _Color.rgb;
	
	float4 reflcol = texCUBElod (_Cube, float4(IN.worldRefl, Blur));
	float4 reflcol2 = texCUBElod (_Cube2, float4(IN.worldRefl, Blur));
	reflcol *= tex.a;
	reflcol2 *= tex.a;

	float4 lerpRefl = lerp(reflcol, reflcol2, _Blend);

	half rim = 1 - saturate(dot(normalize(IN.viewDir), o.Normal));

	o.Emission = lerpRefl.rgb * _ReflectColor.rgb * pow(rim, _RimPower);
	o.Alpha = lerpRefl.a * _Color.a;
}
ENDCG
} 

FallBack "Transparent/Specular"
}
