using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

public class HorizontalDragable : Dragable
{
    private float minValue;
    private float maxValue;
    private float range;
    private float yValue;

    public HorizontalDragable(string PATH, Vector2 POSITION, Vector2 DIMS, Color COLOR, List<IAnimate> ANIMATIONS,
            EventHandler<object> ACTION, object INFO, bool ISTRANSITIONABLE, float MIN, float MAX)
        : base(PATH, Alignment.TOP_LEFT, POSITION, DIMS, COLOR, ANIMATIONS, ACTION, INFO, ISTRANSITIONABLE)
    {
        minValue = MIN;
        maxValue = MAX;
        range = maxValue - minValue;
        yValue = Pos.Y;
    }

    public override void Update()
    {
        if (Hover())
        {
            if (Globals.mouse.LeftClick())
            {
                isHeld = true;
                cursorOffset = Pos - Globals.mouse.newMousePos;
            }
        }
        if (Globals.mouse.LeftClickRelease())
        {
            isHeld = false;
        }

        if (isHeld)
        {
            float xValue = Globals.mouse.newMousePos.X + cursorOffset.X;
            if (xValue < minValue) xValue = minValue;
            if (xValue > maxValue) xValue = maxValue;
            Pos = new Vector2(xValue, yValue);

            float currentValue = (xValue - minValue) / range;
            action(null, currentValue);
        }

        base.SkipOverUpdate();
    }

    public override void Draw()
    {
        base.Draw();
    }
}