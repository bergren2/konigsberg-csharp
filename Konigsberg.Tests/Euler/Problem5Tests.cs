using Konigsberg.Euler;

namespace Konigsberg.Tests.Euler;

public sealed class Problem5Tests : EulerTests
{
    [Theory]
    [InlineData(10, 2520)]
    [InlineData(20, 232792560)]
    public void Solve(int limit, int expected)
    {
        var problem = new Problem5(limit);
        var solution = problem.Solve();
        Assert.Equal(expected, solution);
    }
}