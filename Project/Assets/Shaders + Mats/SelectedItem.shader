Shader "Hidden/SelectedItem"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Color("Colour", Color) = (1, 1, 1, 1)
    }
    SubShader
    {
        Tags{
            "Queue" = "Transparent"
        }
        // No culling or depth
        Cull Off ZWrite Off ZTest Always

        Pass
        {
        Blend SrcAlpha OneMinusSrcAlpha
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            sampler2D _MainTex;
            fixed4 _Color;

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv);
                // just invert the colors
                
                col *= _Color;

                if (col.a != 0) {
                    float alpha = 1;
                    for (int j = 0; j < 3; j++) {
                        fixed4 pixelUp = tex2D(_MainTex, i.uv + fixed2(0, j * .01f));
                        fixed4 pixelDown = tex2D(_MainTex, i.uv - fixed2(0, j * .01f));
                        fixed4 pixelRight = tex2D(_MainTex, i.uv + fixed2(j * .01f, 0));
                        fixed4 pixelLeft = tex2D(_MainTex, i.uv - fixed2(j * .01f, 0));

                        alpha = pixelUp.a * pixelDown.a * pixelRight.a * pixelLeft.a;
                        if (alpha == 0) {
                            col = fixed4(0, 0, 0, 1);
                            break;
                        }
                    }
                }

                return col;
            }
            ENDCG
        }
    }
}
