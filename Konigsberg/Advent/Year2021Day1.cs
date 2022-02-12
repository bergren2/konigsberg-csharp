using System.IO;
using System.Linq;
using static Konigsberg.Helpers.ResourceHelpers;
using Konigsberg.Interfaces;

namespace Konigsberg.Advent
{
    public sealed class Year2021Day1Part1 : IAdventSolvable<int>
    {
        public int Solve(string filename)
        {
            // how many times did it in increase?
            var depths = File.ReadAllLines(ResourcePath("Advent", filename))
                .Select(int.Parse)
                .ToList();
            var count = 0;
            var previous = depths.First();
            foreach (var current in depths.Skip(1))
            {
                if (current > previous) count++;
                previous = current;
            }

            return count;
        }
    }
}