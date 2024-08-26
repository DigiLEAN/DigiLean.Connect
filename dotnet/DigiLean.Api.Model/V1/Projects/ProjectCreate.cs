using System.ComponentModel.DataAnnotations;

namespace DigiLean.Api.Model.V1.Projects
{
    public class ProjectCreate
    {
        [Required]
        public string ProjectNumber { get; set; } = string.Empty;

        [Required]
        public string Name { get; set; } = string.Empty;

        public string? Status { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? EstimatedStartDate { get; set; }
        public DateTime? EstimatedEndDate { get; set; }
        public string? CustomerNumber { get; set; } = string.Empty;

        public string? OwnerEmail { get; set; } = string.Empty;
        public string[]? MembersEmail { get; set; }
        public string? ExternalId { get; set; } = string.Empty;
    }
}