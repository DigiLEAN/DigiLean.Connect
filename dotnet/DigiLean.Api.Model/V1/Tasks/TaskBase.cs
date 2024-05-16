using System.ComponentModel.DataAnnotations;

namespace DigiLean.Api.Model.V1.Tasks
{
    public class TaskBase
    {
        public string? ExternalId { get; set; }
        public int? BoardId { get; set; }
        
        [Required]
        public string? Title { get; set; }
        public string? Description { get; set; }


        public TaskStatus Status { get; set; } = TaskStatus.NotStarted; // NotStarted, Completed, Blocked

        public string? ResponsibleUserId { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? StartDate { get; set; }

        public int? RowCategoryId { get; set; }
        public int? ColumnCategoryId { get; set; }

        public List<string> Tags { get; set; } = new List<string>();

        public string GetDbStatus()
        {
            switch (Status)
            {
                case TaskStatus.NotStarted:
                    return "blank";
                case TaskStatus.Completed:
                    return "OK";
                case TaskStatus.Blocked:
                    return "unacceptable";
            }
            return "blank";
        }
    }
}
