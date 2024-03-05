
Texture2D SpriteTexture : register(t0);
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
    
    if (input.TextureCoordinates.x < 0.2)
        col = input.TextureCoordinates.x * 10.0 * col;
    if (input.TextureCoordinates.y < 0.2)
        col = input.TextureCoordinates.y * 10.0 * col;
    if (input.TextureCoordinates.x > 0.8)
        col = (1.0 - input.TextureCoordinates.x) * 10.0 * col;
    if (input.TextureCoordinates.y > 0.8)
        col = (1.0 - input.TextureCoordinates.y) * 10.0 * col;

    return tex2D(SpriteTextureSampler, input.TextureCoordinates) * float4(col, input.Color.a);
}

technique SpriteDrawing
{
    pass pass0
    {
        PixelShader = compile ps_4_0_level_9_1 MainPS();
    }
};