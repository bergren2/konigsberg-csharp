using System.IO;

namespace Konigsberg.Helpers;

public static class ResourceHelpers
{
    public static string ResourcePath(string projectBasePath, string filename)
    {
        return Path.Combine(projectBasePath, "Resources", filename);
    }
}