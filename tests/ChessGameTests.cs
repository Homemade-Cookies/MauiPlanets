using MauiPlanets.Models;
using MauiPlanets.Services;
using Xunit;

namespace MauiPlanets.Tests
{
    public class ChessGameTests
    {
        [Fact]
        public void ValidateMove_ValidMove_ReturnsTrue()
        {
            // Arrange
            var chessBoard = new ChessBoard();
            var piece = new ChessPiece("Pawn", "White", (1, 0));

            // Act
            var result = chessBoard.ValidateMove(piece, (2, 0));

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void ValidateMove_InvalidMove_ReturnsFalse()
        {
            // Arrange
            var chessBoard = new ChessBoard();
            var piece = new ChessPiece("Pawn", "White", (1, 0));

            // Act
            var result = chessBoard.ValidateMove(piece, (3, 0));

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void CalculateBestMove_ReturnsValidMove()
        {
            // Arrange
            var chessBoard = new ChessBoard();
            var aiService = new AIService();
            aiService.SetDifficultyLevel(1);

            // Act
            var bestMove = aiService.CalculateBestMove(chessBoard, "Black");

            // Assert
            Assert.NotEqual((-1, -1), bestMove);
        }

        [Fact]
        public void SaveGameState_LoadGameState_RestoresGameState()
        {
            // Arrange
            var chessGameService = new ChessGameService();
            var piece = new ChessPiece("Pawn", "White", (1, 0));
            chessGameService.MakeMove(piece, (2, 0));
            var filePath = "test_game_state.json";

            // Act
            chessGameService.SaveGameState(filePath);
            chessGameService.LoadGameState(filePath);

            // Assert
            var restoredPiece = chessGameService.GetPieceAt((2, 0));
            Assert.NotNull(restoredPiece);
            Assert.Equal("Pawn", restoredPiece.Type);
            Assert.Equal("White", restoredPiece.Color);
            Assert.Equal((2, 0), restoredPiece.Position);
        }

        [Fact]
        public async Task ValidateMoveAsync_ValidMove_ReturnsTrue()
        {
            // Arrange
            var chessBoard = new ChessBoard();
            var piece = new ChessPiece("Pawn", "White", (1, 0));

            // Act
            var result = await chessBoard.ValidateMoveAsync(piece, (2, 0));

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task ValidateMoveAsync_InvalidMove_ReturnsFalse()
        {
            // Arrange
            var chessBoard = new ChessBoard();
            var piece = new ChessPiece("Pawn", "White", (1, 0));

            // Act
            var result = await chessBoard.ValidateMoveAsync(piece, (3, 0));

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void UndoMove_RestoresPreviousState()
        {
            // Arrange
            var chessGameService = new ChessGameService();
            var piece = new ChessPiece("Pawn", "White", (1, 0));
            chessGameService.MakeMove(piece, (2, 0));

            // Act
            chessGameService.UndoMove();

            // Assert
            var restoredPiece = chessGameService.GetPieceAt((1, 0));
            Assert.NotNull(restoredPiece);
            Assert.Equal("Pawn", restoredPiece.Type);
            Assert.Equal("White", restoredPiece.Color);
            Assert.Equal((1, 0), restoredPiece.Position);
        }

        [Fact]
        public void RedoMove_RestoresNextState()
        {
            // Arrange
            var chessGameService = new ChessGameService();
            var piece = new ChessPiece("Pawn", "White", (1, 0));
            chessGameService.MakeMove(piece, (2, 0));
            chessGameService.UndoMove();

            // Act
            chessGameService.RedoMove();

            // Assert
            var restoredPiece = chessGameService.GetPieceAt((2, 0));
            Assert.NotNull(restoredPiece);
            Assert.Equal("Pawn", restoredPiece.Type);
            Assert.Equal("White", restoredPiece.Color);
            Assert.Equal((2, 0), restoredPiece.Position);
        }
    }
}
