
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
    float yRem = (input.TextureCoordinates.y + time) * 1280 % 10;
    float alpha = yRem < 4 ? yRem / 20 * input.Color.a : 0;
    float4 color = float4(alpha, alpha, alpha, alpha);
    return tex2D(SpriteTextureSampler, input.TextureCoordinates) * color;
}

technique SpriteDrawing
{
	pass pass0
	{
		PixelShader = compile ps_4_0_level_9_1 MainPS();
	}
};