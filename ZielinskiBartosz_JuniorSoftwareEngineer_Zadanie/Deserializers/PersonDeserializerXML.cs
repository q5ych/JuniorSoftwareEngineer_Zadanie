using System.Xml.Serialization;

public class PersonDeserializerXML : PersonDeserializerBase
{
    public PersonDeserializerXML(ISerializedDataLoader serializedDataProvider) 
        : base("XML", serializedDataProvider)
    {
    }

    public override IList<Person> DeserializePersons(string serializedData)
    {
        // Deserialization
        var serializer = new XmlSerializer(typeof(List<Person>));
        List<Person>? deserializedProduct;
        using (TextReader reader = new StringReader(serializedData))
        {
            deserializedProduct = (List<Person>?)serializer.Deserialize(reader);
        }

        // Providing non-null data
        if (deserializedProduct == null)
            return new List<Person>();
        else
            return deserializedProduct;
    }
}

