﻿namespace MauiPlanets.Services;

internal static class PlanetsService
{
	private static  List<Planet> planets = new()
	{
		new()
		{
			Name = "Mercury",
			Subtitle = "The smallest planet",
			HeroImage = "mercury.png",
			Description = "Mercury is the first of the four terrestrial planets. This means it is a planet made mostly of rock. The planets closest to the Sun—Venus, Earth, and Mars—are the other three.\n\nMercury is the smallest of the terrestrial planets. It has an iron core that accounts for about 3/4 of its diameter. Most of the rest of the planet is made up of a rocky crust.",
			AccentColorStart = null,
			AccentColorEnd = null,
			Images = new()
            {
				"",
				"",
				""
            }
		},
        new()
        {
            Name = "Venus",
            Subtitle = "The pressure cooker",
            HeroImage = "venus.png",
            Description = "Of all the planets, Venus is the one most similar to Earth. In fact, Venus is often called Earth's “sister” planet. As similar as it is in some ways, however, it is also very different in others.\n\nEarth and Venus are similar in size. The two planets are very close to each other as they orbit the Sun; because of this, Venus is the most visible planet in the night sky. Both planets are relatively young, judging from the lack of craters on their surfaces.",
            AccentColorStart = null,
            AccentColorEnd = null,
            Images = new()
            {
                "",
                "",
                ""
            }
        },
        new()
        {
            Name = "Earth",
            Subtitle = "The cradle of life",
            HeroImage = "earth.png",
            Description = "The Earth is the only planet known where life exists. Almost 1.5 million species of animals and plants have been discovered so far, and many more have yet to be found. While other planets may have small amounts of ice or steam, the Earth is 2/3 water. Earth has perfect conditions for a breathable atmosphere.\n\nEarth is the largest of the terrestrial planets and the fifth largest in the solar system. It is believed to be about 4.5 billion years old, which makes it very young compared to other celestial bodies!",
            AccentColorStart = null,
            AccentColorEnd = null,
            Images = new()
            {
                "",
                "",
                ""
            }
        },
        new()
        {
            Name = "Mars",
            Subtitle = "The red beauty",
            HeroImage = "mars.png",
            Description = "No planet has sparked the imaginations of humans as much as Mars. It may be the reddish color of Mars, or the fact that it can often be easily seen in the night sky, that has caused people to wonder about this close neighbor of ours. Tales of “Martians” invading Earth have been around for well over fifty years. But is it likely that any kind of life really does exist on Mars?\n\nScientists aren't sure. Life as we know it couldn't survive there. Even so, there is evidence that there may be water on Mars. The presence of methane, which may be given off by organisms, provides another clue.",
            AccentColorStart = null,
            AccentColorEnd = null,
            Images = new()
            {
                "",
                "",
                ""
            }
        },
        new()
        {
            Name = "Jupiter",
            Subtitle = "The gas giant",
            HeroImage = "jupiter.png",
            Description = "The planet Jupiter is the first of the gas giant planets. Made mostly of gas, they include Jupiter, Saturn, Uranus, and Neptune.\n\nJupiter is first among the planets in terms of size and mass. Its diameter is 11 times bigger than Earth, and its mass is 2.5 times greater than all the other planets combined. The “Great Red Spot” on Jupiter is actually a raging storm.",
            AccentColorStart = null,
            AccentColorEnd = null,
            Images = new()
            {
                "https://solarsystem.nasa.gov/system/feature_items/images/11_Full_Jupiter-800.jpg",
                "https://solarsystem.nasa.gov/system/feature_items/images/10_Jupiter_Io_Juno-800.jpg",
                "https://solarsystem.nasa.gov/system/feature_items/images/13_PIA24237_Jupiter_Cyclones-800.jpg"
            }
        },
        new()
        {
            Name = "Saturn",
            Subtitle = "The ring planet",
            HeroImage = "saturn.png",
            Description = "Most people know about the rings around Saturn, because they are the brightest and most colorful. These rings are made mainly out of ice particles orbiting the planet. While the rings themselves seem big, the particles are very small, usually no more than 10 feet (3 meters) wide.\n\nSaturn is the second largest planet. It is the farthest planet from the Earth that can be seen without a telescope. It appears flat at the poles because its great rotational speed makes the middle of the planet bulge.",
            AccentColorStart = null,
            AccentColorEnd = null,
            Images = new()
            {
                "https://solarsystem.nasa.gov/system/feature_items/images/151_saturn_carousel_1.jpg",
                "https://solarsystem.nasa.gov/system/feature_items/images/152_saturn_carousel_2.jpg",
                "https://solarsystem.nasa.gov/system/feature_items/images/155_saturn_carousel_5.jpg",
                "https://solarsystem.nasa.gov/system/feature_items/images/153_saturn_carousel_3.jpg"
            }
        },
        new()
        {
            Name = "Uranus",
            Subtitle = "The cold ball",
            HeroImage = "uranus.png",
            Description = "Uranus is the first planet so far away from the Earth that it can only be seen with the use of a telescope. When it was first discovered in 1781, scientists didn't know what they had found. As astronomers studied the object more closely, they discovered that it had a circular orbit around the Sun. They had found the seventh planet.\n\nUranus is so far from the Sun that it takes 84 years to complete an orbit of the Sun. It is the only planet that spins on its side, so each pole is tilted away from the Sun for half its orbit. That means each night and day lasts an amazing 42 years. Imagine staying awake that long! Of course, you'd also get a lot of time to catch up on your sleep!",
            AccentColorStart = null,
            AccentColorEnd = null,
            Images = new()
            {
                "https://solarsystem.nasa.gov/system/feature_items/images/88_carousel_uranus.jpg",
                "https://solarsystem.nasa.gov/system/feature_items/images/89_uranus_carousel_1.jpg",
                "https://solarsystem.nasa.gov/system/feature_items/images/88_carousel_uranus.jpg"
            }
        },
        new()
        {
            Name = "Neptune",
            Subtitle = "Eighth & fathest-away",
            HeroImage = "neptune.png",
            Description = "Imagine being so good at math that you could figure out the location of a planet you had never even seen! That is what John C. Adams did in 1843 when he discovered Neptune.\n\nNeptune was named after the Roman god of the sea because it is so far out in the deep “sea” of space. The name also fits because Neptune appears to be a beautiful bright blue because of the methane clouds that surround it. It is the most distant planet from the Sun. It takes a very long time—165 years—to orbit the Sun. Neptune has made only one trip around the Sun since it was discovered.",
            AccentColorStart = null,
            AccentColorEnd = null,
            Images = new()
            {
                "",
                "",
                ""
            }
        }
    };

	public static List<Planet> GetAllPlanets()
		=> planets;

    public static Planet GetPlanet(string planetName)
		=> planets.Where(_planet => _planet.Name == planetName).FirstOrDefault();

    public static List<Planet> GetFeaturedPlanets()
    {
        var rnd = new Random();
        var randomizedPlanets = planets.OrderBy(item => rnd.Next());

		return randomizedPlanets.Take(2).ToList();
    }
        

}

