using Konigsberg.LeetCode;
using Xunit;

namespace Konigsberg.Tests.LeetCode;

public sealed class Problem2Tests
{
    [Theory]
    [InlineData(new[] { 2, 4, 3 },             new[] { 5, 6, 4 },    new[] { 7, 0, 8 })]
    [InlineData(new[] { 0 },                   new[] { 0 },          new[] { 0 })]
    [InlineData(new[] { 0 },                   new[] { 7, 3 },       new[] { 7, 3 })]
    [InlineData(new[] { 9, 9, 9, 9, 9, 9, 9 }, new[] { 9, 9, 9, 9 }, new[] { 8, 9, 9, 9, 0, 0, 0, 1 })]
    public void Solve(int[] array1, int[] array2, int[] expected)
    {
        var problem = new Problem2();
        var solution = problem.AddTwoNumbers(new ListNode(array1), new ListNode(array2));
        Assert.Equal(expected, solution.ToArray());
    }
}