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
        nextPiece = BlockMaker.RandomPiece();
    }

    public void Update()
    {
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