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
    private readonly Func<Promotion> _promotion;

    private void DefaultStart()
    {
        _kingWhite = new King(Allegiance.White, (4, 7), IsCheck);
        _kingBlack = new King(Allegiance.Black, (4, 0), IsCheck);       
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
   
    private void Castle()
    {
        _kingWhite = new King(Allegiance.White, (4, 7), IsCheck);
        _kingBlack = new King(Allegiance.Black, (4, 0), IsCheck);       
        _piecesBlack =
        [
            new Rook(Allegiance.Black, (0, 0)),
            new Honse(Allegiance.Black, (1, 0)),
            new Bishop(Allegiance.Black, (2, 0)),
            _kingBlack,       
            new Rook(Allegiance.Black, (7, 0)),
            //rest of pieces
        ];
        _piecesWhite =
        [
            new Rook(Allegiance.White, (0, 7)),
            new Queen(Allegiance.White, (3, 7)),
            _kingWhite,
            new Bishop(Allegiance.White, (0, 4)),
            new Rook(Allegiance.White, (7, 7)),
        ];
    }
    private void PawnPromotion()
    {
        _kingWhite = new King(Allegiance.White, (4, 7), IsCheck);
        _kingBlack = new King(Allegiance.Black, (4, 0), IsCheck);       
        _piecesBlack =
        [
            new Pawn(Allegiance.Black , (3 , 1)),
            new Pawn(Allegiance.Black , (4 , 1)),
            new Pawn(Allegiance.Black , (5 , 1)),
            _kingBlack,       
            //rest of pieces
        ];
        _piecesWhite =
        [
            new Pawn(Allegiance.White , (1 , 1)),
            _kingWhite,
        ];
    }
    private void StaleMate()
    {
        _kingWhite = new King(Allegiance.White, (4, 2), IsCheck);
        _kingBlack = new King(Allegiance.Black, (5, 0), IsCheck);       
        _piecesBlack =
        [
            _kingBlack,
        ];
        _piecesWhite =
        [
            _kingWhite,
            new Pawn(Allegiance.White , (5 , 1)),
        ];
    }
    private void EnPassant()
    {
        _kingWhite = new King(Allegiance.White, (4, 7), IsCheck);
        _kingBlack = new King(Allegiance.Black, (4, 0), IsCheck);       
        _piecesBlack =
        [
            _kingBlack,       
            new Pawn(Allegiance.Black, (3, 4) )
        ];
        
        _piecesWhite =
        [
            _kingWhite,
            new Pawn(Allegiance.White , (4 , 6) )
        ];
        
    }
    private void CheckorCheckMate()
    {
        _kingWhite = new King(Allegiance.White, (4, 7), IsCheck);
        _kingBlack = new King(Allegiance.Black, (4, 0), IsCheck);       
        _piecesBlack =
        [
            _kingBlack,       
            new Rook(Allegiance.Black, (4, 1)),
            new Pawn(Allegiance.Black , (5 , 1)),
            new Pawn(Allegiance.Black , (3 , 1)),
        ];
        
        _piecesWhite =
        [
            _kingWhite,
            new Queen(Allegiance.White, (6, 7)),
        ];
        
    }
    public GameLogic(Tests test, Func<Promotion> promotion)
    {
        _promotion = promotion;
        _deadPieces = new List<Piece>();
        _playerTurn = Allegiance.White;
        _board = new ChessBoard();
        switch (test)
        {
            case Tests.DefaultOrRestart:
                DefaultStart();
                break;
            case Tests.Castle:
                Castle();
                break;
            case Tests.EnPassant:
                EnPassant();
                break;
            case Tests.PawnPromotion:
                PawnPromotion();
                break;
            case Tests.CheckOrCheckMate:
                CheckorCheckMate();
                break;
            case Tests.StaleMate:
                StaleMate();
                break;
        }
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
    
    public Allegiance GetOtherAllegiance(Allegiance allegiance)
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
    
    public bool CanMove(Allegiance allegiance)
    {
        List<Piece>  firendlyPieces = GetPiecesOfAllegiance(allegiance);
        foreach (Piece piece in firendlyPieces)
        {
            foreach ((int, int) move in piece.ValidMoves(GetPiece))
            {
                TurnStatus status = MovePiece(piece.Pos , move,true);
                if (status == TurnStatus.Success)
                {
                    return true;
                }
            }
        }
        return false;
    }

    private void UndoMove((int, int) endPos, Piece? endPiece, Piece? startPiece, (int, int) startPos)
    {
        _board.Set(endPos, endPiece);
        if (endPiece != null)
        {
            List<Piece> enemyPieces = GetPiecesOfAllegiance(endPiece.GetAllegiance());
            _deadPieces.Remove(endPiece);
            enemyPieces.Add(endPiece);
        }
        startPiece?.UndoMove();
        _board.Set(startPos, startPiece);
    }
    private TurnStatus MovePiece((int, int) startPos, (int,int) endPos, bool alwaysUndo)
    {
         // Do move
        Piece? startPiece = GetPiece(startPos);
        _board.Set(startPos, null);
        startPiece?.Move(endPos);
        Piece? endPiece = GetPiece(endPos);
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

    private TurnStatus MakeMoves(List<((int, int), (int, int))> moves , bool alwaysUndo)
    {
        List < ((int, int), (int, int)) > movesMade = new();
        foreach (((int, int), (int, int)) move in moves)
        {
            TurnStatus mp = MovePiece(move.Item1, move.Item2, alwaysUndo);
            if (mp != TurnStatus.Success) 
            {
                foreach ( ((int, int), (int, int)) undoMove in movesMade)
                {
                    MovePiece(undoMove.Item2, undoMove.Item1, alwaysUndo);
                }
                return mp;
            }
            movesMade.Add(move);
        }

        if (alwaysUndo)
        {
            foreach ( ((int, int), (int, int)) undoMove in movesMade)
            {
                MovePiece(undoMove.Item2, undoMove.Item1, alwaysUndo);
            }
        }
        return TurnStatus.Success;
    }
    
    public (TurnStatus, List<((int, int), (int, int))>) submitTurn((int,int) start, (int,int) end)
    {
        Piece? selectedPiece = GetPiece(start);
        
        if (selectedPiece == null)
        {
            return (TurnStatus.ErrNoPiece, Coord.MovesNone());
        }
        if (selectedPiece.GetAllegiance() != _playerTurn)
        {
            return (TurnStatus.ErrInvalidAllegiance, Coord.MovesNone());
        }

        List<((int, int), (int, int))> moves = selectedPiece.ValidateMove(end, GetPiece);
        if (moves.Count == 0)
        {
            return (TurnStatus.ErrInvalidMove, Coord.MovesNone());
        }
        // Pawn Promotion
        Pawn? pawn = selectedPiece as Pawn;
        if (pawn != null)
        {
            if (end.Item2 == 0 || end.Item2 == 7)
            {
                Promotion promotion = _promotion();
                switch (promotion)
                {
                    case Promotion.None:
                        return (TurnStatus.ErrNoPromotionChoice, Coord.MovesNone());
                    case Promotion.Queen:
                        selectedPiece = new Queen(pawn.GetAllegiance(), pawn.Pos);
                        break;
                    case Promotion.Honse:
                        selectedPiece = new Honse(pawn.GetAllegiance(), pawn.Pos);
                        break;
                    case Promotion.Bishop:
                        selectedPiece = new Bishop(pawn.GetAllegiance(), pawn.Pos);
                        break;
                    case Promotion.Rook:
                        selectedPiece = new Rook(pawn.GetAllegiance(), pawn.Pos);
                        break;
                }
                _board.Set(selectedPiece.Pos, selectedPiece);
                List<Piece> pieces = GetPiecesOfAllegiance(selectedPiece.GetAllegiance());
                pieces.Remove(pawn);
                pieces.Add(selectedPiece);
            }
        }
        
        TurnStatus mp = MakeMoves(moves, false);
        if (mp != TurnStatus.Success) {
            return (mp, Coord.MovesNone());
        }
        
        //switch turn
        _playerTurn = GetOtherAllegiance(_playerTurn);
        if (IsCheck(GetPlayerTurn()))
        {
            if (!CanMove(GetPlayerTurn()))
            {
                return (TurnStatus.CheckMate, moves);
            }
            return (TurnStatus.Check, moves);
        }
        if (!CanMove(GetPlayerTurn()))
        {
            return (TurnStatus.StaleMate, moves);
        }
        return (mp, moves);
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