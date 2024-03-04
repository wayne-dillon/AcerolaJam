
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
    float3 col = input.Color;
    
    if (time % 4 < 0.25)
    {
        float yRem = ((input.TextureCoordinates.y * 500) + time) % 20;
        if (yRem > 16)
        {
            col = float3(0.0, 0.0, 0.0);
        }
        if (yRem > 11 && yRem < 14)
        {
            col = float3(0.0, 0.0, 0.0);
        }
    }
    
    return tex2D(SpriteTextureSampler, input.TextureCoordinates) * float4(col, 1.0);
}

technique SpriteDrawing
{
	pass pass0
	{
		PixelShader = compile ps_4_0_level_9_1 MainPS();
	}
};