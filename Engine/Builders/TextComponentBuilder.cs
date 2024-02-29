using System.Collections.Generic;
using Microsoft.Xna.Framework;

public class TextComponentBuilder
{
    private string Text = "";
    private List<string> TextList = new();
    private float LineSpacing = 5;
    private Vector2 Offset;
    private Alignment ScreenAlignment = Alignment.CENTER;
    private Alignment TextAlignment = Alignment.CENTER;
    private Color Color = Color.Black;
    private List<IAnimate> Animations = new();
    private bool IsTransitionable = true;

    public TextComponent Build() => new(Text, TextAlignment, ScreenAlignment, Offset, Color, Animations, IsTransitionable);

    public MultiLineTextComponent BuildMultiLine() => new(TextList, LineSpacing, TextAlignment, ScreenAlignment, Offset, Color, Animations, IsTransitionable);

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