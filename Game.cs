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
            new Piece(1, 0, '♞')
            //rest of pieces
        ];
        piecesWhite =
        [
            new Piece(0, 7, '♖'),
            new Piece(1, 7, '♘')
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