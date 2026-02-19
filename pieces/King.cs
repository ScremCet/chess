using Chess;

namespace chess.pieces;

public class King : CommonPiece
{
    public King(Allegiance allegiance, (int,int) pos, Func<Allegiance, bool> isCheck) : base(allegiance, pos)
    {
        _isCheck = isCheck;
    }
    private Func<Allegiance, bool>  _isCheck;
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
        (int,int) vect = Coord.Vector(Pos, dest);
        if (_kingMove.Contains(vect))
        {
            Piece? whatThere = getPiece(dest);
            if (whatThere is null || !OnSameTeam(whatThere))
            {
                return new(){(Pos,dest)};
            }
        }
        
        
        Piece? castle = getPiece(dest);
        if (castle != null)
        {
            Rook? rook = castle as Rook;
            if (
                rook != null 
                && OnSameTeam(rook) 
                && !_hasMoved
                && !rook.GetHasMoved()
                && !_isCheck(GetAllegiance())
                )
            {
                (int,int) dir = Coord.Step(vect);
                (int,int) rookDest = Coord.Add(Pos, (dir.Item1 == -1 ? -2 : 1 , 0));
                (int,int) kingDest = Coord.Add(dest , (dir.Item1 * -1 , 0));
                if (
                    getPiece(rookDest) == null
                    && getPiece(kingDest) == null
                    && getPiece(Coord.Add(rookDest, (1, 0) )) == null
                    )
                {
                    return new (){(Pos,kingDest),(rook.Pos,rookDest)};
                }
                
            }
        }
        
        
        return Coord.MovesNone();
    }
    
    

    protected override HashSet<(int, int)> GetPotentialMoves()
    {
        return _kingMove;
    }
}