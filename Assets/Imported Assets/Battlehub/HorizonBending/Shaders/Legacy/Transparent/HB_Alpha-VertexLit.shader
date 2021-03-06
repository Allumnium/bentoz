// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Battlehub/Legacy Shaders/Transparent/HB_VertexLit" {
Properties {
	_Color ("Main Color", Color) = (1,1,1,1)
	_Emission("Emissive Color", Color) = (0,0,0,0)
	_MainTex ("Base (RGB) Trans (A)", 2D) = "white" {}
}

SubShader {
	Tags {"Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent"}
	LOD 100
	
	ZWrite Off
	Blend SrcAlpha OneMinusSrcAlpha 
	ColorMask RGB
		
	// Non-lightmapped
	Pass{
		Tags{ "LightMode" = "Vertex" }
		Lighting On
		CGPROGRAM
		#include "../../CGIncludes/HB_Core.cginc"
		#include "UnityCG.cginc"
		
		
		#pragma vertex vert
		#pragma fragment frag
		#pragma multi_compile_fog
		

		struct v2f {
			float2 uv : TEXCOORD0;
			UNITY_FOG_COORDS(1)
			fixed4 diff : COLOR0;
			float4 pos : SV_POSITION;
		};

		uniform float4 _MainTex_ST;
		uniform float4 _Color;
		uniform float4 _Emission;

		v2f vert(appdata_base v)
		{
			v2f o;
			
			HB(v.vertex)
			o.pos = UnityObjectToClipPos(v.vertex);
			o.uv = TRANSFORM_TEX(v.texcoord,_MainTex);
			float4 diffuse = float4(ShadeVertexLightsFull(v.vertex, v.normal, 4, true), 1.0f);
			float4 emission = float4(_Emission.rgb, 0.0f);
			o.diff =  diffuse * saturate(_Color + emission) + emission;
			UNITY_TRANSFER_FOG(o,o.pos);
			return o;
		}

		uniform sampler2D _MainTex;

		fixed4 frag(v2f i) : SV_Target
		{
			fixed4 temp = tex2D(_MainTex, i.uv) ;
			fixed4 c;
			c.xyz = temp.xyz * i.diff.xyz;
			c.w = temp.w * i.diff.w;
			UNITY_APPLY_FOG(i.fogCoord, c); 
			return c;
		}
		ENDCG
	}

	// Lightmapped
	Pass
	{
		Tags{ "LightMode" = "VertexLM" }
	

		CGPROGRAM
		#include "../../CGIncludes/HB_Core.cginc"
		
		#pragma vertex vert
		#pragma fragment frag
		#pragma multi_compile_fog

		#include "UnityCG.cginc"

		struct v2f {
			half2 uv : TEXCOORD0;
			half2 uv2 : TEXCOORD1;
			UNITY_FOG_COORDS(2)
			float4 pos : SV_POSITION;
		};

		uniform float4 _MainTex_ST;
	
		v2f vert(float4 vertex : POSITION, float2 uv : TEXCOORD0, float2 uv2 : TEXCOORD1)
		{
			v2f o;
			
			HB(vertex)
			o.pos = UnityObjectToClipPos(vertex);
			o.uv = TRANSFORM_TEX(uv,_MainTex);
			o.uv2 = uv2 * unity_LightmapST.xy + unity_LightmapST.zw;
			UNITY_TRANSFER_FOG(o,o.pos);
			return o;
		}

		uniform sampler2D _MainTex;
		uniform fixed4 _Color;

		fixed4 frag(v2f i) : SV_Target
		{
			fixed4 lm = UNITY_SAMPLE_TEX2D(unity_Lightmap, i.uv2) * _Color;
			fixed4 c = tex2D(_MainTex, i.uv);
			c.rgb *= lm.rgb * 2;
			UNITY_APPLY_FOG(i.fogCoord, c);
			return c;
		}
		ENDCG
	}

	// Lightmapped, encoded as RGBM
	Pass{
		Tags{ "LightMode" = "VertexLMRGBM" }
	
		CGPROGRAM
		#include "../../CGIncludes/HB_Core.cginc"
		
		#pragma vertex vert
		#pragma fragment frag
		#pragma multi_compile_fog

		#include "UnityCG.cginc"

		struct v2f {
			half2 uv : TEXCOORD0;
			half2 uv2 : TEXCOORD1;
			UNITY_FOG_COORDS(2)
			float4 pos : SV_POSITION;
		};

		uniform float4 _MainTex_ST;

		v2f vert(float4 vertex : POSITION, float2 uv : TEXCOORD0, float2 uv2 : TEXCOORD1)
		{
			v2f o;
			
			HB(vertex)
			o.pos = UnityObjectToClipPos(vertex);
			o.uv = TRANSFORM_TEX(uv,_MainTex);
			o.uv2 = uv2 * unity_LightmapST.xy + unity_LightmapST.zw;
			UNITY_TRANSFER_FOG(o,o.pos);
			return o;
		}

		uniform sampler2D _MainTex;
		uniform fixed4 _Color;

		fixed4 frag(v2f i) : SV_Target
		{
			fixed4 lm = UNITY_SAMPLE_TEX2D(unity_Lightmap, i.uv2);
			lm *= lm.a * 2;
			lm *= _Color;
			fixed4 c = tex2D(_MainTex, i.uv);
			c.rgb *= lm.rgb * 4;
			UNITY_APPLY_FOG(i.fogCoord, c);
			return c;
		}
		ENDCG
	}
}
Fallback "Legacy Shaders/Transparent/VertexLit"
}