Shader "Custom/HexGrid"
{
	Properties
	{
		_Color("Color", Color) = (1,1,1,1)
		_MainTex("Albedo (RGB)", 2D) = "white" {}
		_Emission("Emission", Float) = 1
		_Center("Center", Vector) = (0.0, 0.0, 0.0)
		_GridScale("GridScale", Float) = 1.5
	}
		SubShader
		{
			Tags { "RenderType" = "Opaque" }
			LOD 200

			CGPROGRAM
			#pragma surface surf Standard fullforwardshadows	// Physically based Standard lighting model, and enable shadows on all light types
			#pragma target 3.0    // Use shader model 3.0 target, to get nicer looking lighting

			sampler2D _MainTex;

			struct Input
			{
				float2 uv_MainTex;
				float3 worldPos;
				float4 screenPos;
			};

			fixed4 _Color;
			float _Emission;
			float3 _Center;
			float _GridScale;

			float  _gl_mod(float  a, float  b) { return a - b * floor(a / b); }
			float2 _gl_mod(float2 a, float2 b) { return a - b * floor(a / b); }
			float3 _gl_mod(float3 a, float3 b) { return a - b * floor(a / b); }
			float4 _gl_mod(float4 a, float4 b) { return a - b * floor(a / b); }

			// Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
			// See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
			// #pragma instancing_options assumeuniformscaling
			UNITY_INSTANCING_BUFFER_START(Props)
				// put more per-instance properties here
			UNITY_INSTANCING_BUFFER_END(Props)

			float Hex(float2 p, float2 h)
			{
				float2 q = abs(p);
				return max(q.x - h.y, max(q.x + q.y*0.57735, q.y*1.1547) - h.x);
			}
			float HexGrid(float3 p)
			{
				float scale = _GridScale;
				float2 grid = float2(0.692, 0.4) * scale;
				float radius = 0.22 * scale;

				float2 p1 = _gl_mod(p.xz, grid) - grid * 0.5;
				float c1 = Hex(p1, radius);

				float2 p2 = _gl_mod(p.xz + grid * 0.5, grid) - grid * 0.5;
				float c2 = Hex(p2, radius);
				return min(c1, c2);
			}

			float3 GuessNormal(float3 p)
			{
				const float d = 0.01;
				return normalize(float3(
					HexGrid(p + float3(d, 0.0, 0.0)) - HexGrid(p + float3(-d, 0.0, 0.0)),
					HexGrid(p + float3(0.0, d, 0.0)) - HexGrid(p + float3(0.0, -d, 0.0)),
					HexGrid(p + float3(0.0, 0.0, d)) - HexGrid(p + float3(0.0, 0.0, -d))));
			}
			void surf(Input IN, inout SurfaceOutputStandard o)
			{
				float2 coord = (IN.screenPos.xy / IN.screenPos.w);
				float3 center = IN.worldPos - _Center;
				float grid_d = HexGrid(IN.worldPos);
				float grid = grid_d > 0.0 ? 1.0 : 0.0;
				float3 n = GuessNormal(center);
				n = mul(UNITY_MATRIX_VP, float4(n, 0.0)).xyz;
					
				// Albedo comes from a texture tinted by color
				//fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
				o.Albedo = 0.0;
				o.Alpha = 1.0;
				o.Emission = _Emission;
				float g = saturate((grid_d + 0.02)*50.0);
				coord += n.xz * (g > 0.0 && g < 1.0 ? 1.0 : 0.0) * 0.02;
				o.Emission += (1.0 - grid * 0.9);
			}
			ENDCG
		}
			FallBack "Diffuse"
}