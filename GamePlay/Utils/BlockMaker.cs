public class BlockMaker
{
    public static BasePiece RandomPiece()
    {
        int num = Globals.random.Next(0, 7);
        switch (num)
        {
            case 0:
                return new LongPiece();
            case 1:
                return new LPiece();
            case 2:
                return new RPiece();
            case 3:
                return new SPiece();
            case 4:
                return new SquarePiece();
            case 5:
                return new TPiece();
            default:
                return new ZPiece();
        }
    }
}
