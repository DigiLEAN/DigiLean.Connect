using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace DigiLean.Api.Model.V1.Improvements;

[JsonConverter(typeof(StringEnumConverter), typeof(DefaultNamingStrategy))]
public enum ImprovementEvaluation
{
    Medium = 0,
    Good = 1,
    Bad = -1
}

[JsonConverter(typeof(StringEnumConverter), typeof(DefaultNamingStrategy))]
public enum ImprovementStatus
{
    Suggested,
    Planned,
    InProgress,
    Implemented,
    Evaluated,
    Archived,
    Activated,
    Open
}