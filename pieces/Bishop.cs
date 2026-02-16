namespace chess.pieces;

public class Bishop : BlockablePiece
{
    private readonly HashSet<(int,int)> _bishopMove = MoveSet();
    public static HashSet<(int,int)> MoveSet()
    {
        HashSet<(int, int)> bishopMove = new HashSet<(int, int)>();
        for (int i = -7; i < 8; i++)
        {
            bishopMove.Add((i,i));
        }
        for (int i = -7; i < 8; i++)
        {
            bishopMove.Add((i * -1 ,i));
        }
        return bishopMove;
    }
    public Bishop(Allegiance allegiance, (int,int) pos) : base(allegiance, pos){}

    public override char GetSymbol()
    {
        return GetAllegiance() == Allegiance.White ? '♗' : '♝';
    }

    //IsValidMove() Inherited from BlockablePiece

    protected override HashSet<(int, int)> GetPotentialMoves()
    {
        return _bishopMove;
    }
}