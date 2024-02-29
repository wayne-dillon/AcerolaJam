using System.Collections.Generic;
using Microsoft.Xna.Framework;

public class SquarePiece : BasePiece
{
    public SquarePiece() : base(Colors.squarePiece)
    {
        Dictionary<Coordinate, bool> coords = new()
        {
            { new(0,0), true },
            { new(1,0), true },
            { new(0,1), true },
            { new (1,1), true },
        };
        configurations.Add(Orientation.NORTH, new(coords, 0, 0, 1));
        configurations.Add(Orientation.EAST, new(coords, 0, 0, 1));
        configurations.Add(Orientation.SOUTH, new(coords, 0, 0, 1));
        configurations.Add(Orientation.WEST, new(coords, 0, 0, 1));
    }
}