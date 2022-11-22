public interface IPersonDeserializer
{
    public string FileType { get; }

    IList<Person> DeserializePersons(string serializedData);
}