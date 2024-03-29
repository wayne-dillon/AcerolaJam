﻿using System.Collections.Generic;
using Microsoft.Xna.Framework;

public class RPiece : BasePiece
{
    public RPiece(int NEXTPOS) : base(Colors.rPiece, NEXTPOS)
    {
    }

    protected override void SetBaseConf()
    {
        baseConf = new(new() { { new(0, -1), true }, { new(0, 0), true }, { new(1, -1), true }, { new(0, 1), true } });
    }

    protected override Coordinate[] GetCoords()
    {
        if (isAberrant)
        {
            switch (Globals.random.Next(0, 13))
            {
                case 0:
                    return new Coordinate[] { new(0, 0), new(1, -1), new(0, 1) };
                case 1:
                    return new Coordinate[] { new(0, -1), new(1, -1), new(0, 1) };
                case 2:
                    return new Coordinate[] { new(0, -1), new(0, 0), new(0, 1) };
                case 3:
                    return new Coordinate[] { new(0, -1), new(0, 0), new(1, -1) };
                case 4:
                    return new Coordinate[] { new(0, -1), new(0, 0), new(1, -1), new(0, 1), new(0, -2) };
                case 5:
                    return new Coordinate[] { new(0, -1), new(0, 0), new(1, -1), new(0, 1), new(0, 2) };
                case 6:
                    return new Coordinate[] { new(0, -1), new(0, 0), new(1, -1), new(0, 1), new(-1, -1) };
                case 7:
                    return new Coordinate[] { new(0, -1), new(0, 0), new(1, -1), new(0, 1), new(2,-1) };
                case 8:
                    return new Coordinate[] { new(0, -1), new(0, 0), new(1, -1), new(0, 1), new(-1, 0) };
                case 9:
                    return new Coordinate[] { new(0, -1), new(0, 0), new(1, -1), new(0, 1), new(1, 0) };
                case 10:
                    return new Coordinate[] { new(0, -1), new(0, 0), new(1, -1), new(0, 1), new(-1, 1) };
                case 11:
                    return new Coordinate[] { new(0, -1), new(0, 0), new(1, -1), new(0, 1), new(1, 1) };
                default:
                    return new Coordinate[] { new(0, -1), new(0, 0), new(1, -1), new(0, 1), new(1, -2) };
            }
        }
        return new Coordinate[] { new(0, -1), new(0, 0), new(1, -1), new(0, 1) };
    }
}