using System.Collections.Generic;

public class BlockGrid
{
    private Dictionary<Coordinate, bool> northCoords;

    public BlockGrid()
    {
        northCoords = new Dictionary<Coordinate, bool>();

        for (int i = -2; i < 3; i++)
        {
            for (int j = -2; j < 3; j++)
            {
                northCoords.Add(new Coordinate(i, j), false);
            }
        }
    }

    public void SetNorthCoords(Coordinate[] coords)
    {
        foreach(Coordinate coord in coords)
        {
            northCoords[coord] = true;
        }
    }

    public Dictionary<Coordinate, bool> NorthCoords() { return northCoords; }

    public Dictionary<Coordinate, bool> EastCoords()
    {
        Dictionary<Coordinate, bool>  eastCoords = new Dictionary<Coordinate, bool>();

        for (int i = -2; i < 3; i++)
        {
            for (int j = -2; j < 3; j++)
            {
                eastCoords.Add(new Coordinate(-j, i), northCoords[new(i, j)]);
            }
        }

        return eastCoords;
    }

    public Dictionary<Coordinate, bool> SouthCoords()
    {
        Dictionary<Coordinate, bool> southCoords = new Dictionary<Coordinate, bool>();

        for (int i = -2; i < 3; i++)
        {
            for (int j = -2; j < 3; j++)
            {
                southCoords.Add(new Coordinate(-i, -j), northCoords[new(i, j)]);
            }
        }

        return southCoords;
    }

    public Dictionary<Coordinate, bool> WestCoords()
    {
        Dictionary<Coordinate, bool> westCoords = new Dictionary<Coordinate, bool>();

        for (int i = -2; i < 3; i++)
        {
            for (int j = -2; j < 3; j++)
            {
                westCoords.Add(new Coordinate(j, -i), northCoords[new(i, j)]);
            }
        }

        return westCoords;
    }

}
