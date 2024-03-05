using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class TextComponentBuilder
{
    private string Text = "";
    private List<string> TextList = new();
    private SpriteFont Font = Globals.defaultFont;
    private float LineSpacing = 0;
    private Vector2 Offset;
    private Alignment ScreenAlignment = Alignment.CENTER;
    private Alignment TextAlignment = Alignment.CENTER;
    private Color Color = Colors.Black;
    private List<IAnimate> Animations = new();
    private bool IsTransitionable = true;

    public TextComponent Build() => new(Text, Font, TextAlignment, ScreenAlignment, Offset, Color, Animations, IsTransitionable);

    public MultiLineTextComponent BuildMultiLine() => new(TextList, Font, LineSpacing, TextAlignment, ScreenAlignment, Offset, Color, Animations, IsTransitionable);

    public TextComponentBuilder WithText(string TEXT)
    {
        Text = TEXT;
        return this;
    }

    public TextComponentBuilder WithTextList(List<string> TEXTLIST)
    {
        TextList = TEXTLIST;
        return this;
    }

    public TextComponentBuilder WithFont(SpriteFont FONT)
    {
        Font = FONT;
        return this;
    }

    public TextComponentBuilder WithLineSpacing(float SPACING)
    {
        LineSpacing = SPACING;
        return this;
    }

    public TextComponentBuilder WithAbsolutePosition(Vector2 POS)
    {
        ScreenAlignment = Alignment.TOP_LEFT;
        Offset = POS;
        return this;
    }

    public TextComponentBuilder WithOffset(Vector2 OFFSET)
    {
        Offset = OFFSET;
        return this;
    }

    public TextComponentBuilder WithScreenAlignment(Alignment ALIGNMENT)
    {
        ScreenAlignment = ALIGNMENT;
        return this;
    }

    public TextComponentBuilder WithTextAlignment(Alignment ALIGNMENT)
    {
        TextAlignment = ALIGNMENT;
        return this;
    }

    public TextComponentBuilder WithColor(Color COLOR)
    {
        Color = COLOR;
        return this;
    }

    public TextComponentBuilder WithAnimations(List<IAnimate> ANIMATIONS)
    {
        Animations = ANIMATIONS;
        return this;
    } 

    public TextComponentBuilder WithAnimation(IAnimate ANIMATION)
    {
        Animations.Add(ANIMATION);
        return this;
    } 

    public TextComponentBuilder ClearAnimations()
    {
        Animations.Clear();
        return this;
    } 

    public TextComponentBuilder WithTransitionable(bool ISTRANSITIONABLE)
    {
        IsTransitionable = ISTRANSITIONABLE;
        return this;
    }
}