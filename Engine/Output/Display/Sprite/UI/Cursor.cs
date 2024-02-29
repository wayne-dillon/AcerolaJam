using Microsoft.Xna.Framework;

public class Cursor : Sprite
{
    public Cursor() : base("rect", Alignment.TOP_LEFT, new Vector2(0,0), new Vector2(25,25), Color.Pink, null, false) 
    {
    }

    public override void Update()
    {
        Pos = Globals.mouse.newMousePos + new Vector2(10,12);

        base.Update();
    }

    public override void Draw()
    {
        base.Draw(Pos);
    }
}