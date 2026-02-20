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
    ErrNoPromotionChoice,
    StaleMate
}
public enum Allegiance
{
    White,
    Black
}

public enum Tests
{
    None,
    DefaultOrRestart,
    EnPassant,
    PawnPromotion,
    Castle,
    CheckOrCheckMate,
    StaleMate
}

public enum Promotion
{
    None,
    Queen,
    Bishop,
    Rook,
    Honse
}