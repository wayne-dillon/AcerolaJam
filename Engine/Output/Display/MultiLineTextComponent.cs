using System.Collections.Generic;
using FontStashSharp;
using Microsoft.Xna.Framework;

public class MultiLineTextComponent : TextComponent
{
    private List<string> stringList;
    private List<LineTextAndPos> textList;
    private float lineSpacing;

    private struct LineTextAndPos
    {
        public string text;
        public Vector2 offset;

        public LineTextAndPos(string TEXT, Vector2 OFFSET)
        {
            text = TEXT;
            offset = OFFSET;
        }
    }

    public MultiLineTextComponent(List<string> TEXTLIST, float LINESPACING, Alignment TEXTALIGNMENT, Alignment SCREENALIGNMENT, Vector2 OFFSET, Color COLOR, List<IAnimate> ANIMATIONS, bool ISTRANSITIONABLE)
        : base("", TEXTALIGNMENT, SCREENALIGNMENT, OFFSET, COLOR, ANIMATIONS, ISTRANSITIONABLE)
    {
        stringList = TEXTLIST;
        lineSpacing = LINESPACING;
        Init();
    }

    public override void Init()
    {
        PopulateLines(stringList);
        base.Init();
    }

    public void Update(List<string> TEXTLIST)
    {
        stringList = TEXTLIST;
        PopulateLines(stringList);
        Update();
    }

    public override float GetHeight()
    {
        if (textList.Count == 0) return 0;
        return (textList.Count * font.MeasureString(textList[0].text).Y) + ((textList.Count - 1) * lineSpacing);
    }

    public override float GetWidth()
    {
        float maxWidth = 0;
        foreach (LineTextAndPos line in textList)
        {
            float width = font.MeasureString(line.text).X;
            if (width > maxWidth) maxWidth = width;
        }
        return maxWidth;
    }

    private void PopulateLines(List<string> STRINGS)
    {
        textList = new();
        if (STRINGS == null || STRINGS.Count == 0) return;
        int count = STRINGS.Count;
        float lineHeight = GetHeight(STRINGS[0]);
        for (int i = 0; i < count; i++)
        {
            string current = STRINGS[i];
            float yOffset = (i - (float)count/2) * lineHeight;
            yOffset += (i - (float)(count - 1)/2) * lineSpacing;
            textList.Add(new(current, new(GetTextAlignmentOffset(current).X,yOffset)));
        }
    }

    public override void Draw()
    {
        if (textList.Count == 0) return;
        if (effect != null) Globals.ReopenSpriteBatch(effect);

        foreach (LineTextAndPos line in textList)
        {
            Globals.spriteBatch.DrawString(font, line.text, (Pos + line.offset), color);
        }
        
        if (effect != null) Globals.ReopenSpriteBatch(null);
    }
}