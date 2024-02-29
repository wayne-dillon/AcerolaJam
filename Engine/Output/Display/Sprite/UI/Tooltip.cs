using System.Collections.Generic;
using Microsoft.Xna.Framework;

public class Tooltip
{
    private Sprite background;
    private MultiLineTextComponent text;

    public Tooltip(List<string> TEXT, Vector2 POSITION, float TEXTSIZE)
    {
        text = new TextComponentBuilder().WithTextList(TEXT).WithAbsolutePosition(POSITION).WithTransitionable(false).BuildMultiLine();
        background = new SpriteBuilder().WithPath("rect").WithAbsolutePosition(POSITION).WithDims(new(text.GetWidth() + 10, text.GetHeight() + 10)).WithTransitionable(false).Build();
    }

    public void Update()
    {
        text.Update();
        background.Update();
    }

    public void Update(Vector2 POS)
    {
        text.SetAnchor(POS);
        text.Update();
        background.Pos = POS;
        background.Update();
    }

    public void Draw()
    {
        background.Draw();
        text.Draw();
    }
}