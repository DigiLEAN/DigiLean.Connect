namespace DigiLean.Api.Model.V1.Projects
{
    public class Project
    {
        public int Id { get; set; }
        public string? ProjectNumber { get; set; }
        public string? Status { get; set; }
        public string? ExternalId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? CustomerNumber { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? EstimatedStartDate { get; set; }
        public DateTime? EstimatedEndDate { get; set; }
    }
}