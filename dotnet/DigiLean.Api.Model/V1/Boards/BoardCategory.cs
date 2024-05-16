namespace DigiLean.Api.Model.V1.Boards
{

    public class BoardCategory
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? WeekDay { get; set; }
        public bool IsColumnCategory { get; set; }
        public string? Style { get; set; }
        public int SortOrder { get; set; }
        public string? ResponsibleUserId { get; set; }
        public string? ResponsibleUser { get; set; }
    }
}
