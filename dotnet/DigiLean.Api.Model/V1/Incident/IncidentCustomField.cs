using System;

namespace DigiLean.Api.Model.V1.Incident
{
    public class IncidentCustomField
    {
        public IncidentCustomField()
        {

        }


        public int Id { get; set; }
        public string Value { get; set; } = string.Empty;
        public string DataListValue { get; set; } = string.Empty;
        public int? DataListId { get; set; }
        public string DataListName { get; set; } = string.Empty;
        public DateTime RegistrationDate { get; set; }
        public string Label { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
    }
}
