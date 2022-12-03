using Konigsberg.Libraries;

namespace Konigsberg.Tests.Libraries;

[Trait("Category", nameof(Libraries))]
public sealed class Ascii85ConverterTests
{
    [Theory]
    [InlineData("Man ", "9jqo^")]
    [InlineData("Man sure", "9jqo^F*2M7")]
    [InlineData("Hello there!", "87cURD]j.8ATD?*")]
    [InlineData("an odd number", "@;[3+A7Qg#F_tT!EW")]
    public void EncodeString(string input, string output)
    {
        var encoded = Ascii85Converter.Encode(input);
        Assert.Equal(output, encoded);
    }

    [Theory]
    [InlineData("9jqo^", "Man ")]
    [InlineData("9jqo^F*2M7", "Man sure")]
    [InlineData("87cURD]j.8ATD?*", "Hello there!")]
    [InlineData("@;[3+A7Qg#F_tT!EW", "an odd number")]
    public void DecodeString(string input, string output)
    {
        var decoded = Ascii85Converter.Decode(input);
        Assert.Equal(output, decoded);
    }
}