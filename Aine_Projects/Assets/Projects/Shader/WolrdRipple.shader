Shader "MakeShader/Standard_Ripple"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
		//_SecondColor ("SecondColor", Color) = (1,1,1,1)
		_Emission ("Emission", Float) = 0.1
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
		_SecondTex ("Second (RGB)", 2D) = "black" {}
        _BumpMap ("Normal Map", 2D) = "white" {}
        _BumpScale ("Normal ", Float) = 1
        _HeightMap ("Height Map", 2D) = "white" {}
        _HeightMapScale ("Height", Float) = 1
        _MetallicGlossMap ("Metallic", 2D) = "white" {}
        _Metallic ("Metallic", Range(0,1)) = 0.0
        _OcclusionMap("OcclusionMap", 2D) = "white" {}
        _OcclusionStrength("Occlusion Strength", Float) = 1
        _Glossiness ("Smoothness", Range(0,1)) = 0.5

		
		_RippleOrigin ("Ripple origin", Vector) = (0.0, 0.0, 0.0, 0.0)
		_RippleDistance ("Ripple distance", Float) = 0.0
		_RippleWidth ("Ripple width", Float) = 0.1
		_Center ("Center", Vector) = (0.0, 0.0, 0.0)
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainTex;
		//sampler2D _SecondTex;
        sampler2D _BumpMap;
        sampler2D _HeightMap;
        sampler2D _MetallicGlossMap;
        sampler2D _OcclusionMap;

        struct Input
        {
            float2 uv_MainTex;
			float2 uv_SecondTex;
			float3 worldPos;
        };
		
        half _BumpScale;
        half _HeightMapScale;
        half _Metallic;
        half _OcclusionStrength;
        half _Glossiness;
        fixed4 _Color;
		fixed4 _SecondColor;
		float _Emission;
		
		fixed4 _RippleOrigin;
		float _RippleDistance;
		float _RippleWidth;
		float3 _Center;

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

		
		float  _gl_mod(float  a, float  b) { return a - b * floor(a/b); }
		float2 _gl_mod(float2 a, float2 b) { return a - b * floor(a/b); }
		float3 _gl_mod(float3 a, float3 b) { return a - b * floor(a/b); }
		float4 _gl_mod(float4 a, float4 b) { return a - b * floor(a/b); }
		float Hex( float2 p, float2 h )
		{
			float2 q = abs(p);
			return max(q.x-h.y,max(q.x+q.y*0.57735,q.y*1.1547)-h.x);
		}

		float HexGrid(float3 p)
		{
			float scale = 1;
			float2 grid = float2(0.692, 0.4) * scale;
			float radius = 0.22 * scale;

			float2 p1 = _gl_mod(p.xz, grid) - grid*0.5;
			float c1 = Hex(p1, radius);

			float2 p2 = _gl_mod(p.xz+grid*0.5, grid) - grid*0.5;
			float c2 = Hex(p2, radius);
			return min(c1, c2);
		}
		float Circle(float3 pos)
		{
			float o_radius = 5.0;
			float i_radius = 4.0;
			float d = length(pos.xz);
			float c = max(o_radius-(o_radius-_gl_mod(d-_Time.y*1.5, o_radius))-i_radius, 0.0);
			return c;
		}



		
        void vert(inout appdata_full v,  out Input o)
		{
            UNITY_INITIALIZE_OUTPUT(Input, o);
            float4 heightMap = tex2Dlod(_HeightMap, float4(v.texcoord.xy,0,0));
            //fixed4 heightMap = _HeightMap;
            v.vertex.y += heightMap.b * _HeightMapScale;
        }

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
			float distance = length(IN.worldPos.xyz - _RippleOrigin.xyz) - (_RippleDistance * _RippleOrigin.w);
			float halfWidth = _RippleWidth * 0.5;
			float lowerDistance = distance - halfWidth;
			float upperDistance = distance + halfWidth;
			
			//fixed4 cs = tex2D (_SecondTex, IN.uv_SecondTex) * _SecondColor;
			float ringStrength = pow(1 - abs(distance / halfWidth), 8) * (lowerDistance < 0 && upperDistance > 0);
			
			float grid_d = HexGrid(IN.worldPos);
			float grid = grid_d > 0.0 ? 1.0 : 0.0;
			float3 center = IN.worldPos - _Center;
			float circle = Circle(center);


            // Albedo comes from a texture tinted by color
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
			o.Albedo = (/*cs.rgb + */(ringStrength * c.rgb * (1 - _RippleOrigin.w)) * (1 - _RippleOrigin.w >= 0));
			//o.Albedo = c.rgb;
			o.Emission += _Emission * (grid * circle) * c.rgb;
			//o.Emission = _Emission * (grid /** circle*/) * ringStrength * c.rgb * (1 - _RippleOrigin.w) * (1 - _RippleOrigin.w >= 0);
			o.Normal = UnpackScaleNormal(tex2D(_BumpMap, IN.uv_MainTex), _BumpScale);
            fixed4 gloss = tex2D(_MetallicGlossMap, IN.uv_MainTex);
            o.Metallic = gloss.r * _Metallic;
            o.Smoothness = gloss.a * _Glossiness;
            o.Occlusion = tex2D(_OcclusionMap, IN.uv_MainTex) * _OcclusionStrength;
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}