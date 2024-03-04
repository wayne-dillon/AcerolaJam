using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

public class Checkbox : Clickable
{
    private ChildSprite check;
    protected bool isChecked;
    
    public Checkbox(Alignment ALIGNMENT, Vector2 OFFSET, List<IAnimate> ANIMATIONS, EventHandler<object> BUTTONCLICKED, object INFO, bool ISTRANSITIONABLE, bool ISCHECKED) 
        : base("rect", ALIGNMENT, OFFSET, new Vector2(20,20), Colors.BaseUIElement, Colors.BaseUIElement, Colors.Unavailable, 
                ANIMATIONS, Vector2.One, true, BUTTONCLICKED, INFO, ISTRANSITIONABLE) 
    {
        isChecked = ISCHECKED;
        check = new SpriteBuilder().WithPath("rect").WithColor(Colors.Black).WithDims(dims).WithParent(this).BuildChild();
    }

    public override void Update()
    {
        base.Update();
        check.Update();
    }

    protected override void OnButtonClicked()
    {
        isChecked = !isChecked;
        base.OnButtonClicked();
    }

    public void SetChecked(bool CHECKED)
    {
        isChecked = CHECKED;
    }

    public override void Draw()
    {
        base.Draw();
        if (isChecked) {
            check.Draw();
        }
    }
}