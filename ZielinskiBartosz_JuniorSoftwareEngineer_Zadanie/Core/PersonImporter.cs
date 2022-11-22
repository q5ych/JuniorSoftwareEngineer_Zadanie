public class PersonImporter : IPersonImporter
{
    IDeserializerProvider _deserializerProvider;
    ISerializedDataLoader _dataLoader;
    IErrorHandler? _errorHandler;

    public PersonImporter(
        IDeserializerProvider deserializerProvider,
        ISerializedDataLoader dataLoader,
        IErrorHandler? personMenagerErrorHandler = null)
    {
        _deserializerProvider = deserializerProvider;
        _errorHandler = personMenagerErrorHandler;
        _dataLoader = dataLoader;
    }

    public IList<Person>? ImportPersons(string filepath)
    {
        IList<Person>? persons;
        string fileType;
        string serializedData;

        // Try to get file type (basing on file extention)
        try
        {
            fileType = Path.GetExtension(filepath).ToUpper().Trim('.');
        }
        catch (ArgumentException)
        {
            _errorHandler?.HandleError("Unable to identify extention.");
            return null;
        }

        // Try to find correct deserializer
        IPersonDeserializer? deserializer;
        if(!_deserializerProvider.TryGetDeserializer(fileType, out deserializer))
        {
            _errorHandler?.HandleError($"Unable to find any importer for extention: [{fileType}] -OR- more than one importer found.");
            return null;
        }

        // Loading serialized data
        try
        {
            serializedData = _dataLoader.ReadFile(filepath);
        }
        catch (Exception e)
        {
            _errorHandler?.HandleError($"Unable to load data. {e.Message}");
            return null;
        }

        // Try to convert data to objects
        try
        {
            persons = deserializer.DeserializePersons(serializedData);
        }
        catch (Exception e)
        {
            _errorHandler?.HandleError($"Unable to deserialize file: {e.Message}");
            return null;
        }

        return persons;
    }
}