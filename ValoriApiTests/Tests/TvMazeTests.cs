using FluentAssertions;
using ValoriApiTests.Repositories;

namespace ValoriApiTests.Tests
{
    [TestClass]
    public class TvMazeTests
    {

        private TvMazeApi sut = new TvMazeApi();

        [TestMethod]
        public async Task IfShowIsSearchedWithId_ShouldReturnBodyWhichContainsUrlWithId()
        {
            // Arrange
            var showList = await sut.GetShowsByNameAsync("Breaking Bad");
            var firstShowId = showList?.FirstOrDefault()?.Show.Id;
            firstShowId?.Should().NotBe(null);

            // Act
            var result = await sut.GetShowInfoById(firstShowId.ToString());

            // Assert 
            result?.Url.Should().Contain(firstShowId.ToString());
        }
    }
}

