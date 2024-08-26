using System.ComponentModel.DataAnnotations;

namespace DigiLean.Api.Model.V1.Incident
{
    public class CustomField
    {
        public int Id { get; set; }
        public string Label { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public int SortOrder { get; set; }
        public int? DataListId { get; set; }
    }
}