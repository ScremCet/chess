namespace chess.pieces;

public class Pawn : CommonPiece
{
    public Pawn(Allegiance allegiance, (int,int) pos) : base(allegiance, pos){}
    
    public override char GetSymbol()
    {
        return GetAllegiance() == Allegiance.White ? '♙' : '♟';
    }

    public override bool IsValidMove((int,int) dest, Func<(int,int), Piece?> getPiece)
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
                    return true;
                }
                break;
            case (0, 2):
                if (!_hasMoved
                    && getPiece(dest) == null
                    && getPiece(Coord.Add(Pos, Coord.Step(vect))) == null /*Check the position one Step ahead*/
                   )
                {
                    return true;
                }
                break;
            case (1, 1): 
            case (-1, 1):
                var destPiece = getPiece(dest);
                if (destPiece != null && !OnSameTeam(destPiece))
                {
                    return true;
                }
                break;
        }
        return false;
    }
}