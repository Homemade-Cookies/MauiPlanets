using MauiPlanets.Services;
using MauiPlanets.Models;
using Xunit;

public class PlanetsServiceTests
{
    [Fact]
    public void GetAllPlanets_ReturnsAllPlanets()
    {
        // Act
        var result = PlanetsService.GetAllPlanets();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(8, result.Count);
    }

    [Theory]
    [InlineData("Mercury")]
    [InlineData("Venus")]
    [InlineData("Earth")]
    [InlineData("Mars")]
    [InlineData("Jupiter")]
    [InlineData("Saturn")]
    [InlineData("Uranus")]
    [InlineData("Neptune")]
    public void GetPlanet_ReturnsCorrectPlanet(string planetName)
    {
        // Act
        var result = PlanetsService.GetPlanet(planetName);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(planetName, result.Name);
    }

    [Fact]
    public void GetFeaturedPlanets_ReturnsTwoPlanets()
    {
        // Act
        var result = PlanetsService.GetFeaturedPlanets();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count);
    }
}
