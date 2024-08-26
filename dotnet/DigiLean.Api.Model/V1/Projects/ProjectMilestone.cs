using System.ComponentModel.DataAnnotations;

namespace DigiLean.Api.Model.V1.Projects
{
    public class ProjectMilestone : ProjectMilestoneBase
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
    }

    public class ProjectMilestoneBase
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        public DateTime? PlannedDate { get; set; }
        public DateTime? ActualDate { get; set; }
    }
}