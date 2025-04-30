using DigiLean.Api.Model.Clients;
using DigiLean.Api.Model.V1.Groups;
using DigiLean.Api.Model.V1.Users;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;

namespace DigiLean.Api.Client.V1
{
    public class UsersApi : ApiEndpointBase
    {
        public UsersApi(HttpClient client, ILogger logger) : base(client, logger, "/v1/Users")
        {
        }

        /// <summary>
        /// List users
        /// </summary>
        /// <param name="filter">OData filter example: firstName eq Per</param>
        public Task<List<User>> List(string? filter = null)
        {
            var url = $"{BasePath}";
            if (!string.IsNullOrWhiteSpace(filter))
                url = QueryHelpers.AddQueryString(url, "$filter", filter);

            return GetResponseAndHandleError<List<User>>(url);
        }

        public Task<User> GetOne(string userId)
        {
            var url = $"{BasePath}/{userId}";
            return GetResponseAndHandleError<User>(url);
        }

        public Task<List<Group>> GetUserGroups(string userId)
        {
            var url = $"{BasePath}/{userId}/groups";
            return GetResponseAndHandleError<List<Group>>(url);
        }

        public Task<List<User>> ListUsersByRole(UserRoleType role)
        {
            var url = $"{BasePath}/roles/{role}";
            return GetResponseAndHandleError<List<User>>(url);
        }

        public Task<User> Create(UserBase user)
        {
            var url = BasePath;
            return PostGetResponseAndHandleError<User>(url, user);
        }

        public Task<User> Update(string userId, UserBase user)
        {
            var url = $"{BasePath}/{userId}";
            return PutGetResponseAndHandleError<User>(url, user);
        }

        public Task<User> UpdateByUserName(string userName, UserBase user)
        {
            var url = $"{BasePath}/UpdateByUserName?userName={userName}";
            return PutGetResponseAndHandleError<User>(url, user);
        }

        public Task<User> Delete(string userId)
        {
            var url = $"{BasePath}/{userId}";
            return DeleteGetResponseAndHandleError<User>(url);
        }

        public Task<User> AddRole(string userId, UserRoleType role)
        {
            var url = $"{BasePath}/{userId}/roles/{role}";
            return PutGetResponseAndHandleError<User>(url);
        }

        public Task<User> RemoveRole(string userId, UserRoleType role)
        {
            var url = $"{BasePath}/{userId}/roles/{role}";
            return DeleteGetResponseAndHandleError<User>(url);
        }

        public Task<List<UserNotification>> GetNotifications(string userId)
        {
            var url = $"{BasePath}/{userId}/notifications";
            return GetResponseAndHandleError<List<UserNotification>>(url);
        }

        public Task<List<UserNotification>> UpdateNotification(string userId, UserNotificationUpdate update)
        {
            var url = $"{BasePath}/{userId}/notifications";
            return PutGetResponseAndHandleError<List<UserNotification>>(url, update);
        }

        public Task<List<UserNotification>> EnableALLNotifications(string userId)
        {
            var url = $"{BasePath}/{userId}/notifications";
            var enableAll = new UserNotificationUpdate { Type = NotificationType.All, Email = true, Mobile = true };
            return PutGetResponseAndHandleError<List<UserNotification>>(url, enableAll);
        }
        public Task<List<UserNotification>> DisableALLNotifications(string userId)
        {
            var url = $"{BasePath}/{userId}/notifications";
            var disableAll = new UserNotificationUpdate { Type = NotificationType.All, Email = false, Mobile = false };
            return PutGetResponseAndHandleError<List<UserNotification>>(url, disableAll);
        }

        // convenience methods
        public async Task<List<User>> GetOnlyAdUsers()
        {
            var adUsers = await List("useAD eq true"); // use OData filter
            return adUsers;
        }
    }
}
