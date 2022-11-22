using Newtonsoft.Json;

public class PersonDeserializerJSON : PersonDeserializerBase
{
    public PersonDeserializerJSON(ISerializedDataLoader serializedDataProvider) 
        : base("JSON", serializedDataProvider)
    {
    }

    public override IList<Person> DeserializePersons(string serializedData)
    {
        // JSON deserialization
        List<Person>? deserializedProduct = JsonConvert.DeserializeObject<List<Person>>(serializedData);

        // Providing non-null data
        if (deserializedProduct == null)
            return new List<Person>();
        else
            return deserializedProduct;
    }
}
