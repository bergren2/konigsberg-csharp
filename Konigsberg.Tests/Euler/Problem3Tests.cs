using Konigsberg.Euler;

namespace Konigsberg.Tests.Euler;

public sealed class Problem3Tests : EulerTests
{
    [Theory]
    [InlineData(13195, 29)]
    [InlineData(600851475143, 6857)]
    public void Solve(long n, long expectedLargestPrimeFactor)
    {
        var problem = new Problem3(n);
        var solution = problem.Solve();
        Assert.Equal(expectedLargestPrimeFactor, solution);
    }
}