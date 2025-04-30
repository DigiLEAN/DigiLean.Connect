using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace DigiLean.Api.Model.V1.Incident
{
    [JsonConverter(typeof(StringEnumConverter), typeof(DefaultNamingStrategy))]
    public enum IncidentEvaluation
    {
        Medium = 0,
        Good = 1,
        Bad = -1
    }
}
