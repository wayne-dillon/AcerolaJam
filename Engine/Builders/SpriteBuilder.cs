using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class SpriteBuilder
{
    private string Path, Text = "";
    private SpriteFont Font;
    private Vector2 Offset, Dims, HoverScale = new(1.01f, 1.01f);
    private Alignment ScreenAlignment = Alignment.CENTER;
    private Color Color = Color.White;
    private Color HoverColor = Color.AliceBlue;
    private Color UnavailableColor = Colors.Unavailable;
    private List<IAnimate> Animations = new();
    private EventHandler<object> ButtonAction;
    private object ButtonInfo;
    private Sprite Parent;
    private bool IsAvailable = true;
    private bool IsTransitionable = true;
    private bool IsChecked;

    private Dictionary<int, string> PathDict;
    private int FrameTime;
    private int RangeMin;
    private int RangeMax;

    public Sprite Build() => new(Path, ScreenAlignment, Offset, Dims, Color, Animations, IsTransitionable);

    public AnimatedSprite BuildAnimated() => new(PathDict, FrameTime, RangeMin, RangeMax, ScreenAlignment, Offset, Dims, Color, Animations, IsTransitionable);

    public Button BuildButton() => new(Path, ScreenAlignment, Offset, Dims, Color, HoverColor, 
                UnavailableColor, HoverScale, Animations, Text, IsAvailable, ButtonAction, ButtonInfo, IsTransitionable);

    public LinkedButton BuildLinkedButton() => new(Path, ScreenAlignment, Offset, Dims, Color, HoverColor, 
                UnavailableColor, HoverScale, Animations, Text, IsAvailable, ButtonAction, ButtonInfo, IsTransitionable);

    public Checkbox BuildCheckbox() => new(ScreenAlignment, Offset, Animations, ButtonAction, ButtonInfo, IsTransitionable, IsChecked);

    public LinkedCheckbox BuildLinkedCheckbox() => new(Text, ScreenAlignment, Offset, Animations, ButtonAction, ButtonInfo, IsTransitionable, IsChecked);

    public ChildSprite BuildChild() => new(Path, Dims, Offset, Color, Parent, IsTransitionable);

    public Clickable BuildClickable() => new(Path, ScreenAlignment, Offset, Dims, Color, HoverColor, UnavailableColor, Animations, HoverScale, IsAvailable, 
            ButtonAction, ButtonInfo, IsTransitionable);

    public Dragable BuildDragable() => new(Path, ScreenAlignment, Offset, Dims, Color, Animations, ButtonAction, ButtonInfo, IsTransitionable);

    public SpriteBuilder WithPath(string PATH)
    {
        Path = PATH;
        return this;
    }

    public SpriteBuilder WithText(string TEXT)
    {
        Text = TEXT;
        return this;
    }

    public SpriteBuilder WithFont(SpriteFont FONT)
    {
        Font = FONT;
        return this;
    }

    public SpriteBuilder WithAbsolutePosition(Vector2 POS)
    {
        ScreenAlignment = Alignment.TOP_LEFT;
        Offset = POS;
        return this;
    }

    public SpriteBuilder WithOffset(Vector2 OFFSET)
    {
        Offset = OFFSET;
        return this;
    }

    public SpriteBuilder WithDims(Vector2 DIMS)
    {
        Dims = DIMS;
        return this;
    }

    public SpriteBuilder WithHoverScale(Vector2 HOVERSCALE)
    {
        HoverScale = HOVERSCALE;
        return this;
    }

    public SpriteBuilder WithScreenAlignment(Alignment ALIGNMENT)
    {
        ScreenAlignment = ALIGNMENT;
        return this;
    }

    public SpriteBuilder WithColor(Color COLOR)
    {
        Color = COLOR;
        return this;
    }

    public SpriteBuilder WithHoverColor(Color COLOR)
    {
        HoverColor = COLOR;
        return this;
    }

    public SpriteBuilder WithUnavailableColor(Color COLOR)
    {
        UnavailableColor = COLOR;
        return this;
    }

    public SpriteBuilder WithAnimations(List<IAnimate> ANIMATIONS)
    {
        Animations = ANIMATIONS;
        return this;
    } 

    public SpriteBuilder WithAnimation(IAnimate ANIMATION)
    {
        Animations.Add(ANIMATION);
        return this;
    } 

    public SpriteBuilder ClearAnimations(IAnimate ANIMATION)
    {
        Animations.Clear();
        return this;
    } 

    public SpriteBuilder WithButtonAction(EventHandler<object> BUTTONACTION)
    {
        ButtonAction = BUTTONACTION;
        return this;
    }

    public SpriteBuilder WithButtonInfo(object INFO)
    {
        ButtonInfo = INFO;
        return this;
    }

    public SpriteBuilder WithParent(Sprite PARENT)
    {
        Parent = PARENT;
        return this;
    }

    public SpriteBuilder WithTransitionable(bool ISTRANSITIONABLE)
    {
        IsTransitionable = ISTRANSITIONABLE;
        return this;
    }

    public SpriteBuilder WithChecked(bool ISCHECKED)
    {
        IsChecked = ISCHECKED;
        return this;
    }

    public SpriteBuilder WithAvailable(bool ISAVAILABLE)
    {
        IsAvailable = ISAVAILABLE;
        return this;
    }

    public SpriteBuilder WithPathDict(Dictionary<int, string> PATHDICT)
    {
        PathDict = PATHDICT;
        return this;
    }

    public SpriteBuilder WithFrameTime(int FRAMETIME)
    {
        FrameTime = FRAMETIME;
        return this;
    }

    public SpriteBuilder WithRangeMinMax(int MIN, int MAX)
    {
        RangeMin = MIN;
        RangeMax = MAX;
        return this;
    }
}