using System.Collections.Generic;

using Konigsberg.Euler;

namespace Konigsberg.Tests.Euler;

public sealed class Problem24Tests : EulerTests
{
    [Theory]
    [InlineData(1, "012")]
    [InlineData(2, "021")]
    [InlineData(3, "102")]
    [InlineData(4, "120")]
    [InlineData(5, "201")]
    [InlineData(6, "210")]
    public void SolveSmallerExample(int nthElement, string expectedLexPerm)
    {
        var elements = new List<int> { 0, 1, 2 };
        var problem = new Problem24(elements, nthElement);
        var solution = problem.Solve();
        Assert.Equal(expectedLexPerm, solution);
    }

    [Fact]
    public void Solve()
    {
        var elements = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        var problem = new Problem24(elements, 1_000_000);
        var solution = problem.Solve();
        Assert.Equal("2783915460", solution);
    }
}