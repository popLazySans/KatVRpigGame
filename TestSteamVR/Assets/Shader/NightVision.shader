Shader "Custom/NightVision" {
    Properties {
        _MainTex ("Texture", 2D) = "white" {}
    }

    CGINCLUDE
    #include "UnityCG.cginc"
    struct appdata
    {
        float4 vertex : POSITION;
        float3 normal : NORMAL;
    };

    struct v2f
    {
        float4 pos : POSITION;
        float4 color : COLOR;
    };
   

    sampler2D _MainTex;

    v2f vert(appdata v)
    {
        v2f o;
        o.pos = UnityObjectToClipPos(v.vertex);
        o.color = float4(1, 1, 1, 1);
        return o;
    }

    fixed4 frag(v2f i) : COLOR
    {
        // Apply night vision effect here (e.g., darken the scene, add noise)
        return tex2D(_MainTex, i.color);
    }
     ENDCG
}