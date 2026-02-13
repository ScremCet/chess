using Chess;

namespace chess;

public partial class Form1 : Form
{
    private const int SquareSize = 75;
    private const int SquareBorder = 15;
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
        create_Board();
    }

    public void create_Square(bool isThisWhite, int x, int y)
    {
        Panel square = new Panel();

        square.BackColor = isThisWhite ? Color.White : Color.Black;
        
        square.Location = new Point(StartX + (x * SquareSize), StartY + (y * SquareSize));
        square.MaximumSize = new Size(SquareSize, SquareSize);
        square.MinimumSize = new Size(SquareSize, SquareSize);
        square.Size = new Size(SquareSize, SquareSize);
        square.Name = "panel_" + x + "_" + y;

        Label displayPiece = new Label();
        displayPiece.MinimumSize = new Size(SquareSize-(SquareBorder*2), SquareSize-(SquareBorder*2));
        displayPiece.MaximumSize = new Size(SquareSize-(SquareBorder*2), SquareSize-(SquareBorder*2));
        displayPiece.Location = new Point(SquareBorder, SquareBorder);
        displayPiece.Name = "label_piece";
        displayPiece.Font = new Font("Comic Sans", 30);
        displayPiece.TextAlign = ContentAlignment.TopCenter;
        displayPiece.BackColor = Color.White;
        Piece? currentPiece = gameLogic.GetPiece(x, y);
        displayPiece.Text = currentPiece == null ? " " : currentPiece.GetSymbol().ToString();
        square.Controls.Add(displayPiece);
        
        Controls.Add(square);
    }
    
    public void update_Square(int x, int y)
    {
        // find the panel at x and y
        
        Panel? p = Controls[Controls.IndexOfKey("panel_" + x + "_" + y)] as Panel;

        // find the label
        Label? displayPiece = p.Controls[p.Controls.IndexOfKey("label_piece")] as Label;
        
        // get the piece
        Piece? currentPiece = gameLogic.GetPiece(x, y);

        // update
        displayPiece.Text = currentPiece == null ? " " : currentPiece.GetSymbol().ToString();
    }
    
    public void create_Board()
    {
        SuspendLayout();
        bool isWhite = true;

        // Rows  
        for (int y = 0; y < 8; y++)
        {
            for (int x = 0; x < 8; x++)
            {
                create_Square(isWhite, x, y);
                isWhite = !isWhite;
            }
            isWhite = !isWhite;
        }
        ResumeLayout(false);
    }

    private void submit_Click_1(object sender, EventArgs e)
    {
        int sx = SX.Text[0] - 65;
        int sy = 7 - (SY.Text[0] - 49);
        int ex = EX.Text[0] - 65;
        int ey = 7 - (EY.Text[0] - 49);
        
        gameLogic.submitTurn(sx,sy,ex,ey);
        update_Square(sx,sy);
        update_Square(ex,ey);
        label1.Text = gameLogic.GetPlayerTurn() + "'s turn";
    }
}