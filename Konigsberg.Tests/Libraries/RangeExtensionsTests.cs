using System;
using Konigsberg.Libraries;

namespace Konigsberg.Tests.Libraries;

[Trait("Category", nameof(Libraries))]
public sealed class RangeExtensionsTests
{
    [Theory]
    [InlineData(1, 4, 2, 3, true)]
    [InlineData(2, 3, 1, 4, false)]
    [InlineData(1, 2, 1, 2, true)]
    [InlineData(1, 3, 1, 2, true)]
    [InlineData(1, 3, 2, 3, true)]
    [InlineData(1, 3, 2, 2, true)]
    [InlineData(1, 1, 2, 2, false)]
    public void Range_Contains(int start1, int end1, int start2, int end2, bool expected)
    {
        // arrange
        var one = new Range(start1, end1);
        var two = new Range(start2, end2);

        // act
        var result = one.Contains(two);
        // assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(1, 4, 2, 3, true)]
    [InlineData(2, 3, 1, 4, true)]
    [InlineData(1, 2, 1, 2, true)]
    [InlineData(1, 2, 2, 3, true)]
    [InlineData(1, 3, 2, 3, true)]
    [InlineData(1, 3, 2, 2, true)]
    [InlineData(1, 1, 2, 2, false)]
    [InlineData(1, 2, 3, 4, false)]
    public void Range_Overlaps(int start1, int end1, int start2, int end2, bool expected)
    {
        // arrange
        var one = new Range(start1, end1);
        var two = new Range(start2, end2);

        // act
        var result = one.Overlaps(two);
        // assert
        Assert.Equal(expected, result);
    }
}