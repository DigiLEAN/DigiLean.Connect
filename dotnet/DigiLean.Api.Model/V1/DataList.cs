namespace DigiLean.Api.Model.V1
{
    public class DataList
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime LastModified { get; set; }
        public string? LastModifiedByUser { get; set; }
    }
}
