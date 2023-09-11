using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DigiLean.Api.Model.V1.Users
{
    [JsonConverter(typeof(StringEnumConverter), typeof(DefaultNamingStrategy))]
    public enum AssetRoleType
    {
        Member,
        Viewer,
        Owner
    }
}
