using Newtonsoft.Json;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

// Class has got hardcoded data.
// Its created for preparing predefined data in compilation directory,
// just to speed up and simplify code review.
public static class TestFilesGen
{
    public static void GenerateFiles()
    {
        JsonGen("persons.json");
        XmlGen("persons.xml");
        CsvGen("persons.csv");
        UnhandledFileTypeGen("persons.txt");
    }


    private static void UnhandledFileTypeGen(string path)
    {
        File.Create(path);
    }

    private static void JsonGen(string path)
    {
        List<Person> files = new List<Person>();
        files.Add(new Person { FirstName = "Tess", LastName = "Traci", Email = "ttraci@gmail.com" });
        files.Add(new Person { FirstName = "Nicola", LastName = "Sloan", Email = "nsloan@gmail.com" });
        files.Add(new Person { FirstName = "Braidy", LastName = "Seano", Email = "bseano@gmail.com" });
        files.Add(new Person { FirstName = "Braylon", LastName = "Jayna", Email = "bjayna@gmail.com" });
        files.Add(new Person { FirstName = "Demelza", LastName = "Alexandra", Email = "dalexandra@gmail.com" });
        files.Add(new Person { FirstName = "Jaden", LastName = "Tilly", Email = "jtilly@gmail.com" });
        files.Add(new Person { FirstName = "Josie", LastName = "Tillie", Email = "jtillie@gmail.com" });
        files.Add(new Person { FirstName = "Corey", LastName = "Elfrida", Email = "celfrida@gmail.com" });
        files.Add(new Person { FirstName = "Charlene", LastName = "Ellie", Email = "cellie@gmail.com" });
        files.Add(new Person { FirstName = "Michele", LastName = "Cuthbert", Email = "mcuthbert@gmail.com" });

        string output = JsonConvert.SerializeObject(files);
        File.WriteAllText(path, output);
    }

    private static void XmlGen(string path)
    {
        List<Person> files = new List<Person>();
        files.Add(new Person { FirstName = "Chelsie", LastName = "Toria", Email = "ctoria@gmail.com" });
        files.Add(new Person { FirstName = "Munro", LastName = "Cayley", Email = "mcayley@gmail.com" });
        files.Add(new Person { FirstName = "Leyla", LastName = "Jonathon", Email = "ljonathon@gmail.com" });
        files.Add(new Person { FirstName = "Cristen", LastName = "Augustine", Email = "caugustine@gmail.com" });
        files.Add(new Person { FirstName = "Adele", LastName = "Cheryl", Email = "acheryl@gmail.com" });
        files.Add(new Person { FirstName = "Bernard", LastName = "Catherina", Email = "bcatherina@gmail.com" });
        files.Add(new Person { FirstName = "Sydnie", LastName = "Rollo", Email = "srollo@gmail.com" });
        files.Add(new Person { FirstName = "Harmon", LastName = "Phoenix", Email = "hphoenix@gmail.com" });
        files.Add(new Person { FirstName = "Andie", LastName = "Sylvan", Email = "asylvan@gmail.com" });
        files.Add(new Person { FirstName = "Jenelle", LastName = "Suzanna", Email = "jsuzanna@gmail.com" });

        XmlSerializer xsSubmit = new XmlSerializer(typeof(List<Person>));

        using (var sw = new StringWriter())
        {
            using (XmlWriter writer = XmlWriter.Create(sw))
            {
                xsSubmit.Serialize(writer, files);
                File.WriteAllText(path, sw.ToString());
            }
        }

    }

    private static void CsvGen(string path)
    {
        var sb = new StringBuilder();
        sb.AppendLine("Pearl,Mollie,pmollie@gmail.com");
        sb.AppendLine("Louie,Zaria,lzaria@gmail.com");
        sb.AppendLine("Jerrold,Kimir,jkimir@gmail.com");
        sb.AppendLine("Issac,Bobbi,ibobbi@gmail.com");
        sb.AppendLine("Monica,Grahame,mgrahame@gmail.com");
        sb.AppendLine("Cali,Crispin,ccrispin@gmail.com");
        sb.AppendLine("Janene,Lorrin,jlorrin@gmail.com");
        sb.AppendLine("Everleigh,Gaila,egaila@gmail.com");
        sb.AppendLine("China,Bertram,cbertram@gmail.com");
        sb.AppendLine("Esmee,Fleur,efleur@gmail.com");

        File.WriteAllText(path, sb.ToString());
    }
}
