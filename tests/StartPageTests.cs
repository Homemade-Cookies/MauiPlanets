using MauiPlanets.Views;
using MauiPlanets.Models;
using Xunit;

public class StartPageTests
{
    [Fact]
    public void ExploreNow_Clicked_NavigatesToPlanetsPage()
    {
        // Arrange
        var page = new StartPage();
        var navigation = new NavigationPage(page);
        Application.Current = new App { MainPage = navigation };

        // Act
        page.ExploreNow_Clicked(null, null);

        // Assert
        Assert.Contains(navigation.Navigation.NavigationStack, p => p is PlanetsPage);
    }
}
