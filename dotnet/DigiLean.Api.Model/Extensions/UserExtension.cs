using DigiLean.Api.Model.V1.Users;

namespace DigiLean.Api.Model.Extensions
{
    public static class UserExtension
    {
        public static bool HasRole(this User user, string role)
        {
            return user.Roles.Any(u => u == role);
        }

        public static bool HasRole(this User user, UserRoleType role)
        {
            return user.HasRole(role.ToString());
        }
    }
}