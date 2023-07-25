Shader "Custom/DisableZWrite"
{

	Subshader{
		Tags{
			"RenderType" = "Opaque"
		}
		Pass{
			ZWrite off
		}
	}
}