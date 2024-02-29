using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class TextComponent : Animatable
{
    private string text;
    public SpriteFont font;
    protected Vector2 absolutePos;
    private readonly Alignment textAlignment;

    public TextComponent(string TEXT, Alignment TEXTALIGNMENT, Alignment SCREENALIGNMENT, Vector2 OFFSET, Color COLOR, List<IAnimate> ANIMATIONS, bool ISTRANSITIONABLE)
        : base(COLOR, Coordinates.Get(SCREENALIGNMENT) + OFFSET, Vector2.Zero, SCREENALIGNMENT, ANIMATIONS, ISTRANSITIONABLE)
    {
        text = TEXT;
        textAlignment = TEXTALIGNMENT;
        font = Globals.content.Load<SpriteFont>("Fonts//IndieFlower12");
        Init();
    }

    public virtual void Init()
    {
        SetAnchor(Pos);
    }

    public override void Update() 
    {
        absolutePos = Pos + GetTextAlignmentOffset();
        base.Update();
    }

    public void Update(string TEXT) 
    {
        text = TEXT;
        Update();
    }

    public Vector2 GetTextAlignmentOffset() 
    {
        return textAlignment switch
        {
            Alignment.CENTER or Alignment.TOP or Alignment.BOTTOM => new Vector2(-GetWidth() / 2 / Globals.ScalingFactor().X, -GetHeight() / 2 / Globals.ScalingFactor().Y),
            Alignment.CENTER_LEFT or Alignment.TOP_LEFT or Alignment.BOTTOM_LEFT => new Vector2(0, -GetHeight() / 2 / Globals.ScalingFactor().Y),
            _ => new Vector2(-GetWidth() / Globals.ScalingFactor().X, -GetHeight() / 2 / Globals.ScalingFactor().Y),
        };
    }

    public Vector2 GetTextAlignmentOffset(string TEXT) 
    {
        return textAlignment switch
        {
            Alignment.CENTER or Alignment.TOP or Alignment.BOTTOM => new Vector2(-GetWidth(TEXT) / 2 / Globals.ScalingFactor().X, -GetHeight(TEXT) / 2 / Globals.ScalingFactor().Y),
            Alignment.CENTER_LEFT or Alignment.TOP_LEFT or Alignment.BOTTOM_LEFT => new Vector2(0, -GetHeight(TEXT) / 2 / Globals.ScalingFactor().Y),
            _ => new Vector2(-GetWidth(TEXT) / Globals.ScalingFactor().X, -GetHeight(TEXT) / 2 / Globals.ScalingFactor().Y),
        };
    }

    public virtual float GetHeight() => GetHeight(text);

    public virtual float GetWidth() => GetWidth(text);

    public float GetHeight(string TEXT) => font.MeasureString(TEXT).Y;

    public float GetWidth(string TEXT) => font.MeasureString(TEXT).X;

    public void SetAnchor(Vector2 ANCHOR)
    {
        Pos = ANCHOR;
        absolutePos = Pos + GetTextAlignmentOffset();
    }

    public override void Draw() 
    {
        if (effect != null) Globals.ReopenSpriteBatch(effect);

        Globals.spriteBatch.DrawString(font, text, absolutePos * Globals.ScalingFactor(), color);

        if (effect != null) Globals.ReopenSpriteBatch(null);
    }
}