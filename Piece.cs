
namespace chess;
public interface Piece
{
    char GetSymbol();
    (int, int) Pos { get; }
    void Move((int, int) move);
    void UndoMove();
    //A single Valid Move can trigger multiple Pieces being moved
    List<((int,int),(int,int))> ValidateMove((int,int) dest, Func<(int,int), Piece?> getPiece);
    List<(int, int)> ValidMoves(Func<(int,int), Piece?> getPiece);
    Allegiance GetAllegiance();
}

