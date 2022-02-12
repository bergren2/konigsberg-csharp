using System.Collections;
using System.Collections.Generic;
using Konigsberg.Advent;
using static Konigsberg.Tests.Advent.AdventTestsRunner.ProblemPart;

namespace Konigsberg.Tests.Advent;

public sealed partial class AdventTestsRunner
{
    private sealed class AdventProblemsEnumerator : IEnumerable<object[]>
    {
        private readonly List<object[]> _problems = new()
        {
            new object[] { new Year2021Day1("Year2021Day1_1.txt"), Part1, 7 },
            new object[] { new Year2021Day1("Year2021Day1_2.txt"), Part1, 1548},
            new object[] { new Year2021Day1("Year2021Day1_1.txt"), Part2, 5 },
            new object[] { new Year2021Day1("Year2021Day1_2.txt"), Part2, 1589},
            new object[] { new Year2021Day2("Year2021Day2_1.txt"), Part1, 150 },
            new object[] { new Year2021Day2("Year2021Day2_2.txt"), Part1, 1690020 },
        };

        public IEnumerator<object[]> GetEnumerator() => _problems.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}