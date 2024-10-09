namespace MauiPlanets.Models;

public sealed record Planet
{
    public string Name { get; set; } = string.Empty;
    public string Subtitle { get; set; } = string.Empty;
    public string HeroImage { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public Color AccentColorStart { get; set; } = Colors.LightGray;
    public Color AccentColorEnd { get; set; } = Colors.DarkGray;
    public List<UriImageSource> Images { get; init; } = [];

    // Background
    private Brush? _background;
    public Brush Background => _background ??= CreateBackground();
    private LinearGradientBrush CreateBackground()
    {
        var gradientStops = new GradientStopCollection
            {
                new GradientStop(AccentColorStart, 0.0f),
                new GradientStop(AccentColorEnd, 1.0f)
            };

        var bgBrush = new LinearGradientBrush(
            gradientStops,
            new Point(0.0, 0.0),
            new Point(1.0, 1.0));

        return bgBrush;
    }
}
