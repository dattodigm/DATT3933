Shader "WobblyLife/Custom/WobblyIceCave" {
	Properties {
		_BaseColour ("Base Colour", Vector) = (0.2406042,0.6449719,0.7830189,0)
		_HighLightColour ("HighLight Colour", Vector) = (0.5114682,0.782253,0.8396226,1)
		_FresnelScale ("Fresnel Scale", Float) = 1
		_FresnelPower ("Fresnel Power", Float) = 4
		_Scale ("Scale", Float) = 0.1
		_VoronoiPower ("Voronoi Power", Float) = 5
		_PatternStrength ("Pattern Strength", Float) = 0.2
		[HideInInspector] __dirty ("", Float) = 1
	}
	//DummyShaderTextExporter
	SubShader{
		Tags { "RenderType" = "Opaque" }
		LOD 200

		Pass
		{
			HLSLPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			float4x4 unity_ObjectToWorld;
			float4x4 unity_MatrixVP;

			struct Vertex_Stage_Input
			{
				float4 pos : POSITION;
			};

			struct Vertex_Stage_Output
			{
				float4 pos : SV_POSITION;
			};

			Vertex_Stage_Output vert(Vertex_Stage_Input input)
			{
				Vertex_Stage_Output output;
				output.pos = mul(unity_MatrixVP, mul(unity_ObjectToWorld, input.pos));
				return output;
			}

			float4 frag(Vertex_Stage_Output input) : SV_TARGET
			{
				return float4(1.0, 1.0, 1.0, 1.0); // RGBA
			}

			ENDHLSL
		}
	}
	Fallback "Diffuse"
	//CustomEditor "ASEMaterialInspector"
}