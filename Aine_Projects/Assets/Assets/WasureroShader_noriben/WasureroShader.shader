// Shader created with Shader Forge v1.38 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3138,x:34184,y:34300,varname:node_3138,prsc:2|emission-4945-OUT,alpha-4688-OUT,voffset-6091-OUT,tess-4520-OUT;n:type:ShaderForge.SFN_Color,id:7241,x:32946,y:33156,ptovrint:False,ptlb:Color,ptin:_Color,varname:_Color,prsc:2,glob:False,taghide:False,taghdr:True,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:0,c3:0,c4:1;n:type:ShaderForge.SFN_TexCoord,id:5714,x:31089,y:32776,varname:node_5714,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Vector2,id:3630,x:31089,y:32933,varname:node_3630,prsc:2,v1:0.5,v2:0.5;n:type:ShaderForge.SFN_Distance,id:1213,x:31308,y:32813,varname:node_1213,prsc:2|A-5714-UVOUT,B-3630-OUT;n:type:ShaderForge.SFN_Step,id:8817,x:31649,y:32744,varname:node_8817,prsc:2|A-3299-OUT,B-1213-OUT;n:type:ShaderForge.SFN_Slider,id:8288,x:29816,y:33074,ptovrint:False,ptlb:Speed,ptin:_Speed,varname:_Speed,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1.000001,max:3;n:type:ShaderForge.SFN_Step,id:3918,x:31665,y:32875,varname:node_3918,prsc:2|A-3180-OUT,B-1213-OUT;n:type:ShaderForge.SFN_Add,id:3180,x:31452,y:32964,varname:node_3180,prsc:2|A-3299-OUT,B-261-OUT;n:type:ShaderForge.SFN_Slider,id:5183,x:30932,y:33070,ptovrint:False,ptlb:Thickness,ptin:_Thickness,varname:_Thickness,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.04087999,max:1;n:type:ShaderForge.SFN_Add,id:4460,x:32032,y:32813,varname:node_4460,prsc:2|A-4707-OUT,B-3918-OUT;n:type:ShaderForge.SFN_OneMinus,id:3191,x:32199,y:32813,varname:node_3191,prsc:2|IN-4460-OUT;n:type:ShaderForge.SFN_Color,id:3785,x:31883,y:32994,ptovrint:False,ptlb:CircleColor,ptin:_CircleColor,varname:_CircleColor,prsc:2,glob:False,taghide:False,taghdr:True,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Multiply,id:7141,x:32387,y:32813,varname:node_7141,prsc:2|A-3191-OUT,B-1725-OUT;n:type:ShaderForge.SFN_Time,id:6603,x:29973,y:32893,varname:node_6603,prsc:2;n:type:ShaderForge.SFN_RemapRange,id:3299,x:30509,y:32977,varname:node_3299,prsc:2,frmn:0,frmx:1,tomn:0,tomx:1|IN-2358-OUT;n:type:ShaderForge.SFN_Frac,id:2358,x:30336,y:32977,varname:node_2358,prsc:2|IN-7744-OUT;n:type:ShaderForge.SFN_Multiply,id:7744,x:30165,y:32977,varname:node_7744,prsc:2|A-6603-T,B-8288-OUT;n:type:ShaderForge.SFN_OneMinus,id:4707,x:31821,y:32744,varname:node_4707,prsc:2|IN-8817-OUT;n:type:ShaderForge.SFN_Add,id:261,x:31284,y:33056,varname:node_261,prsc:2|A-5183-OUT,B-584-OUT;n:type:ShaderForge.SFN_Multiply,id:584,x:30972,y:33236,varname:node_584,prsc:2|A-3299-OUT,B-7463-OUT;n:type:ShaderForge.SFN_Slider,id:7463,x:30596,y:33261,ptovrint:False,ptlb:TimeThickness,ptin:_TimeThickness,varname:_TimeThickness,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.07,max:1;n:type:ShaderForge.SFN_Color,id:1509,x:31883,y:33160,ptovrint:False,ptlb:CircleColor2,ptin:_CircleColor2,varname:_CircleColor2,prsc:2,glob:False,taghide:False,taghdr:True,tagprd:False,tagnsco:False,tagnrm:False,c1:0.07586192,c2:0,c3:1,c4:1;n:type:ShaderForge.SFN_Lerp,id:1725,x:32169,y:33018,varname:node_1725,prsc:2|A-3785-RGB,B-1509-RGB,T-7881-OUT;n:type:ShaderForge.SFN_Add,id:4945,x:33191,y:33100,varname:node_4945,prsc:2|A-7141-OUT,B-7241-RGB;n:type:ShaderForge.SFN_ConstantClamp,id:7881,x:31332,y:33267,varname:node_7881,prsc:2,min:0,max:1|IN-3299-OUT;n:type:ShaderForge.SFN_TexCoord,id:4859,x:29969,y:35146,varname:node_4859,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Distance,id:9735,x:30214,y:35146,varname:node_9735,prsc:2|A-4859-UVOUT,B-5234-OUT;n:type:ShaderForge.SFN_Vector2,id:5234,x:29969,y:35303,varname:node_5234,prsc:2,v1:0.5,v2:0.5;n:type:ShaderForge.SFN_Multiply,id:6481,x:33419,y:35398,varname:node_6481,prsc:2|A-7135-OUT,B-5007-OUT;n:type:ShaderForge.SFN_Slider,id:5007,x:33022,y:35536,ptovrint:False,ptlb:OffsetScale,ptin:_OffsetScale,varname:_OffsetScale,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-10,cur:1,max:10;n:type:ShaderForge.SFN_Multiply,id:6091,x:33660,y:35487,varname:node_6091,prsc:2|A-6481-OUT,B-7285-OUT;n:type:ShaderForge.SFN_NormalVector,id:7285,x:33419,y:35643,prsc:2,pt:False;n:type:ShaderForge.SFN_Step,id:3962,x:30528,y:35144,varname:node_3962,prsc:2|A-9735-OUT,B-107-OUT;n:type:ShaderForge.SFN_Slider,id:107,x:30061,y:35429,ptovrint:False,ptlb:SizeOuter,ptin:_SizeOuter,varname:_SizeOuter,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Step,id:6026,x:30528,y:35304,varname:node_6026,prsc:2|A-9735-OUT,B-2385-OUT;n:type:ShaderForge.SFN_Step,id:7642,x:30528,y:35495,varname:node_7642,prsc:2|A-9735-OUT,B-5182-OUT;n:type:ShaderForge.SFN_Slider,id:2385,x:30070,y:35564,ptovrint:False,ptlb:SizeMiddle,ptin:_SizeMiddle,varname:_SizeMiddle,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.3203422,max:1;n:type:ShaderForge.SFN_Slider,id:5182,x:30070,y:35673,ptovrint:False,ptlb:SizeInner,ptin:_SizeInner,varname:_SizeInner,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.1615491,max:1;n:type:ShaderForge.SFN_OneMinus,id:7262,x:31290,y:35132,varname:node_7262,prsc:2|IN-3154-OUT;n:type:ShaderForge.SFN_OneMinus,id:6919,x:31177,y:35343,varname:node_6919,prsc:2|IN-59-OUT;n:type:ShaderForge.SFN_OneMinus,id:6531,x:30762,y:35575,varname:node_6531,prsc:2|IN-7642-OUT;n:type:ShaderForge.SFN_Add,id:1600,x:32668,y:35179,varname:node_1600,prsc:2|A-7262-OUT,B-2001-OUT,C-6132-OUT;n:type:ShaderForge.SFN_Slider,id:1319,x:31851,y:35258,ptovrint:False,ptlb:HeightOuter,ptin:_HeightOuter,varname:_HeightOuter,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-0.5,cur:0.5,max:0.5;n:type:ShaderForge.SFN_Add,id:7251,x:32668,y:35335,varname:node_7251,prsc:2|A-6919-OUT,B-5913-OUT,C-3272-OUT;n:type:ShaderForge.SFN_Add,id:3500,x:32668,y:35490,varname:node_3500,prsc:2|A-6531-OUT,B-6166-OUT,C-2301-OUT;n:type:ShaderForge.SFN_Slider,id:6559,x:31851,y:35417,ptovrint:False,ptlb:HeightMiddle,ptin:_HeightMiddle,varname:_HeightMiddle,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-0.5,cur:0.01404852,max:0.5;n:type:ShaderForge.SFN_Slider,id:5046,x:31838,y:35588,ptovrint:False,ptlb:HeightInner,ptin:_HeightInner,varname:_HeightInner,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-0.5,cur:-0.5,max:0.5;n:type:ShaderForge.SFN_Slider,id:4520,x:33824,y:34696,ptovrint:False,ptlb:Tessellation,ptin:_Tessellation,varname:_Tessellation,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:1,cur:11.55556,max:20;n:type:ShaderForge.SFN_Slider,id:4853,x:33247,y:34310,ptovrint:False,ptlb:Opacity,ptin:_Opacity,varname:_Opacity,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Min,id:7135,x:32961,y:35317,varname:node_7135,prsc:2|A-1600-OUT,B-7251-OUT,C-3500-OUT;n:type:ShaderForge.SFN_Multiply,id:59,x:30991,y:35343,varname:node_59,prsc:2|A-6026-OUT,B-6531-OUT;n:type:ShaderForge.SFN_Multiply,id:5040,x:30963,y:35132,varname:node_5040,prsc:2|A-3962-OUT,B-9814-OUT;n:type:ShaderForge.SFN_OneMinus,id:9814,x:30774,y:35197,varname:node_9814,prsc:2|IN-6026-OUT;n:type:ShaderForge.SFN_Add,id:2001,x:32355,y:35240,varname:node_2001,prsc:2|A-1319-OUT,B-9747-OUT;n:type:ShaderForge.SFN_Vector1,id:9747,x:32157,y:35315,varname:node_9747,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Add,id:5913,x:32355,y:35412,varname:node_5913,prsc:2|A-6559-OUT,B-9747-OUT;n:type:ShaderForge.SFN_Add,id:6166,x:32355,y:35574,varname:node_6166,prsc:2|A-5046-OUT,B-9747-OUT;n:type:ShaderForge.SFN_Time,id:1356,x:31282,y:35928,varname:node_1356,prsc:2;n:type:ShaderForge.SFN_Sin,id:2381,x:31548,y:35894,varname:node_2381,prsc:2|IN-1356-TTR;n:type:ShaderForge.SFN_Clamp01,id:396,x:31904,y:35938,varname:node_396,prsc:2|IN-9792-OUT;n:type:ShaderForge.SFN_RemapRange,id:9792,x:31731,y:35904,varname:node_9792,prsc:2,frmn:-1,frmx:1,tomn:0,tomx:0.1|IN-2381-OUT;n:type:ShaderForge.SFN_Tex2d,id:9555,x:31847,y:34226,varname:node_9555,prsc:2,tex:76cffd3707128a143800eadcd1cd8ea4,ntxv:0,isnm:False|UVIN-2438-UVOUT,TEX-6803-TEX;n:type:ShaderForge.SFN_OneMinus,id:3643,x:32488,y:34259,varname:node_3643,prsc:2|IN-7403-OUT;n:type:ShaderForge.SFN_Add,id:1586,x:32168,y:34251,varname:node_1586,prsc:2|A-9555-R,B-7262-OUT;n:type:ShaderForge.SFN_Add,id:7087,x:32168,y:34400,varname:node_7087,prsc:2|A-1659-R,B-6919-OUT;n:type:ShaderForge.SFN_Add,id:5547,x:32168,y:34555,varname:node_5547,prsc:2|A-1883-R,B-6531-OUT;n:type:ShaderForge.SFN_OneMinus,id:4829,x:32498,y:34396,varname:node_4829,prsc:2|IN-8768-OUT;n:type:ShaderForge.SFN_OneMinus,id:6542,x:32498,y:34551,varname:node_6542,prsc:2|IN-3793-OUT;n:type:ShaderForge.SFN_Add,id:7937,x:32715,y:34376,varname:node_7937,prsc:2|A-3643-OUT,B-4829-OUT,C-6542-OUT;n:type:ShaderForge.SFN_Tex2dAsset,id:6803,x:31417,y:33965,ptovrint:False,ptlb:MainTex,ptin:_MainTex,varname:_MainTex,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:76cffd3707128a143800eadcd1cd8ea4,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:1659,x:31847,y:34417,varname:node_1659,prsc:2,tex:76cffd3707128a143800eadcd1cd8ea4,ntxv:0,isnm:False|UVIN-9731-UVOUT,TEX-6803-TEX;n:type:ShaderForge.SFN_Tex2d,id:1883,x:31847,y:34566,varname:node_1883,prsc:2,tex:76cffd3707128a143800eadcd1cd8ea4,ntxv:0,isnm:False|UVIN-8073-UVOUT,TEX-6803-TEX;n:type:ShaderForge.SFN_TexCoord,id:4940,x:31080,y:34136,varname:node_4940,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Rotator,id:2438,x:31443,y:34236,varname:node_2438,prsc:2|UVIN-4940-UVOUT,SPD-5954-OUT;n:type:ShaderForge.SFN_Slider,id:5954,x:31080,y:34314,ptovrint:False,ptlb:RotationOuter,ptin:_RotationOuter,varname:_RotationOuter,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-5,cur:1.978833,max:5;n:type:ShaderForge.SFN_Clamp01,id:3315,x:32943,y:34376,varname:node_3315,prsc:2|IN-7937-OUT;n:type:ShaderForge.SFN_Clamp01,id:3154,x:31129,y:35132,varname:node_3154,prsc:2|IN-5040-OUT;n:type:ShaderForge.SFN_Clamp01,id:7403,x:32332,y:34251,varname:node_7403,prsc:2|IN-1586-OUT;n:type:ShaderForge.SFN_Clamp01,id:8768,x:32332,y:34396,varname:node_8768,prsc:2|IN-7087-OUT;n:type:ShaderForge.SFN_Clamp01,id:3793,x:32332,y:34551,varname:node_3793,prsc:2|IN-5547-OUT;n:type:ShaderForge.SFN_Rotator,id:9731,x:31443,y:34387,varname:node_9731,prsc:2|UVIN-4940-UVOUT,SPD-1123-OUT;n:type:ShaderForge.SFN_Slider,id:1123,x:31080,y:34465,ptovrint:False,ptlb:RotationMiddle,ptin:_RotationMiddle,varname:_RotationMiddle,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-5,cur:-1.73778,max:5;n:type:ShaderForge.SFN_Rotator,id:8073,x:31443,y:34561,varname:node_8073,prsc:2|UVIN-4940-UVOUT,SPD-6894-OUT;n:type:ShaderForge.SFN_Slider,id:6894,x:31058,y:34657,ptovrint:False,ptlb:RotationInner,ptin:_RotationInner,varname:_RotationInner,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-5,cur:-1.116505,max:5;n:type:ShaderForge.SFN_TexCoord,id:2007,x:32797,y:34619,varname:node_2007,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Distance,id:5488,x:33004,y:34619,varname:node_5488,prsc:2|A-2007-UVOUT,B-2751-OUT;n:type:ShaderForge.SFN_Vector2,id:2751,x:32783,y:34782,varname:node_2751,prsc:2,v1:0.5,v2:0.5;n:type:ShaderForge.SFN_Multiply,id:2337,x:33404,y:34518,varname:node_2337,prsc:2|A-3315-OUT,B-1033-OUT;n:type:ShaderForge.SFN_Step,id:1033,x:33219,y:34648,varname:node_1033,prsc:2|A-5488-OUT,B-2245-OUT;n:type:ShaderForge.SFN_Slider,id:2245,x:32756,y:34907,ptovrint:False,ptlb:CirlceClip,ptin:_CirlceClip,varname:_CirlceClip,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.5,max:1;n:type:ShaderForge.SFN_Cos,id:7537,x:31560,y:36040,varname:node_7537,prsc:2|IN-1356-TDB;n:type:ShaderForge.SFN_RemapRange,id:4978,x:31753,y:36062,varname:node_4978,prsc:2,frmn:-1,frmx:1,tomn:0,tomx:0.1|IN-7537-OUT;n:type:ShaderForge.SFN_RemapRange,id:7621,x:31768,y:36229,varname:node_7621,prsc:2,frmn:-1,frmx:1,tomn:0,tomx:0.1|IN-8961-OUT;n:type:ShaderForge.SFN_Clamp01,id:9636,x:31935,y:36080,varname:node_9636,prsc:2|IN-4978-OUT;n:type:ShaderForge.SFN_Clamp01,id:9640,x:31976,y:36229,varname:node_9640,prsc:2|IN-7621-OUT;n:type:ShaderForge.SFN_Sin,id:8961,x:31560,y:36190,varname:node_8961,prsc:2|IN-1356-T;n:type:ShaderForge.SFN_SwitchProperty,id:7745,x:31951,y:36448,ptovrint:False,ptlb:MoveRandom,ptin:_MoveRandom,varname:_MoveRandom,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:False|A-7603-OUT,B-693-OUT;n:type:ShaderForge.SFN_Multiply,id:6132,x:32241,y:35922,varname:node_6132,prsc:2|A-396-OUT,B-7745-OUT;n:type:ShaderForge.SFN_Multiply,id:3272,x:32253,y:36069,varname:node_3272,prsc:2|A-9636-OUT,B-7745-OUT;n:type:ShaderForge.SFN_Multiply,id:2301,x:32253,y:36204,varname:node_2301,prsc:2|A-9640-OUT,B-7745-OUT;n:type:ShaderForge.SFN_Vector1,id:7603,x:31628,y:36407,varname:node_7603,prsc:2,v1:0;n:type:ShaderForge.SFN_Vector1,id:693,x:31640,y:36495,varname:node_693,prsc:2,v1:1;n:type:ShaderForge.SFN_Multiply,id:4688,x:33892,y:34432,varname:node_4688,prsc:2|A-4881-OUT,B-2337-OUT;n:type:ShaderForge.SFN_Time,id:9252,x:32047,y:33921,varname:node_9252,prsc:2;n:type:ShaderForge.SFN_Sin,id:5332,x:32412,y:33921,varname:node_5332,prsc:2|IN-6387-OUT;n:type:ShaderForge.SFN_Multiply,id:4881,x:33691,y:34260,varname:node_4881,prsc:2|A-6038-OUT,B-4853-OUT;n:type:ShaderForge.SFN_RemapRange,id:4980,x:33266,y:34018,varname:node_4980,prsc:2,frmn:-1,frmx:1,tomn:0,tomx:1|IN-760-OUT;n:type:ShaderForge.SFN_Multiply,id:6387,x:32229,y:33921,varname:node_6387,prsc:2|A-9252-T,B-254-OUT;n:type:ShaderForge.SFN_Slider,id:254,x:31890,y:34079,ptovrint:False,ptlb:OpacityTime,ptin:_OpacityTime,varname:_OpacityTime,prsc:2,glob:False,taghide:True,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:2.2,max:50;n:type:ShaderForge.SFN_Noise,id:275,x:32850,y:33762,varname:node_275,prsc:2|XY-5914-OUT;n:type:ShaderForge.SFN_ComponentMask,id:5914,x:32663,y:33762,varname:node_5914,prsc:2,cc1:0,cc2:0,cc3:-1,cc4:-1|IN-5332-OUT;n:type:ShaderForge.SFN_Lerp,id:760,x:33058,y:33926,varname:node_760,prsc:2|A-5332-OUT,B-275-OUT,T-233-OUT;n:type:ShaderForge.SFN_Slider,id:233,x:32693,y:34014,ptovrint:False,ptlb:TimeNoise,ptin:_TimeNoise,varname:_TimeNoise,prsc:2,glob:False,taghide:True,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.19,max:1;n:type:ShaderForge.SFN_SwitchProperty,id:6038,x:33491,y:34098,ptovrint:False,ptlb:Blink Opacity,ptin:_BlinkOpacity,varname:node_6038,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:False|A-7530-OUT,B-4980-OUT;n:type:ShaderForge.SFN_Vector1,id:7530,x:33266,y:33926,varname:node_7530,prsc:2,v1:1;proporder:6803-7241-8288-5183-3785-1509-7463-5007-5182-2385-107-5046-6559-1319-6894-1123-5954-4853-2245-4520-7745-254-233-6038;pass:END;sub:END;*/

Shader "Noriben/WasureroShader" {
    Properties {
        [Header(Texture)]
        _MainTex ("MainTex", 2D) = "white" {}
        [HDR]_Color ("Color", Color) = (1,0,0,1)

        [Header(Circle Settings)]
        _Speed ("Speed", Range(0, 3)) = 1.000001
        _Thickness ("Thickness", Range(0, 1)) = 0.04087999
        [HDR]_CircleColor ("CircleColor", Color) = (1,1,1,1)
        [HDR]_CircleColor2 ("CircleColor2", Color) = (0.07586192,0,1,1)
        _TimeThickness ("TimeThickness", Range(0, 1)) = 0.07

        [Header(OffsetScale)]
        _OffsetScale ("OffsetScale", Range(-10, 10)) = 1

        [Header(Divide)]
        _SizeInner ("SizeInner", Range(0, 1)) = 0.1615491
        _SizeMiddle ("SizeMiddle", Range(0, 1)) = 0.3203422
        _SizeOuter ("SizeOuter", Range(0, 1)) = 1

        [Header(Height)]
        _HeightInner ("HeightInner", Range(-0.5, 0.5)) = -0.5
        _HeightMiddle ("HeightMiddle", Range(-0.5, 0.5)) = 0.01404852
        _HeightOuter ("HeightOuter", Range(-0.5, 0.5)) = 0.5

        [Header(Rotation)]
        _RotationInner ("RotationInner", Range(-5, 5)) = -1.116505
        _RotationMiddle ("RotationMiddle", Range(-5, 5)) = -1.73778
        _RotationOuter ("RotationOuter", Range(-5, 5)) = 1.978833

        [Header(Other)]
        _Opacity ("Opacity", Range(0, 1)) = 1
        _CirlceClip ("CirlceClip", Range(0, 1)) = 0.5
        _Tessellation ("Tessellation", Range(1, 20)) = 11.55556
        [MaterialToggle] _MoveRandom ("MoveRandom", Float ) = 0
        [HideInInspector]_OpacityTime ("OpacityTime", Range(0, 50)) = 2.2
        [HideInInspector]_TimeNoise ("TimeNoise", Range(0, 1)) = 0.19
        [MaterialToggle] _BlinkOpacity ("Blink Opacity", Float ) = 1
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            Cull Off
            ZWrite Off
            
            CGPROGRAM
            #pragma hull hull
            #pragma domain domain
            #pragma vertex tessvert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #include "Tessellation.cginc"
            #pragma multi_compile_fwdbase
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 5.0
            uniform float4 _Color;
            uniform float _Speed;
            uniform float _Thickness;
            uniform float4 _CircleColor;
            uniform float _TimeThickness;
            uniform float4 _CircleColor2;
            uniform float _OffsetScale;
            uniform float _SizeOuter;
            uniform float _SizeMiddle;
            uniform float _SizeInner;
            uniform float _HeightOuter;
            uniform float _HeightMiddle;
            uniform float _HeightInner;
            uniform float _Tessellation;
            uniform float _Opacity;
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform float _RotationOuter;
            uniform float _RotationMiddle;
            uniform float _RotationInner;
            uniform float _CirlceClip;
            uniform fixed _MoveRandom;
            uniform float _OpacityTime;
            uniform float _TimeNoise;
            uniform fixed _BlinkOpacity;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                float node_9735 = distance(o.uv0,float2(0.5,0.5));
                float node_6026 = step(node_9735,_SizeMiddle);
                float node_7262 = (1.0 - saturate((step(node_9735,_SizeOuter)*(1.0 - node_6026))));
                float node_9747 = 0.5;
                float4 node_1356 = _Time;
                float _MoveRandom_var = lerp( 0.0, 1.0, _MoveRandom );
                float node_6531 = (1.0 - step(node_9735,_SizeInner));
                float node_6919 = (1.0 - (node_6026*node_6531));
                v.vertex.xyz += ((min(min((node_7262+(_HeightOuter+node_9747)+(saturate((sin(node_1356.a)*0.05+0.05))*_MoveRandom_var)),(node_6919+(_HeightMiddle+node_9747)+(saturate((cos(node_1356.b)*0.05+0.05))*_MoveRandom_var))),(node_6531+(_HeightInner+node_9747)+(saturate((sin(node_1356.g)*0.05+0.05))*_MoveRandom_var)))*_OffsetScale)*v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                return o;
            }
            #ifdef UNITY_CAN_COMPILE_TESSELLATION
                struct TessVertex {
                    float4 vertex : INTERNALTESSPOS;
                    float3 normal : NORMAL;
                    float4 tangent : TANGENT;
                    float2 texcoord0 : TEXCOORD0;
                };
                struct OutputPatchConstant {
                    float edge[3]         : SV_TessFactor;
                    float inside          : SV_InsideTessFactor;
                    float3 vTangent[4]    : TANGENT;
                    float2 vUV[4]         : TEXCOORD;
                    float3 vTanUCorner[4] : TANUCORNER;
                    float3 vTanVCorner[4] : TANVCORNER;
                    float4 vCWts          : TANWEIGHTS;
                };
                TessVertex tessvert (VertexInput v) {
                    TessVertex o;
                    o.vertex = v.vertex;
                    o.normal = v.normal;
                    o.tangent = v.tangent;
                    o.texcoord0 = v.texcoord0;
                    return o;
                }
                float Tessellation(TessVertex v){
                    return _Tessellation;
                }
                float4 Tessellation(TessVertex v, TessVertex v1, TessVertex v2){
                    float tv = Tessellation(v);
                    float tv1 = Tessellation(v1);
                    float tv2 = Tessellation(v2);
                    return float4( tv1+tv2, tv2+tv, tv+tv1, tv+tv1+tv2 ) / float4(2,2,2,3);
                }
                OutputPatchConstant hullconst (InputPatch<TessVertex,3> v) {
                    OutputPatchConstant o = (OutputPatchConstant)0;
                    float4 ts = Tessellation( v[0], v[1], v[2] );
                    o.edge[0] = ts.x;
                    o.edge[1] = ts.y;
                    o.edge[2] = ts.z;
                    o.inside = ts.w;
                    return o;
                }
                [domain("tri")]
                [partitioning("fractional_odd")]
                [outputtopology("triangle_cw")]
                [patchconstantfunc("hullconst")]
                [outputcontrolpoints(3)]
                TessVertex hull (InputPatch<TessVertex,3> v, uint id : SV_OutputControlPointID) {
                    return v[id];
                }
                [domain("tri")]
                VertexOutput domain (OutputPatchConstant tessFactors, const OutputPatch<TessVertex,3> vi, float3 bary : SV_DomainLocation) {
                    VertexInput v = (VertexInput)0;
                    v.vertex = vi[0].vertex*bary.x + vi[1].vertex*bary.y + vi[2].vertex*bary.z;
                    v.normal = vi[0].normal*bary.x + vi[1].normal*bary.y + vi[2].normal*bary.z;
                    v.tangent = vi[0].tangent*bary.x + vi[1].tangent*bary.y + vi[2].tangent*bary.z;
                    v.texcoord0 = vi[0].texcoord0*bary.x + vi[1].texcoord0*bary.y + vi[2].texcoord0*bary.z;
                    VertexOutput o = vert(v);
                    return o;
                }
            #endif
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                i.normalDir = normalize(i.normalDir);
                i.normalDir *= faceSign;
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
////// Lighting:
////// Emissive:
                float4 node_6603 = _Time;
                float node_3299 = (frac((node_6603.g*_Speed))*1.0+0.0);
                float node_1213 = distance(i.uv0,float2(0.5,0.5));
                float3 emissive = (((1.0 - ((1.0 - step(node_3299,node_1213))+step((node_3299+(_Thickness+(node_3299*_TimeThickness))),node_1213)))*lerp(_CircleColor.rgb,_CircleColor2.rgb,clamp(node_3299,0,1)))+_Color.rgb);
                float3 finalColor = emissive;
                float4 node_9252 = _Time;
                float node_5332 = sin((node_9252.g*_OpacityTime));
                float2 node_5914 = node_5332.rr;
                float2 node_275_skew = node_5914 + 0.2127+node_5914.x*0.3713*node_5914.y;
                float2 node_275_rnd = 4.789*sin(489.123*(node_275_skew));
                float node_275 = frac(node_275_rnd.x*node_275_rnd.y*(1+node_275_skew.x));
                float4 node_9253 = _Time;
                float node_2438_ang = node_9253.g;
                float node_2438_spd = _RotationOuter;
                float node_2438_cos = cos(node_2438_spd*node_2438_ang);
                float node_2438_sin = sin(node_2438_spd*node_2438_ang);
                float2 node_2438_piv = float2(0.5,0.5);
                float2 node_2438 = (mul(i.uv0-node_2438_piv,float2x2( node_2438_cos, -node_2438_sin, node_2438_sin, node_2438_cos))+node_2438_piv);
                float4 node_9555 = tex2D(_MainTex,TRANSFORM_TEX(node_2438, _MainTex));
                float node_9735 = distance(i.uv0,float2(0.5,0.5));
                float node_6026 = step(node_9735,_SizeMiddle);
                float node_7262 = (1.0 - saturate((step(node_9735,_SizeOuter)*(1.0 - node_6026))));
                float node_9731_ang = node_9253.g;
                float node_9731_spd = _RotationMiddle;
                float node_9731_cos = cos(node_9731_spd*node_9731_ang);
                float node_9731_sin = sin(node_9731_spd*node_9731_ang);
                float2 node_9731_piv = float2(0.5,0.5);
                float2 node_9731 = (mul(i.uv0-node_9731_piv,float2x2( node_9731_cos, -node_9731_sin, node_9731_sin, node_9731_cos))+node_9731_piv);
                float4 node_1659 = tex2D(_MainTex,TRANSFORM_TEX(node_9731, _MainTex));
                float node_6531 = (1.0 - step(node_9735,_SizeInner));
                float node_6919 = (1.0 - (node_6026*node_6531));
                float node_8073_ang = node_9253.g;
                float node_8073_spd = _RotationInner;
                float node_8073_cos = cos(node_8073_spd*node_8073_ang);
                float node_8073_sin = sin(node_8073_spd*node_8073_ang);
                float2 node_8073_piv = float2(0.5,0.5);
                float2 node_8073 = (mul(i.uv0-node_8073_piv,float2x2( node_8073_cos, -node_8073_sin, node_8073_sin, node_8073_cos))+node_8073_piv);
                float4 node_1883 = tex2D(_MainTex,TRANSFORM_TEX(node_8073, _MainTex));
                return fixed4(finalColor,((lerp( 1.0, (lerp(node_5332,node_275,_TimeNoise)*0.5+0.5), _BlinkOpacity )*_Opacity)*(saturate(((1.0 - saturate((node_9555.r+node_7262)))+(1.0 - saturate((node_1659.r+node_6919)))+(1.0 - saturate((node_1883.r+node_6531)))))*step(distance(i.uv0,float2(0.5,0.5)),_CirlceClip))));
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            Cull Off
            
            CGPROGRAM
            #pragma hull hull
            #pragma domain domain
            #pragma vertex tessvert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "Tessellation.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 5.0
            uniform float _OffsetScale;
            uniform float _SizeOuter;
            uniform float _SizeMiddle;
            uniform float _SizeInner;
            uniform float _HeightOuter;
            uniform float _HeightMiddle;
            uniform float _HeightInner;
            uniform float _Tessellation;
            uniform fixed _MoveRandom;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float2 uv0 : TEXCOORD1;
                float4 posWorld : TEXCOORD2;
                float3 normalDir : TEXCOORD3;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                float node_9735 = distance(o.uv0,float2(0.5,0.5));
                float node_6026 = step(node_9735,_SizeMiddle);
                float node_7262 = (1.0 - saturate((step(node_9735,_SizeOuter)*(1.0 - node_6026))));
                float node_9747 = 0.5;
                float4 node_1356 = _Time;
                float _MoveRandom_var = lerp( 0.0, 1.0, _MoveRandom );
                float node_6531 = (1.0 - step(node_9735,_SizeInner));
                float node_6919 = (1.0 - (node_6026*node_6531));
                v.vertex.xyz += ((min(min((node_7262+(_HeightOuter+node_9747)+(saturate((sin(node_1356.a)*0.05+0.05))*_MoveRandom_var)),(node_6919+(_HeightMiddle+node_9747)+(saturate((cos(node_1356.b)*0.05+0.05))*_MoveRandom_var))),(node_6531+(_HeightInner+node_9747)+(saturate((sin(node_1356.g)*0.05+0.05))*_MoveRandom_var)))*_OffsetScale)*v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            #ifdef UNITY_CAN_COMPILE_TESSELLATION
                struct TessVertex {
                    float4 vertex : INTERNALTESSPOS;
                    float3 normal : NORMAL;
                    float4 tangent : TANGENT;
                    float2 texcoord0 : TEXCOORD0;
                };
                struct OutputPatchConstant {
                    float edge[3]         : SV_TessFactor;
                    float inside          : SV_InsideTessFactor;
                    float3 vTangent[4]    : TANGENT;
                    float2 vUV[4]         : TEXCOORD;
                    float3 vTanUCorner[4] : TANUCORNER;
                    float3 vTanVCorner[4] : TANVCORNER;
                    float4 vCWts          : TANWEIGHTS;
                };
                TessVertex tessvert (VertexInput v) {
                    TessVertex o;
                    o.vertex = v.vertex;
                    o.normal = v.normal;
                    o.tangent = v.tangent;
                    o.texcoord0 = v.texcoord0;
                    return o;
                }
                float Tessellation(TessVertex v){
                    return _Tessellation;
                }
                float4 Tessellation(TessVertex v, TessVertex v1, TessVertex v2){
                    float tv = Tessellation(v);
                    float tv1 = Tessellation(v1);
                    float tv2 = Tessellation(v2);
                    return float4( tv1+tv2, tv2+tv, tv+tv1, tv+tv1+tv2 ) / float4(2,2,2,3);
                }
                OutputPatchConstant hullconst (InputPatch<TessVertex,3> v) {
                    OutputPatchConstant o = (OutputPatchConstant)0;
                    float4 ts = Tessellation( v[0], v[1], v[2] );
                    o.edge[0] = ts.x;
                    o.edge[1] = ts.y;
                    o.edge[2] = ts.z;
                    o.inside = ts.w;
                    return o;
                }
                [domain("tri")]
                [partitioning("fractional_odd")]
                [outputtopology("triangle_cw")]
                [patchconstantfunc("hullconst")]
                [outputcontrolpoints(3)]
                TessVertex hull (InputPatch<TessVertex,3> v, uint id : SV_OutputControlPointID) {
                    return v[id];
                }
                [domain("tri")]
                VertexOutput domain (OutputPatchConstant tessFactors, const OutputPatch<TessVertex,3> vi, float3 bary : SV_DomainLocation) {
                    VertexInput v = (VertexInput)0;
                    v.vertex = vi[0].vertex*bary.x + vi[1].vertex*bary.y + vi[2].vertex*bary.z;
                    v.normal = vi[0].normal*bary.x + vi[1].normal*bary.y + vi[2].normal*bary.z;
                    v.tangent = vi[0].tangent*bary.x + vi[1].tangent*bary.y + vi[2].tangent*bary.z;
                    v.texcoord0 = vi[0].texcoord0*bary.x + vi[1].texcoord0*bary.y + vi[2].texcoord0*bary.z;
                    VertexOutput o = vert(v);
                    return o;
                }
            #endif
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                i.normalDir = normalize(i.normalDir);
                i.normalDir *= faceSign;
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
