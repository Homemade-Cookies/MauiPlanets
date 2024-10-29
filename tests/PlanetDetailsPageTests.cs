using MauiPlanets.Views;
using MauiPlanets.Models;
using Microsoft.Maui.Controls;
using Xunit;

public class PlanetDetailsPageTests
{
    [Fact]
    public void BackButton_Clicked_NavigatesBack()
    {
        // Arrange
        var planet = new Planet { Name = "Earth" };
        var page = new PlanetDetailsPage(planet);
        var navigation = new NavigationPage(page);
        Application.Current = new App { MainPage = navigation };

        // Act
        page.BackButton_Clicked(null, null);

        // Assert
        Assert.Equal(0, navigation.Navigation.NavigationStack.Count);
    }

    [Fact]
    public void OnImageTapped_DisplaysZoomedImage()
    {
        // Arrange
        var planet = new Planet { Name = "Earth" };
        var page = new PlanetDetailsPage(planet);
        var image = new Image { Source = "earth.png" };
        var tapEventArgs = new EventArgs();

        // Act
        page.OnImageTapped(image, tapEventArgs);

        // Assert
        Assert.Equal(2, page.Navigation.NavigationStack.Count);
        var zoomPage = page.Navigation.NavigationStack.Last() as ContentPage;
        Assert.NotNull(zoomPage);
        Assert.IsType<Border>(zoomPage.Content);
    }
}
