public class ExtentionDeserializerProvider : IDeserializerProvider
{
    IEnumerable<IPersonDeserializer> _deserializers;

    public ExtentionDeserializerProvider(IEnumerable<IPersonDeserializer> deserializers)
    {
        _deserializers = deserializers;
    }

    public bool TryGetDeserializer(string extention, out IPersonDeserializer? serializer)
    {
        try
        {
            // LINQ trying to find the only one matching deserializer
            serializer = _deserializers.Single(d => d.FileType.ToUpper().Equals(extention.ToUpper()));
            return true;
        }
        catch (InvalidOperationException)
        {
            serializer = null;
            return false;
        }
    }
}