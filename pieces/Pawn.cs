namespace chess.pieces;

public class Pawn : CommonPiece
{
    public Pawn(bool isWhite, int x, int y) : base(isWhite, x, y){}
    
    public override char GetSymbol()
    {
        return IsWhite() ? '♙' : '♟';
    }

    public override bool CheckMove(int x, int y, Func<int, int, Piece?> getPiece)
    {
        //move forward 1
        if (X == x && (IsWhite() ? Y - 1 == y  : Y  + 1 == y))
        {
            if (getPiece(x,y) == null)
            {
                return true;
            }
        }
        //move forward 2 when not moved yet
        if (IsWhite() ? Y == 6 : Y == 1)
        {
            if (X == x && (IsWhite() ? Y - 2 == y  : Y  + 2 == y))
            {
                if (getPiece(x,y) == null && getPiece(x, IsWhite() ? y + 1 : y - 1) == null)
                {
                    return true;
                }
            }
        }
        
        //Kill Diag 1
        
        return false;
    }
}