using System.IO;
using System.Linq;
using System.Text;
// ReSharper disable MemberCanBePrivate.Global

namespace Konigsberg.Libraries;

public static class Ascii85Converter
{
    private const int BASE = 85;
    private const int OFFSET = 33;
    private const int ENCODING_GROUP_SIZE = 4;
    private const int DECODING_GROUP_SIZE = 5;

    public static string Encode(string input) => Encoding.ASCII.GetString(Encode(Encoding.ASCII.GetBytes(input)));

    public static string Decode(string input) => Encoding.ASCII.GetString(Decode(Encoding.ASCII.GetBytes(input)));

    /// <param name="input">Big-endian byte array</param>
    /// <returns></returns>
    public static byte[] Encode(byte[] input)
    {
        // pad input
        var paddedLength = input.Length / ENCODING_GROUP_SIZE * ENCODING_GROUP_SIZE;
        if (paddedLength != input.Length) paddedLength += ENCODING_GROUP_SIZE;
        var paddingAmount = paddedLength - input.Length;
        var padding = BuildArrayWithValue(paddingAmount, (byte) '\0');
        var paddedInput = new byte[paddedLength];
        input.CopyTo(paddedInput, 0);
        padding.CopyTo(paddedInput, paddedLength - paddingAmount);

        using var returnStream = new MemoryStream();
        for (var i = 0; i < paddedInput.Length; i += ENCODING_GROUP_SIZE)
        {
            // calculate 32-bit value
            var bit32Value = 0;
            var shift = 0;
            for (var j = ENCODING_GROUP_SIZE - 1; j >= 0; j--)
            {
                bit32Value += paddedInput[i+j] << shift;
                shift += 8;
            }

            // calculate Base 85 values
            var base85Array = new int[DECODING_GROUP_SIZE];

            var s = bit32Value;
            for (var j = 0; j < base85Array.Length; j++)
            {
                base85Array[j] = s % BASE;
                s = (s - base85Array[j]) / BASE;
            }

            // add offset
            var base85Bytes = base85Array.Select(x => (byte)(x + OFFSET)).Reverse().ToArray();
            returnStream.Write(base85Bytes);
        }

        // remove padding
        return returnStream.ToArray()[..^paddingAmount];
    }

    public static byte[] Decode(byte[] input)
    {
        // pad input
        var paddedLength = input.Length / DECODING_GROUP_SIZE * DECODING_GROUP_SIZE;
        if (paddedLength != input.Length) paddedLength += DECODING_GROUP_SIZE;
        var paddingAmount = paddedLength - input.Length;
        var padding = BuildArrayWithValue(paddingAmount, (byte) 'u');
        var paddedInput = new byte[paddedLength];
        input.CopyTo(paddedInput, 0);
        padding.CopyTo(paddedInput, paddedLength - paddingAmount);

        // remove offset
        var base85Array = paddedInput.Select(x => x - OFFSET).ToArray();

        using var returnStream = new MemoryStream();
        for (var i = 0; i < base85Array.Length; i += DECODING_GROUP_SIZE)
        {
            // calculate 32-bit value
            var bit32Value = 0;
            var power = 1;
            for (var j = DECODING_GROUP_SIZE - 1; j >= 0; j--)
            {
                bit32Value += base85Array[i+j] * power;
                power *= BASE;
            }

            // calculate ASCII values
            var asciiArray = new byte[ENCODING_GROUP_SIZE];
            var modulo = byte.MaxValue + 1;
            var s = bit32Value;
            for (var j = 0; j < ENCODING_GROUP_SIZE; j++)
            {
                asciiArray[j] = (byte) (s % modulo);
                s >>= 8;
            }

            returnStream.Write(asciiArray.Reverse().ToArray());
        }

        return returnStream.ToArray()[..^paddingAmount];
    }

    private static byte[] BuildArrayWithValue(int arraySize, byte value)
    {
        var array = new byte[arraySize];

        for (var i = 0; i < arraySize; i++)
        {
            array[i] = value;
        }

        return array;
    }
}