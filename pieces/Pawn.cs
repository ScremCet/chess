namespace chess.pieces;

public class Pawn : CommonPiece
{
    public Pawn(Allegiance allegiance, int x, int y) : base(allegiance, x, y){}
    
    public override char GetSymbol()
    {
        return GetAllegiance() == Allegiance.White ? '♙' : '♟';
    }

    public override bool IsValidMove(int x, int y, Func<int, int, Piece?> getPiece)
    {
        //move forward 1
        if (X == x && (GetAllegiance() == Allegiance.White ? Y - 1 == y  : Y  + 1 == y))
        {
            if (getPiece(x,y) == null)
            {
                return true;
            }
        }
        //move forward 2 when not moved yet
        if (GetAllegiance() == Allegiance.White ? Y == 6 : Y == 1)
        {
            if (X == x && (GetAllegiance() == Allegiance.White ? Y - 2 == y  : Y  + 2 == y))
            {
                if (getPiece(x,y) == null && getPiece(x, GetAllegiance() == Allegiance.White ? y + 1 : y - 1) == null)
                {
                    return true;
                }
            }
        }
        
        //Kill Diag 1
        
        return false;
    }
}