using Konigsberg.Advent;
using Xunit;

namespace Konigsberg.Tests.Advent
{
    public sealed class Year2021Day1Tests
    {
        [Theory]
        [InlineData("Year2021Day1_1.txt", 7)]
        [InlineData("Year2021Day1_2.txt", 1548)]
        public void SolvePart1(string filename, int expectedResult)
        {
            // Arrange
            var problem = new Year2021Day1(filename);

            // Act
            var result = problem.SolvePart1();

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData("Year2021Day1_1.txt", 5)]
        [InlineData("Year2021Day1_2.txt", 1589)]
        public void SolvePart2(string filename, int expectedResult)
        {
            // Arrange
            var problem = new Year2021Day1(filename);

            // Act
            var result = problem.SolvePart2();

            // Assert
            Assert.Equal(expectedResult, result);
        }
    }
}