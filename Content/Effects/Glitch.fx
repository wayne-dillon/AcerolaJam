
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

bool IsBetween(float value, float lower, float upper)
{
    return value >= lower && value <= upper;
}

float4 MainPS(VertexShaderOutput input) : COLOR
{
    float3 col = input.Color;
    
    if (IsBetween((time / 20) % 7, 2, 4))
    {
        float xClamp = 0;
        if (IsBetween(((input.TextureCoordinates.x * 20) + time) % 20, 0, 13))
            xClamp = 1;
        float yRem = ((input.TextureCoordinates.y * 20) + time + xClamp) % 20;
        if (IsBetween(yRem, 16.0, 20))
        {
            col = float3(0.0, 0.0, 0.0);
        }
        if (IsBetween(yRem, 11.0, 14.0))
        {
            col = float3(1.0, 1.0, 1.0);
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