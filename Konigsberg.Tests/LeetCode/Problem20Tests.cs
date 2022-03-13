using Konigsberg.LeetCode;
using Xunit;

namespace Konigsberg.Tests.LeetCode;

public sealed class Problem20Tests
{
    [Theory]
    [InlineData("()", true)]
    [InlineData("()[]{}", true)]
    [InlineData("(]", false)]
    [InlineData("[", false)]
    [InlineData("yo", false)]
    public void Solve(string s, bool expected)
    {
        var problem = new Problem20();
        var solution = problem.IsValid(s);
        Assert.Equal(expected, solution);
    }
}