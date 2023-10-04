using System;

namespace Konigsberg.Libraries;

public static class IntegerExtensions
{
    /// <summary>
    /// Returns if an integer as a string is palindromic. By definition, negative numbers are not palindromic.
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public static bool IsPalindromic(this int n)
    {
        var s = n.ToString();
        var length = s.Length;
        for (var i = 0; i < length / 2; i++)
        {
            if (s[i] != s[length - 1 - i])
            {
                return false;
            }
        }

        return true;
    }
}