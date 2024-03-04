using System.Collections.Generic;

public class GamePlay
{
    private List<Sprite> backdrops;

    private Grid grid;
    private BasePiece currentPiece;
    private BasePiece nextPiece;
    private TextComponent scoreDisplay;
    private TextComponent highScoreDisplay;
    private MyTimer fallTimer;

    public GamePlay()
    {
    }

    private void Init()
    {
        GameGlobals.gameInProgress = true;

        GameGlobals.grid = grid = new Grid();
        GameGlobals.score = 0;
        GameGlobals.fallTime = GameGlobals.baseFallTime;
        fallTimer = new(GameGlobals.fallTime);

        currentPiece = BlockMaker.RandomPiece();
        currentPiece.MoveToGrid();
        nextPiece = BlockMaker.RandomPiece();

        highScoreDisplay = new TextComponentBuilder().WithAbsolutePosition(new(100, 100)).WithTextAlignment(Alignment.CENTER_LEFT).Build();
        scoreDisplay = new TextComponentBuilder().WithAbsolutePosition(new(100, 150)).WithTextAlignment(Alignment.CENTER_LEFT).Build();

        backdrops = new();
        backdrops.Add(new SpriteBuilder().WithPath("rect").WithDims(new(384,576)).WithColor(Colors.Black).Build());
        backdrops.Add(new SpriteBuilder().WithPath("rect").WithDims(new(176,176)).WithColor(Colors.Black).WithAbsolutePosition(EnumHelper.ScreenPos(new(16, 3))).Build());
    }

    public void Update()
    {
        if (currentPiece.placed)
        {
            currentPiece = nextPiece;
            currentPiece.MoveToGrid();
            if (currentPiece.CheckForCollision(new(0,0)))
            {
                GameGlobals.gameInProgress = false;
            }

            nextPiece = BlockMaker.RandomPiece();
        }

        if (GameGlobals.gameInProgress && !GameGlobals.animating)
        {
            fallTimer.UpdateTimer();
            if (InputController.RotateCW()) currentPiece.RotateClockwise();
            if (InputController.RotateCCW()) currentPiece.RotateCounterClockwise();
            if (InputController.Left()) currentPiece.MoveLeft();
            if (InputController.Right()) currentPiece.MoveRight();
            if (InputController.Up())
            {
                bool moved = true;
                while (moved)
                {
                    moved = currentPiece.MoveDown();
                }
                fallTimer.Reset(GameGlobals.fallTime);
            }
            if (InputController.Down() || (GameGlobals.fallTime != 0 && fallTimer.Test()))
            {
                fallTimer.Reset(GameGlobals.fallTime);
                currentPiece.MoveDown();
            }
        }

        grid.Update();
        currentPiece.Update();
        nextPiece.Update();
        highScoreDisplay.Update("Hi-Score: " + GameGlobals.highScore);
        scoreDisplay.Update("Score: " + GameGlobals.score);

        foreach (var drop in backdrops)
        {
            drop.Update();
        }
    }

    public void Reset(object SENDER, object INFO)
    {
        Init();
    }

    public void Draw()
    {
        foreach (var drop in backdrops)
        {
            drop.Draw();
        }
        grid.Draw();
        currentPiece.Draw();
        nextPiece.Draw();
        highScoreDisplay.Draw();
        scoreDisplay.Draw();
    }
}