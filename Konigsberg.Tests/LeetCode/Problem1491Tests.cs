using Konigsberg.LeetCode;

namespace Konigsberg.Tests.LeetCode;

public sealed class Problem1491Tests : LeetCodeTests
{
    [Theory]
    [InlineData(new[] { 4000, 3000, 1000, 2000 }, 2500.00000)]
    [InlineData(new[] { 1000, 2000, 3000 }, 2000.00000)]
    [InlineData(new[] { 1000, 2000, 30000 }, 2000.00000)]
    public void Solve(int[] salary, int expected)
    {
        var problem = new Problem1491();
        var solution = problem.Average(salary);
        Assert.Equal(expected, solution);
    }
}