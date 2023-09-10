namespace Konigsberg.Euler;

public sealed class Problem2 : IEulerSolvable<int>
{
    const int FirstTerm = 0;
    const int SecondTerm = 1;

    private int _limit;

    /// <summary>
    /// Sum even Fibonacci numbers up to a limit, starting with terms 0 and 1.
    /// </summary>
    /// <param name="limit">Not included in the sum.</param>
    public Problem2(int limit)
    {
        _limit = limit;
    }

    public int Solve()
    {
        var sum = 0;
        var a = FirstTerm;
        var b = SecondTerm;

        while (a + b < _limit)
        {
            var c = a + b;
            a = b;
            b = c;

            if (c % 2 == 0) sum += c;
        }

        return sum;
    }
}