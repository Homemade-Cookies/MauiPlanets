namespace MauiPlanets;

public partial class App
{
    public App()
    {
        InitializeComponent();
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        try
        {
            var window = new Window(new AppShell());
            return window;
        }
        catch (Exception ex)
        {
            // Log the exception
            Console.WriteLine($"Error creating window: {ex.Message}");
            throw;
        }
    }
}
