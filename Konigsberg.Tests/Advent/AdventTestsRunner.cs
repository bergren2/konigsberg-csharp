using System;
using Konigsberg.Advent;
using Xunit;
using static Konigsberg.Tests.Advent.AdventTestsRunner.ProblemPart;

namespace Konigsberg.Tests.Advent;

public sealed partial class AdventTestsRunner
{
    [Theory]
    [ClassData(typeof(AdventProblemsEnumerator))]
    public void Solve(IAdventSolvable<int> problem, ProblemPart part, int expectedResult)
    {
        // arrange
        // act
        var result = part switch
        {
            Part1 => problem.SolvePart1(),
            Part2 => problem.SolvePart2(),
            _     => throw new ArgumentOutOfRangeException(nameof(part), part, null)
        };

        // assert
        Assert.Equal(expectedResult, result);
    }
}