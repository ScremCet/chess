using System.Collections.Generic;
using chess;
using chess.pieces;

namespace Chess;

class GameLogic
{
    private List<Piece> piecesWhite;
    private List<Piece> piecesBlack;
    // dead []Piece

    private ChessBoard board;
    private bool whiteTurn;

    // hey piece what can you do
    // -> 
    public GameLogic()
    {
        whiteTurn = true;
        
        board = new ChessBoard();
        piecesBlack =
        [
            new Temp(0, 0, '♜'),
            new Temp(1, 0, '♞'),
            new Temp(2, 0, '♝'),
            new Temp(3, 0, '♛'),
            new Temp(4, 0, '♚'),
            new Temp(5, 0, '♝'),
            new Temp(6, 0, '♞'),
            new Temp(7, 0, '♜'),
            //rest of pieces
        ];
        for (int x = 0; x < 8; x++)
        {
            piecesBlack.Add(new Pawn(false , x, 1 ));
        }
        
        piecesWhite =
        [
            new Temp(0, 7, '♖'),
            new Temp(1, 7, '♘'),
            new Temp(2, 7, '♗'),
            new Temp(3, 7, '♕'),
            new Temp(4, 7, '♔'),
            new Temp(5, 7, '♗'),
            new Temp(6, 7, '♘'),
            new Temp(7, 7, '♖'),
        ];
        for (int x = 0; x < 8; x++)
        {
            piecesWhite.Add(new Pawn(true , x , 6 ));
        }
        board.Add(piecesWhite);
        board.Add(piecesBlack);
    }

    public Piece? GetPiece(int x, int y)
    {
        return board.gridOfPieces[y][x];
    }

    public String GetPlayerTurn()
    {
        return whiteTurn ? "White" : "Black";
    }

    public void submitTurn(int sx, int sy, int ex, int ey)
    {
        //select Piece
        Piece? selectedPiece = board.gridOfPieces[sy][sx];
        if (selectedPiece == null)
        {
            return;
        }
        if (!selectedPiece.CheckMove(ex, ey, GetPiece))
        {
            return;
        };
        board.gridOfPieces[sy][sx] = null;
        //select move
        selectedPiece.X = ex; 
        selectedPiece.Y = ey;
        board.gridOfPieces[ey][ex] = selectedPiece;
        //validate move
        //Error or Move Piece
        
        whiteTurn = !whiteTurn;
    }
}

public class Temp : Piece
{
    private bool isDead;
    public int X { get; set; }
    public int Y { get; set; }
    
    public bool CheckMove(int x, int y, Func<int, int, Piece?> getPiece)
    {
        return false;
    }

    public bool IsWhite()
    {
        return true;
    }

    private char symbol;
    
    public Temp(int x, int y, char symbol)
    {
        isDead = false;
        
        this.X = x;
        this.Y = y;
        this.symbol = symbol;
    }

    public char GetSymbol()
    {
        return this.symbol;
    }
    
}

public class ChessBoard
{
    public List<List<Piece?>> gridOfPieces;

    public void Add(List<Piece> pieces)
    {
        foreach (Piece piece in pieces)
        {
            gridOfPieces[piece.Y][piece.X] = piece;
        };
    }

    public ChessBoard()
    {
        gridOfPieces = new List<List<Piece?>>(8);
        for (int y = 0; y < 8; y++)
        {
            var row = new List<Piece?>(8);
            for (int x = 0; x < 8; x++)
            {
                row.Add(null);
            } 
            gridOfPieces.Add(row);
        }
    }
}