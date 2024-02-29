using Microsoft.Xna.Framework;

public class Tile
{
    private Coordinate coordinate;
    public Coordinate Coordinate { get { return coordinate; } set { coordinate = value; } }

    private bool isOccupied;
    public bool IsOccupied { get { return isOccupied; } set { isOccupied = value; } }

    private Sprite background;

    public Tile(Coordinate COORD, Color COLOR)
    {
        coordinate = COORD;

        background = new SpriteBuilder().WithPath("rect")
                                        .WithDims(new Vector2(32, 32))
                                        .WithAbsolutePosition(ScreenPos())
                                        .WithColor(COLOR)
                                        .Build();
    }

    public void Update()
    {
        background.Pos = ScreenPos();
        background.Update();
    }

    private Vector2 ScreenPos()
    {
        float x = 464 + (coordinate.X * 32);
        float y = 88 + (coordinate.Y * 32);
        return new Vector2(x, y);
    }

    public void SetColor(Color COLOR)
    {
        background.color = COLOR;
    }

    public void Draw()
    {
        background.Draw();
    }
}