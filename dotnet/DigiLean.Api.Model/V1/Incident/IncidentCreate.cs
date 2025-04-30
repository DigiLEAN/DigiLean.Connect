using System.ComponentModel.DataAnnotations;

namespace DigiLean.Api.Model.V1.Incident
{
    public class IncidentCreate : IncidentBase
    {
        public string? CreatedByUserId { get; set; }
        
        public List<IncidentConsequence> Consequences { get; set; } = [];

        [Required(ErrorMessage = "One category is required")]
        public List<IncidentCategory> Categories { get; set; } = [];
        public List<IncidentCause> Causes { get; set; } = [];
        public List<CustomFieldValue> CustomFields { get; set; } = [];
    }
}