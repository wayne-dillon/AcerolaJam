using System.Collections.Generic;
using Microsoft.Xna.Framework;

public class ZPiece : BasePiece
{
    public ZPiece(int NEXTPOS) : base(Colors.zPiece, NEXTPOS)
    {
    }

    protected override void SetBaseConf()
    {
        baseConf = new(new() { { new(0, -1), true }, { new(0, 0), true }, { new(-1, 0), true }, { new(-1, 1), true } });
    }

    protected override Coordinate[] GetCoords()
    {
        if (isAberrant)
        {
            switch (Globals.random.Next(0, 5))
            {
                case 0:
                    return new Coordinate[] { new(0, 0), new(-1, 0), new(-1, 1) };
                case 1:
                    return new Coordinate[] { new(0, -1), new(-1, 0), new(-1, 1) };
                case 2:
                    return new Coordinate[] { new(0, -1), new(0, 0), new(-1, 0), new(-1, 1), new(0, -2) };
                case 3:
                    return new Coordinate[] { new(0, -1), new(0, 0), new(-1, 0), new(-1, 1), new(0, 1) };
                case 4:
                    return new Coordinate[] { new(0, -1), new(0, 0), new(-1, 0), new(-1, 1), new(1, 0) };
                default:
                    return new Coordinate[] { new(0, -1), new(0, 0), new(-1, 0), new(-1, 1), new(-1, -1) };
            }
        }
        return new Coordinate[] { new(0, -1), new(0, 0), new(-1, 0), new(-1, 1) };
    }
}