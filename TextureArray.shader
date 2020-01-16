// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/TextureArray"
{
	Properties
	{
		_MainTex("Tex", 2DArray) = "" {}
	}
		SubShader
	{
		Pass
		{
		CGPROGRAM
		#pragma vertex vert
		#pragma fragment frag

		UNITY_DECLARE_TEX2DARRAY(_MainTex);

		#include "UnityCG.cginc"
		struct appdata
		{
			float4 vertex : POSITION;
			float2 uv : TEXCOORD0;
			float2 uv2: TEXCOORD1;
		};

		struct v2f
		{
			float4 vertex : SV_POSITION;
			float2 uv : TEXCOORD0;
			float2 uv2 : TEXCOORD1;
		};

		v2f vert(appdata v)
		{
			v2f o;
			o.vertex = UnityObjectToClipPos(v.vertex);
			o.uv = float2(v.uv.xy);
			o.uv2 = float2(v.uv2.xy);

			return o;
		}

		fixed4 frag(v2f i) : SV_TARGET
		{
			fixed4 color = UNITY_SAMPLE_TEX2DARRAY(_MainTex, float3(i.uv,i.uv2.x));
			return color;
		}
		ENDCG
		}
	}
}
