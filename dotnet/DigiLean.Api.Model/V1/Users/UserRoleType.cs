using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace DigiLean.Api.Model.V1.Users
{
    [JsonConverter(typeof(StringEnumConverter), typeof(DefaultNamingStrategy))]
    public enum UserRoleType
    {
        Admin,
        BusinessunitAdmin,
        BoardDesigner,
        A3Admin,
        DataAdmin,
        MessageWriter,
        DeviationAdmin,
        ImprovementAdmin,
        ProjectAdmin,
        StrategyAdmin,
        LearningAdmin
    }
}