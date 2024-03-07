using System.Collections.Generic;
using Microsoft.Xna.Framework;

public class LongPiece : BasePiece
{
    public LongPiece(int NEXTPOS) : base(Colors.longPiece, NEXTPOS)
    {
    }

    protected override void SetBaseConf()
    {
        baseConf = new(new() { { new(-1, 0), true }, { new(0, 0), true }, { new(1, 0), true }, { new(2, 0), true } });
    }

    protected override Coordinate[] GetCoords()
    {
        if (isAberrant)
        {
            switch (Globals.random.Next(0, 7))
            {
                case 0:
                    return new Coordinate[] { new(-1, 0), new(0, 0), new(1, 0) };
                case 1: 
                    return new Coordinate[] { new(-1, 0), new(0, 0), new(2, 0) };
                case 2: 
                    return new Coordinate[] { new(-1, 0), new(0, 0), new(1, 0), new(2, 0), new(-2, 0) };
                case 3: 
                    return new Coordinate[] { new(-1, 0), new(0, 0), new(1, 0), new(2, 0), new(-1, 1) };
                case 4:
                    return new Coordinate[] { new(-1, 0), new(0, 0), new(1, 0), new(2, 0), new(0, 1) };
                case 5:
                    return new Coordinate[] { new(-1, 0), new(0, 0), new(1, 0), new(2, 0), new(1, 1) };
                default:
                    return new Coordinate[] { new(-1, 0), new(0, 0), new(1, 0), new(2, 0), new(2, 1) };
            }
        }
        return new Coordinate[] { new(-1, 0), new(0, 0), new(1, 0), new(2, 0) };
    }
}