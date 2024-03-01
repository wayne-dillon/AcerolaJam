﻿using System.Collections.Generic;
using Microsoft.Xna.Framework;

public class TPiece : BasePiece
{
    public TPiece() : base(Colors.tPiece)
    {
        Dictionary<Coordinate, bool> north = new()
        {
            { new(0,0), true },
            { new(-1,0), true },
            { new(0,-1), true },
            { new(1,0), true },
        };
        Dictionary<Coordinate, bool> east = new()
        {
            { new(0,0), true },
            { new(0,-1), true },
            { new(1,0), true },
            { new(0,1), true },
        };
        Dictionary<Coordinate, bool> south = new()
        {
            { new(0,0), true },
            { new(-1,0), true },
            { new(0,1), true },
            { new(1,0), true },
        };
        Dictionary<Coordinate, bool> west = new()
        {
            { new(0,0), true },
            { new(0,-1), true },
            { new(-1,0), true },
            { new (0,1), true },
        };
        configurations.Add(Orientation.NORTH, new(north, 1, 1, 1));
        configurations.Add(Orientation.EAST, new(east, 1, 0, 1));
        configurations.Add(Orientation.SOUTH, new(south, 0, 1, 1));
        configurations.Add(Orientation.WEST, new(west, 1, 1, 0));

        MoveToUpNext();
    }
}