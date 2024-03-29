using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

public class LinkedButton : Button
{
    private List<LinkedButton> linkedList;
    
    public LinkedButton(string PATH, Alignment ALIGNMENT, Vector2 OFFSET, Vector2 DIMS, Color COLOR, Color HOVERCOLOR, Color UNAVAILABLECOLOR,
                Vector2 HOVERSCALE, List<IAnimate> ANIMATIONS, string TEXT, bool ISAVAILABLE, EventHandler<object> BUTTONCLICKED,
                object INFO, bool ISTRANSITIONABLE) 
        : base(PATH, ALIGNMENT, OFFSET, DIMS, COLOR, HOVERCOLOR, UNAVAILABLECOLOR, HOVERSCALE, ANIMATIONS, TEXT, ISAVAILABLE, BUTTONCLICKED,
                INFO, ISTRANSITIONABLE)
    {
    }

    public override void Update()
    {
        base.Update();
    }

    protected override void OnButtonClicked()
    {
        if (linkedList == null || !isAvailable) 
        {
            return;
        }

        foreach (LinkedButton button in linkedList)
        {
            button.isAvailable = true;
        }
        isAvailable = false;

        base.OnButtonClicked();
    }

    public void SetLinkedList(List<LinkedButton> LIST)
    {
        linkedList = LIST;
    }

    public override void Draw()
    {
        base.Draw();
    }
}