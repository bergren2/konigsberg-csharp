using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using static Konigsberg.Helpers.ResourceHelpers;

namespace Konigsberg.Advent;

public sealed class Year2021Day2 : IAdventSolvable<int>
{
    private readonly ReadOnlyCollection<Command> _commands;

    public Year2021Day2(string filename)
    {
        _commands = File.ReadAllLines(ResourcePath("Advent", filename))
            .Select(MapToCommand)
            .ToList()
            .AsReadOnly();
    }

    public int SolvePart1()
    {
        var depth = 0;
        var position = 0;
        foreach (var (direction, magnitude) in _commands)
        {
            switch (direction)
            {
                case Direction.Forward:
                    position += magnitude;
                    break;
                case Direction.Down:
                    depth += magnitude;
                    break;
                case Direction.Up:
                    depth -= magnitude;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        return depth * position;
    }

    public int SolvePart2()
    {
        var depth = 0;
        var position = 0;
        var aim = 0;
        foreach (var (direction, magnitude) in _commands)
        {
            switch (direction)
            {
                case Direction.Forward:
                    position += magnitude;
                    depth += aim * magnitude;
                    break;
                case Direction.Down:
                    aim += magnitude;
                    break;
                case Direction.Up:
                    aim -= magnitude;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        return depth * position;
    }

    private static Command MapToCommand(string commandString)
    {
        var strings = commandString.Split();
        var dir = strings[0] switch
        {
            "forward" => Direction.Forward,
            "down"    => Direction.Down,
            "up"      => Direction.Up,
            _         => throw new ArgumentOutOfRangeException()
        };
        return new Command(dir, int.Parse(strings[1]));
    }

    private sealed record Command
    (
        Direction Direction,
        int Magnitude
    );

    private enum Direction
    {
        Forward,
        Down,
        Up
    }
}