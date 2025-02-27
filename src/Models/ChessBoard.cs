namespace MauiPlanets.Models
{
    public class ChessBoard
    {
        private readonly ChessPiece[][] _board;

        public ChessBoard()
        {
            _board = new ChessPiece[8][];
            for (int i = 0; i < 8; i++)
            {
                _board[i] = new ChessPiece[8];
            }
            InitializeBoard();
        }

        private void InitializeBoard()
        {
            // Initialize the board with pieces in their starting positions
            // Place pawns
            for (int i = 0; i < 8; i++)
            {
                _board[1][i] = new ChessPiece("Pawn", "White", (1, i));
                _board[6][i] = new ChessPiece("Pawn", "Black", (6, i));
            }

            // Place rooks
            _board[0][0] = new ChessPiece("Rook", "White", (0, 0));
            _board[0][7] = new ChessPiece("Rook", "White", (0, 7));
            _board[7][0] = new ChessPiece("Rook", "Black", (7, 0));
            _board[7][7] = new ChessPiece("Rook", "Black", (7, 7));

            // Place knights
            _board[0][1] = new ChessPiece("Knight", "White", (0, 1));
            _board[0][6] = new ChessPiece("Knight", "White", (0, 6));
            _board[7][1] = new ChessPiece("Knight", "Black", (7, 1));
            _board[7][6] = new ChessPiece("Knight", "Black", (7, 6));

            // Place bishops
            _board[0][2] = new ChessPiece("Bishop", "White", (0, 2));
            _board[0][5] = new ChessPiece("Bishop", "White", (0, 5));
            _board[7][2] = new ChessPiece("Bishop", "Black", (7, 2));
            _board[7][5] = new ChessPiece("Bishop", "Black", (7, 5));

            // Place queens
            _board[0][3] = new ChessPiece("Queen", "White", (0, 3));
            _board[7][3] = new ChessPiece("Queen", "Black", (7, 3));

            // Place kings
            _board[0][4] = new ChessPiece("King", "White", (0, 4));
            _board[7][4] = new ChessPiece("King", "Black", (7, 4));
        }

        private static int GetDirection(string color)
        {
            return color == "White" ? 1 : -1;
        }

        public bool ValidateMove(ChessPiece piece, (int Row, int Column) newPosition)
        {
            // Validate the move for the given piece
            if (piece == null)
            {
                return false;
            }

            int newRow = newPosition.Row;
            int newColumn = newPosition.Column;

            // Check if the new position is within the bounds of the board
            if (newRow < 0 || newRow >= 8 || newColumn < 0 || newColumn >= 8)
            {
                return false;
            }

            // Check if the new position is occupied by a piece of the same color
            ChessPiece targetPiece = _board[newRow][newColumn];
            if (targetPiece != null && targetPiece.Color == piece.Color)
            {
                return false;
            }

            // Additional validation logic for each type of piece
            switch (piece.Type)
            {
                case "Pawn":
                    // Pawns move forward one square, or two squares from their starting position
                    int direction = GetDirection(piece.Color);
                    if (newColumn == piece.Position.Column &&
                    (newRow == piece.Position.Row + direction ||
                    (piece.Position.Row == (piece.Color == "White" ? 1 : 6) && newRow == piece.Position.Row + 2 * direction)))
                    {
                        return true;
                    }
                    break;
                case "Rook":
                    // Rooks move horizontally or vertically any number of squares
                    if (newRow == piece.Position.Row || newColumn == piece.Position.Column)
                    {
                        return true;
                    }
                    break;
                case "Knight":
                    // Knights move in an L-shape: two squares in one direction and then one square perpendicular
                    if ((Math.Abs(newRow - piece.Position.Row) == 2 && Math.Abs(newColumn - piece.Position.Column) == 1) ||
                    (Math.Abs(newRow - piece.Position.Row) == 1 && Math.Abs(newColumn - piece.Position.Column) == 2))
                    {
                        return true;
                    }
                    break;
                case "Bishop":
                    // Bishops move diagonally any number of squares
                    if (Math.Abs(newRow - piece.Position.Row) == Math.Abs(newColumn - piece.Position.Column))
                    {
                        return true;
                    }
                    break;
                case "Queen":
                    // Queens move horizontally, vertically, or diagonally any number of squares
                    if (newRow == piece.Position.Row || newColumn == piece.Position.Column ||
                    Math.Abs(newRow - piece.Position.Row) == Math.Abs(newColumn - piece.Position.Column))
                    {
                        return true;
                    }
                    break;
                case "King":
                    // Kings move one square in any direction
                    if (Math.Abs(newRow - piece.Position.Row) <= 1 && Math.Abs(newColumn - piece.Position.Column) <= 1)
                        return true;
                    break;
                default:
                    throw new InvalidOperationException($"Unknown piece type: {piece.Type}");
            }

            return false;
        }

        public async Task<bool> ValidateMoveAsync(ChessPiece piece, (int Row, int Column) newPosition)
        {
            // Asynchronously validate the move for the given piece

            return await Task.Run(() => ValidateMove(piece, newPosition));
        }
    }
}
