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
            Serilog.Log.Information("Window created successfully");
            return window;
        }
        catch (Exception ex)
        {
            // Log the exception using Serilog
            Serilog.Log.Error(ex, "Error creating window");
            throw;
        }
    }
}
