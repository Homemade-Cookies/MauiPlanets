using Microsoft.Maui.Controls.Shapes;

namespace MauiPlanets.Views;

public sealed partial class PlanetDetailsPage : ContentPage
{
    public PlanetDetailsPage(Planet planet)
    {
        InitializeComponent();

        this.BindingContext = planet;
    }

    async void BackButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private async void OnImageTapped(object sender, EventArgs e)
    {
        if (sender is Image image)
        {
            // Create a new page to display the zoomed image
            var zoomPage = new ContentPage
            {
                Content = new Border
                {
                    Content = new ScrollView
                    {
                        Content = new Image
                        {
                            Source = image.Source,
                            Aspect = Aspect.AspectFit,
                            GestureRecognizers =
                            {
                                new TapGestureRecognizer
                                {
                                    Command = new Command(async () =>
                                    {
                                        await Navigation.PopAsync();
                                    })
                                }
                            }
                        }
                    },
                    StrokeShape = new RoundRectangle
                    {
                        CornerRadius = new CornerRadius(10)
                    },
                    Shadow = new Shadow
                    {
                        Brush = Brush.Black,
                        Offset = new Point(10, 10),
                        Radius = 20,
                        Opacity = 0.5f
                    },
                    BackgroundColor = Colors.White,
                    Margin = new Thickness(20)
                }
            };

            // Navigate to the zoom page
            await Navigation.PushAsync(zoomPage);
        }
    }
}
