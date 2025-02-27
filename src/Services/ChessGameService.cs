namespace MauiPlanets.Services
{
    public class ChessGameService
    {
        private Stack<ChessMove> _moveHistory;
        private Stack<ChessMove> _redoStack;
        private ChessBoard _chessBoard;

        public ChessGameService()
        {
            _moveHistory = new Stack<ChessMove>();
            _redoStack = new Stack<ChessMove>();
            _chessBoard = new ChessBoard();
        }

        public void SaveGameState(string filePath)
        {
            var gameState = new GameState
            {
                MoveHistory = _moveHistory.ToList(),
                RedoStack = _redoStack.ToList(),
                BoardState = _chessBoard
            };

            var json = JsonSerializer.Serialize(gameState);
            File.WriteAllText(filePath, json);
        }

        public void LoadGameState(string filePath)
        {
            var json = File.ReadAllText(filePath);
            var gameState = JsonSerializer.Deserialize<GameState>(json);

            if (gameState != null)
            {
                _moveHistory = new Stack<ChessMove>(gameState.MoveHistory);
                _redoStack = new Stack<ChessMove>(gameState.RedoStack);
                _chessBoard = gameState.BoardState;
            }
        }

        public void UndoMove()
        {
            if (_moveHistory.Count > 0)
            {
                var lastMove = _moveHistory.Pop();
                _redoStack.Push(lastMove);
                lastMove.Piece.Position = lastMove.OldPosition;
                // Implement additional undo move logic
            }
        }

        public void RedoMove()
        {
            if (_redoStack.Count > 0)
            {
                var move = _redoStack.Pop();
                _moveHistory.Push(move);
                move.Piece.Position = move.NewPosition;
                // Implement additional redo move logic
            }
        }

        public void MakeMove(ChessPiece piece, (int Row, int Column) newPosition)
        {
            if (_chessBoard.ValidateMove(piece, newPosition))
            {
                var move = new ChessMove(piece, piece.Position, newPosition);
                _moveHistory.Push(move);
                piece.Position = newPosition;
                _redoStack.Clear();
                // Implement additional move logic
                // Check for capturing a piece
                var targetPiece = _chessBoard.GetPieceAt(newPosition);
                if (targetPiece != null && targetPiece.Color != piece.Color)
                {
                    // Capture the piece
                    _chessBoard.RemovePiece(targetPiece);
                }

                // Check for special moves like castling, en passant, and pawn promotion
                if (piece.Type == "King" && Math.Abs(newPosition.Column - piece.Position.Column) == 2)
                {
                    // Castling
                    var rookColumn = newPosition.Column == 6 ? 7 : 0;
                    var rookNewColumn = newPosition.Column == 6 ? 5 : 3;
                    var rook = _chessBoard.GetPieceAt((piece.Position.Row, rookColumn));
                    if (rook != null)
                    {
                        rook.Position = (piece.Position.Row, rookNewColumn);
                    }
                }
                else if (piece.Type == "Pawn" && newPosition.Row == (piece.Color == "White" ? 7 : 0))
                {
                    // Pawn promotion
                    piece.Type = "Queen"; // Promote to queen for simplicity
                }
            }
        }

        public ChessPiece GetPieceAt((int Row, int Column) position)
        {
            return _chessBoard.GetPieceAt(position);
        }
    }

    public class ChessMove
    {
        public ChessPiece Piece { get; }
        public (int Row, int Column) OldPosition { get; }
        public (int Row, int Column) NewPosition { get; }

        public ChessMove(ChessPiece piece, (int Row, int Column) oldPosition, (int Row, int Column) newPosition)
        {
            Piece = piece;
            OldPosition = oldPosition;
            NewPosition = newPosition;
        }
    }

    public class GameState
    {
        public List<ChessMove> MoveHistory { get; set; }
        public List<ChessMove> RedoStack { get; set; }
        public ChessBoard BoardState { get; set; }
    }
}
