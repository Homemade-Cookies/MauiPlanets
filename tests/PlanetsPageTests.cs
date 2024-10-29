using MauiPlanets.Views;
using MauiPlanets.Models;
using MauiPlanets.Services;
using Xunit;

public class PlanetsPageTests
{
    [Fact]
    public void Planets_SelectionChanged_NavigatesToPlanetDetailsPage()
    {
        // Arrange
        var page = new PlanetsPage();
        var planet = PlanetsService.GetPlanet("Earth");

        // Act
        page.Planets_SelectionChanged(page, new SelectionChangedEventArgs(null, new List<object> { planet }));

        // Assert
        Assert.Contains(page.Navigation.NavigationStack, p => p is PlanetDetailsPage);
    }

    [Fact]
    public void ProfilePic_Clicked_RevealsMenu()
    {
        // Arrange
        var page = new PlanetsPage();

        // Act
        page.ProfilePic_Clicked(page, EventArgs.Empty);

        // Assert
        Assert.Equal(-page.Width * 0.5, page.MainContentGrid.TranslationX);
        Assert.Equal(page.Height * 0.1, page.MainContentGrid.TranslationY);
        Assert.Equal(0.8, page.MainContentGrid.Scale);
        Assert.Equal(0.8, page.MainContentGrid.Opacity);
    }

    [Fact]
    public void GridArea_Tapped_ClosesMenu()
    {
        // Arrange
        var page = new PlanetsPage();
        page.ProfilePic_Clicked(page, EventArgs.Empty);

        // Act
        page.GridArea_Tapped(page, EventArgs.Empty);

        // Assert
        Assert.Equal(1, page.MainContentGrid.Opacity);
        Assert.Equal(1, page.MainContentGrid.Scale);
        Assert.Equal(0, page.MainContentGrid.TranslationX);
        Assert.Equal(0, page.MainContentGrid.TranslationY);
    }

    [Fact]
    public void PlanetsPage_InitializesCorrectly()
    {
        // Arrange & Act
        var page = new PlanetsPage();

        // Assert
        Assert.NotNull(page);
        Assert.NotNull(page.MainContentGrid);
        Assert.NotNull(page.lstPopularPlanets);
        Assert.NotNull(page.lstAllPlanets);
    }

    [Fact]
    public void OnNavigatedTo_SetsItemsSource()
    {
        // Arrange
        var page = new PlanetsPage();
        var args = new NavigatedToEventArgs();

        // Act
        page.OnNavigatedTo(args);

        // Assert
        Assert.NotNull(page.lstPopularPlanets.ItemsSource);
        Assert.NotNull(page.lstAllPlanets.ItemsSource);
    }

    [Fact]
    public void Planets_SelectionChanged_NavigatesToPlanetDetailsPage_WithoutException()
    {
        // Arrange
        var page = new PlanetsPage();
        var planet = PlanetsService.GetPlanet("Earth");

        // Act & Assert
        var exception = Record.ExceptionAsync(() => page.Planets_SelectionChanged(page, new SelectionChangedEventArgs(null, new List<object> { planet })));
        Assert.Null(exception.Result);
    }

    [Fact]
    public void ProfilePic_Clicked_RevealsMenu_WithoutException()
    {
        // Arrange
        var page = new PlanetsPage();

        // Act & Assert
        var exception = Record.ExceptionAsync(() => page.ProfilePic_Clicked(page, EventArgs.Empty));
        Assert.Null(exception.Result);
    }

    [Fact]
    public void GridArea_Tapped_ClosesMenu_WithoutException()
    {
        // Arrange
        var page = new PlanetsPage();
        page.ProfilePic_Clicked(page, EventArgs.Empty);

        // Act & Assert
        var exception = Record.ExceptionAsync(() => page.GridArea_Tapped(page, EventArgs.Empty));
        Assert.Null(exception.Result);
    }
}
