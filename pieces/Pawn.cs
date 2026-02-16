namespace chess.pieces;

public class Pawn : CommonPiece
{
    public Pawn(Allegiance allegiance, (int,int) pos) : base(allegiance, pos){}
    
    public override char GetSymbol()
    {
        return GetAllegiance() == Allegiance.White ? '♙' : '♟';
    }

    public override List<((int,int), (int,int))> ValidateMove((int,int) dest, Func<(int,int), Piece?> getPiece)
    {
        (int,int) vect = Coord.Vector(Pos, dest);
        (int, int) relVect = (vect.Item1, vect.Item2);
        if (GetAllegiance() == Allegiance.White)
        {
            relVect.Item2 *= -1;
        }

        switch (relVect)
        {
            case (0, 1):
                if (getPiece(dest) == null)
                {
                    return new(){(Pos,dest)};
                }
                break;
            case (0, 2):
                if (!_hasMoved
                    && getPiece(dest) == null
                    && getPiece(Coord.Add(Pos, Coord.Step(vect) )) == null /*Check the position one Step ahead*/
                   )
                {
                    return new(){(Pos,dest)};
                }
                break;
            case (1, 1): 
            case (-1, 1):
                Piece? destPiece = getPiece(dest);
                if (destPiece == null)
                {
                    Piece? enPassant = getPiece(Coord.Add(Pos, (vect.Item1 , 0) ));
                    if (enPassant != null)
                    {
                        Pawn? pawn = enPassant as Pawn;
                        
                        if (pawn != null && !OnSameTeam(pawn) && pawn.DoubleJumped())
                        {
                            return new(){(dest,pawn.Pos) , (Pos,dest)};
                        }
                    }
                    return Coord.MovesNone();
                }
                if (!OnSameTeam(destPiece))
                {
                    return new(){(Pos,dest)};
                }
                break;
        }
        return Coord.MovesNone();
    }

    private bool DoubleJumped()
    {
        (int, int) vector = Coord.Vector(_lastState.Item1, Pos);
        return vector == (0, 2) || vector == (0, -2);
    }

    //Checkmate PawnLogic Missing
    protected override HashSet<(int, int)> GetPotentialMoves()
    {
        return GetAllegiance() == Allegiance.White
            ? new()
            {
                (0,-1),
                (-1,-1),
                (1,-1),
                (0,-2),
            }
            : new()
            {
                (0,1),
                (-1,1),
                (1,1),
                (0,2),
            };

    }
}