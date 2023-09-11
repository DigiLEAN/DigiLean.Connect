namespace DigiLean.Api.Model.V1.Users
{
    public class UserGroupMember
    {
        public UserGroupMember()
        {
        }

        public string UserId { get; set; }
        public string AzureObjectId { get; set; }
        public int GroupId { get; set; }
        public AssetRoleType GroupRole { get; set; }
    }
}
