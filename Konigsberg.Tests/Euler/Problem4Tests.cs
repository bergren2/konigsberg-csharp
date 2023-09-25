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

    [Theory]
    [InlineData(1, true)]
    [InlineData(11, true)]
    [InlineData(12, false)]
    [InlineData(121, true)]
    [InlineData(1221, true)]
    [InlineData(1111, true)]
    [InlineData(1131, false)]
    [InlineData(3111, false)]
    public void IsPalindromic(int n, bool expected)
    {
        var actual = Problem4.IsPalindromic(n);
        Assert.Equal(expected, actual);
    }
}