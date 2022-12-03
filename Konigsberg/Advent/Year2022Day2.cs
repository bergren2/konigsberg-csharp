using System;
using System.Collections.Generic;
// ReSharper disable IdentifierTypo

namespace Konigsberg.Advent;

public sealed class Year2022Day2 : IAdventSolvable
{
    private readonly IEnumerable<(string, string)> _rounds;

    public Year2022Day2(string filename)
    {
        _rounds = File.ReadAllLines(ResourcePath("Advent", filename))
            .Select(x =>
            {
                var codes = x.Split();
                return ValueTuple.Create(codes[0], codes[1]);
            });
    }

    public int SolvePart1() =>
        _rounds
            .Select(r =>
            {
                var opps = StringToShape(r.Item1);
                var yours = StringToShape(r.Item2);
                return ScoreTheRound(opps, yours) + (int) yours;
            }).Sum();

    public int SolvePart2() =>
        _rounds
            .Select(r =>
            {
                var opps = StringToShape(r.Item1);
                var outcome = StringToOutcome(r.Item2);
                return (int) ShapeNeededToCreateOutcome(opps, outcome) + (int) outcome;
            }).Sum();

    private static Shape StringToShape(string s) =>
        s switch
        {
            "A" or "X" => Shape.Rock,
            "B" or "Y" => Shape.Paper,
            "C" or "Z" => Shape.Scissors,
            _ => throw new ArgumentOutOfRangeException(nameof(s), s, $"Invalid encrypted strategy code: {s}.")
        };

    private static Outcome StringToOutcome(string s) =>
        s switch
        {
            "X" => Outcome.Lose,
            "Y" => Outcome.Draw,
            "Z" => Outcome.Win,
            _   => throw new ArgumentOutOfRangeException(nameof(s), s, $"Invalid encrypted score code: {s}")
        };

    private static Shape ShapeNeededToCreateOutcome(Shape opps, Outcome outcome) =>
        (opps, outcome) switch
        {
            (_, Outcome.Draw) => opps,
            (Shape.Paper, Outcome.Win) or (Shape.Rock, Outcome.Lose) => Shape.Scissors,
            (Shape.Scissors, Outcome.Win) or (Shape.Paper, Outcome.Lose) => Shape.Rock,
            (Shape.Rock, Outcome.Win) or (Shape.Scissors, Outcome.Lose) => Shape.Paper,
            _ => throw new ArgumentOutOfRangeException(nameof(opps), opps, $"Can't compute outcome '{outcome}' for opponent's shape '{opps}'")
        };

    /// <summary>
    /// Calculates a score based on which shapes your opponent and you threw.
    /// </summary>
    /// <param name="opps">Opponent's shape</param>
    /// <param name="yours">Your shape</param>
    /// <returns></returns>
    private static int ScoreTheRound(Shape opps, Shape yours) =>
        (int) ((opps, yours) switch
        {
            (Shape.Rock, Shape.Paper) or (Shape.Paper, Shape.Scissors) or (Shape.Scissors, Shape.Rock) => Outcome.Win,
            (Shape.Rock, Shape.Rock) or (Shape.Paper, Shape.Paper) or (Shape.Scissors, Shape.Scissors) => Outcome.Draw,
            (Shape.Rock, Shape.Scissors) or (Shape.Scissors, Shape.Paper) or (Shape.Paper, Shape.Rock) => Outcome.Lose,
            _ => throw new ArgumentOutOfRangeException(nameof(opps), opps, $"The following pair doesn't make sense: ${opps} & ${yours}")
        });

    private enum Shape
    {
        Rock = 1,
        Paper = 2,
        Scissors = 3
    }

    private enum Outcome
    {
        Lose = 0,
        Draw = 3,
        Win = 6
    }
}