namespace chess.pieces;

public abstract class CommonPiece : Piece
{
    public CommonPiece(Allegiance allegiance, (int,int) pos)
    {
        _allegiance = allegiance;
        Pos = pos;
        _hasMoved = false;
    }
    private readonly Allegiance _allegiance;

    public abstract char GetSymbol();

    protected bool _hasMoved;
    private ((int, int), bool) _lastState;
    public (int,int) Pos { get; private set; }

    public void Move((int, int) move)
    {
        _lastState = (Pos, _hasMoved);
        Pos = move;
        _hasMoved = true;
    }

    public void UndoMove()
    {
        (Pos, _hasMoved) = _lastState;
    }

    public bool OnSameTeam(Piece other)
    {
        return GetAllegiance() == other.GetAllegiance();
    }

    public abstract bool IsValidMove((int,int) dest, Func<(int,int), Piece?> getPiece);
    public Allegiance GetAllegiance()
    {
        return _allegiance;
    }
}