
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
	if (time > 90)
    {
        float yRem = (input.TextureCoordinates.y + time / 100) * 1280 % 10;
        float alpha = 0.75 + (yRem / 40);
        float4 color = float4(input.Color.r, input.Color.g, input.Color.b, alpha);
        return tex2D(SpriteTextureSampler, input.TextureCoordinates) * color;
    }

    return tex2D(SpriteTextureSampler, input.TextureCoordinates) * input.Color;
}

technique SpriteDrawing
{
	pass pass0
	{
		PixelShader = compile ps_4_0_level_9_1 MainPS();
	}
};