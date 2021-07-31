Shader "TutanDev/Sepia"
{
    Properties
    {
        _MainTex("Texture", 2D) = "white" {}
    }
        SubShader
    {
        Tags { "RenderType" = "Opaque" }

        Pass
        {
            CGPROGRAM
            #pragma vertex vert_img
            #pragma fragment frag

            #include "UnityCG.cginc"

            sampler2D _MainTex;
            float4    _MainTex_ST;



            fixed4 frag(v2f_img i) : COLOR
            {
                float4 tex = tex2D(_MainTex, i.uv);

                half3x3 sepiaVals = half3x3
                (
                    0.393, 0.349, 0.272,    // Red
                    0.769, 0.686, 0.534,    // Green
                    0.189, 0.168, 0.131     // Blue
                );
                half3 sepiaResult = mul(tex.rgb, sepiaVals);

                return half4(sepiaResult, tex.a);
            }
            ENDCG
        }
    }
}
