namespace DigiLean.Api.Model.V1
{
    public class Project
    {
        public int Id { get; set; }
        public string ProjectNumber { get; set; }
        public string Status { get; set; }
        public string ExternalId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CustomerNumber { get; set; }
    }
}
