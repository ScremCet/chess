namespace chess;

public enum TurnStatus
{
    Success,
    ErrCheck,
    ErrWillCheck,
    CheckMate,
    ErrNoPiece, 
    ErrInvalidAllegiance, 
    ErrInvalidMove, 
    ErrInvalidSpecialMove
}

public enum Allegiance
{
    White,
    Black
}