namespace ImporterApp.Helpers
{
    internal static class FileHelper
    {
        internal static async Task<List<string>> ReadFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"The file '{filePath}' was not found.");
            }

            var lines = await File.ReadAllLinesAsync(filePath);
            return lines.ToList();
        }
    }
}
