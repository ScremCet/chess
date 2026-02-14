namespace chess.pieces;

public class Honse : CommonPiece
{
    public Honse(Allegiance allegiance, int x, int y) : base(allegiance, x, y){}
    
    private static readonly HashSet<(int,int)> _honseMove = new()
    {
        (-1,+2), (+1,+2), (-1,-2), (+1,-2), (-2,+1), (+2,+1), (-2,-1), (+2,-1)
    };
    
    public override char GetSymbol()
    {
        return GetAllegiance() == Allegiance.White ? '♘' : '♞';
    }
    
    public override bool IsValidMove(int x, int y, Func<int, int, Piece?> getPiece)
    {
        // move vector
        
        if (_honseMove.Contains((x - X , y - Y)))
        {
            Piece? whatThere = getPiece(x, y);
            if (whatThere is null || !OnSameTeam(whatThere))
            {
                return true;
            }
        }
        return false;
    }
}