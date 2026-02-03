using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace Chess;

class GameLogic
{
    // whiteAlive []Piece
    // blackAlive []Piece
    // dead []Piece

    private ChessBoard board;
    
    // hey piece what can you do
    // -> 
    public GameLogic()
    {
        board = new ChessBoard();
       
    }

    public void Print()
    {
        board.PrintBoard();
    }
}

class Piece
{
    private bool isDead;
    private int x, y;
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
    private List<List<Piece?>> piecelist;

    public void Add(List<Piece> pieces)
    {
        
    }

    public ChessBoard()
    {
        piecelist = new List<List<Piece?>>(8);
        for (int i = 0; i < 8; i++)
        {
            piecelist.Add(new List<Piece?>(8));
        }
    }
    
    public void PrintSquare(bool isThisWhite)
    {
        if (isThisWhite)
        {
            Console.BackgroundColor = ConsoleColor.White;
        }
        else
        {
            Console.BackgroundColor = ConsoleColor.Black;
        }
        Console.Write(' ');
        Console.ResetColor();
    }
    public void PrintBoard()
    {
        bool isWhite = true;

        // Rows  
        foreach (List<Piece?> pieces in piecelist)
        {
            Console.WriteLine("ROW");
            foreach (Piece? piece in pieces)
            {
                Console.WriteLine("PIECE");
                PrintSquare(isWhite);
                isWhite = !isWhite;
            }
            Console.WriteLine();
            isWhite = !isWhite;
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        GameLogic gl = new GameLogic();
        gl.Print();
    }
}