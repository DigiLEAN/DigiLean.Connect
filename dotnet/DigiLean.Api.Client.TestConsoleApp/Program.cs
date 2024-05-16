// See https://aka.ms/new-console-template for more information
using DigiLean.Api.Client;
using DigiLean.Api.Client.TestConsoleApp;
using DigiLean.Api.Client.TestConsoleApp.Utilities;
using DigiLean.Api.Model.Clients;
using Microsoft.Extensions.Configuration;


// Get configuration
var builder = new ConfigurationBuilder();
IConfiguration configuration = builder.GetConfigCmd(args);


//******************************************************************
// Make sure you have updated app.settings.jon with your ClientID AND Secret
//******************************************************************
// Read API settings, should not be hardcoded
var clientId = configuration.GetValue<string>("ClientId");
var secretKey = configuration.GetValue<string>("SecretKey");

if (clientId == null)
    throw new ApplicationException("missing client id");
if (secretKey == null)
    throw new ApplicationException("missing secret key");

Console.WriteLine($" ############################ Using ClientID: {clientId}##########################");
// Create our API client, the API mode will determine which endpoint to use.
// ClientId / SecretKey is unique pr mode so Test(sandbox) and prod has different pairs.
// Localhost can only be used when running the API on developer Machine
var apiClient = DigiLeanApi.Create(clientId, secretKey, ApiMode.Test, null);


try
{
    var data = await apiClient.Version1.DataValues.GetByDataSourceAndPage(432);
    foreach (var item in data)
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