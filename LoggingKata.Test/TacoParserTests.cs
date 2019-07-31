using System;
using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Fact]
        public void ShouldDoSomething()
        {
            // TODO: Complete Something, if anything
        }

        [Theory]
        [InlineData("31.236691, -85.459825, Taco Bell Dothan","Taco Bell Dothan", 31.236691, -85.459825)]
        [InlineData("31.440529,-86.953648,Taco Bell Evergreen", "Taco Bell Evergreen", 31.440529, -86.953648)]

        public void ShouldParse(string str, string name, double latitude, double longitude)
        {
            // TODO: Complete Should Parse
            //Arrange
            TacoParser findTaco = new TacoParser();
            Point tacoLocation = new Point(latitude, longitude);

            //Act
            ITrackable actual = findTaco.Parse(str);

            //Assert
            Assert.Equal(name, actual.Name);
            Assert.Equal(tacoLocation.Latitude, actual.Location.Latitude);
            Assert.Equal(tacoLocation.Longitude, actual.Location.Longitude);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void ShouldFailParse(string str)
        {
            // TODO: Complete Should Fail Parse
            //Arrange
            TacoParser findTaco = new TacoParser();

            //Act
            ITrackable actual = findTaco.Parse(str);

            //Assert
            Assert.Null(actual);
        }
    }
}
