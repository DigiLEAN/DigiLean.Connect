using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace DigiLean.Api.Model.V1.Groups
{
    [JsonConverter(typeof(StringEnumConverter), typeof(DefaultNamingStrategy))]
    public enum GroupType
    {
        GENERAL,
        BUSINESSUNIT,
        PROJECT,
        CUSTOMIZED
    }
}
