using Konigsberg.Euler;

namespace Konigsberg.Tests.Euler;

public sealed class Problem4Tests : EulerTests
{
    [Theory]
    [InlineData(1, 9)]
    [InlineData(2, 9009)]
    [InlineData(3, 906609)]
    public void Solve(int numberOfDigits, int expectedLargest)
    {
        var problem = new Problem4(numberOfDigits);
        var solution = problem.Solve();
        Assert.Equal(expectedLargest, solution);
    }
}