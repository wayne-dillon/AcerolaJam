using System.Collections.Generic;
using Microsoft.Xna.Framework;
public class BasePiece
{
    public Color color;
    protected Dictionary<Orientation, Configuration> configurations;
    private Orientation currentOrientation;
    public Orientation CurrentOrientation {  get { return currentOrientation; } }
    public Configuration CurrentConfiguration { get { return configurations[currentOrientation]; } }
    private Coordinate originPos;
    public Coordinate OriginPos {  get { return originPos; } }

    public BasePiece(Color COLOR)
    {
        color = COLOR;
        currentOrientation = EnumHelper.RandomOrientation();
    }

    public void Update()
    {

    }

    /*
     * Attempt to move the piece down a square
     * if possible return true
     * else set the letter and return false
     */
    public void DropBlock()
    {
        foreach (var coord in CurrentConfiguration.coordinates)
        {
            Tile tile = GameGlobals.grid.GetTile(coord.Key + originPos);
            tile.IsOccupied = true;
            tile.SetColor(color);
        }
    }

    public bool MoveDown()
    {
        foreach (var coord in CurrentConfiguration.coordinates)
        {
            Coordinate newPos = coord.Key + new Coordinate(0, 1) + originPos;
            if (coord.Value && !GameGlobals.grid.IsUnoccupied(newPos))
            {
                DropBlock();
                return false;
            }
        }
        originPos += new Coordinate(0, 1);
        return true;
    }

    public bool MoveLeft()
    {
        foreach (var coord in CurrentConfiguration.coordinates)
        {
            Coordinate newPos = coord.Key + new Coordinate(-1, 0) + originPos;
            if (coord.Value && !GameGlobals.grid.IsUnoccupied(newPos)) return false;
        }
        originPos += new Coordinate(-1, 0);
        return true;
    }

    public bool MoveRight()
    {
        foreach (var coord in CurrentConfiguration.coordinates)
        {
            Coordinate newPos = coord.Key + new Coordinate(1, 0) + originPos;
            if (coord.Value && !GameGlobals.grid.IsUnoccupied(newPos)) return false;
        }
        originPos += new Coordinate(1, 0);
        return true;
    }

    public void Draw()
    {

    }
}