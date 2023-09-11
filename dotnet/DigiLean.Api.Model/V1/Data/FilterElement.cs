using System.Collections.Generic;

namespace DigiLean.Api.Model.V1.Data
{
    public class FilterElement
    {
        public FilterElement()
        {
            Items = new List<string>();
        }
        public string SourceColumn { get; set; }
        public string CustomFieldId { get; set; }
        public string Operator { get; set; }
        public List<string> Items { get; set; }

        public bool IsCustomField()
        {
            return string.IsNullOrWhiteSpace(CustomFieldId) == false;
        }
    }
}
