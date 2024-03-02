using System.Collections.Generic;

public struct Configuration
{
    public Dictionary<Coordinate, bool> coordinates;
    private int originDepth;
    private int originLeft;
    private int originRight;

    public Configuration(Dictionary<Coordinate, bool> COORDS, int DEPTH, int LEFT, int RIGHT)
    {
        coordinates = COORDS;
        originDepth = DEPTH;
        originLeft = LEFT;
        originRight = RIGHT;
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
