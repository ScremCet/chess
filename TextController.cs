using System;
using System.Collections.Generic;

namespace Chess;

class TextController
{
    public static void PrintSquare(bool isThisWhite, char symbol)
    {
        if (isThisWhite)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
        }
        else
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
        Console.Write(symbol);
        Console.ResetColor();
        
    }
    static void PrintBoard(ChessBoard board)
    {
        bool isWhite = true;

        // Rows  
        foreach (List<Piece?> pieces in board.gridOfPieces)
        {
            foreach (Piece? piece in pieces)
            {
                PrintSquare(isWhite,piece == null ? ' ' : piece.GetSymbol());
                isWhite = !isWhite;
            }
            Console.WriteLine();
            isWhite = !isWhite;
        }
    }
}