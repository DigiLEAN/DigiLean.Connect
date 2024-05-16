using Newtonsoft.Json;

namespace DigiLean.Api.Client.TestConsoleApp.Utilities
{
    public static class FormatExtensions
    {
        public static string AsPrintJson(this object payLoad)
        {
            string json = JsonConvert.SerializeObject(payLoad, Formatting.Indented);
            return json;
        }
    }
}
