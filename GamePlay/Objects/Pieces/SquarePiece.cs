﻿using System.Collections.Generic;
using Microsoft.Xna.Framework;

public class SquarePiece : BasePiece
{
    public SquarePiece() : base(Colors.squarePiece)
    {
        blockGrid.SetNorthCoords(new Coordinate[] { new(1, 0), new(0, 0), new(0, 1), new(1, 1) });

        configurations.Add(Orientation.NORTH, new(blockGrid.NorthCoords(), 0, 0, 1));
        configurations.Add(Orientation.EAST, new(blockGrid.EastCoords(), 0, 0, 1));
        configurations.Add(Orientation.SOUTH, new(blockGrid.SouthCoords(), 0, 0, 1));
        configurations.Add(Orientation.WEST, new(blockGrid.WestCoords(), 0, 0, 1));

        MoveToUpNext();
    }

    public override void RotateClockwise()
    {
        if (isAberrant)
            base.RotateClockwise();
    }

    public override void RotateCounterClockwise()
    {
        if (isAberrant)
            base.RotateCounterClockwise();
    }
}