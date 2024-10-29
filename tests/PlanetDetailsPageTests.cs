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

    [Fact]
    public void PlanetDetailsPage_InitializesCorrectly()
    {
        // Arrange
        var planet = new Planet
        {
            Name = "Earth",
            Subtitle = "The cradle of life",
            HeroImage = "earth.png",
            Description = "The Earth is the only planet known where life exists."
        };

        // Act
        var page = new PlanetDetailsPage(planet);

        // Assert
        Assert.Equal(planet, page.BindingContext);
        Assert.Equal("Earth", ((Planet)page.BindingContext).Name);
        Assert.Equal("The cradle of life", ((Planet)page.BindingContext).Subtitle);
        Assert.Equal("earth.png", ((Planet)page.BindingContext).HeroImage);
        Assert.Equal("The Earth is the only planet known where life exists.", ((Planet)page.BindingContext).Description);
    }

    [Fact]
    public void BackButton_Clicked_NavigatesBack_WithoutException()
    {
        // Arrange
        var planet = new Planet { Name = "Earth" };
        var page = new PlanetDetailsPage(planet);
        var navigation = new NavigationPage(page);
        Application.Current = new App { MainPage = navigation };

        // Act & Assert
        var exception = Record.ExceptionAsync(() => page.BackButton_Clicked(null, null));
        Assert.Null(exception.Result);
    }

    [Fact]
    public void OnImageTapped_DisplaysZoomedImage_WithoutException()
    {
        // Arrange
        var planet = new Planet { Name = "Earth" };
        var page = new PlanetDetailsPage(planet);
        var image = new Image { Source = "earth.png" };
        var tapEventArgs = new EventArgs();

        // Act & Assert
        var exception = Record.ExceptionAsync(() => page.OnImageTapped(image, tapEventArgs));
        Assert.Null(exception.Result);
    }
}
