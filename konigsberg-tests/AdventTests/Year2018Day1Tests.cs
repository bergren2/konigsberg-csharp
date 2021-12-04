using Xunit;
using Konigsberg.Advent;

namespace KonigsbergTests.AdventTests
{
    public class Year2018Day1Test
    {
        [Fact]
        public void SolvePart1()
        {
            // Arrange
            var problem = new Year2018Day1Part1();

            // Act
            int solution = problem.Solve();

            // Assert
            Assert.Equal(1, solution);
        }
    }
}
