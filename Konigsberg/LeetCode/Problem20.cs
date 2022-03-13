using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Konigsberg.LeetCode;

public sealed class Problem20
{
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
                    if (!(o == '(' && c == ')' ||
                        o == '[' && c == ']' ||
                        o == '{' && c == '}'))
                    {
                        return false;
                    }
                    break;
            }


        }

        return !charStack.Any();
    }
}