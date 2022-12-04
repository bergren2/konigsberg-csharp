using System;
using System.Collections.Generic;
using Konigsberg.Libraries;

namespace Konigsberg.Advent;

public sealed class Year2022Day4 : IAdventSolvable
{
    private readonly IEnumerable<(Range, Range)> _assignments;

    public Year2022Day4(string filename)
    {
        _assignments = File.ReadAllLines(ResourcePath("Advent", filename))
            .Select(assignment => assignment
                .Split(',')
                .Select(range =>
                {
                    var r = range.Split('-').Select(int.Parse).ToArray();
                    return new Range(r[0], r[1]);
                })
            ).Select(assignment =>
            {
                var a = assignment.ToArray();
                return ValueTuple.Create(a[0], a[1]);
            });
    }

    public int SolvePart1() =>
        _assignments
            .Select(a => a.Item1.Contains(a.Item2) || a.Item2.Contains(a.Item1))
            .Count(a => a);

    public int SolvePart2() =>
        _assignments
            .Select(a => a.Item1.Overlaps(a.Item2))
            .Count(a => a);
}