using Chess;

namespace chess;

public partial class Form1 : Form
{
    private const int SquareSize = 75;
    private const int StartX = 340;
    private const int StartY = 40;
    private GameLogic gameLogic;
    public Form1()
    {
        MaximizeBox = false;
        MaximumSize = new Size(1280, 720);
        MinimumSize = new Size(1280, 720);
        StartPosition = FormStartPosition.CenterScreen;
        InitializeComponent();
        gameLogic = new GameLogic();
        chess_Board(gameLogic.GetBoard());
    }

    public void panel_Creator(bool isThisWhite, int y, int x)
    {
        Panel p = new System.Windows.Forms.Panel();
        
        if (isThisWhite)
        {
            p.BackColor = System.Drawing.Color.White;
        }
        else
        {
            p.BackColor = System.Drawing.Color.Black;
        }
        
        p.Location = new System.Drawing.Point(StartX + (x * SquareSize), StartY + (y * SquareSize));
        p.MaximumSize = new System.Drawing.Size(SquareSize, SquareSize);
        p.MinimumSize = new System.Drawing.Size(SquareSize, SquareSize);
        p.Size = new System.Drawing.Size(SquareSize, SquareSize);
        
        Controls.Add(p);
    }
    
    public void chess_Board(ChessBoard board)
    {
        SuspendLayout();
        bool isWhite = true;

        // Rows  
        for (int y = 0; y < 8; y++)
        {
            for (int x = 0; x < 8; x++)
            {
                panel_Creator(isWhite, y, x);
                isWhite = !isWhite;
            }
            isWhite = !isWhite;
        }
        ResumeLayout(false);
    }
 
    private void button1_Click_1(object sender, EventArgs e)
    {
        gameLogic.submitTurn(0,0,0,0);
        label1.Text = gameLogic.GetPlayerTurn() + "'s turn";
    }
    
}