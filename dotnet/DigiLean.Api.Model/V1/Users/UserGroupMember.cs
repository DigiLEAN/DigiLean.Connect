using System.ComponentModel.DataAnnotations;

namespace DigiLean.Api.Model.V1.Users
{
    public class UserGroupMember
    {
        public UserGroupMember()
        {
        }
        [Required]
        public string UserId { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string? AzureObjectId { get; set; }
        public int GroupId { get; set; }

        [Required]
        public AssetRoleType GroupRole { get; set; }
    }
}
