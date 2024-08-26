namespace DigiLean.Api.Model.V1.Tasks
{

    public class TaskInfo : TaskBase
    {
        public TaskInfo() { }

        public int Id { get; set; }
        public int? ParentId { get; set; }
        public DateTime? LastModified { get; set; }
        public string? ResponsibleUser { get; set; }
    }
}
