namespace chess;

public interface Piece
{
    char GetSymbol();
    public int X { get; set; }
    public int Y { get; set; }

    bool CheckMove(int x, int y, Func<int, int, Piece?> getPiece);
    bool IsWhite();
    
}