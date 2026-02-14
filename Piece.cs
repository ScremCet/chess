namespace chess;

public interface Piece
{
    char GetSymbol();
    int X { get; set; }
    int Y { get; set; }
    bool OnSameTeam(Piece other);
    bool IsValidMove(int x, int y, Func<int, int, Piece?> getPiece);
    Allegiance GetAllegiance();
}