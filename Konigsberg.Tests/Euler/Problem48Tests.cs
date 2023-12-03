using Konigsberg.Euler;

namespace Konigsberg.Tests.Euler;

public sealed class Problem48Tests : EulerTests
{
    [Theory]
    [InlineData(10, "0405071317")]
    [InlineData(1000, "9110846700")]
    public void Solve(int limit, string expectedLastTenDigits)
    {
        var problem = new Problem48(limit);
        var solution = problem.Solve();
        Assert.Equal(expectedLastTenDigits, solution);
    }
}