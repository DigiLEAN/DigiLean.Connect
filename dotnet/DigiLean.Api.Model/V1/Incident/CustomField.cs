namespace DigiLean.Api.Model.V1.Incident
{
    public class CustomField
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public string Type { get; set; }
        public int SortOrder { get; set; }
        public int? DataListId { get; set; }
    }
}