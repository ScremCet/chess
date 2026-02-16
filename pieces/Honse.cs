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
    
    public override List<((int,int),(int,int))> ValidateMove((int,int) dest, Func<(int,int), Piece?> getPiece)
    {
        // move vector
        
        if (_honseMove.Contains(Coord.Vector(Pos,dest)))
        {
            Piece? whatThere = getPiece(dest);
            if (whatThere is null || !OnSameTeam(whatThere))
            {
                return new(){(Pos,dest)};
            }
        }
        return Coord.MovesNone();
    }

    protected override HashSet<(int, int)> GetPotentialMoves()
    {
        return _honseMove;
    }
}