﻿using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace DigiLean.Api.Model.V1.Incident
{
    [JsonConverter(typeof(StringEnumConverter), typeof(DefaultNamingStrategy))]
    public enum IncidentSeverity
    {
        None = 0,
        Low = 1,
        Medium = 2,
        High = 3
    }
}
