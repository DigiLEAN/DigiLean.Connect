using System.ComponentModel.DataAnnotations;

namespace DigiLean.Api.Model.V1.Groups
{
    public class GroupCreate
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int? ParentId { get; set; }
        public string? ExternalId { get; set; }
        public int? BuisnessUnitId { get; set; }
    }
    public class Group : GroupCreate
    {
        public int Id { get; set; }
        public string? Type { get; set; }
        public int? ProjectId { get; set; }
    }
}