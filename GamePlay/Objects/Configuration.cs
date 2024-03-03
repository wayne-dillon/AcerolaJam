using System.Collections.Generic;

public struct Configuration
{
    public Dictionary<Coordinate, bool> coordinates;

    public Configuration(Dictionary<Coordinate, bool> COORDS)
    {
        coordinates = COORDS;
    }

    public int TopRow()
    {
        int top = 2;

        foreach (var coord  in coordinates)
        {
            if (coord.Value && coord.Key.Y < top) top = coord.Key.Y;
        }

        return top;
    }

    public int BottomRow()
    {
        int bottom = -2;

        foreach (var coord in coordinates)
        {
            if (coord.Value && coord.Key.Y > bottom) bottom = coord.Key.Y;
        }

        return bottom;
    }

    public int LeftColumn()
    {
        int left = 2;

        foreach (var coord in coordinates)
        {
            if (coord.Value && coord.Key.X < left) left = coord.Key.X;
        }

        return left;
    }

    public int RightColumn()
    {
        int right = -2;

        foreach (var coord in coordinates)
        {
            if (coord.Value && coord.Key.X > right) right = coord.Key.X;
        }

        return right;
    }
}
