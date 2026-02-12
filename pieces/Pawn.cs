using System.Diagnostics;

namespace chess.pieces;

public abstract class Take()
{
    
}

public abstract class PathChecker()
{
    
}

public class Pawn : Piece
{
    public Pawn(bool isWhite, int x, int y)
    {
        this.isWhite = isWhite;
        X = x;
        Y = y;
    }
    public int X { get; set; }
    public int Y { get; set; }
    
    private bool isWhite;
    public char GetSymbol()
    {
        return IsWhite() ? '♙' : '♟';
    }

    public bool CheckMove(int x, int y, Func<int, int, Piece?> getPiece)
    {
        //move forward 1
        if (X == x && isWhite ? Y - 1 == y  : Y  + 1 == y)
        {
            if (getPiece(x,y) == null)
            {
                return true;
            }
        }
        //move forward 2 when not moved yet
        if (isWhite ? Y == 6 : Y == 1)
        {
            
            if (X == x && isWhite ? Y - 2 == y  : Y  + 2 == y)
            {
                if (getPiece(x,y) == null && getPiece(x, isWhite ? y + 1 : y - 1) == null)
                {
                    return true;
                }
            }
        }
        
        //Kill Diag 1
        return false;
    }

    public bool IsWhite()
    {
        return isWhite;
    }
}