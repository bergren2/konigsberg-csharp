using System.Text;
// ReSharper disable MemberCanBePrivate.Global

namespace Konigsberg.Libraries;

public static class Ascii85Converter
{
    private const int Base = 85;
    private const int Offset = 33;
    private const int EncodingGroupSize = 4;
    private const int DecodingGroupSize = 5;

    public static string Encode(string input) => Encoding.ASCII.GetString(Encode(Encoding.ASCII.GetBytes(input)));

    public static string Decode(string input) => Encoding.ASCII.GetString(Decode(Encoding.ASCII.GetBytes(input)));

    /// <param name="input">Big-endian byte array</param>
    /// <returns></returns>
    public static byte[] Encode(byte[] input)
    {
        // pad input
        var paddedLength = input.Length / EncodingGroupSize * EncodingGroupSize;
        if (paddedLength != input.Length) paddedLength += EncodingGroupSize;
        var paddingAmount = paddedLength - input.Length;
        var padding = BuildArrayWithValue(paddingAmount, (byte) '\0');
        var paddedInput = new byte[paddedLength];
        input.CopyTo(paddedInput, 0);
        padding.CopyTo(paddedInput, paddedLength - paddingAmount);

        using var returnStream = new MemoryStream();
        for (var i = 0; i < paddedInput.Length; i += EncodingGroupSize)
        {
            // calculate 32-bit value
            var bit32Value = 0;
            var shift = 0;
            for (var j = EncodingGroupSize - 1; j >= 0; j--)
            {
                bit32Value += paddedInput[i+j] << shift;
                shift += 8;
            }

            var base85Array = BuildBase85ArrayWithOffset(bit32Value);
            returnStream.Write(base85Array);
        }

        // remove padding
        return returnStream.ToArray()[..^paddingAmount];
    }

    public static byte[] Decode(byte[] input)
    {
        // pad input
        var paddedLength = input.Length / DecodingGroupSize * DecodingGroupSize;
        if (paddedLength != input.Length) paddedLength += DecodingGroupSize;
        var paddingAmount = paddedLength - input.Length;
        var padding = BuildArrayWithValue(paddingAmount, (byte) 'u');
        var paddedInput = new byte[paddedLength];
        input.CopyTo(paddedInput, 0);
        padding.CopyTo(paddedInput, paddedLength - paddingAmount);

        // remove offset
        var base85Array = paddedInput.Select(x => x - Offset).ToArray();

        using var returnStream = new MemoryStream();
        for (var i = 0; i < base85Array.Length; i += DecodingGroupSize)
        {
            // calculate 32-bit value
            var bit32Value = 0;
            var power = 1;
            for (var j = DecodingGroupSize - 1; j >= 0; j--)
            {
                bit32Value += base85Array[i+j] * power;
                power *= Base;
            }

            var asciiArray = BuildAsciiArray(bit32Value);
            returnStream.Write(asciiArray);
        }

        return returnStream.ToArray()[..^paddingAmount];
    }

    private static byte[] BuildBase85ArrayWithOffset(int bit32Value)
    {
        // calculate Base 85 values
        var base85Array = new int[DecodingGroupSize];
        for (var i = 0; i < base85Array.Length; i++)
        {
            base85Array[i] = bit32Value % Base;
            bit32Value = (bit32Value - base85Array[i]) / Base;
        }

        // add offset
        var base85Bytes = base85Array.Select(x => (byte)(x + Offset)).Reverse().ToArray();

        return base85Bytes;
    }

    private static byte[] BuildAsciiArray(int bit32Value)
    {
        var asciiArray = new byte[EncodingGroupSize];
        var modulo = byte.MaxValue + 1;
        for (var i = 0; i < EncodingGroupSize; i++)
        {
            asciiArray[i] = (byte) (bit32Value % modulo);
            bit32Value >>= 8;
        }

        return asciiArray.Reverse().ToArray();
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