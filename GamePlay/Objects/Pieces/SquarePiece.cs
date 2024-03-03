using System.Collections.Generic;
using Microsoft.Xna.Framework;

public class SquarePiece : BasePiece
{
    public SquarePiece() : base(Colors.squarePiece)
    {
    }

    protected override Coordinate[] GetCoords()
    {
        if (isAberrant)
        {
            switch (Globals.random.Next(0, 4))
            {
                case 0:
                    return new Coordinate[] { new(1, 0), new(0, 0), new(0, 1) };
                case 1:
                    return new Coordinate[] { new(1, 0), new(0, 0), new(0, 1), new(1, 1), new(0, -1) };
                case 2:
                    return new Coordinate[] { new(1, 0), new(0, 0), new(0, 1), new(1, 1), new(-1, -1) };
                default:
                    return new Coordinate[] { new(1, 0), new(0, 0), new(0, 1), new(1, 1), new(1, -1) };
            }
        }
        return new Coordinate[] { new(1, 0), new(0, 0), new(0, 1), new(1, 1) };
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