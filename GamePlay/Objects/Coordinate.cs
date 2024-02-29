using System;

public struct Coordinate
{
    public int X;
    public int Y;

    public Coordinate(int X, int Y)
    {
        this.X = X;
        this.Y = Y;
    }

    public static Coordinate operator +(Coordinate a, Coordinate b) => new(a.X + b.X, a.Y + b.Y);
    public static Coordinate operator -(Coordinate a, Coordinate b) => new(a.X - b.X, a.Y - b.Y);

    public readonly int DistanceTo(Coordinate COORD)
    {
        return Math.Abs(X - COORD.X) + Math.Abs(Y - COORD.Y);
    }
}