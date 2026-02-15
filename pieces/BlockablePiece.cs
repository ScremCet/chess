namespace chess.pieces;

public abstract class BlockablePiece : CommonPiece
{
    protected BlockablePiece(Allegiance allegiance, (int,int) pos) : base(allegiance, pos){}
    
    public override bool IsValidMove((int, int) dest, Func<(int, int), Piece?> getPiece)
    {
        (int, int) moveVector = Coord.Vector(Pos, dest);
        if (GetValidMoves().Contains(moveVector))
        {
            Piece? whatThere = getPiece(dest);
            if (whatThere is null || !OnSameTeam(whatThere))
            {
                (int, int) step = Coord.Step(moveVector);
                
                for ((int,int) c =  Coord.Add(Pos,step); c != dest ; c = Coord.Add(c,step))
                {
                    if (getPiece(c) != null)
                    {
                        return false;
                    }
                }
                return true;
            }
        }
        return false;
    }

    protected abstract HashSet<(int,int)> GetValidMoves();
}