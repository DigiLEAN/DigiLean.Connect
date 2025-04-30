using System.ComponentModel.DataAnnotations;

namespace DigiLean.Api.Model.V1.Incident
{
    public class IncidentBase
    {
        public IncidentStatus Status { get; set; }

        [Required]
        public int IncidentTypeId { get; set; }

        [Required]
        public IncidentSeverity Severity { get; set; }

        public int? ReportedByGroupId { get; set; }
        public int? FollowUpGroupId { get; set; }
        public string? ResponsibleUserId { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        public string? Text { get; set; }

        [Required(ErrorMessage = "Incident date is required")]
        [DataType(DataType.Date)]
        public DateTime? IncidentDate { get; set; }

        public DateTime? ResolvedDate { get; set; }
        public DateTime? DueDate { get; set; }
        public IncidentEvaluation? EvaluationStatus { get; set; }
        public string? EvaluationText { get; set; }
        public bool IsAnonymous { get; set; }
        public int? AreaId { get; set; }
        public int? ProjectId { get; set; }
        public string? ExternalId { get; set; }
    }

    [Obsolete("Keeping it to not break V1")]
    public class IncidentUpdate : IncidentBase
    {
        public int Id { get; set; }
    }
}