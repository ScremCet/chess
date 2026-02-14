namespace chess.pieces;

public abstract class CommonPiece : Piece
{
    public CommonPiece(Allegiance allegiance, int x, int y)
    {
        this._allegiance = allegiance;
        X = x;
        Y = y;
    }
    private Allegiance _allegiance;

    public abstract char GetSymbol();
    public int X { get; set; }
    public int Y { get; set; }

    public bool OnSameTeam(Piece other)
    {
        return GetAllegiance() == other.GetAllegiance();
    }

    public abstract bool IsValidMove(int x, int y, Func<int, int, Piece?> getPiece);
    public Allegiance GetAllegiance()
    {
        return _allegiance;
    }
}