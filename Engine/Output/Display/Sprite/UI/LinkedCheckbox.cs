using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

public class LinkedCheckbox : Checkbox
{
    private List<LinkedCheckbox> linkedList;
    private TextComponent label;
    
    public LinkedCheckbox(string LABEL, Alignment ALIGNMENT, Vector2 OFFSET, List<IAnimate> ANIMATIONS, EventHandler<object> BUTTONCLICKED, 
                            object INFO, bool ISTRANSITIONABLE, bool ISCHECKED) 
        : base(ALIGNMENT, OFFSET, ANIMATIONS, BUTTONCLICKED, INFO, ISTRANSITIONABLE, ISCHECKED) 
    {
        label = new TextComponentBuilder().WithText(LABEL)
                                        .WithScreenAlignment(ALIGNMENT)
                                        .WithTextAlignment(Alignment.CENTER_RIGHT)
                                        .WithOffset(OFFSET + new Vector2(-25, 0))
                                        .WithAnimations(ANIMATIONS)
                                        .Build();
    }

    public override void Update()
    {
        base.Update();
        label.Update();
    }

    protected override void OnButtonClicked()
    {
        if (linkedList == null || isChecked) 
        {
            return;
        }

        foreach (Checkbox box in linkedList)
        {
            box.SetChecked(false);
        }

        base.OnButtonClicked();
    }

    public void SetLinkedList(List<LinkedCheckbox> LIST)
    {
        linkedList = LIST;
    }

    public override void Draw()
    {
        base.Draw();
        label.Draw();
    }
}