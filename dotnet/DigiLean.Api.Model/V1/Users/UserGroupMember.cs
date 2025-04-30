using System.ComponentModel.DataAnnotations;

namespace DigiLean.Api.Model.V1.Users
{
    public class GroupMemberCreate
    {
        [Required]
        public string UserId { get; set; } = string.Empty;

        [Required]
        public AssetRoleType GroupRole { get; set; }
    }
    public class UserGroupMember : GroupMemberCreate
    {
        public string UserName { get; set; } = string.Empty;
        public string? AzureObjectId { get; set; }
        public int GroupId { get; set; }
    }
}
