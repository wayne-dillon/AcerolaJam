using System;
using Microsoft.Xna.Framework;

public class Slider
{
    private Sprite background;
    private HorizontalDragable node;
    private int length = 200;

    public Slider(Alignment ALIGNMENT, Vector2 OFFSET, float INITIALPOS, EventHandler<object> ACTION)
    {
        background = new SpriteBuilder().WithPath("SliderBar200x10")
                                        .WithScreenAlignment(ALIGNMENT)
                                        .WithOffset(OFFSET)
                                        .WithDims(new Vector2(length, 10))
                                        .Build();

        float minX = background.Pos.X - length/2;
        float maxX = minX + length;
        Vector2 nodePos = new(minX + (length * INITIALPOS), background.Pos.Y); 
        node = new("Node20x20", nodePos, new Vector2(20, 20), Colors.Gray, null, ACTION, null, true, minX, maxX);
    }

    public void Update()
    {
        background.Update();
        node.Update();
    }

    public void Draw()
    {
        background.Draw();
        node.Draw();
    }
}