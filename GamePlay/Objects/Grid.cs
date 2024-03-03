using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

public class Grid
{
    private readonly Dictionary<Coordinate, Tile> tiles;
    private List<int> filledRows;
    private MyTimer animationTimer;

    public Grid()
    {
        int x = GameGlobals.gridSize.X;
        int y = GameGlobals.gridSize.Y;
        tiles = new();
        filledRows = new();
        animationTimer = new(300);

        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                Coordinate coord = new(i, j);
                tiles.Add(coord, new Tile(coord, Colors.White));
            }
        }
    }

    public void Update()
    {
        foreach (Tile tile in tiles.Values)
        {
            tile.Update();
        }

        if (GameGlobals.animating)
        {
            animationTimer.UpdateTimer();
            if (animationTimer.Test())
            {
                foreach (int i in filledRows)
                {
                    RemoveRow(i);
                }
                filledRows.Clear();
                GameGlobals.animating = false;
            }
        }
        else
        {
            CheckForFilledRows();
        }
    }

    private void CheckForFilledRows()
    {
        filledRows.Clear();
        for (int i = 0; i < GameGlobals.gridSize.Y; i++)
        {
            bool filled = true;
            for (int j = 0; j < GameGlobals.gridSize.X; j++)
            {
                if (!tiles[new(j, i)].IsOccupied)
                {
                    filled = false; break;
                }
            }
            if (filled)
            {
                filledRows.Add(i);
                GameGlobals.completedRows += filledRows.Count;
                if (GameGlobals.fallTime != 0 && GameGlobals.increaseThreshold != 0 && GameGlobals.completedRows % GameGlobals.increaseThreshold == 0) 
                    GameGlobals.fallTime = (int)(GameGlobals.fallTime * 0.95f);
            }
        }

        if (filledRows.Count != 0)
        {
            GameGlobals.score += 100 * filledRows.Count * filledRows.Count;
            if (GameGlobals.score > GameGlobals.highScore) GameGlobals.highScore = GameGlobals.score;
            GameGlobals.animating = true;
            animationTimer.ResetToZero();
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

    public Tile GetTile(Coordinate COORDS)
    {
        if (!Exists(COORDS)) return null;
        return tiles[COORDS];
    }

    public List<Tile> GetAllTiles()
    {
        return tiles.Values.ToList();
    }

    public bool IsUnavailable(Coordinate COORD)
    {
        return !Exists(COORD) || tiles[COORD].IsOccupied;
    }

    public bool Exists(Coordinate COORD)
    {
        return tiles.ContainsKey(COORD);
    }

    public void RemoveRow(int ROWNUM)
    {
        for (int i = ROWNUM; i >= 0; i--)
        {
            for (int j = 0; j < GameGlobals.gridSize.X; j++)
            {
                tiles[new(j, i)].IsOccupied = i == 0 ? false : tiles[new(j, i-1)].IsOccupied;
                tiles[new(j, i)].SetColor(i == 0 ? Colors.White : tiles[new(j, i - 1)].GetColor());
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