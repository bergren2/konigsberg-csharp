namespace Konigsberg.Euler;

public sealed class Problem1 : IEulerSolvable<int>
{
    private readonly int _limit;

    /// <summary>
    /// Calculate Fizz Buzz up to a limit.
    /// </summary>
    /// <param name="limit">Natural number limit, not included in the sum.</param>
    public Problem1(int limit)
    {
        _limit = limit;
    }
    public int Solve()
    {
        var sum = 0;
        for (var i = 0; i < _limit; i++)
        {
            if (i % 3 == 0 || i % 5 == 0) sum += i;
        }

        return sum;
    }
}