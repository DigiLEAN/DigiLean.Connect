using System.ComponentModel.DataAnnotations;

namespace DigiLean.Api.Model.V1.Incident
{
    public class IncidentBase
    {
        public int Id { get; set; }

        /// <summary>
        ///  New = 0,
        /// InProgress = 10,
        /// Resolved = 20,
        /// Rejected = 30
        /// </summary>
        public int Status { get; set; }

        public IncidentStatus StatusText => (IncidentStatus)Status;

        [Required]
        public int IncidentTypeId { get; set; }

        /// <summary>
        ///  None = 0,
        /// Low = 1,
        /// Medium = 2,
        /// High = 3
        /// </summary>
        public int Severity { get; set; }
        public int? ReportedByGroupId { get; set; }
        public int? FollowUpGroupId { get; set; }
        public string? ResponsibleUserId { get; set; }
        [Required]
        public string Title { get; set; } = string.Empty;
        public string? Text { get; set; }

        [Required]
        public DateTime IncidentDate { get; set; }

        public DateTime? ResolvedDate { get; set; }
        public DateTime? DueDate { get; set; }
        public int? EvaluationStatus { get; set; } //? What are values here
        public string? EvaluationText { get; set; }
        public bool IsAnonymous { get; set; }
        public int? AreaId { get; set; }
        public int? ProjectId { get; set; }
        public string? ExternalId { get; set; }
    }
}