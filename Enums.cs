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
    ErrNoPromotionChoice
}
public enum Allegiance
{
    White,
    Black
}

public enum Tests
{
    Default,
    EnPassant,
    PawnPromotion,
    Castle,
    CheckOrCheckMate
}

public enum Promotion
{
    None,
    Queen,
    Bishop,
    Rook,
    Honse
}