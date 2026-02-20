using Chess;
using chess.pieces;

namespace chess;

public partial class ChessForm : Form
{
    private const int _SquareSize = 75;
    private const int _SquareBorder = 15;
    private const int _StartX = 340;
    private const int _StartY = 40;
    private GameLogic _gameLogic;
    public ChessForm()
    {
        MaximizeBox = false;
        MaximumSize = new Size(1280, 720);
        MinimumSize = new Size(1280, 720);
        StartPosition = FormStartPosition.CenterScreen;
        InitializeComponent();
        _gameLogic = new GameLogic(Tests.DefaultOrRestart, Promote);
        create_Board();
    }

    public void create_Square(bool isThisWhite, (int, int) pos)
    {
        Panel square = new Panel();

        square.BackColor = isThisWhite ? Color.White : Color.Black;
        
        square.Location = new Point(_StartX + (pos.Item1 * _SquareSize), _StartY + (pos.Item2 * _SquareSize));
        square.MaximumSize = new Size(_SquareSize, _SquareSize);
        square.MinimumSize = new Size(_SquareSize, _SquareSize);
        square.Size = new Size(_SquareSize, _SquareSize);
        square.Name = "panel_" + pos.Item1 + "_" + pos.Item2;

        Label displayPiece = new Label();
        displayPiece.MinimumSize = new Size(_SquareSize-(_SquareBorder*2), _SquareSize-(_SquareBorder*2));
        displayPiece.MaximumSize = new Size(_SquareSize-(_SquareBorder*2), _SquareSize-(_SquareBorder*2));
        displayPiece.Location = new Point(_SquareBorder, _SquareBorder);
        displayPiece.Name = "label_piece";
        displayPiece.Font = new Font("Comic Sans", 30);
        displayPiece.TextAlign = ContentAlignment.TopCenter;
        displayPiece.BackColor = Color.White;
        Piece? currentPiece = _gameLogic.GetPiece(pos);
        displayPiece.Text = currentPiece == null ? " " : currentPiece.GetSymbol().ToString();
        square.Controls.Add(displayPiece);
        
        Controls.Add(square);
    }
    
    public void update_Square((int,int)pos)
    {
        // find the panel at x and y
        
        Panel? p = Controls[Controls.IndexOfKey("panel_" + pos.Item1 + "_" + pos.Item2)] as Panel;

        // find the label
        Label? displayPiece = p.Controls[p.Controls.IndexOfKey("label_piece")] as Label;
        
        // get the piece
        Piece? currentPiece = _gameLogic.GetPiece(pos);

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
                create_Square(isWhite, (x, y));
                isWhite = !isWhite;
            }
            isWhite = !isWhite;
        }
        ResumeLayout(false);
    }

    public void update_Board()
    {
        // Rows
        for (int y = 0; y < 8; y++)
        {
            for (int x = 0; x < 8; x++)
            {
                update_Square((x, y));
            }
        }
    }
    
    public void update_StatOut(TurnStatus status)
    {
        StatOut.Text = status.ToString();
    }
    private void submit_Click_1(object sender, EventArgs e)
    {
        if (SX.Text == "" || SY.Text == "" || EX.Text == "" || EY.Text == "")
        {
            StatOut.Text = "ErrMissingValues";
            return;
        }
        (int,int) start = (SX.Text[0] - 65, 7 - (SY.Text[0] - 49));
        (int, int) end = (EX.Text[0] - 65, 7 - (EY.Text[0] - 49));
        (TurnStatus, List<((int, int), (int, int))>) ts = _gameLogic.submitTurn(start,end);
        update_StatOut(ts.Item1);
        
        foreach (((int, int), (int, int)) move in ts.Item2)
        {
            update_Square(move.Item1);
            update_Square(move.Item2);
        }
        if (ts.Item1 == TurnStatus.CheckMate)
        {
            MessageBox.Show( "Checkmate! " + _gameLogic.GetOtherAllegiance(_gameLogic.GetPlayerTurn()) + " wins. To start new game select Default/Restart in Load Test");
        }
        if (ts.Item1 == TurnStatus.StaleMate)
        {
            MessageBox.Show( "Stalemate! To start new game select Default/Restart in Load Test");
        }
        label1.Text = _gameLogic.GetPlayerTurn() + "'s turn";
    }

    private Promotion Promote()
    {
        Promotion promotion = new Promotion();
        switch (PromotionChoice.Text)
        {
            case  "Queen":
                promotion = Promotion.Queen;
                break;
            case "Rook":
                promotion = Promotion.Rook;
                break;
            case "Bishop":
                promotion = Promotion.Bishop;
                break;
            case "Honse":
                promotion = Promotion.Honse;
                break;
        }
        return promotion;
    }
    private void LoadButton_Click(object sender, EventArgs e)
    {
        Tests test = Tests.DefaultOrRestart;
        switch (SelectedTest.Text)
        {
            case "":
                MessageBox.Show("Restart or test not selected");
                return;
            case "Default/Restart":
                test = Tests.DefaultOrRestart;
                break;
            case"En Passant":
                test = Tests.EnPassant;
                break;
            case "Pawn promotion":
                test = Tests.PawnPromotion;
                break;
            case "Castle":
                test = Tests.Castle;
                break;
            case "Check/Check Mate":
                test = Tests.CheckOrCheckMate;
                break;
            case "Stale Mate":
                test = Tests.StaleMate;
                break;
        }

        _gameLogic = new GameLogic(test,Promote);
        update_Board();
        label1.Text = _gameLogic.GetPlayerTurn() + "'s turn";
    }
}