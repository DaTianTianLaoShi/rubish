// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

Shader "Unlit/NewUnlitShader"
{       //加入顶点光照
        //高光反射计算公式
        //高光反射系数，视角方向，反射方向
        //反射方向由表面法线和光源方向I计算得到，用cg reflect(入射方向,法线方向)
        //
    Properties
    {
        _abc("Diff",Color) = (1,1,1,1)
        Main("texture",2D) = "red"{}
    }
        SubShader
    {
        Pass
        {
             Tags{"LightMode"="ForwardBase"}//声明光照模式

     CGPROGRAM
#include "Lighting.cginc"
            #pragma vertex vert
            #pragma fragment frag
            #include "Lighting.cginc"
    fixed4 _abc;
	sampler2D _MainTex;
	float4 _MainTex_ST;
	fixed4 _Specular;
	float _Gloss;
     struct av 
    {    float4 ve:POSITION;
         float3 no:NORMAL;   
         float4 tex:TEXCOORD0;
     };                  
    struct av2 
    {
        float4 vertex:SV_POSITION;
        float3 colour:COLOR0;
        float3 textures:TEXCOORD0;//纯色图
        float3 textures1:TEXCOORD1;//法线图
		float2 uv:TEXCOOOR2;
    };
    av2 vert(av v) 
    {
        av2 o;
        o.vertex =UnityObjectToClipPos(v.ve);
       // o.colour = v.no * fixed3(0, 0.9, 0.5);
        //return UnityObjectToClipPos(v.ve);
        o.textures = UnityObjectToWorldNormal(v.no);
        o.textures1 = mul(unity_ObjectToWorld,v.ve).xyz;
		o.uv = v.tex.xy* _MainTex_ST.xy + _MainTex_ST.zw;
        fixed3 WordNormaze = normalize(mul(v.no,(float3x3)unity_WorldToObject));

        fixed3 guangzhaofangxiang = UNITY_LIGHTMODEL_AMBIENT.xyz;
        fixed3 worldLight = normalize(_WorldSpaceLightPos0.xyz);
        fixed3 de = _LightColor0.rgb*saturate(dot(WordNormaze,worldLight))*_abc.rgb;
       
        o.colour = de + WordNormaze;
        return o;
    }
    fixed4 frag(av2 a) :SV_Target
    {
        //收集Unity的光源照射方向
		//归一化纹理
		fixed3 normal = normalize(a.textures);
	     //存储光照方向，并且归一化
	    fixed3 worldLightNormal = normalize(UnityWorldSpaceLightDir(a.textures1));
		fixed3 worldLightDir = normalize(_WorldSpaceLightPos0.xyz);
		fixed3 albedo = tex2D(_MainTex,a.uv).rgb;//进行纹理采样
		fixed3 ambin = UNITY_LIGHTMODEL_AMBIENT.xyz;//系统环境光
		fixed3 diffuse = _LightColor0.rgb*albedo*max(0,dot(normal, worldLightNormal));
		fixed3 reflecdir = normalize(reflect(worldLightDir,worldLightNormal));
		fixed3 viewDir = normalize(_WorldSpaceCameraPos.xyz-a.vertex.xyz);
			fixed3 specular = _LightColor0.rgb*_Specular.rgb*pow(saturate(dot(reflecdir, viewDir)),_Gloss);
        return fixed4(ambin+diffuse+ specular+albedo,1.0);
        //加入光照
    }
    ENDCG
        }
       
    }
        Fallback "Diffuse"
}
