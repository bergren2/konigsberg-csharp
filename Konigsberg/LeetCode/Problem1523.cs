namespace Konigsberg.LeetCode;

public sealed class Problem1523
{
    public int CountOdds(int low, int high)
    {
        var count = (high - low) / 2;
        if (high % 2 == 1 || low % 2 == 1)
        {
            count += 1;
        }
        return count;
    }
}