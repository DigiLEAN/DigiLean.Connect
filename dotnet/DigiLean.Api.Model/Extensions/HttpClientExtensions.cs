using DigiLean.Api.Model.Clients;
using Newtonsoft.Json;
using System.Text;

namespace DigiLean.Api.Model.Extensions
{
    public static class HttpClientExtensions
    {
        public static StringContent AsJson(this object o)
        {
            var json = JsonConvert.SerializeObject(o);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }

        public static string AsJsonStringified(this object o)
        {
            return JsonConvert.SerializeObject(o, Formatting.Indented);
        }

        public static async Task<ProblemDetails?> ParseProblemDetails(this HttpContent content)
        {
            var errorString = await content.ReadAsStringAsync();
            try
            {
                var details = JsonConvert.DeserializeObject<ProblemDetails>(errorString);
                return details;
            }
            catch (Exception) { }
            return null;
        }
    }
}
