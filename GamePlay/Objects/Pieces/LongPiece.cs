using System.Collections.Generic;
using Microsoft.Xna.Framework;

public class LongPiece : BasePiece
{
    public LongPiece() : base(Colors.longPiece)
    {
        Dictionary<Coordinate, bool> horizontal = new()
        {
            { new(0,0), true },
            { new(-1,0), true },
            { new(1,0), true },
            { new(2,0), true },
        };
        Dictionary<Coordinate, bool> vertical = new()
        {
            { new(0,0), true },
            { new(0,-1), true },
            { new(0,1), true },
            { new(0,2), true },
        };
        configurations.Add(Orientation.NORTH, new(vertical, 1, 0, 0));
        configurations.Add(Orientation.EAST, new(horizontal, 0, 1, 2));
        configurations.Add(Orientation.SOUTH, new(vertical, 1, 0, 0));
        configurations.Add(Orientation.WEST, new(horizontal, 0, 1, 2));
    }
}