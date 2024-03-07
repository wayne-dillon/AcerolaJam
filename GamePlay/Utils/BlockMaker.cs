public class BlockMaker
{
    public static BasePiece RandomPiece(int NEXTPOS)
    {
        int num = Globals.random.Next(0, 7);
        switch (num)
        {
            case 0:
                return new LongPiece(NEXTPOS);
            case 1:
                return new LPiece(NEXTPOS);
            case 2:
                return new RPiece(NEXTPOS);
            case 3:
                return new SPiece(NEXTPOS);
            case 4:
                return new SquarePiece(NEXTPOS);
            case 5:
                return new TPiece(NEXTPOS);
            default:
                return new ZPiece(NEXTPOS);
        }
    }
}
