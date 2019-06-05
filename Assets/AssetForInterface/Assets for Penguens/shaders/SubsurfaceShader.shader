Shader "Custom/SubsurfaceShader"
{
	Properties{
		_Color("Color", Color) = (1,1,1,1)
		_MainTex("Texture", 2D) = "white" {}
	}
		SubShader{
		Tags { "RenderType" = "Opaque" }
	CGPROGRAM
	#pragma surface surf WrapLambert
		fixed4 _Color;

	half4 LightingWrapLambert(SurfaceOutput s, half3 lightDir, half atten) {
		half NdotL = dot(s.Normal, lightDir);
		half diff = NdotL * 0.5 + 0.5;
		half4 c;
		c.rgb = s.Albedo * _LightColor0.rgb * (diff * atten);
		c.a = s.Alpha;
		return c;
	}

	struct Input {
		float2 uv_MainTex;
	};

	sampler2D _MainTex;
		void surf(Input IN, inout SurfaceOutput o) {
		fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
		o.Albedo = c.rgb;
		o.Alpha = c.a;
	}
	ENDCG
	}
		Fallback "Diffuse"
}