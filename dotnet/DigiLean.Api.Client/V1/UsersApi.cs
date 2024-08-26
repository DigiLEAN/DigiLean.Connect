using DigiLean.Api.Model.Clients;
using DigiLean.Api.Model.V1.Groups;
using DigiLean.Api.Model.V1.Users;
using Microsoft.Extensions.Logging;

namespace DigiLean.Api.Client.V1
{
    public class UsersApi : ApiEndpointBase
    {
        public UsersApi(HttpClient client, ILogger logger) : base(client, logger, "/v1/Users")
        {
        }

        public Task<List<User>> GetAll()
        {
            return GetResponseAndHandleError<List<User>>(BasePath);
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

        // convenience methods
        public async Task<List<User>> GetOnlyAdUsers()
        {
            var adUsers = new List<User>();
            var users = await GetAll();

            foreach (var user in users)
            {
                if (user.UseAD)
                    adUsers.Add(user);
            }
            return adUsers;
        }
    }
}
