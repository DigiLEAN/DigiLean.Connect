using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace DigiLean.Api.Model.V1.Incident
{
    [JsonConverter(typeof(StringEnumConverter), typeof(DefaultNamingStrategy))]
    public enum IncidentStatus
    {
        New = 0,
        InProgress = 10,
        Resolved = 20,
        Rejected = 30
    }
}
