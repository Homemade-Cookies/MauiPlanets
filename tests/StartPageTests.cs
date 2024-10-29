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

    [Fact]
    public void OnAppearing_StartsTransitionAnimation()
    {
        // Arrange
        var page = new StartPage();

        // Act
        page.OnAppearing();

        // Assert
        Assert.True(page.AnimationIsRunning("TransitionAnimation"));
    }

    [Fact]
    public void ParentAnimation_InitializesCorrectly()
    {
        // Arrange
        var page = new StartPage();

        // Act
        var animation = page.ParentAnimation;

        // Assert
        Assert.NotNull(animation);
        Assert.Equal(8, animation.Children.Count); // 8 planet animations
    }

    [Fact]
    public void ExploreNow_Clicked_DoesNotThrowException()
    {
        // Arrange
        var page = new StartPage();
        var navigation = new NavigationPage(page);
        Application.Current = new App { MainPage = navigation };

        // Act & Assert
        var exception = Record.ExceptionAsync(() => page.ExploreNow_Clicked(null, null));
        Assert.Null(exception.Result);
    }
}
