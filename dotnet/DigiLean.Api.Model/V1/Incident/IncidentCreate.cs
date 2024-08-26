using System.ComponentModel.DataAnnotations;

namespace DigiLean.Api.Model.V1.Incident
{
    public class IncidentCreate
    {
        public int Id { get; set; }
        [Required]
        public int IncidentTypeId { get; set; }
        [Required]
        public string Title { get; set; } = string.Empty;
        [Required]
        public DateTime IncidentDate { get; set; }

        public string? Text { get; set; }
        public int? ReportedByGroupId { get; set; }
        public int? FollowUpGroupId { get; set; }
        public int? ProjectId { get; set; }
        public int? AreaId { get; set; }

        public DateTime? DueDate { get; set; }
        public DateTime? StatusModifiedDate { get; set; }

        [Required]
        public int Severity { get; set; }
        public IncidentSeverity SeverityText => (IncidentSeverity)Severity;
        public int Status { get; set; }


        public int? EvaluationStatus { get; set; }
        public string? EvaluationText { get; set; }

        public string? ResponsibleUserId { get; set; }
        public string? Responsible { get; set; }
        public string? ResponsibleDisplayName { get; set; }

        public DateTime CreatedDate { get; set; }
        public string? CreatedByUserId { get; set; }
        public string? CreatedByUser { get; set; }
        public string? CreatedByUserDisplayName { get; set; }
        public DateTime? StatusNewDate { get; set; }

        public string? ExternalId { get; set; }
        public bool IsAnonymous { get; set; }
        public List<IncidentConsequence> Consequences { get; set; } = new List<IncidentConsequence>();
        public List<IncidentCategory> Categories { get; set; } = new List<IncidentCategory>();
        public List<IncidentCause> Causes { get; set; } = new List<IncidentCause>();
        public List<CustomFieldValue> CustomFields { get; set; } = new List<CustomFieldValue>();
    }
}
