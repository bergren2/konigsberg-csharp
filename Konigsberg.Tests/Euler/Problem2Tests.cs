using Konigsberg.Euler;

namespace Konigsberg.Tests.Euler;

public sealed class Problem2Tests : EulerTests
{
    [Theory]
    [InlineData(10, 10)]
    [InlineData(90, 44)]
    [InlineData(4_000_000, 4613732)]
    public void Solve(int limit, int expectedSum)
    {
        var problem = new Problem2(limit);
        var solution = problem.Solve();
        Assert.Equal(expectedSum, solution);
    }
}