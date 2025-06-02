using FluentAssertions;
using System.Net;
using ValoriApiTests.Repositories;

namespace ValoriApiTests.Tests
{
    [TestClass]
    public sealed class WeatherApiTests
    {
        private OpenWeatherApi sut = new OpenWeatherApi();

        [TestMethod]
        public async Task IfAppIdIsNotProvided_ShouldReturn401AndEmptyBody()
        {
            // Act
            var result = await sut.GetWeatherByCityNameAsync("Utrecht", "");

            // Assert 
            result.Body.Should().NotContain("coord", "there is a content which contains the status code and error message, but should not contain the weather");
            result.StatusCode.Should().Be(HttpStatusCode.Unauthorized, "no app Id was provided");
        }

        [TestMethod]
        public async Task IfAppIdAndCityAreProvided_ShouldReturn200AndFilledBodyWithCorrectCityName()
        {
            // Act
            var result = await sut.GetWeatherByCityNameAsync("Utrecht", config.ApiKey);

            // Assert
            result.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Body.Should().Contain("Provincie Utrecht");
        }

        [TestMethod]
        public async Task IfCityNameIsProvidedThatDoesNotExist_ShouldReturn404WithMessageCityNotFound()
        {
            // Act
            var result = await sut.GetWeatherByCityNameAsync("Barchester", config.ApiKey);

            // Assert
            result.StatusCode.Should().Be(HttpStatusCode.NotFound);
            result.Body.Should().Contain("city not found");
        }

        [DataRow("Amsterdam", "2759794")]
        [DataRow("Rotterdam", "2747891")]
        [DataRow("Den Haag", "2747373")]
        [DataRow("Groningen", "2755249")]
        [DataTestMethod]
        public async Task ShouldReturnCorrectIdThatBelongsToCityName(string cityName, string id)
        {
            // Act
            var result = await sut.GetWeatherByCityNameAsync(cityName, config.ApiKey);

            // Assert
            result.Body.Should().Contain($"\"id\":{id}");
        }
    }
}
