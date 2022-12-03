using System.IO;
using Konigsberg.Libraries;

namespace Konigsberg.Onion;

public sealed class OnionSolver
{

    /// <summary>
    /// Peel the <paramref name="layer" /> and write the output to the <paramref name="outputPath" />
    /// </summary>
    /// <param name="layer"></param>
    /// <param name="outputPath"></param>
    /// <returns></returns>
    public static Layer Peel(Layer layer, string outputPath)
    {
        // remove first two bytes <~ and last two bytes ~>
        var nextLayer = Ascii85Converter.Decode(layer.Payload[2..^2]);

        // will create in output directory, but that's fine
        // we'll still test against it and if we like the results, we'll move it to our program source
        using var fileStream = File.Open(outputPath, FileMode.Create);
        fileStream.Write(nextLayer);
        fileStream.Dispose(); // doing this explicitly so the Layer we create doesn't complain about access

        return new Layer(outputPath);
    }
}