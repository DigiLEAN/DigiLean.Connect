using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace DigiLean.Api.Model.V1.Tasks
{
    [JsonConverter(typeof(StringEnumConverter), typeof(DefaultNamingStrategy))]
    public enum TaskStatus
    {
        NotStarted,
        Completed,
        Blocked
    }
}
