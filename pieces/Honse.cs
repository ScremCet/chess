namespace chess.pieces;

public class Honse : CommonPiece
{
    public Honse(bool isWhite, int x, int y) : base(isWhite, x, y){}
    
    private static readonly HashSet<(int,int)> honseMove = new()
    {
        (-1,+2), (+1,+2), (-1,-2), (+1,-2), (-2,+1), (+2,+1), (-2,-1), (+2,-1)
    };
    
    public override char GetSymbol()
    {
        return IsWhite() ? '♘' : '♞';
    }
    
    public override bool CheckMove(int x, int y, Func<int, int, Piece?> getPiece)
    {
        // move vector
        
        if (honseMove.Contains((x - X , y - Y)))
        {
            Piece? whatThere = getPiece(x, y);
            if (whatThere == null || !OnSameTeam(whatThere))
            {
                return true;
            }
        }
        return false;
    }
}