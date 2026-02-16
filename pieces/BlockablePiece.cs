namespace chess.pieces;

public abstract class BlockablePiece : CommonPiece
{
    protected BlockablePiece(Allegiance allegiance, (int,int) pos) : base(allegiance, pos){}
    
    public override List<((int,int),(int,int))> ValidateMove((int, int) dest, Func<(int, int), Piece?> getPiece)
    {
        (int, int) moveVector = Coord.Vector(Pos, dest);
        if (GetPotentialMoves().Contains(moveVector))
        {
            Piece? whatThere = getPiece(dest);
            if (whatThere is null || !OnSameTeam(whatThere))
            {
                (int, int) step = Coord.Step(moveVector);
                
                for ((int,int) c =  Coord.Add(Pos,step); c != dest ; c = Coord.Add(c,step))
                {
                    if (getPiece(c) != null)
                    {
                        return Coord.MovesNone();
                    }
                }
                return new(){(Pos,dest)};
            }
        }
        return Coord.MovesNone();
    }
}