using System.Collections.Generic;
using Microsoft.Xna.Framework;
public class BasePiece
{
    private Sprite sprite;
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
        configurations = new Dictionary<Orientation, Configuration>();
        currentOrientation = EnumHelper.RandomOrientation();
        sprite = new SpriteBuilder().WithPath("rect").WithColor(color).WithDims(new(32,32)).WithTransitionable(false).Build();
    }

    public void Update()
    {
        sprite.Update();
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
            if (coord.Value && GameGlobals.grid.IsUnavailable(newPos))
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
            if (coord.Value && GameGlobals.grid.IsUnavailable(newPos)) return false;
        }
        originPos += new Coordinate(-1, 0);
        return true;
    }

    public bool MoveRight()
    {
        foreach (var coord in CurrentConfiguration.coordinates)
        {
            Coordinate newPos = coord.Key + new Coordinate(1, 0) + originPos;
            if (coord.Value && GameGlobals.grid.IsUnavailable(newPos)) return false;
        }
        originPos += new Coordinate(1, 0);
        return true;
    }

    public void MoveToGrid()
    {
        originPos = new(5 + CurrentConfiguration.originLeft, 0 + CurrentConfiguration.originDepth);
    }

    protected void MoveToUpNext()
    {
        originPos = new(14 + CurrentConfiguration.originLeft, 1 + CurrentConfiguration.originDepth);
    }

    public void RotateClockwise()
    {
        currentOrientation = currentOrientation == Orientation.WEST ? Orientation.NORTH : currentOrientation + 1;
        if (originPos.Y == 0 && CurrentConfiguration.originDepth != 0) originPos += new Coordinate(0, CurrentConfiguration.originDepth);
    }

    public void RotateCounterClockwise()
    {
        currentOrientation = currentOrientation == Orientation.NORTH ? Orientation.WEST : currentOrientation - 1;
        if (originPos.Y == 0 && CurrentConfiguration.originDepth != 0) originPos += new Coordinate(0, CurrentConfiguration.originDepth);
    }

    public void Draw()
    {
        foreach(var coord in CurrentConfiguration.coordinates)
        {
            if (coord.Value)
            {
                sprite.Draw(EnumHelper.ScreenPos(coord.Key + originPos));
            }
        }
    }
}