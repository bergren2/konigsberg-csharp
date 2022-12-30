using System.Collections.Generic;

namespace Konigsberg.Advent;

public sealed class Year2022Day1 : IAdventSolvable<int>
{
    private readonly IEnumerable<IEnumerable<int>> _calories;

    public Year2022Day1(string filename)
    {
        var lines = File.ReadAllLines(ResourcePath("Advent", filename));

        var current = new List<int>();
        var calories = new List<List<int>> { current };
        for (var i = 0; i < lines.Length - 1; i++ )
        {
            if (string.IsNullOrEmpty(lines[i]))
            {
                current = new List<int>();
                calories.Add(current);
                i++;
            }

            current.Add(int.Parse(lines[i]));
        }

        _calories = calories;
    }

    public int SolvePart1() =>
        _calories
            .Select(x => x.Sum())
            .Max();

    public int SolvePart2() =>
        _calories
            .Select(x => x.Sum())
            .OrderBy(x => x)
            .TakeLast(3)
            .Sum();
}