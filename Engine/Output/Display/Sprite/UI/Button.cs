using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class Button : Clickable
{
    private readonly TextComponent text;

    public Button(string PATH, Alignment ALIGNMENT, Vector2 OFFSET, Vector2 DIMS, Color COLOR, Color HOVERCOLOR, Color UNAVAILABLECOLOR,
                Vector2 HOVERSCALE, List<IAnimate> ANIMATIONS, string TEXT, bool ISAVAILABLE, EventHandler<object> BUTTONCLICKED,
                object INFO, bool ISTRANSITIONABLE) 
        : base(PATH, ALIGNMENT, OFFSET, DIMS, COLOR, HOVERCOLOR, UNAVAILABLECOLOR, ANIMATIONS, HOVERSCALE, ISAVAILABLE, BUTTONCLICKED, INFO, ISTRANSITIONABLE) 
    {
        text = new TextComponentBuilder().WithText(TEXT).WithScreenAlignment(ALIGNMENT).WithOffset(OFFSET).Build();
    }

    public override void Update()
    {
        base.Update();
        text.Update();
    }

    public override void Draw()
    {
        base.Draw();
        text.Draw();
    }
}
