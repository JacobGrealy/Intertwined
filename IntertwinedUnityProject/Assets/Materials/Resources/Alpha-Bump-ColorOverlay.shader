Shader "Transparent/Bumped Diffuse Color-Overlay" {
Properties {
	_Color ("Main Color", Color) = (1,1,1,1)
	_MainTex ("Base", 2D) = "white" {}
	_BumpMap ("Normalmap", 2D) = "bump" {}
	_Alpha ("Alpha map (A)", 2D) = "gray" {}
	_ColorTint ("Tint", Color) = (1.0, 0.6, 0.6, 1.0)
}

SubShader {
	Tags {"Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent"}
	LOD 300
	
CGPROGRAM
#pragma surface surf Lambert finalcolor:mycolor alpha

sampler2D _MainTex;
sampler2D _BumpMap;
sampler2D _Alpha;
fixed4 _Color;
fixed4 _ColorTint;

struct Input {
	float2 uv_MainTex;
	float2 uv_BumpMap;
	float2 uv_Detail;
};
void mycolor (Input IN, SurfaceOutput o, inout fixed4 color)
{
    color *= _ColorTint;
}

void surf (Input IN, inout SurfaceOutput o) {
	fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
	o.Albedo = c.rgb;
	o.Albedo = tex2D (_MainTex, IN.uv_MainTex).rgb;
	o.Alpha = tex2D (_Alpha, IN.uv_Detail).a;
	o.Normal = UnpackNormal(tex2D(_BumpMap, IN.uv_BumpMap));
}
ENDCG
}

FallBack "Transparent/Diffuse"
}