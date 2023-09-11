using DigiLean.Connect.Client.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DigiLean.Connect.Client.Extensions
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

        public static async Task<ProblemDetails> ParseProblemDetails(this HttpContent content)
        {
            var errorString = await content.ReadAsStringAsync();
            try
            {
                var details = JsonConvert.DeserializeObject<ProblemDetails>(errorString);
                return details;
            }
            catch(Exception) { }
            return null;
        }
    }
}
