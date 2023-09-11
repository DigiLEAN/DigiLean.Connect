using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace DigiLean.Api.Model.V1.Users
{
    [JsonConverter(typeof(StringEnumConverter), typeof(DefaultNamingStrategy))]
    public enum AssetType
    {
        GENERAL,
        PROJECT,
        CUSTOMIZED
    }
}
