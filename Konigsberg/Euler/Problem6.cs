namespace Konigsberg.Euler;

public sealed class Problem6 : IEulerSolvable<int>
{
    private readonly int _limit;

    public Problem6(int limit)
    {
        _limit = limit;
    }

    public int Solve()
    {
        var sumOfSquares = 0;
        var theSum = 0;

        for (var i = 1; i <= _limit; i++)
        {
            sumOfSquares += i * i; // i^2
            theSum += i;
        }

        return theSum * theSum - sumOfSquares; // theSum^2 - sumOfSquares
    }
}