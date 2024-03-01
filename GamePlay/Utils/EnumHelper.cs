using Microsoft.Xna.Framework;

public class EnumHelper
{
    public static Orientation RandomOrientation() => (Orientation)Globals.random.Next(0, 4);

    public static Vector2 ScreenPos(Coordinate coordinate)
    {
        float x = 464 + (coordinate.X * 32);
        float y = 88 + (coordinate.Y * 32);
        return new Vector2(x, y);
    }
}
