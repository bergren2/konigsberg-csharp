namespace Konigsberg.Euler;

public sealed class Problem48 : IEulerSolvable<string>
{
    private readonly string _solution;

    public Problem48(int limit)
    {
        long sum = 0;
        for (var i = 1; i < limit; i++)
        {
            sum += SelfPowWithTenDigitsOfAccuracy(i);
        }

        _solution = LastTenDigits(sum).ToString("0000000000");
    }

    public string Solve() => _solution;

    /// <summary>
    /// Raise x to the x power, within ten digits of accuracy
    /// </summary>
    /// <param name="x"></param>
    /// <returns></returns>
    private static long SelfPowWithTenDigitsOfAccuracy(long x)
    {
        long prod = 1;
        for (var i = 0; i < x; i++)
        {
            prod *= x;
            prod = LastTenDigits(prod);
        }

        return prod;
    }

    private static long LastTenDigits(long i) => i % 10_000_000_000;
}