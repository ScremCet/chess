namespace chess.pieces;

public class King : CommonPiece
{
    public King(Allegiance allegiance, int x, int y) : base(allegiance, x, y)
    {
        
    }
    
    private static readonly HashSet<(int,int)> _kingMove = new()
    {
        (-1,+1), (+1,+1), (-1,-1), (+1,-1), (0,+1), (0,-1), (-1,0), (+1,0)
    };

    public override char GetSymbol()
    {
        return GetAllegiance() == Allegiance.White ? '♔' : '♚';
    }
    public override bool IsValidMove(int x, int y, Func<int, int, Piece?> getPiece)
    {
        if (_kingMove.Contains((x - X, y - Y)))
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