using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace DigiLean.Api.Model.V1.Incident
{
    [JsonConverter(typeof(StringEnumConverter), typeof(DefaultNamingStrategy))]
    public enum IncidentSeverity
    {
        [Display(Name = "")]
        None = 0,
        Low = 1,
        Medium = 2,
        High = 3
    }
}
