
Texture2D SpriteTexture : register(t0);
float time;
sampler2D SpriteTextureSampler : register(s0) = sampler_state
{
    Texture = <SpriteTexture>;
};

struct VertexShaderOutput
{
	float4 Position : SV_POSITION;
	float4 Color : COLOR0;
	float2 TextureCoordinates : TEXCOORD0;
};

float4 MainPS(VertexShaderOutput input) : COLOR
{
    float3 col = 0.5 + 0.5 * cos(time + input.TextureCoordinates.xyx + float3(0, 2, 4));
    return tex2D(SpriteTextureSampler, input.TextureCoordinates) * float4(col, 1);
}

technique SpriteDrawing
{
	pass pass0
	{
		PixelShader = compile ps_4_0_level_9_1 MainPS();
	}
};