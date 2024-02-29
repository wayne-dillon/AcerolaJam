﻿using System.Collections.Generic;
using Microsoft.Xna.Framework;

public class SPiece : BasePiece
{
    public SPiece() : base(Colors.sPiece)
    {
        Dictionary<Coordinate, bool> vertical = new()
        {
            { new(0,0), true },
            { new(0,-1), true },
            { new(1,0), true },
            { new(1,1), true },
        };
        Dictionary<Coordinate, bool> horizontal = new()
        {
            { new(0,0), true },
            { new(1,0), true },
            { new(-1,1), true },
            { new(0,1), true },
        };
        configurations.Add(Orientation.NORTH, new(vertical, 1, 0, 1));
        configurations.Add(Orientation.EAST, new(horizontal, 0, 1, 1));
        configurations.Add(Orientation.SOUTH, new(vertical, 1, 0, 1));
        configurations.Add(Orientation.WEST, new(horizontal, 0, 1, 1));
    }
}