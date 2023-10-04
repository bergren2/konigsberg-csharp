using Konigsberg.Euler;

namespace Konigsberg.Tests.Euler;

public sealed class Problem6Tests : EulerTests
{
    [Theory]
    [InlineData(10, 2640)]
    [InlineData(100, 25164150)]
    public void Solve(int limit, int expectedDifference)
    {
        var problem = new Problem6(limit);
        var solution = problem.Solve();
        Assert.Equal(expectedDifference, solution);
    }
}