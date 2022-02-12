using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using static Konigsberg.Helpers.ResourceHelpers;
using Konigsberg.Interfaces;

namespace Konigsberg.Advent
{
    public sealed class Year2021Day1 : IAdventSolvable<int>
    {
        private readonly ReadOnlyCollection<int> _depths;

        public Year2021Day1(string filename)
        {
            _depths = File.ReadAllLines(ResourcePath("Advent", filename))
                .Select(int.Parse)
                .ToList()
                .AsReadOnly();
        }

        public int SolvePart1()
        {
            // how many times did it in increase?
            var count = 0;
            var previous = _depths.First();
            foreach (var current in _depths.Skip(1))
            {
                if (current > previous) count++;
                previous = current;
            }

            return count;
        }

        public int SolvePart2()
        {
            // we can be clever and compare currents that are 3 away from each other.
            var count = 0;

            for (int oldIndex = 0, newIndex = 3; newIndex < _depths.Count; oldIndex++, newIndex++)
            {
                if (_depths[newIndex] > _depths[oldIndex]) count++;
            }

            return count;
        }
    }
}