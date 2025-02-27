using Microsoft.Maui.Controls;

namespace MauiPlanets.Views
{
    public partial class ChessGamePage : ContentPage
    {
        private ChessBoard _chessBoard;
        private ChessPiece _selectedPiece;

        public ChessGamePage()
        {
            InitializeComponent();
            InitializeChessBoard();
        }

        private void InitializeChessBoard()
        {
            _chessBoard = new ChessBoard();
            // Initialize the chess pieces on the board
        }

        private void OnPieceSelected(object sender, EventArgs e)
        {
            // Handle piece selection
            var piece = (ChessPiece)((Image)sender).BindingContext;
            _selectedPiece = piece;
        }

        private void OnPieceMoved(object sender, EventArgs e)
        {
            // Handle piece movement
            var newPosition = GetNewPosition((Image)sender);
            if (_chessBoard.ValidateMove(_selectedPiece, newPosition))
            {
                AnimatePieceMovement((View)sender, newPosition.Column * 100, newPosition.Row * 100);
                _selectedPiece.Position = newPosition;
            }
        }

        private (int Row, int Column) GetNewPosition(Image piece)
        {
            // Calculate the new position based on the piece's current position
            var x = piece.TranslationX;
            var y = piece.TranslationY;
            var row = (int)(y / 100);
            var column = (int)(x / 100);
            return (row, column);
        }

        private void AnimatePieceMovement(View piece, double x, double y)
        {
            piece.TranslateTo(x, y, 250, Easing.CubicInOut);
        }

        private void AnimatePieceCapture(View piece)
        {
            piece.FadeTo(0, 250, Easing.CubicInOut);
            piece.ScaleTo(0, 250, Easing.CubicInOut);
        }
    }
}
