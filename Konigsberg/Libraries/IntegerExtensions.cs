using System;
using System.Collections.Generic;

namespace Konigsberg.Libraries;

public static class IntegerExtensions
{
    /// <summary>
    /// Returns if an integer as a string is palindromic. By definition, negative numbers are not palindromic.
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public static bool IsPalindromic(this int n)
    {
        var s = n.ToString();
        var length = s.Length;
        for (var i = 0; i < length / 2; i++)
        {
            if (s[i] != s[length - 1 - i])
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    /// Returns a factorization dictionary with the prime as the key and the exponent as the value.
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public static Dictionary<int, int> PrimeFactorization(this int n)
    {
        if (n <= 1) throw new ArgumentException("Must be 2 or greater.", nameof(n));

        var factorization = new Dictionary<int, int>();

        var primes = PrimesUpThru(n);
        foreach (var p in primes)
        {
            var e = 0; // init exponent
            while (n % p == 0)
            {
                n /= p;
                e += 1;
            }

            factorization[p] = e;
        }

        return factorization;
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
                if (!isPrime || primeCandidate % j != 0)
                {
                    continue;
                }

                isPrime = primes.All(p => j % p != 0);
            }
            if (isPrime) primes.Add(primeCandidate);
        }

        return primes;
    }
}