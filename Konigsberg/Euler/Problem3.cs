using System;
using System.Collections.Generic;

namespace Konigsberg.Euler;

public sealed class Problem3 : IEulerSolvable<long>
{
    private readonly long _n;

    public Problem3(long n)
    {
        _n = n;
    }

    public long Solve()
    {
        var primeFactors = new List<long>();

        var limit = (long) Math.Ceiling(Math.Sqrt(_n));
        for (var i = 2; i < limit; i++)
        {
            if (_n % i != 0) continue;

            var isPrime = primeFactors.All(p => i % p != 0);
            if (isPrime) primeFactors.Add(i);
        }

        return primeFactors.Last();
    }
}