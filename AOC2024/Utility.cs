namespace AOC2024;

public static class Utility
{
    public static string[] GetInput(string dir, string file)
    {
        string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

        string projectRootDirectory = Path.GetFullPath(Path.Combine(baseDirectory, @"..\..\..\..\"));

        string fullPath = Path.Combine(projectRootDirectory, "AOC2024", dir, file);

        if (!File.Exists(fullPath))
        {
            throw new FileNotFoundException($"Input file not found: {fullPath}");
        }

        return File.ReadAllLines(fullPath);
    }
}