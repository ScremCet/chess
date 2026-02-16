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
    protected ((int, int), bool) _lastState;
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

    public abstract List<((int,int),(int,int))> ValidateMove((int,int) dest, Func<(int,int), Piece?> getPiece);
    public List<(int, int)> ValidMoves(Func<(int,int), Piece?> getPiece)
    {
        List<(int,int)> validMoves = new List<(int, int)>();
        HashSet<(int,int)> potentialMoves = GetPotentialMoves();
        foreach ((int, int) move in potentialMoves)
        {
            (int, int) dest = Coord.Add(Pos, move);
            if (0 > dest.Item1 || dest.Item1 > 7 || 0 > dest.Item2 || dest.Item2 > 7)
            {
                continue;
            }
            if (ValidateMove(dest, getPiece).Count > 0)
            {
                validMoves.Add(dest);
            }
        }
        return validMoves;
    }

    protected abstract HashSet<(int, int)> GetPotentialMoves();


    public Allegiance GetAllegiance()
    {
        return _allegiance;
    }
}