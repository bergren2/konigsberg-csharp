using System.Collections.Generic;

namespace Konigsberg.Euler;

public sealed class Problem24 : IEulerSolvable<string>
{
    private readonly string _solution;

    public Problem24(IEnumerable<int> elements, int nthElementToLookup)
    {
        var stringElements = elements.Select(x => x.ToString()).ToList();
        stringElements.Sort(string.CompareOrdinal);

        // we can be clever and calculate the nth element
        _solution = StringAtIndexRecursive(nthElementToLookup - 1, stringElements);
    }

    public string Solve() => _solution;

    private static int Factorial(int n)
        => Enumerable.Range(1, n).Aggregate(1, (p, item) => p * item);

    private static string StringAtIndexRecursive(int index, List<string> sortedRemainingElements)
    {
        // base case
        if (sortedRemainingElements.Count == 1) return sortedRemainingElements[0];

        // recursive
        var factorial = Factorial(sortedRemainingElements.Count - 1);
        var thisIndex = index / factorial;
        var digit = sortedRemainingElements[thisIndex];
        sortedRemainingElements.RemoveAt(thisIndex); // this is a little unclear b/c we're modifying in place

        // here we use our calculated first digit and recurse on the remaining digits
        return digit + StringAtIndexRecursive(index - (thisIndex * factorial), sortedRemainingElements);
    }
}