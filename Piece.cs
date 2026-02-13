namespace chess;

public interface Piece
{
    char GetSymbol();
    public int X { get; set; }
    public int Y { get; set; }
    bool OnSameTeam(Piece other);
    bool CheckMove(int x, int y, Func<int, int, Piece?> getPiece);
    bool IsWhite();
    
}