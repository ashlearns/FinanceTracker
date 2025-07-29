public static class JsonStorageHelper
{
    // Custom directory: D:\tracker
    private static readonly string BaseDirectory = Path.Combine(@"D:\tracker");

    public static async Task SaveToFileAsync<T>(string fileName, T data)
    {
        // Ensure the directory exists
        if (!Directory.Exists(BaseDirectory))
            Directory.CreateDirectory(BaseDirectory);

        // Serialize object to JSON with indentation
        var json = System.Text.Json.JsonSerializer.Serialize(data, new System.Text.Json.JsonSerializerOptions
        {
            WriteIndented = true
        });

        // Save file to the specified path
        var filePath = Path.Combine(BaseDirectory, fileName);
        await File.WriteAllTextAsync(filePath, json);
    }

    public static async Task<T?> LoadFromFileAsync<T>(string fileName)
    {
        var filePath = Path.Combine(BaseDirectory, fileName);

        if (!File.Exists(filePath))
            return default;

        var json = await File.ReadAllTextAsync(filePath);
        return System.Text.Json.JsonSerializer.Deserialize<T>(json);
    }
}
