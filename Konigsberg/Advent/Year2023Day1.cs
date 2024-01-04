using System;

namespace Konigsberg.Advent;

public sealed class Year2023Day1 : IAdventSolvable<int>
{
    private const int MinWordLength = 3;

    private readonly string[] _lines;
    public Year2023Day1(string filename)
    {
        _lines = File.ReadAllLines(ResourcePath("Advent", filename));
    }

    public int SolvePart1() =>
        _lines.Sum(line =>
            int.Parse(line.First(char.IsDigit).ToString() + line.Last(char.IsDigit)));

    public int SolvePart2()
    {
        return _lines.Sum(line => 10 * FindFirstNumber(line) + FindLastNumber(line));
    }

    private static int FindFirstNumber(string line)
    {
        for (var i = 0; i < line.Length; i++)
        {
            var n = FindNumber(line[i..]);
            if (n != null) return n.Value;
        }

        throw new NotImplementedException("You screwed something up.");
    }

    private static int FindLastNumber(string line)
    {
        for (var i = 1; i <= line.Length; i++)
        {
            var n = FindNumber(line[^i..]);
            if (n != null) return n.Value;
        }

        throw new NotImplementedException("You screwed something up.");
    }

    /// <summary>
    /// See if a number starts at string <paramref name="s" />
    /// </summary>
    /// <param name="s">string to search in</param>
    /// <returns></returns>
    private static int? FindNumber(string s)
    {
        if (int.TryParse(s[0].ToString(), out int n))
        {
            return n;
        }

        for (var i = MinWordLength - 1; i <= s.Length; i++)
        {
            var m = WordToDigit(s[..i]);
            if (m != null) return m;
        }

        return null;
    }

    private static int? WordToDigit(string s)
    {
        return s switch
        {
            "one"   => 1,
            "two"   => 2,
            "three" => 3,
            "four"  => 4,
            "five"  => 5,
            "six"   => 6,
            "seven" => 7,
            "eight" => 8,
            "nine"  => 9,
            _       => null
        };
    }
}