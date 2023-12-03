using Konigsberg.Libraries;

namespace Konigsberg.Tests.LeetCode;

public sealed class Problem9Tests : LeetCodeTests
{
    [Fact]
    public void Problem9Test()
    {
        Assert.True(9.IsPalindromic());
    }
}