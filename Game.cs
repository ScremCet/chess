using System.Collections.Generic;
using System.Windows.Forms.VisualStyles;
using chess;
using chess.pieces;

namespace Chess;

class GameLogic
{
    private List<Piece> _piecesWhite;
    private List<Piece> _piecesBlack;
    // dead []Piece

    private ChessBoard _board;
    private Allegiance _playerTurn;
    private King _kingWhite;
    private King _kingBlack;
    // hey piece what can you do
    // -> 
    public GameLogic()
    {
        _playerTurn = Allegiance.White;
        _kingWhite = new King(Allegiance.White, 4, 7);
        _kingBlack = new King(Allegiance.Black, 4, 0);            
        _board = new ChessBoard();
        _piecesBlack =
        [
            new Temp(0, 0, '♜'),
            new Honse(Allegiance.Black, 1, 0),
            new Temp(2, 0, '♝'),
            new Temp(3, 0, '♛'),
            _kingBlack,       
            new Temp(5, 0, '♝'),
            new Honse(Allegiance.Black, 6, 0),
            new Temp(7, 0, '♜'),
            //rest of pieces
        ];
        for (int x = 0; x < 8; x++)
        {
            _piecesBlack.Add(new Pawn(Allegiance.Black , x, 1 ));
        }
        
        _piecesWhite =
        [
            new Temp(0, 7, '♖'),
            new Honse(Allegiance.White, 1, 7),
            new Temp(2, 7, '♗'),
            new Temp(3, 7, '♕'),
            _kingWhite,
            new Temp(5, 7, '♗'),
            new Honse(Allegiance.White, 6, 7),
            new Temp(7, 7, '♖'),
        ];
        for (int x = 0; x < 8; x++)
        {
            _piecesWhite.Add(new Pawn(Allegiance.White , x , 6 ));
        }
        _board.Add(_piecesWhite);
        _board.Add(_piecesBlack);
    }

    public Piece? GetPiece(int x, int y)
    {
        return _board.gridOfPieces[y][x];
    }

    public Allegiance GetPlayerTurn()
    {
        
        return _playerTurn;
    }

    private bool block;
    public bool IsCheckMate()
    {
        throw new NotImplementedException();
    }
    
    public bool IsCheck(Allegiance allegiance)
    {
        
        //get king
        King currentKing = allegiance == Allegiance.White ? _kingWhite : _kingBlack;
        List<Piece> evilPieces = currentKing.GetAllegiance() == Allegiance.White ? _piecesBlack : _piecesWhite;
        //check all possible attacks
        foreach (Piece piece in evilPieces)
        {
            if (piece.IsValidMove(currentKing.X, currentKing.Y, GetPiece))
            {
                return true;
            }
        }
        //check if correct piece type
        return false;
        //check if enemy does
    }

    private void MovePiece(Piece selectedPiece, int ex, int ey)
    {
        _board.gridOfPieces[selectedPiece.Y][selectedPiece.X] = null;
        selectedPiece.X = ex; 
        selectedPiece.Y = ey;
        _board.gridOfPieces[ey][ex] = selectedPiece;
    }
    
    public TurnStatus submitTurn(int sx, int sy, int ex, int ey)
    {
        Piece? selectedPiece = GetPiece(sx, sy);
        if (selectedPiece == null)
        {
            return TurnStatus.ErrNoPiece;
        }
        if (selectedPiece.GetAllegiance() != _playerTurn)
        {
            return TurnStatus.ErrInvalidColor;
        }
        // if (IsCheck())
        // {
        //     return TurnStatus.ErrCheck;
        // }
        if (!selectedPiece.IsValidMove(ex, ey, GetPiece))
        {
            return TurnStatus.ErrInvalidMove;
        };
        
        MovePiece(selectedPiece, ex, ey);
        //switch turn
        _playerTurn = _playerTurn == Allegiance.White ? Allegiance.Black : Allegiance.White;
        return TurnStatus.Success;
    }
}

public class Temp : CommonPiece
{
    private bool _isDead;
    
    public override bool IsValidMove(int x, int y, Func<int, int, Piece?> getPiece)
    {
        return false;
    }

    private char symbol;
    
    public Temp(int x, int y, char symbol) : base(Allegiance.White, x, y)
    {
        _isDead = false;
        this.symbol = symbol;
    }

    public override char GetSymbol()
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