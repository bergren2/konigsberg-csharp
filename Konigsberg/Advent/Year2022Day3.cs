using System;

namespace Konigsberg.Advent;

public sealed class Year2022Day3 : IAdventSolvable
{
    private readonly string[] _rucksacks;
    public Year2022Day3(string filename)
    {
        _rucksacks = File.ReadAllLines(ResourcePath("Advent", filename));
    }

    public int SolvePart1() =>
        _rucksacks
            .Select(sack =>
            {
                var half = sack.Length / 2;
                var pocket1 = sack[..half];
                var pocket2 = sack[half..];
                return GetPriority(pocket1.Intersect(pocket2).Single());
            }).Sum();

    public int SolvePart2() =>
        _rucksacks
            .Chunk(3)
            .Select(sacks => GetPriority(sacks[0].Intersect(sacks[1]).Intersect(sacks[2]).Single()))
            .Sum();

    private static int GetPriority(char c)
    {
        const int LOWERCASE_OFFSET = 96;
        const int UPPERCASE_OFFSET = 38;

        if (!char.IsLetter(c)) throw new ArgumentOutOfRangeException(nameof(c), c, "Argument is not a letter");

        return char.IsLower(c) ? c - LOWERCASE_OFFSET : c - UPPERCASE_OFFSET;
    }
}