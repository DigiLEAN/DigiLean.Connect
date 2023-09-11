using Microsoft.Extensions.Configuration;

namespace DigiLEAN.Connect.ConsoleApp
{
    internal static class ConfigurationBuilderExtensions
    {
        internal static IConfigurationRoot GetConfigCmd(this IConfigurationBuilder builder, string[] args)
        {
            builder
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true)
                .AddJsonFile("appsettings.Production.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables(prefix: "ConfigPrefix_")
                .AddCommandLine(args);

            var configuration = builder.Build();
            return configuration;
        }
    }
}
