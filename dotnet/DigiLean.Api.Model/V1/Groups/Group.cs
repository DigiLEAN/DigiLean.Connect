namespace DigiLean.Api.Model.V1.Groups
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public int? ParentId { get; set; }
        public int? ProjectId { get; set; }
        public string ExternalId { get; set; }
    }
}
