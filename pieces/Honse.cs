namespace chess.pieces;

public class Honse : CommonPiece
{
    public Honse(Allegiance allegiance, (int,int) pos) : base(allegiance, pos){}
    
    private static readonly HashSet<(int,int)> _honseMove = new()
    {
        (-1,+2), (+1,+2), (-1,-2), (+1,-2), (-2,+1), (+2,+1), (-2,-1), (+2,-1)
    };
    
    public override char GetSymbol()
    {
        return GetAllegiance() == Allegiance.White ? '♘' : '♞';
    }
    
    public override bool IsValidMove((int,int) dest, Func<(int,int), Piece?> getPiece)
    {
        // move vector
        
        if (_honseMove.Contains(Coord.Vector(Pos,dest)))
        {
            Piece? whatThere = getPiece(dest);
            if (whatThere is null || !OnSameTeam(whatThere))
            {
                return true;
            }
        }
        return false;
    }
}