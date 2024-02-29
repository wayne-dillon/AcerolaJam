using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class Sprite : Animatable
{
    public bool hFlipped;
    public Texture2D myModel;
    public Sprite(string PATH, Alignment ALIGNMENT, Vector2 OFFSET, Vector2 DIMS, Color COLOR, List<IAnimate> ANIMATIONS, bool ISTRANSITIONABLE)
        : base(COLOR, Coordinates.Get(ALIGNMENT) + OFFSET, DIMS, ALIGNMENT, ANIMATIONS, ISTRANSITIONABLE)
    {
        myModel = Globals.content.Load<Texture2D>(PATH);
    }

    public override void Update()
    {
        base.Update();
    }

    public virtual bool Hover() {
        return HoverImg();
    }

    public virtual bool HoverImg() { 
        Vector2 mousePos = Globals.mouse.newMousePos;

        if (mousePos.X >= Pos.X - dims.X / 2 && mousePos.X <= Pos.X + dims.X / 2
                && mousePos.Y >= Pos.Y - dims.Y / 2 && mousePos.Y <= Pos.Y  + dims.Y / 2)
        {
            return true;
        }

        return false;
    }

    public override void Draw() {
        Draw(Pos, color);
    }

    public virtual void Draw(Color COLOR)
    {
        Draw(Pos, new Color(COLOR, color.A));
    }

    public virtual void Draw(Vector2 POS)
    {
        Draw(POS, color);
    }

    public virtual void Draw(Vector2 POS, Color COLOR)
    {
        if (myModel != null)
        {
            if (effect != null) Globals.ReopenSpriteBatch(effect);
        
            Globals.spriteBatch.Draw(myModel, new Rectangle((int)POS.X, (int)POS.Y, 
                (int)dims.X, (int)dims.Y), null, COLOR, rot, 
                new Vector2(myModel.Bounds.Width / 2, myModel.Bounds.Height / 2), hFlipped ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0);
        
            if (effect != null) Globals.ReopenSpriteBatch(null);
        }
    }
}
