namespace DigiLean.Api.Model.V1.Incident
{
    public class Cause
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int? SortOrder { get; set; }
    }
}