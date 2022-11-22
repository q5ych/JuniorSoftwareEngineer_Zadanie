public class ConsolePersonImporterErrorPrinter : IErrorHandler
{
    public void HandleError(string message)
    {
        Console.WriteLine("[Error handler]: Unable to show persons. ");
        Console.WriteLine($"[Error handler]: Reason: {message}");
    }
}