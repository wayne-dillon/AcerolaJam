using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

public struct Grid
{
    private readonly Dictionary<Coordinate, Tile> tiles;

    public Grid()
    {
        int x = GameGlobals.gridSize.X;
        int y = GameGlobals.gridSize.Y;
        tiles = new();

        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                Coordinate coord = new(i, j);
                tiles.Add(coord, new Tile(coord, Color.Gray));
            }
        }
    }

    public void Update()
    {
        foreach (Tile tile in tiles.Values)
        {
            tile.Update();
        }
    }

    public void ColorRow(int ROWNUM, bool VALID)
    {
        Color color = VALID ? Color.Green : Color.Red;
        for (int i = 0; i < 5; i++)
        {
            tiles[new(i, ROWNUM)].SetColor(color);
        }
    }

    public readonly Tile GetTile(Coordinate COORDS)
    {
        return tiles[COORDS];
    }

    public readonly List<Tile> GetAllTiles()
    {
        return tiles.Values.ToList();
    }

    public readonly bool IsUnavailable(Coordinate COORD)
    {
        return !Exists(COORD) || tiles[COORD].IsOccupied;
    }

    public readonly bool Exists(Coordinate COORD)
    {
        return tiles.ContainsKey(COORD);
    }

    public void RemoveRow(int ROWNUM)
    {
        for (int i = ROWNUM; i >= 0; i--)
        {
            for (int j = 0; j < GameGlobals.gridSize.X; j++)
            {
                tiles[new(j, i)].SetColor(Color.Gray);
            }
        }
    }

    public void Draw()
    {
        foreach (Tile tile in tiles.Values)
        {
            tile.Draw();
        }
    }
}