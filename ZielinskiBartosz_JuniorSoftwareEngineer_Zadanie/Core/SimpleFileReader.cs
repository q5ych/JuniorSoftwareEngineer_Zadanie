public class SimpleFileReader : ISerializedDataLoader
{
    public string ReadFile(string source)
    {
        return File.ReadAllText(source);
    }
}