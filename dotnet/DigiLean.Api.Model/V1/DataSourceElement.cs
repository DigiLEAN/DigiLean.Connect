namespace DigiLean.Api.Model.V1
{
    public class DataSourceElement
    {
        public int Id { get; set; }
        public string? Label { get; set; }
        public string? Type { get; set; }
        public bool IsMandatory { get; set; }
        public string? SourceColumn { get; set; }
        public int DataSourceId { get; set; }
        public int? DataListId { get; set; }
    }
}
