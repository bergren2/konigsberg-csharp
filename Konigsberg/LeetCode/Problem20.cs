using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Konigsberg.LeetCode;

public sealed class Problem20
{
    private readonly List<Paren> _parens;

    public Problem20()
    {
        _parens = new List<Paren>
        {
            new('(', ')'),
            new('[', ']'),
            new('{', '}'),
        };
    }

    public bool IsValid(string s)
    {
        var regex = new Regex(@"^[\(\)\[\]\{\}]*$");
        if (!regex.IsMatch(s)) return false;

        // use a stack, test when you pop off to match against a closed
        var charStack = new Stack<char>();
        foreach (var c in s.ToCharArray())
        {
            switch (c)
            {
                case '(':
                case '[':
                case '{':
                    charStack.Push(c);
                    break;
                default: // all ending characters
                    if (!charStack.Any()) return false;

                    var o = charStack.Pop();
                    if (_parens.Single(x => x.Start == o).End != c)
                    {
                        return false;
                    }
                    break;
            }
        }

        return !charStack.Any();
    }

    record Paren(
        char Start,
        char End
    );
}