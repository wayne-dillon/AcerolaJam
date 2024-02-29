using Microsoft.Xna.Framework;

public class StatBar : ChildSprite
{
    private ChildSprite background;
    private Vector2 offsetOrigin;
    private float maxValue;

    public StatBar(Vector2 DIMS, Vector2 OFFSET, Color COLOR, Sprite PARENT)
        : base("rect", DIMS, OFFSET, COLOR, PARENT, true)
    {
        maxValue = DIMS.X;
        offsetOrigin = OFFSET;
        background = new SpriteBuilder().WithPath("rect")
                                    .WithParent(PARENT)
                                    .WithOffset(OFFSET)
                                    .WithColor(Color.Black)
                                    .WithDims(DIMS + new Vector2(3, 3))
                                    .BuildChild();
    }

    public override void Update()
    {
        background.Update();
        base.Update();
    }

    public void Update(float FRACTION)
    {
        float newX = FRACTION * maxValue;
        dims.X = newX;
        offset = offsetOrigin - new Vector2((maxValue - newX) / 2, 0);
        Update();
    }

    public override void Draw()
    {
        background.Draw();
        base.Draw();
    }
}