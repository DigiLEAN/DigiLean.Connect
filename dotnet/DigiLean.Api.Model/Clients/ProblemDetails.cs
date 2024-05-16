using System.Text.Json.Serialization;

namespace DigiLean.Api.Model.Clients
{
    public class ProblemDetails
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("status")]
        public int? Status { get; set; }
        [JsonPropertyName("detail")]
        public string Detail { get; set; }
        [JsonPropertyName("instance")]
        public string Instance { get; set; }
        [JsonExtensionData]
        public IDictionary<string, object> Extensions { get; }
    }
}
