using System.Collections.Generic;
using System.Windows.Forms.VisualStyles;
using chess;
using chess.pieces;

namespace Chess;

class GameLogic
{
    private List<Piece> _piecesWhite;
    private List<Piece> _piecesBlack;
    private List<Piece> _deadPieces;
    
    private ChessBoard _board;
    private Allegiance _playerTurn;
    private King _kingWhite;
    private King _kingBlack;

    private void defaultStart()
    {
        _piecesBlack =
        [
            new Rook(Allegiance.Black, (0, 0)),
            new Honse(Allegiance.Black, (1, 0)),
            new Bishop(Allegiance.Black, (2, 0)),
            new Queen(Allegiance.Black, (3, 0)),
            _kingBlack,       
            new Bishop(Allegiance.Black, (5, 0)),
            new Honse(Allegiance.Black, (6, 0)),
            new Rook(Allegiance.Black, (7, 0)),
            //rest of pieces
        ];
        for (int x = 0; x < 8; x++)
        {
            _piecesBlack.Add(new Pawn(Allegiance.Black, (x, 1) ));
        }
        _piecesWhite =
        [
            new Rook(Allegiance.White, (0, 7)),
            new Honse(Allegiance.White, (1, 7)),
            new Bishop(Allegiance.White, (2, 7)),
            new Queen(Allegiance.White, (3, 7)),
            _kingWhite,
            new Bishop(Allegiance.White, (5, 7)),
            new Honse(Allegiance.White, (6, 7)),
            new Rook(Allegiance.White, (7, 7)),
        ];
        for (int x = 0; x < 8; x++)
        {
            _piecesWhite.Add(new Pawn(Allegiance.White , (x , 6) ));
        }
    }
   

    public GameLogic()
    {
        _deadPieces = new List<Piece>();
        _playerTurn = Allegiance.White;
        _kingWhite = new King(Allegiance.White, (4, 7));
        _kingBlack = new King(Allegiance.Black, (4, 0));            
        _board = new ChessBoard();
        defaultStart(); // we can test other scenarios by changing the start func
        _board.Add(_piecesWhite);
        _board.Add(_piecesBlack);
    }

    public Piece? GetPiece((int,int) target)
    {
        return _board.Get(target);
    }

    public Allegiance GetPlayerTurn()
    {
        
        return _playerTurn;
    }

    public List<Piece> GetPiecesOfAllegiance(Allegiance allegiance)
    {
        return allegiance == Allegiance.White ? _piecesWhite : _piecesBlack;
    }

    public King GetKingOfAllegiance(Allegiance allegiance)
    {
        return allegiance == Allegiance.White ? _kingWhite : _kingBlack;
    }
    
    Allegiance GetOtherAllegiance(Allegiance allegiance)
    {
        return allegiance == Allegiance.White ? Allegiance.Black :  Allegiance.White;
    }

    public bool IsCheck(Allegiance allegiance)
    {
        //get king
        King currentKing = GetKingOfAllegiance(allegiance);
        List<Piece> enemyPieces = GetPiecesOfAllegiance(GetOtherAllegiance(allegiance));
        //check all possible attacks
        foreach (Piece piece in enemyPieces)
        {
            if (piece.ValidateMove(currentKing.Pos, GetPiece).Count > 0)
            {
                return true;
            }
        }
        return false;
    }
    
    public bool IsCheckMate(Allegiance allegiance)
    {
        List<Piece>  firendlyPieces = GetPiecesOfAllegiance(allegiance);
        foreach (Piece piece in firendlyPieces)
        {
            foreach ((int, int) move in piece.ValidMoves(GetPiece))
            {
                TurnStatus status = MovePiece(piece, move,true);
                if (status == TurnStatus.Success)
                {
                    return false;
                }
            }
        }
        return true;
    }

    private void UndoMove((int, int) endPos, Piece? endPiece, Piece startPiece, (int, int) startPos)
    {
        _board.Set(endPos, endPiece);
        if (endPiece != null)
        {
            List<Piece> enemyPieces = GetPiecesOfAllegiance(endPiece.GetAllegiance());
            _deadPieces.Remove(endPiece);
            enemyPieces.Add(endPiece);
        }
        startPiece.UndoMove();
        _board.Set(startPos, startPiece);
    }
    private TurnStatus MovePiece(Piece startPiece, (int,int) endPos, bool alwaysUndo)
    {
         // Do move
        (int, int) startPos = startPiece.Pos;
        _board.Set(startPos, null);
        startPiece.Move(endPos);
        Piece ? endPiece = GetPiece(endPos);
        if (endPiece != null)
        {
            List<Piece> enemyPieces = GetPiecesOfAllegiance(endPiece.GetAllegiance());
            enemyPieces.Remove(endPiece);
            _deadPieces.Add(endPiece);
        }
        _board.Set(endPos, startPiece);
        
        // If this creates a king in check
        if (IsCheck(GetPlayerTurn()))
        {
            // roll back
            UndoMove(endPos, endPiece, startPiece, startPos);
            return TurnStatus.ErrCheck;
        }

        if (alwaysUndo)
        {
            UndoMove(endPos, endPiece, startPiece, startPos);
        }

        // else commit
        return TurnStatus.Success;
    }
    
    public TurnStatus submitTurn((int,int) start, (int,int) end)
    {
        Piece? selectedPiece = GetPiece(start);
        
        if (selectedPiece == null)
        {
            return TurnStatus.ErrNoPiece;
        }
        if (selectedPiece.GetAllegiance() != _playerTurn)
        {
            return TurnStatus.ErrInvalidAllegiance;
        }

        List<((int, int), (int, int))> moves = selectedPiece.ValidateMove(end, GetPiece);
        if (moves.Count == 0)
        {
            return TurnStatus.ErrInvalidMove;
        }
        TurnStatus mp = MovePiece(selectedPiece, end, false);
        if (mp != TurnStatus.Success) {
            return mp;
        }
        //switch turn
        _playerTurn = GetOtherAllegiance(_playerTurn);
        if (IsCheck(GetPlayerTurn()))
        {
            if (IsCheckMate(GetPlayerTurn()))
            {
                return TurnStatus.CheckMate;
            }
            return TurnStatus.Check;
        }
        return mp;
    }
}

public class ChessBoard
{
    private List<List<Piece?>> gridOfPieces;

    public void Set((int, int) pos, Piece? piece)
    {
        gridOfPieces[pos.Item2][pos.Item1] = piece;
    }

    public Piece? Get((int, int) pos)
    {
        return gridOfPieces[pos.Item2][pos.Item1];
    }
    public void Add(List<Piece> pieces)
    {
        foreach (Piece piece in pieces)
        {
            Set(piece.Pos , piece);
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