namespace MauiPlanets.Models
{
    public class ChessPiece
    {
        public string Type { get; set; }
        public string Color { get; set; }
        public (int Row, int Column) Position { get; set; }

        public ChessPiece(string type, string color, (int Row, int Column) position)
        {
            Type = type;
            Color = color;
            Position = position;
        }
    }
}
