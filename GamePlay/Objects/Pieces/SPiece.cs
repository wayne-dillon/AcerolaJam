using System.Collections.Generic;
using Microsoft.Xna.Framework;

public class SPiece : BasePiece
{
    public SPiece() : base(Colors.sPiece)
    {
        blockGrid.SetNorthCoords(new Coordinate[] { new(0, -1), new(0, 0), new(1, 0), new(1, 1) });

        configurations.Add(Orientation.NORTH, new(blockGrid.NorthCoords(), 1, 0, 1));
        configurations.Add(Orientation.EAST, new(blockGrid.EastCoords(), 0, 1, 1));
        configurations.Add(Orientation.SOUTH, new(blockGrid.SouthCoords(), 1, 0, 1));
        configurations.Add(Orientation.WEST, new(blockGrid.WestCoords(), 0, 1, 1));

        MoveToUpNext();
    }
}