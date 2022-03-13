using System;

namespace Konigsberg.LeetCode;

public sealed class Problem1
{
    public int[] TwoSum(int[] nums, int target)
    {
        for (var i = 0; i < nums.Length; i++)
        {
            for (var j = i + 1; j < nums.Length; j++)
            {
                if (nums[i] + nums[j] == target)
                {
                    var solution = new[] { i, j };
                    Array.Sort(solution);
                    return solution;
                }
            }
        }
        throw new ArgumentException("We should never reach this with the given problem inputs");
    }
}