namespace chess.pieces;

public class Queen :BlockablePiece
{
    private readonly HashSet<(int,int)> _queenMove = MoveSet();

    public static HashSet<(int, int)> MoveSet()
    {
        var queenMove = new HashSet<(int, int)>();
        queenMove.UnionWith(Rook.MoveSet());
        queenMove.UnionWith(Bishop.MoveSet());
        return queenMove;
    }
    
    public Queen(Allegiance allegiance, (int,int) pos) : base(allegiance, pos){}

    public override char GetSymbol()
    {
        return GetAllegiance() == Allegiance.White ? '♕' : '♛';
    }

    //IsValidMove() Inherited from BlockablePiece

    protected override HashSet<(int, int)> GetPotentialMoves()
    {
        return _queenMove;
    }
}