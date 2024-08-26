using DigiLean.Api.Client;
using DigiLean.Api.Client.TestConsoleApp.Utilities;
using DigiLean.Api.Model.Clients;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var builder = Host.CreateApplicationBuilder(args);

        var configuration = builder.Configuration;

        //******************************************************************
        // Read ClientId AND Secret from appsettings.json or appsettings.Development.json
        //******************************************************************
        var clientId = configuration.GetValue<string>("ClientId");
        var secretKey = configuration.GetValue<string>("SecretKey");

        if (string.IsNullOrWhiteSpace(clientId))
            throw new ApplicationException("missing client id");
        if (string.IsNullOrWhiteSpace(secretKey))
            throw new ApplicationException("missing secret key");

        Console.WriteLine($" ############################ Using ClientId: {clientId}##########################");
        // Create our API client, API mode will determine which endpoint to use.
        var apiClient = DigiLeanApi.Create(clientId, secretKey, ApiMode.Production);


        try
        {
            var data = await apiClient.Version1.DataValues.GetValues(432);
            foreach (var item in data.Values)
                Console.WriteLine(item.AsPrintJson());
        }
        catch (DigiLeanApiException dex)
        {
            if (dex.StatusCode == System.Net.HttpStatusCode.Forbidden)
                Console.WriteLine("You don't have access to this resouce, check scopes");

            if (dex.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                Console.WriteLine("Token is not valid");
        }
        catch (Exception e)
        {
            Console.Error.WriteLine($"General exception occured: {e.Message}");
        }
    }
}