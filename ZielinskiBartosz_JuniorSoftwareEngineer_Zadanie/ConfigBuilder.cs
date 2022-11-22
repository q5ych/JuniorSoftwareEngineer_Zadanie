using Autofac;

public static class ConfigBuilder
{
    public static IContainer BuildConfig()
    {
        var builder = new ContainerBuilder();

        // Register Person Manager core logic
        builder.RegisterType<PersonImporter>().As<IPersonImporter>();
        builder.RegisterType<SimpleFileReader>().As<ISerializedDataLoader>();
        builder.RegisterType<ExtentionDeserializerProvider>().As<IDeserializerProvider>();

        // Register Printers
        builder.RegisterType<ConsolePersonPrinter>().As<IPersonPrinter>();
        builder.RegisterType<ConsolePersonImporterErrorPrinter>().As<IErrorHandler>();  // No needed to register. Nullable.

        // Register available deserializers
        builder.RegisterType<PersonDeserializerJSON>().As<IPersonDeserializer>();
        builder.RegisterType<PersonDeserializerCSV>().As<IPersonDeserializer>();
        builder.RegisterType<PersonDeserializerXML>().As<IPersonDeserializer>();

        // To add new filetype deserializers register new type as IPersonDeserializer:
        // builder.RegisterType<...>().As<IPersonLoader>();


        return builder.Build();
    }

}
