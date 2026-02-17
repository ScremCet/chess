using System.Diagnostics;

namespace chess.pieces;

public class Rook : BlockablePiece
{
    private readonly HashSet<(int,int)> _rookMove = MoveSet();
    public static HashSet<(int,int)> MoveSet()
    {
        HashSet<(int, int)> rookMove = new HashSet<(int, int)>();
        for (int x = -7; x < 8; x++)
        {
            rookMove.Add((x,0));
        }
        for (int y = -7; y < 8; y++)
        {
            rookMove.Add((0,y));
        }
        return rookMove;
    }
    public Rook(Allegiance allegiance, (int,int) pos) : base(allegiance, pos){}
    
    public override char GetSymbol()
    {
        return GetAllegiance() == Allegiance.White ? '♖' : '♜';
    }

    //IsValidMove() Inherited from BlockablePiece

    protected override HashSet<(int, int)> GetPotentialMoves()
    {
        return _rookMove;
    }

    // public bool GetHasMoved()
    // {
    //     return _hasMoved;
    // }
}

