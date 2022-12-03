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
            new object[] { new Year2021Day2("Year2021Day2_1.txt"), Part2, 900 },
            new object[] { new Year2021Day2("Year2021Day2_2.txt"), Part2, 1408487760 },

            new object[] { new Year2022Day1("Year2022Day1_1.txt"), Part1, 24000 },
            new object[] { new Year2022Day1("Year2022Day1_2.txt"), Part1, 71502 },
            new object[] { new Year2022Day1("Year2022Day1_1.txt"), Part2, 45000 },
            new object[] { new Year2022Day1("Year2022Day1_2.txt"), Part2, 208191 },

            new object[] { new Year2022Day2("Year2022Day2_1.txt"), Part1, 15 },
            new object[] { new Year2022Day2("Year2022Day2_2.txt"), Part1, 13009 },
            new object[] { new Year2022Day2("Year2022Day2_1.txt"), Part2, 12 },
            new object[] { new Year2022Day2("Year2022Day2_2.txt"), Part2, 10398 },

            new object[] { new Year2022Day2("Year2022Day2_1.txt"), Part1, 15 },
            new object[] { new Year2022Day2("Year2022Day2_2.txt"), Part1, 13009 },
            new object[] { new Year2022Day2("Year2022Day2_1.txt"), Part2, 12 },
            new object[] { new Year2022Day2("Year2022Day2_2.txt"), Part2, 10398 },

            new object[] { new Year2022Day3("Year2022Day3_1.txt"), Part1, 157 },
            new object[] { new Year2022Day3("Year2022Day3_2.txt"), Part1, 8185 },
            new object[] { new Year2022Day3("Year2022Day3_1.txt"), Part2, 70 },
            new object[] { new Year2022Day3("Year2022Day3_2.txt"), Part2, 2817 },
        };

        public IEnumerator<object[]> GetEnumerator() => _problems.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}