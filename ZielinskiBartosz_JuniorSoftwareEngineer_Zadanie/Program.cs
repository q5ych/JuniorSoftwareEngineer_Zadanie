using Autofac;

// ╔═══════════════════════════════════════════════════════════════════════════════════════════════╗
// ║                                            SUMMARY                                            ║
// ╠═══════════════════════════════════════════════════════════════════════════════════════════════╣
// ║ 1) Autofac library is used as Dependency inversion framework.                                 ║
// ║ 2) The structure of the code allows it to be written and extended by multiple developers.     ║
// ║ 3) Software allows to import and show Person data (FirstName, LastName, Email).               ║
// ║ 4) Software is able to open: JSON, CSV and XML file types.                                    ║
// ║ 5) To add new supported file type:                                                            ║
// ║ - implement new class, which implements IPersonDeserializer                                   ║
// ║ - register this class in ConfigBuilder.cs / BuildConfig()                                     ║
// ╠═══════════════════════════════════════════════════════════════════════════════════════════════╣
// ║ 6) Implementations like ISerializedDataLoader interface is created for:                       ║
// ║ - simplyfing tests - it allows mocking this interface and provide data content                ║
// ║ directly from tests classes, without using files,                                             ║
// ║ - allows to use different sources of "Person" data,                                           ║
// ║ 7) TestFilesGen.GenerateFiles() is used to generate predefined data in compilation directory. ║
// ║ It will generate the same files, which can be found in "Files to read" directory.             ║
// ║ 8) IErrorHandler interfac is not needed to be registered.                                     ║
// ╚═══════════════════════════════════════════════════════════════════════════════════════════════╝

// Pregenerating files
TestFilesGen.GenerateFiles();


// List of file pathes
List<string> filePathes = new List<string>();

//-correct files
filePathes.Add(@"persons.json");
filePathes.Add(@"persons.csv");
filePathes.Add(@"persons.xml");

//-incorrect files
filePathes.Add(@"missingFileTypeImplementation.txt");
filePathes.Add(@"missingFile.json");



// DI config builder
var config = ConfigBuilder.BuildConfig();

// Creating a scope for declared DI registrations 
using (var scope = config.BeginLifetimeScope())
{
    var personImporter = scope.Resolve<IPersonImporter>();
    var personPrinter = scope.Resolve<IPersonPrinter>();

    foreach (var path in filePathes)
    {
        Console.WriteLine();
        Console.WriteLine($" -> Showing persons from file: {path}");
        Console.WriteLine();

        var personsToShow = personImporter.ImportPersons(path);

        if (personsToShow != null)
            foreach (var person in personsToShow)
                personPrinter.DisplayPerson(person);

        Console.WriteLine("__________________________________________________________");
    }
    Console.WriteLine();
    Console.WriteLine();
}
