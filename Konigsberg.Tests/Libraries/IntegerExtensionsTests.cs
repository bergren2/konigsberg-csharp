using System.Collections.Generic;

using Konigsberg.Libraries;

namespace Konigsberg.Tests.Libraries;

[Trait("Category", nameof(Libraries))]
public sealed class IntegerExtensionsTests
{
    [Theory]
    [InlineData(-1, false)]
    [InlineData(0, true)]
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
        var actual = n.IsPalindromic();
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void PrimesUpThruTest()
    {
        var expectedPrimes = new List<int> { 2, 3, 5, 7, 11 };
        var primes = IntegerExtensions.PrimesUpThru(11);
        Assert.Equal(expectedPrimes, primes);
    }
}