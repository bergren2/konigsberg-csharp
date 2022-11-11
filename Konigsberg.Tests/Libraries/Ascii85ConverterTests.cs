using System;
using Konigsberg.Libraries;
using Xunit;

namespace Konigsberg.Tests.Libraries;

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
}