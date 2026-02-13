namespace chess.pieces;

public abstract class CommonPiece : Piece
{
    public CommonPiece(bool isWhite, int x, int y)
    {
        this.isWhite = isWhite;
        X = x;
        Y = y;
        
    }
    private bool isWhite;

    public abstract char GetSymbol();
    public int X { get; set; }
    public int Y { get; set; }

    public bool OnSameTeam(Piece other)
    {
        return this.IsWhite() == other.IsWhite();
    }

    public abstract bool CheckMove(int x, int y, Func<int, int, Piece?> getPiece);

    public bool IsWhite()
    {
        return isWhite;
    }
}