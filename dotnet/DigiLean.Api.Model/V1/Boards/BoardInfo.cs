namespace DigiLean.Api.Model.V1.Boards
{
    public class BoardInfo
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? BoardType { get; set; }
        public bool IsPublic { get; set; }
        public int? GroupId { get; set; }
        public string? GroupName { get; set; }
    }
}
