using System;
using System.Collections.Generic;

using Konigsberg.Libraries;

namespace Konigsberg.Euler;

public sealed class Problem5 : IEulerSolvable<int>
{
    private readonly int _limit;
    public Problem5(int limit)
    {
        _limit = limit;
    }

    // this is a straight translation from my Ruby code and could use some improvements
    public int Solve()
    {
        var lcmFactors = new Dictionary<int, int>();

        // find least common prime factorization
        // for each prime divisor, we're finding the largest power of that prime
        // needed by any number up to the limit
        for (var i = 2; i < _limit; i++)
        {
            lcmFactors = lcmFactors.Concat(i.PrimeFactorization())
                .GroupBy(d => d.Key)
                .ToDictionary(d => d.Key, d => d.Max(p => p.Value));
        }

        return lcmFactors.Aggregate(1, (current, factor) => current * (int) Math.Pow(factor.Key, factor.Value));
    }


}