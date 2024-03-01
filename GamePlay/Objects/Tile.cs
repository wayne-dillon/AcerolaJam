using Microsoft.Xna.Framework;

public class Tile
{
    private Coordinate coordinate;
    public Coordinate Coordinate { get { return coordinate; } set { coordinate = value; } }

    private bool isOccupied;
    public bool IsOccupied { get { return isOccupied; } set { isOccupied = value; } }

    private Sprite emptyBackground;
    private Sprite filledBackground;

    public Tile(Coordinate COORD, Color COLOR)
    {
        coordinate = COORD;

        SpriteBuilder builder = new SpriteBuilder().WithDims(new Vector2(32, 32))
                                        .WithAbsolutePosition(EnumHelper.ScreenPos(coordinate))
                                        .WithColor(COLOR);

        emptyBackground = builder.WithPath("EmptyFrame").Build();
        filledBackground = builder.WithPath("Block").Build();
    }

    public void Update()
    {
        emptyBackground.Pos = EnumHelper.ScreenPos(coordinate);
        emptyBackground.Update();
        filledBackground.Pos = EnumHelper.ScreenPos(coordinate);
        filledBackground.Update();
    }

    public Color GetColor()
    {
        return filledBackground.color;
    }

    public void SetColor(Color COLOR)
    {
        filledBackground.color = COLOR;
    }

    public void Draw()
    {
        if (isOccupied)
        {
            filledBackground.Draw();
        }
        else
        {
            emptyBackground.Draw();
        }
    }
}