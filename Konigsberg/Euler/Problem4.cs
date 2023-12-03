using System;

using Konigsberg.Libraries;

namespace Konigsberg.Euler;

public sealed class Problem4 : IEulerSolvable<int>
{
    private readonly int _numberOfDigits;
    public Problem4(int numberOfDigits)
    {
        _numberOfDigits = numberOfDigits;
    }

    public int Solve()
    {
        var largest = 0;
        var lowerBound = (int) Math.Pow(10, _numberOfDigits - 1);
        var upperBound = (int) Math.Pow(10, _numberOfDigits);

        for (var i = upperBound; i >= lowerBound; i--)
        {
            for (var j = i; j < upperBound; j++)
            {
                var n = i * j;
                if (n.IsPalindromic() && n > largest) largest = n;
            }
        }

        return largest;
    }
}