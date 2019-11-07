// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:True,rprd:True,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:1,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:2,rntp:3,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:5959,x:33291,y:32215,varname:node_5959,prsc:2|emission-4458-OUT,clip-1210-OUT;n:type:ShaderForge.SFN_Tex2d,id:9253,x:32540,y:32601,ptovrint:False,ptlb:MainTex,ptin:_MainTex,varname:_MainTex,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-7946-UVOUT;n:type:ShaderForge.SFN_OneMinus,id:547,x:32682,y:32386,varname:node_547,prsc:2|IN-9253-RGB;n:type:ShaderForge.SFN_Panner,id:7946,x:32292,y:32601,varname:node_7946,prsc:2,spu:0.1,spv:0|UVIN-201-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:201,x:32309,y:32423,varname:node_201,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Multiply,id:4458,x:33027,y:32277,varname:node_4458,prsc:2|A-547-OUT,B-5634-OUT;n:type:ShaderForge.SFN_HsvToRgb,id:5634,x:32721,y:32001,varname:node_5634,prsc:2|H-3244-OUT,S-1028-OUT,V-5844-OUT;n:type:ShaderForge.SFN_Time,id:2613,x:32106,y:32180,varname:node_2613,prsc:2;n:type:ShaderForge.SFN_Vector1,id:5844,x:32358,y:32287,varname:node_5844,prsc:2,v1:1;n:type:ShaderForge.SFN_OneMinus,id:1210,x:32920,y:32611,varname:node_1210,prsc:2|IN-9253-R;n:type:ShaderForge.SFN_Slider,id:2137,x:31777,y:31961,ptovrint:False,ptlb:speed,ptin:_speed,varname:_speed,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0.001,cur:0.5,max:1;n:type:ShaderForge.SFN_Divide,id:3244,x:32374,y:32018,varname:node_3244,prsc:2|A-2613-TSL,B-4708-OUT;n:type:ShaderForge.SFN_OneMinus,id:4708,x:32171,y:31924,varname:node_4708,prsc:2|IN-2137-OUT;n:type:ShaderForge.SFN_Slider,id:9581,x:32217,y:32149,ptovrint:False,ptlb:saturation,ptin:_saturation,varname:_saturation,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Multiply,id:1028,x:32549,y:32125,varname:node_1028,prsc:2|A-5844-OUT,B-9581-OUT;proporder:9253-2137-9581;pass:END;sub:END;*/

Shader "Custom/armband" 
{
    Properties 
	{
        _MainTex ("MainTex", 2D) = "white" {}
		_Emissive("Emissive", Float) = 1
		_speed ("speed", Range(0.001, 1)) = 0.5
        _saturation ("saturation", Range(0, 1)) = 0
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader 
	{
        Tags 
		{
            "Queue"="AlphaTest"
            "RenderType"="TransparentCutout"
        }
        LOD 200
        Pass 
		{
            Name "FORWARD"
            Tags 
			{
                "LightMode"="ForwardBase"
            }
            Cull Off
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            // Dithering function, to use with scene UVs (screen pixel coords)
            // 2x2 Bayer matrix, based on https://en.wikipedia.org/wiki/Ordered_dithering
            float BinaryDither2x2( float value, float2 sceneUVs )
			{
                float2x2 mtx = float2x2(
                    float2( 1, 3 )/5.0,
                    float2( 4, 2 )/5.0
                );
                float2 px = floor(_ScreenParams.xy * sceneUVs);
                int xSmp = fmod(px.x,2);
                int ySmp = fmod(px.y,2);
                float2 xVec = 1-saturate(abs(float2(0,1) - xSmp));
                float2 yVec = 1-saturate(abs(float2(0,1) - ySmp));
                float2 pxMult = float2( dot(mtx[0],yVec), dot(mtx[1],yVec) );
                return round(value + dot(pxMult, xVec));
            }
            uniform sampler2D _MainTex; 
			uniform float4 _MainTex_ST;
			uniform float _Emissive;
            uniform float _speed;
            uniform float _saturation;
            struct VertexInput 
			{
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput
			{
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 projPos : TEXCOORD1;
                UNITY_FOG_COORDS(2)
            };
            VertexOutput vert (VertexInput v) 
			{
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR 
			{
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                float2 sceneUVs = (i.projPos.xy / i.projPos.w);
                float4 node_8012 = _Time;
                float2 node_7946 = (i.uv0+node_8012.g*float2(0.1,0));
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(node_7946, _MainTex));
                clip( BinaryDither2x2((1.0 - _MainTex_var.r) - 1.5, sceneUVs) );
////// Lighting:
////// Emissive:
                float4 node_2613 = _Time;
                float node_5844 = 1.0;
                float3 emissive = ((1.0 - _MainTex_var.rgb)*(lerp(float3(1,1,1),saturate(3.0*abs(1.0-2.0*frac((node_2613.r/(1.0 - _speed))+float3(0.0,-1.0/3.0,1.0/3.0)))-1),(node_5844*_saturation))*node_5844)) * _Emissive;
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass 
		{
            Name "ShadowCaster"
            Tags 
			{
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            Cull Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            // Dithering function, to use with scene UVs (screen pixel coords)
            // 2x2 Bayer matrix, based on https://en.wikipedia.org/wiki/Ordered_dithering
            float BinaryDither2x2( float value, float2 sceneUVs ) 
			{
                float2x2 mtx = float2x2(
                    float2( 1, 3 )/5.0,
                    float2( 4, 2 )/5.0
                );
                float2 px = floor(_ScreenParams.xy * sceneUVs);
                int xSmp = fmod(px.x,2);
                int ySmp = fmod(px.y,2);
                float2 xVec = 1-saturate(abs(float2(0,1) - xSmp));
                float2 yVec = 1-saturate(abs(float2(0,1) - ySmp));
                float2 pxMult = float2( dot(mtx[0],yVec), dot(mtx[1],yVec) );
                return round(value + dot(pxMult, xVec));
            }
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            struct VertexInput 
			{
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput 
			{
                V2F_SHADOW_CASTER;
                float2 uv0 : TEXCOORD1;
                float4 projPos : TEXCOORD2;
            };
            VertexOutput vert (VertexInput v)
			{
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = UnityObjectToClipPos( v.vertex );
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR
			{
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                float2 sceneUVs = (i.projPos.xy / i.projPos.w);
                float4 node_3850 = _Time;
                float2 node_7946 = (i.uv0+node_3850.g*float2(0.1,0));
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(node_7946, _MainTex));
                clip( BinaryDither2x2((1.0 - _MainTex_var.r) - 1.5, sceneUVs) );
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
