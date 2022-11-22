public abstract class PersonDeserializerBase : IPersonDeserializer
{
    public string FileType { get; } // File type which is handled by class

    public PersonDeserializerBase(string fileType, ISerializedDataLoader serializedDataProvider)
    {
        FileType = fileType;
    }

    public abstract IList<Person> DeserializePersons(string serializedData);
}