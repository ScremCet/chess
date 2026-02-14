namespace chess;

public enum TurnStatus
{
    Success,
    ErrCheck,
    ErrWillCheck,
    CheckMate,
    ErrNoPiece, 
    ErrInvalidColor, 
    ErrInvalidMove, 
    ErrInvalidSpecialMove
}

public enum Allegiance
{
    White,
    Black
}