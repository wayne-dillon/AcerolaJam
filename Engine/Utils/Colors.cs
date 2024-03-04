using Microsoft.Xna.Framework;

public class Colors
{
    public static readonly Color Black = new(0,0,0);
    public static readonly Color Gray = new(70,70,70);
    public static readonly Color OffWhite = new(180, 180, 180);
    public static readonly Color White = new(255, 255, 255);
    public static readonly Color Red = new(255,3,43);
    public static readonly Color Orange = new(255,143,0);
    public static readonly Color Yellow = new(255,255,13);
    public static readonly Color Green = new(10,255,10);
    public static readonly Color Blue = new(41,41,255);
    public static readonly Color Indigo = new(13,255,255);
    public static readonly Color Violet = new(255,8,255);

    public static readonly Color longPiece = Red;
    public static readonly Color lPiece = Orange;
    public static readonly Color rPiece = Yellow;
    public static readonly Color sPiece = Green;
    public static readonly Color squarePiece = Blue;
    public static readonly Color tPiece = Indigo;
    public static readonly Color zPiece = Violet;

    public static readonly Color BaseUIElement = White;
    public static readonly Color Unavailable = Gray;
    public static readonly Color Background = Black;
}