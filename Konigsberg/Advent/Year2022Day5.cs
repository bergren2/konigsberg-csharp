using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Konigsberg.Advent;

public sealed class Year2022Day5 : IAdventSolvable<string>
{
    private readonly Stack<char>[] _stacks;
    private readonly IEnumerable<Instruction> _instructions;

    public Year2022Day5(string filename)
    {
        var lines = File.ReadAllLines(ResourcePath("Advent", filename));
        var stackSection = lines.TakeWhile(x => !string.IsNullOrWhiteSpace(x))
            .Reverse()
            .Select(x => x.Chunk(4).ToArray())
            .ToList();
        _instructions = lines.Skip(stackSection.Count + 1).Select(x => new Instruction(x));

        var labels = stackSection.Take(1).Single();
        _stacks = new Stack<char>[labels.Length];
        for (var i = 0; i < labels.Length; i++)
        {
            _stacks[i] = new Stack<char>();
        }

        foreach(var chunks in stackSection.Skip(1))
        {
            for (var i = 0; i < chunks.Length; i++)
            {
                if (!char.IsWhiteSpace(chunks[i][1]))
                {
                    _stacks[i].Push(chunks[i][1]); // chunk looks like "[C] "
                }
            }
        }
    }

    public string SolvePart1()
    {
        foreach (var instruction in _instructions)
        {
            for (var i = 0; i < instruction.Amount; i++)
            {
                _stacks[instruction.Destination - 1].Push(_stacks[instruction.Source - 1].Pop());
            }
        }

        return GetTopCratesOfStacks(_stacks);
    }

    public string SolvePart2()
    {
        foreach (var instruction in _instructions)
        {
            var tempStack = new Stack<char>();
            for (var i = 0; i < instruction.Amount; i++)
            {
                tempStack.Push(_stacks[instruction.Source - 1].Pop());
            }
            for (var i = 0; i < instruction.Amount; i++)
            {
                _stacks[instruction.Destination - 1].Push(tempStack.Pop());
            }
        }

        return GetTopCratesOfStacks(_stacks);
    }

    private static string GetTopCratesOfStacks(IEnumerable<Stack<char>> stacks) =>
        stacks.Select(x => x.Pop()).Aggregate(string.Empty, (x, y) => x + y);

    private sealed record Instruction
    {
        private static readonly Regex InstructionRegex = new Regex(@"^move (\d+) from (\d) to (\d)$");

        public int Amount { get; }
        public int Source { get; }
        public int Destination { get; }

        public Instruction(string instruction)
        {
            // i.e. "move 1 from 2 to 1"
            var m = InstructionRegex.Match(instruction);
            Amount = int.Parse(m.Groups[1].Value);
            Source = int.Parse(m.Groups[2].Value);
            Destination = int.Parse(m.Groups[3].Value);
        }
    };
}