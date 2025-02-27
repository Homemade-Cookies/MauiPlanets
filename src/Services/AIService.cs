namespace MauiPlanets.Services
{
    public class AIService
    {
        private int _difficultyLevel;

        public AIService()
        {
            _difficultyLevel = 1; // Default difficulty level
        }

        public void SetDifficultyLevel(int level)
        {
            _difficultyLevel = level;
        }

        public (int Row, int Column) CalculateBestMove(ChessBoard board, string aiColor)
        {
            int bestValue = int.MinValue;
            (int Row, int Column) bestMove = (-1, -1);

            foreach (var piece in board.GetPieces(aiColor))
            {
                var validMoves = board.GetValidMoves(piece);
                foreach (var move in validMoves)
                {
                    var boardCopy = board.Clone();
                    boardCopy.MakeMove(piece, move);
                    int moveValue = Minimax(boardCopy, _difficultyLevel, false, int.MinValue, int.MaxValue);
                    if (moveValue > bestValue)
                    {
                        bestValue = moveValue;
                        bestMove = move;
                    }
                }
            }

            return bestMove;
        }

        private int Minimax(ChessBoard board, int depth, bool isMaximizingPlayer, int alpha, int beta)
        {
            if (depth == 0 || board.IsGameOver())
            {
                return EvaluateBoard(board);
            }

            if (isMaximizingPlayer)
            {
                int maxEval = int.MinValue;
                foreach (var piece in board.GetPieces("AI"))
                {
                    var validMoves = board.GetValidMoves(piece);
                    foreach (var move in validMoves)
                    {
                        var boardCopy = board.Clone();
                        boardCopy.MakeMove(piece, move);
                        int eval = Minimax(boardCopy, depth - 1, false, alpha, beta);
                        maxEval = Math.Max(maxEval, eval);
                        alpha = Math.Max(alpha, eval);
                        if (beta <= alpha)
                        {
                            break;
                        }
                    }
                }
                return maxEval;
            }
            else
            {
                int minEval = int.MaxValue;
                foreach (var piece in board.GetPieces("Human"))
                {
                    var validMoves = board.GetValidMoves(piece);
                    foreach (var move in validMoves)
                    {
                        var boardCopy = board.Clone();
                        boardCopy.MakeMove(piece, move);
                        int eval = Minimax(boardCopy, depth - 1, true, alpha, beta);
                        minEval = Math.Min(minEval, eval);
                        beta = Math.Min(beta, eval);
                        if (beta <= alpha)
                        {
                            break;
                        }
                    }
                }
                return minEval;
            }
        }

        private int EvaluateBoard(ChessBoard board)
        {
            int score = 0;

            foreach (var piece in board.GetPieces("AI"))
            {
                score += GetPieceValue(piece);
            }

            foreach (var piece in board.GetPieces("Human"))
            {
                score -= GetPieceValue(piece);
            }

            return score;
        }

        private int GetPieceValue(ChessPiece piece)
        {
            return piece.Type switch
            {
                "Pawn" => 1,
                "Knight" => 3,
                "Bishop" => 3,
                "Rook" => 5,
                "Queen" => 9,
                "King" => 1000,
                _ => 0
            };
        }
    }
}
