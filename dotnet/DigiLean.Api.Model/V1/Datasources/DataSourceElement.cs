using DigiLean.Api.Model.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DigiLean.Api.Model.V1
{
    public class DataSourceElement
    {
        public int Id { get; set; }
        public string? Label { get; set; }
        public DataSourceElementType Type { get; set; }
        public bool IsMandatory { get; set; }
        public string SourceColumn { get; set; } = string.Empty;
        public int? DataListId { get; set; }
    }

    [JsonConverter(typeof(StringEnumConverter), typeof(LowerCaseNamingStrategy))]
    public enum DataSourceElementType
    {
        Area,
        Asset,
        Board,
        Bool,
        Description,
        List,
        Number,
        Project,
        Text,
        User
    }
}
