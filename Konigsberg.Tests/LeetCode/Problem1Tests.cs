using System;
using Konigsberg.LeetCode;
using Xunit;

namespace Konigsberg.Tests.LeetCode;

public sealed class Problem1Tests
{
    [Theory]
    [InlineData(new[] { 2, 7, 11, 15 }, 9, new[] { 0, 1 })]
    [InlineData(new[] { 3, 2, 4 },      6, new[] { 1, 2 })]
    [InlineData(new[] { 3, 3 },         6, new[] { 0, 1 })]
    public void Solve(int[] nums, int target, int[] expected)
    {
        var problem = new Problem1();
        var solution = problem.TwoSum(nums, target);
        Assert.Equal(expected, solution);
    }

    [Fact]
    public void InvalidInput_ShouldThrowAnException()
    {
        var problem = new Problem1();
        Assert.Throws<ArgumentException>(() => problem.TwoSum(new int[1], 0));
    }
}