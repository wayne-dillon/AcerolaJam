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
        : base(PATH, ALIGNMENT, OFFSET, DIMS, Colors.White, Colors.OffWhite, Colors.Gray, ANIMATIONS, HOVERSCALE, ISAVAILABLE, BUTTONCLICKED, INFO, ISTRANSITIONABLE) 
    {
        text = new TextComponentBuilder().WithText(TEXT).WithColor(Colors.Black).WithScreenAlignment(ALIGNMENT).WithOffset(OFFSET).Build();
    }

    public override void Update()
    {
        base.Update();
        if (isAvailable)
        {
            text.color = Colors.Black;
        } else
        {
            text.color = Colors.White;
        }
        text.Update();
    }

    public override void Draw()
    {
        base.Draw();
        text.Draw();
    }
}
