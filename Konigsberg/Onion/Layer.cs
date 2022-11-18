using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Konigsberg.Onion;

public sealed record Layer
{
    private static readonly Regex InstructionsRegex = new(@"^==\[ Layer (?<level>\d)/6: (?<levelName>.+) \]=+$");
    private static readonly Regex PayloadRegex = new(@"^==\[ Payload \]=+$");

    private readonly string _filePath;
    public string Name { get; }
    public LayerLevel Level { get; }
    public byte[] Payload { get; }

    /// <summary>
    /// Create the layer from the file located at <paramref name="filePath" />
    /// </summary>
    /// <param name="filePath">Instructions and payload file</param>
    public Layer(string filePath)
    {
        _filePath = filePath;

        var fileStream = File.OpenRead(_filePath);

        using var memoryStream = new MemoryStream();
        fileStream.CopyTo(memoryStream);
        memoryStream.Seek(0, SeekOrigin.Begin);
        var reader = new StreamReader(memoryStream);

        // assume the first line in the file is the instructions header
        var instructionsHeader = reader.ReadLine()!;
        var match = InstructionsRegex.Match(instructionsHeader);
        if (!match.Success)
        {
            throw new ArgumentException("Couldn't find the Instructions header");
        }

        Name = match.Groups["levelName"].Value;
        Level = (LayerLevel) int.Parse(match.Groups["level"].Value);

        var line = reader.ReadLine();
        while (line != null && !IsPayloadHeader(line))
        {
            line = reader.ReadLine();
        }

        // at Payload header, so consume next line and cursor will be at the beginning of the payload
        reader.ReadLine();

        var payloadLines = new List<string>();
        line = reader.ReadLine();
        while (line != null)
        {
            payloadLines.Add(line);
            line = reader.ReadLine();
        }

        Payload = payloadLines
            .SelectMany(x => Encoding.ASCII.GetBytes(x))
            .ToArray();
    }

    private static bool IsPayloadHeader(string line) => PayloadRegex.Match(line).Success;
}

public enum LayerLevel
{
    Zero = 0,
    One = 1
}