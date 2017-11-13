// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/GaussianBlur" {
	Properties{
		_MainTex("MainTex (RGB)", 2D) = "white" {}

	// ガウスフィルタ重み配列(8サンプリング分 _GaussParam0.xから順に 0～8)
	_GaussParam0("GaussParam0", Vector) = (1, 0, 0, 0)
		_GaussParam1("GaussParam1", Vector) = (0, 0, 0, 0)

		_SamplingLevel("SamplingLevel", Int) = 8
	}

		SubShader
	{
		Tags{ "Queue" = "Overlay" }

		ZWrite Off
		Blend Off
		Lighting Off

		// 1パス目：X軸方向にフィルタを掛ける
		Pass
	{
		CGPROGRAM

#pragma vertex vert
#pragma fragment frag

#include "UnityCG.cginc"

		struct appdata_t {
		float4 vertex : POSITION;
		float2 texcoord : TEXCOORD0;
	};

	struct v2f {
		float4 vertex : SV_POSITION;
		half2 texcoord : TEXCOORD0;
	};

	sampler2D _MainTex;
	float4 _MainTex_ST;
	float _TexSize;
	float4 _GaussParam0;
	float4 _GaussParam1;
	int _SamplingLevel;

	// 1テクセルを正規化した値
	float4	_MainTex_TexelSize;

	v2f vert(appdata_t v)
	{
		v2f o;
		o.vertex = UnityObjectToClipPos(v.vertex);
		o.texcoord = TRANSFORM_TEX(v.texcoord, _MainTex);
		return o;
	}

	fixed4 frag(v2f input) : SV_Target
	{
		// テクセルサイズ
		half texel = _MainTex_TexelSize.x;

	// X方向のサンプリング
	half4 col = tex2D(_MainTex, input.texcoord) * _GaussParam0[0];

	for (int i = 1; i < 4 && i < _SamplingLevel; ++i)
	{
		col += tex2D(_MainTex, input.texcoord + half2(texel*i, 0)) * _GaussParam0[i];
		col += tex2D(_MainTex, input.texcoord + half2(-texel*i, 0)) * _GaussParam0[i];
	}
	for (int i = 4; i < 8 && i < _SamplingLevel; ++i)
	{
		col += tex2D(_MainTex, input.texcoord + half2(texel*i, 0)) * _GaussParam1[i - 4];
		col += tex2D(_MainTex, input.texcoord + half2(-texel*i, 0)) * _GaussParam1[i - 4];
	}
	col.a = 1;	// とりあえずαは1

	return fixed4(col);
	}

		ENDCG
	}

		// 1パス目の描画をテクスチャとする
		GrabPass{}

		// 2パス目：1パス目の画像を元にY方向にフィルタを掛ける
		Pass
	{
		CGPROGRAM

#pragma vertex vert
#pragma fragment frag

#include "UnityCG.cginc"

		struct appdata_t {
		float4 vertex : POSITION;
		float2 texcoord : TEXCOORD0;
	};

	struct v2f {
		float4 vertex : SV_POSITION;
		half2 texcoord : TEXCOORD0;
	};

	sampler2D _GrabTexture;
	float4 _GrabTexture_ST;
	float _TexSize;
	float4 _GaussParam0;
	float4 _GaussParam1;
	int _SamplingLevel;

	float4	_GrabTexture_TexelSize;

	v2f vert(appdata_t v)
	{
		v2f o;
		o.vertex = UnityObjectToClipPos(v.vertex);
		o.texcoord = TRANSFORM_TEX(v.texcoord, _GrabTexture);
		return o;
	}

	fixed4 frag(v2f input) : SV_Target
	{
		// テクセルサイズ
		half texel = _GrabTexture_TexelSize.y;

	// テクセルサイズが負の値の時は、テクスチャの上下が反転しているらしい
	if (_GrabTexture_TexelSize.y < 0)
		input.texcoord.y = 1 - input.texcoord.y;

	// Y方向のサンプリング
	half4 col = tex2D(_GrabTexture, input.texcoord) * _GaussParam0[0];

	for (int i = 1; i < 4 && i < _SamplingLevel; ++i)
	{
		col += tex2D(_GrabTexture, input.texcoord + half2(0,  texel*i)) * _GaussParam0[i];
		col += tex2D(_GrabTexture, input.texcoord + half2(0, -texel*i)) * _GaussParam0[i];
	}
	for (int i = 4; i < 8 && i < _SamplingLevel; ++i)
	{
		col += tex2D(_GrabTexture, input.texcoord + half2(0,  texel*i)) * _GaussParam1[i - 4];
		col += tex2D(_GrabTexture, input.texcoord + half2(0, -texel*i)) * _GaussParam1[i - 4];
	}
	col.a = 1;	// とりあえずαは1

	return fixed4(col);
	}

		ENDCG
	}
	}

		FallBack "Diffuse"
}