namespace chess.pieces;

public class King : CommonPiece
{
    public King(Allegiance allegiance, (int,int) pos) : base(allegiance, pos)
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
    public override List<((int,int),(int,int))> ValidateMove((int,int) dest, Func<(int,int), Piece?> getPiece)
    {
        if (_kingMove.Contains(Coord.Vector(Pos, dest)))
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
        return _kingMove;
    }
}