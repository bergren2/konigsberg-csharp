using Konigsberg.LeetCode;
using Xunit;

namespace Konigsberg.Tests.LeetCode;

public sealed class Problem1523Tests
{
    [Theory]
    [InlineData(3, 7, 3)]
    [InlineData(2, 7, 3)]
    [InlineData(3, 8, 3)]
    [InlineData(2, 8, 3)]
    [InlineData(8, 10, 1)]
    public void Solve(int low, int high, int expected)
    {
        var problem = new Problem1523();
        var solution = problem.CountOdds(low, high);
        Assert.Equal(expected, solution);
    }
}