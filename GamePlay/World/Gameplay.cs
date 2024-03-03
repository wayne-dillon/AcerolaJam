public class GamePlay
{
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
        GameGlobals.fallTime = 1000;
        GameGlobals.aberrationPerc = 50;
        fallTimer = new(GameGlobals.fallTime);

        currentPiece = BlockMaker.RandomPiece();
        currentPiece.MoveToGrid();
        nextPiece = BlockMaker.RandomPiece();

        highScoreDisplay = new TextComponentBuilder().WithAbsolutePosition(new(100, 100)).WithTextAlignment(Alignment.CENTER_LEFT).Build();
        scoreDisplay = new TextComponentBuilder().WithAbsolutePosition(new(100, 150)).WithTextAlignment(Alignment.CENTER_LEFT).Build();
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
                fallTimer.ResetToZero();
            }
            if (InputController.Down() || fallTimer.Test())
            {
                fallTimer.ResetToZero();
                currentPiece.MoveDown();
            }
        }

        grid.Update();
        currentPiece.Update();
        nextPiece.Update();
        highScoreDisplay.Update("Hi-Score: " + GameGlobals.highScore);
        scoreDisplay.Update("Score: " + GameGlobals.score);
    }

    public void Reset(object SENDER, object INFO)
    {
        Init();
    }

    public void Draw()
    {
        grid.Draw();
        currentPiece.Draw();
        nextPiece.Draw();
        highScoreDisplay.Draw();
        scoreDisplay.Draw();
    }
}