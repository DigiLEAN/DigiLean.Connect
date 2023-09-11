using DigiLean.Connect.Client;
using DigiLean.Connect.Client.Apis;
using DigiLEAN.Connect.ConsoleApp;
using Microsoft.Extensions.Configuration;

Console.WriteLine("Hello, DigiLEAN Connect!");

// example of reading appsettings.json
var builder = new ConfigurationBuilder();
IConfiguration configuration = builder.GetConfigCmd(args);
var conf = configuration.GetSection("DigiLean");
var settings = conf.Get<DigiLeanConnectSettings>();
if (settings == null)
    throw new ApplicationException("error reading appsettings");


// create the client
DigiLeanConnectClient client = DigiLeanConnectApi.Create(settings.ClientId, settings.ClientSecret);

// test calling the client in async method
TestApiClient().Wait();

Console.WriteLine("Press any key to exit...");
Console.ReadKey();


async Task TestApiClient()
{
    try
    {
        var datasources = await client.Version1.Datasources.Get();
        foreach (var source in datasources)
            Console.WriteLine($"Datasource: Id={source.Id}, Title={source.Title}");


        var dataValuesInSource = await client.Version1.DataValues.GetByDataSourceAndPage(432);
        Console.WriteLine($"DataValues: Count={dataValuesInSource.ToList().Count}");
    }
    catch (Exception ex)
    {
        Console.Error.WriteLine(ex.Message);
    }
}