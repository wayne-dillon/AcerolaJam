using System.Collections.Generic;
using Microsoft.Xna.Framework;
public class BasePiece
{
    public bool placed = false;
    private Sprite sprite;
    public Color color;

    protected BlockGrid blockGrid;
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
        sprite = new SpriteBuilder().WithPath("Block").WithColor(color).WithDims(new(32,32)).WithTransitionable(false).Build();
        blockGrid = new BlockGrid();
    }

    public void Update()
    {
        sprite.Update();
    }

    private bool CheckForCollision(Coordinate offset)
    {
        foreach (var coord in CurrentConfiguration.coordinates)
        {
            Coordinate newPos = coord.Key + offset + originPos;
            if (coord.Value && GameGlobals.grid.Exists(newPos) && GameGlobals.grid.IsUnavailable(newPos)) return true;
        }
        return false;
    }

    private bool CheckOutOfBounds(Coordinate offset)
    {
        foreach (var coord in CurrentConfiguration.coordinates)
        {
            Coordinate newPos = coord.Key + offset + originPos;
            if (coord.Value && !GameGlobals.grid.Exists(newPos)) return true;
        }
        return false;
    }

    private void CheckTop()
    {
        int topPos = originPos.Y + CurrentConfiguration.TopRow();
        if (topPos < 0) originPos += new Coordinate(0, -CurrentConfiguration.TopRow());
    }

    private void CheckBottom()
    {
        int bottomPos = originPos.Y + CurrentConfiguration.BottomRow();
        if (bottomPos >= GameGlobals.gridSize.Y)
        {
            originPos += new Coordinate(0, -CurrentConfiguration.BottomRow());
            DropBlock();
        }
    }

    private void CheckLeft()
    {
        int leftPos = originPos.X + CurrentConfiguration.LeftColumn();
        if (leftPos < 0) originPos += new Coordinate(-CurrentConfiguration.LeftColumn(), 0);
    }

    private void CheckRight()
    {
        int rightPos = originPos.X + CurrentConfiguration.RightColumn();
        if (rightPos >= GameGlobals.gridSize.X) originPos += new Coordinate(-CurrentConfiguration.RightColumn(), 0);
    }

    public void DropBlock()
    {
        foreach (var coord in CurrentConfiguration.coordinates)
        {
            if (coord.Value)
            {
                Tile tile = GameGlobals.grid.GetTile(coord.Key + originPos);
                tile.IsOccupied = true;
                tile.SetColor(color);
                placed = true;
            }
        }
    }

    public bool MoveDown()
    {
        Coordinate offset = new Coordinate(0, 1);
        if (CheckOutOfBounds(offset) || CheckForCollision(offset))
        {
            DropBlock();
            return false;
        }
        originPos += offset;
        return true;
    }

    public bool MoveLeft()
    {
        Coordinate offset = new Coordinate(-1, 0);
        if (CheckOutOfBounds(offset) || CheckForCollision(offset)) return false;
        originPos += offset;
        return true;
    }

    public bool MoveRight()
    {
        Coordinate offset = new Coordinate(1, 0);
        if (CheckOutOfBounds(offset) || CheckForCollision(offset)) return false;
        originPos += offset;
        return true;
    }

    public void MoveToGrid()
    {
        originPos = new(5, -CurrentConfiguration.TopRow());
    }

    protected void MoveToUpNext()
    {
        originPos = new(14, 1);
    }

    public virtual void Mutate()
    {

    }

    public void RotateClockwise()
    {
        currentOrientation = currentOrientation == Orientation.WEST ? Orientation.NORTH : currentOrientation + 1;
        CheckTop();
        CheckBottom();
        CheckLeft();
        CheckRight();
    }

    public void RotateCounterClockwise()
    {
        currentOrientation = currentOrientation == Orientation.NORTH ? Orientation.WEST : currentOrientation - 1;
        CheckTop();
        CheckLeft();
        CheckRight();
        CheckBottom();
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