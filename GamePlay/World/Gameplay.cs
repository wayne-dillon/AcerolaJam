public class GamePlay
{
    private Grid grid;
    private BasePiece currentPiece;
    private BasePiece nextPiece;

    public GamePlay()
    {
    }

    private void Init()
    {
        GameGlobals.gameInProgress = true;

        grid = new Grid();
        currentPiece = BlockMaker.RandomPiece();
        currentPiece.MoveToGrid();
        nextPiece = BlockMaker.RandomPiece();
    }

    public void Update()
    {
        if (InputController.RotateCW()) currentPiece.RotateClockwise();
        if (InputController.RotateCCW()) currentPiece.RotateCounterClockwise();
        if (InputController.Left()) currentPiece.MoveLeft();
        if (InputController.Right()) currentPiece.MoveRight();
        if (InputController.Down()) currentPiece.MoveDown();

        grid.Update();
        currentPiece.Update();
        nextPiece.Update();
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
    }
}