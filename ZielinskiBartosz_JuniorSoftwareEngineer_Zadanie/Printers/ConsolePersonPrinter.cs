public class ConsolePersonPrinter : IPersonPrinter
{
    public void DisplayPerson(Person person)
    {
        Console.WriteLine($"First name: {person.FirstName}\tLast name: {person.LastName}\te-mail: {person.Email}");
    }
}