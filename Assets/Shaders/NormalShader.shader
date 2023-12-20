Shader "Unlit/NormalShader"
{
    Properties
    {
        _MainTex ("Main Texture", 2D) = "white" {}
        _Shininess ("Shininess",float)=1
        _SpecularColor ("Specular Color",Color)=(1,1,1,1)
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex MyVertexProgram
            #pragma fragment MyFragmentProgram
            #pragma shader_feature USE_SPECULAR
            #pragma shader_feature NORMAL_ONLY
            #pragma shader_feature BLINN_PHONG
            

            #include "UnityCG.cginc"
            #include "UnityStandardBRDF.cginc"

           // #if BLINN_PHONG
                struct VertexData {
                    float4 position:POSITION;
                    float3 normal:NORMAL;
                    float2 uv:TEXCOORD0;
                };
            
                struct FragmentData{
                    float4 position : SV_POSITION;
                    float2 uv : TEXCOORD0;
                    float3 normal : TEXCOORD1;
                    float3 worldPos : TEXCOORD2;

                };
            
                sampler2D _MainTex;
                float4 _MainTex_ST;
                float4 _SpecularColor;
                float _Shininess;

                FragmentData MyVertexProgram (VertexData v) {
                    FragmentData i;
                    i.position = UnityObjectToClipPos(v.position);

                    i.normal = UnityObjectToWorldNormal(v.normal);

                    i.worldPos = mul(unity_ObjectToWorld, v.position);


                    i.uv = v.uv * _MainTex_ST.xy + _MainTex_ST.zw;

                    return i;
                }
            
                float4 MyFragmentProgram(FragmentData i) : SV_TARGET{
                        return float4(i.normal+0.5, 1);
                }
           // #endif


            ENDCG
        }
    }
    CustomEditor "CustomShaderGUI"
}
