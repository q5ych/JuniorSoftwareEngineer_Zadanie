public interface IDeserializerProvider
{
    bool TryGetDeserializer(string extention, out IPersonDeserializer? serializer);
}
