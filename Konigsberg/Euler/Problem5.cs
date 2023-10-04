using System;
using System.Collections.Generic;

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
        var primes = PrimesUpThru(_limit);
        var lcmFactors = new Dictionary<int, int>();

        // find LCM factors
        // for each prime divisor, we're finding the largest power of that prime
        // needed by any number up to the limit
        for (var i = 2; i < _limit; i++) // we can start with 2 b/c 1 divides everything
        {
            var x = i; // working variable

            foreach (var p in primes)
            {
                var e = 0; // init exponent
                while (x % p == 0)
                {
                    x /= p;
                    e += 1;
                }

                if (!lcmFactors.ContainsKey(p) || lcmFactors[p] < e)
                {
                    lcmFactors[p] = e;
                }
            }
        }

        var answer = 1;
        foreach (var factor in lcmFactors)
        {
            answer *= (int) Math.Pow(factor.Key, factor.Value);
        }

        return answer;
    }

    internal static List<int> PrimesUpThru(int n)
    {
        var rootLimit = (int) Math.Floor(Math.Sqrt(n));
        var primes = new List<int>();

        for (var primeCandidate = 2; primeCandidate <= n; primeCandidate++)
        {
            var isPrime = true; // default
            for (var j = 2; j <= rootLimit; j++)
            {
                if (primeCandidate % j == 0)
                {
                    foreach (var p in primes)
                    {
                        if (j % p == 0)
                        {
                            isPrime = false;
                        }
                    }

                }
            }
            if (isPrime) primes.Add(primeCandidate);
        }

        return primes;
    }
}