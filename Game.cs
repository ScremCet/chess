using System.Collections.Generic;

namespace Chess;

class GameLogic
{
    private List<Piece> piecesWhite;
    private List<Piece> piecesBlack;
    // dead []Piece

    private ChessBoard board;
    
    // hey piece what can you do
    // -> 
    public GameLogic()
    {
        board = new ChessBoard();
        piecesBlack =
        [
            new Piece(0, 0, '♜'),
            new Piece(1, 0, '♞'),
            new Piece(2, 0, '♝'),
            new Piece(3, 0, '♛'),
            new Piece(4, 0, '♚'),
            new Piece(5, 0, '♝'),
            new Piece(6, 0, '♞'),
            new Piece(7, 0, '♜'),
            new Piece(0, 1, '♟'),
            new Piece(1, 1, '♟'),
            new Piece(2, 1, '♟'),
            new Piece(3, 1, '♟'),
            new Piece(4, 1, '♟'),
            new Piece(5, 1, '♟'),
            new Piece(6, 1, '♟'),
            new Piece(7, 1, '♟'),
            //rest of pieces
        ];
        piecesWhite =
        [
            new Piece(0, 7, '♖'),
            new Piece(1, 7, '♘'),
            new Piece(2, 7, '♗'),
            new Piece(3, 7, '♕'),
            new Piece(4, 7, '♔'),
            new Piece(5, 7, '♗'),
            new Piece(6, 7, '♘'),
            new Piece(7, 7, '♖'),
            new Piece(0, 6, '♙'),
            new Piece(1, 6, '♙'),
            new Piece(2, 6, '♙'),
            new Piece(3, 6, '♙'),
            new Piece(4, 6, '♙'),
            new Piece(5, 6, '♙'),
            new Piece(6, 6, '♙'),
            new Piece(7, 6, '♙'),
            //rest of pieces
        ];
        board.Add(piecesWhite);
        board.Add(piecesBlack);
    }
}

class Piece
{
    private bool isDead;
    public int x, y;
    private char symbol;
    
    public Piece(int x, int y, char symbol)
    {
        isDead = false;
        
        this.x = x;
        this.y = y;
        this.symbol = symbol;
    }

    public char GetSymbol()
    {
        return this.symbol;
    }
}

class ChessBoard
{
    public List<List<Piece?>> gridOfPieces;

    public void Add(List<Piece> pieces)
    {
        foreach (Piece piece in pieces)
        {
            gridOfPieces[piece.y][piece.x] = piece;
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