using System;
using System.Text;

namespace Konigsberg.Libraries;

public static class Ascii85Converter
{
    /// <summary>
    /// Big-endian byte array
    /// </summary>
    /// <param name="paddedInput"></param>
    /// <param name="padding"></param>
    /// <returns></returns>
    private static string Encode(byte[] paddedInput, int padding)
    {
        var size = paddedInput.Length;
        if (size % 4 != 0) throw new ArgumentException("Input needs to be padded to a multiple of 4", nameof(paddedInput));
        var returnString = string.Empty;

        for (var i = 0; i < size; i += 4)
        {
            var bit32Value = (paddedInput[i] << 24) + (paddedInput[i+1] << 16) + (paddedInput[i+2] << 8) + paddedInput[i+3];
            var d0 = bit32Value % 85;
            var s0 = (bit32Value - d0) / 85;

            var d1 = s0 % 85;
            var s1 = (s0 - d1) / 85;

            var d2 = s1 % 85;
            var s2 = (s1 - d2) / 85;

            var d3 = s2 % 85;
            var s3 = (s2 - d3) / 85;

            var d4 = s3 % 85;

            var base85Bytes = new[] { (byte) (d4 + 33), (byte) (d3 + 33), (byte) (d2 + 33), (byte) (d1 + 33), (byte) (d0 + 33) };
            returnString += Encoding.ASCII.GetString(base85Bytes);
        }

        return returnString[..^padding];
    }

    public static string Encode(string input)
    {
        var roundedLength = input.Length / 4 * 4;
        if (roundedLength != input.Length) roundedLength += 4;
        var paddedInput = input.PadRight(roundedLength, '\0');
        return Encode(Encoding.ASCII.GetBytes(paddedInput), paddedInput.Length - input.Length);
    }

    public static string Decode(string input)
    {
        return string.Empty;
    }
}