using Konigsberg.Euler;

namespace Konigsberg.Tests.Euler;

public sealed class Problem1Tests : EulerTests
{
    [Theory]
    [InlineData(10, 23)]
    [InlineData(1000, 233168)]
    public void Solve(int limit, int expectedSum)
    {
        var problem = new Problem1(limit);
        var solution = problem.Solve();
        Assert.Equal(expectedSum, solution);
    }
}