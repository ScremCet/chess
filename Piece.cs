namespace chess;

public interface Piece
{
    char GetSymbol();
    (int, int) Pos { get; }
    void Move((int, int) move);
    void UndoMove();
    bool IsValidMove((int,int) dest, Func<(int,int), Piece?> getPiece);
    Allegiance GetAllegiance();
}