public class PersonDeserializerCSV : PersonDeserializerBase
{
    private char _separator;
    private int _expectedFieldsCount;

    public PersonDeserializerCSV(ISerializedDataLoader serializedDataProvider)
        : base("CSV", serializedDataProvider)
    {
        _separator = ',';
        _expectedFieldsCount = 3;
    }

    public override IList<Person> DeserializePersons(string serializedData)
    {
        List<Person> persons = new List<Person>();
        Person person;

        
        using (TextReader reader = new StringReader(serializedData))
        {
            string? line = reader.ReadLine();

            while (line != null)
            {
                // Analise each line, ignoring incorrect ones
                if (TryConvertOneLine(line, out person))
                    persons.Add(person);

                line = reader.ReadLine();
            }
        }

        return persons;
    }

    private bool TryConvertOneLine(string? line, out Person person)
    {
        person = new Person();

        // Check if line from source is not empty 
        if (string.IsNullOrEmpty(line))
            return false;

        // Splitting => extracting values
        var elements = line.Split(_separator);

        // Check if CSV line have got expected elements count
        if (elements.Length != _expectedFieldsCount)
            return false;

        // Check if any field is not empty
        foreach (var element in elements)
            if (string.IsNullOrEmpty(element))
                return false;

        // Preparing object if convertion was valid
        person.FirstName = elements[0];
        person.LastName = elements[1];
        person.Email = elements[2];

        return true;
    }
}

