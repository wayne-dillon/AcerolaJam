using System.Collections.Generic;
using Microsoft.Xna.Framework;

public class LPiece : BasePiece
{
    public LPiece() : base(Colors.lPiece)
    {
    }

    protected override Coordinate[] GetCoords()
    {
        if (isAberrant)
        {
            switch (Globals.random.Next(0, 13))
            {
                case 0:
                    return new Coordinate[] { new(0, -1), new(0, 0), new(0, 1) };
                case 1:
                    return new Coordinate[] { new(0, -1), new(0, 0), new(1, 1) };
                case 2:
                    return new Coordinate[] { new(0, -1), new(0, 1), new(1, 1) };
                case 3:
                    return new Coordinate[] { new(0, 0), new(0, 1), new(1, 1) };
                case 4:
                    return new Coordinate[] { new(0, -1), new(0, 0), new(0, 1), new(1, 1), new(1, -1) };
                case 5:
                    return new Coordinate[] { new(0, -1), new(0, 0), new(0, 1), new(1, 1), new(-1, -1) };
                case 6:
                    return new Coordinate[] { new(0, -1), new(0, 0), new(0, 1), new(1, 1), new(0, -2) };
                case 7:
                    return new Coordinate[] { new(0, -1), new(0, 0), new(0, 1), new(1, 1), new(0, 2) };
                case 8:
                    return new Coordinate[] { new(0, -1), new(0, 0), new(0, 1), new(1, 1), new(1, 0) };
                case 9:
                    return new Coordinate[] { new(0, -1), new(0, 0), new(0, 1), new(1, 1), new(-1, 0) };
                case 10:
                    return new Coordinate[] { new(0, -1), new(0, 0), new(0, 1), new(1, 1), new(1, 2) };
                case 11:
                    return new Coordinate[] { new(0, -1), new(0, 0), new(0, 1), new(1, 1), new(2, 1) };
                default:
                    return new Coordinate[] { new(0, -1), new(0, 0), new(0, 1), new(1, 1), new(-1, 1) };
            }
        }
        return new Coordinate[] { new(0, -1), new(0, 0), new(0, 1), new(1, 1) };
    }
}