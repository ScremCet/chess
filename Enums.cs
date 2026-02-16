namespace chess;

public enum TurnStatus
{
    Success,
    ErrCheck,
    Check,
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