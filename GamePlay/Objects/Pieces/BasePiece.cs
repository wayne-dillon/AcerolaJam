using System.Collections.Generic;
using Microsoft.Xna.Framework;
public class BasePiece
{
    public bool placed = false;
    private Sprite sprite;
    public Color color;
    protected bool isAberrant;

    protected BlockGrid blockGrid;
    protected Dictionary<Orientation, Configuration> configurations;
    private Orientation currentOrientation;
    public Orientation CurrentOrientation {  get { return currentOrientation; } }
    public Configuration CurrentConfiguration { get { return configurations[currentOrientation]; } }
    private Coordinate originPos;
    public Coordinate OriginPos {  get { return originPos; } }

    private Vector2 offset = Vector2.Zero;

    public BasePiece(Color COLOR)
    {
        color = COLOR;
        configurations = new Dictionary<Orientation, Configuration>();
        currentOrientation = EnumHelper.RandomOrientation();
        sprite = new SpriteBuilder().WithPath("Block").WithColor(color).WithDims(new(32,32)).WithTransitionable(false).Build();
        CheckAberration();
        if (isAberrant) sprite.effect = Effects.glitch;

        blockGrid = new BlockGrid();
        blockGrid.SetNorthCoords(GetCoords());
        configurations.Add(Orientation.NORTH, new(blockGrid.NorthCoords()));
        configurations.Add(Orientation.EAST, new(blockGrid.EastCoords()));
        configurations.Add(Orientation.SOUTH, new(blockGrid.SouthCoords()));
        configurations.Add(Orientation.WEST, new(blockGrid.WestCoords()));

        MoveToUpNext();
    }

    public void Update()
    {
        sprite.Update();
    }

    protected virtual Coordinate[] GetCoords() => new Coordinate[0];

    protected void CheckAberration()
    {
        if (Globals.random.Next(0, 100) < GameGlobals.aberrationPerc)
        {
            isAberrant = true;
        }
    }

    public bool CheckForCollision(Coordinate offset)
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

    private bool BlockedTop()
    {
        int topPos = originPos.Y + CurrentConfiguration.TopRow();
        if (topPos >= 0) return false;
        Coordinate offset = new(0, -CurrentConfiguration.TopRow());
        if (CheckForCollision(offset)) return true;
        originPos += offset;
        return false;
    }

    private bool BlockedLeft()
    {
        int leftPos = originPos.X + CurrentConfiguration.LeftColumn();
        if (leftPos >= 0) return false;
        Coordinate offset = new(-CurrentConfiguration.LeftColumn(), 0);
        if (CheckForCollision(offset)) return true;
        originPos += offset;
        return false;
    }

    private bool BlockedRight()
    {
        int rightPos = originPos.X + CurrentConfiguration.RightColumn();
        if (rightPos < GameGlobals.gridSize.X) return false;
        Coordinate offset = new(-CurrentConfiguration.RightColumn(), 0);
        if (CheckForCollision(offset)) return true;
        originPos += offset;
        return false;
    }

    private bool BlockedBottom()
    {
        int bottomPos = originPos.Y + CurrentConfiguration.BottomRow();
        if (bottomPos < GameGlobals.gridSize.Y) return false;
        Coordinate offset = new(0, -CurrentConfiguration.BottomRow());
        if (CheckForCollision(offset)) return true;
        originPos += offset;
        DropBlock();
        return false;
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
        if (CheckOutOfBounds(offset) || CheckForCollision(offset))
        {
            SFXPlayer.PlaySound(SoundEffects.INVALID);
            return false;
        }
        originPos += offset;
        return true;
    }

    public bool MoveRight()
    {
        Coordinate offset = new Coordinate(1, 0);
        if (CheckOutOfBounds(offset) || CheckForCollision(offset))
        {
            SFXPlayer.PlaySound(SoundEffects.INVALID);
            return false;
        }
        originPos += offset;
        return true;
    }

    public void MoveToGrid()
    {
        originPos = new(5, -CurrentConfiguration.TopRow());
        offset = Vector2.Zero;
    }

    protected void MoveToUpNext()
    {
        originPos = new(18, 5);
        int upDown = CurrentConfiguration.TopRow() + CurrentConfiguration.BottomRow();
        int leftRight = CurrentConfiguration.LeftColumn() + CurrentConfiguration.RightColumn();
        offset = new(-leftRight * 32 / 2, -upDown * 32 / 2);
    }

    public virtual void RotateClockwise()
    {
        Orientation prev = currentOrientation;
        currentOrientation = currentOrientation == Orientation.WEST ? Orientation.NORTH : currentOrientation + 1;
        if (CheckForCollision(new(0, 0)) || BlockedTop() || BlockedBottom() || BlockedLeft() || BlockedRight())
        {
            SFXPlayer.PlaySound(SoundEffects.INVALID);
            currentOrientation = prev;
        }
    }

    public virtual void RotateCounterClockwise()
    {
        Orientation prev = currentOrientation;
        currentOrientation = currentOrientation == Orientation.NORTH ? Orientation.WEST : currentOrientation - 1;
        if (CheckForCollision(new(0, 0)) || BlockedTop() || BlockedBottom() || BlockedLeft() || BlockedRight())
        {
            SFXPlayer.PlaySound(SoundEffects.INVALID);
            currentOrientation = prev;
        }
    }

    public void Draw()
    {
        foreach(var coord in CurrentConfiguration.coordinates)
        {
            if (coord.Value)
            {
                sprite.Draw(EnumHelper.ScreenPos(coord.Key + originPos) + offset);
            }
        }
    }
}