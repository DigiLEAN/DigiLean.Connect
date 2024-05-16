using DigiLean.Api.Model.Clients;
using DigiLean.Api.Model.V1;
using Microsoft.Extensions.Logging;

namespace DigiLean.Api.Client.V1
{
    public class UsersApi : ApiEndpointBase
    {
        public UsersApi(HttpClient client, ILogger logger) : base(client, logger, "/v1/Users")
        {
        }

        public async Task<List<User>> GetAll()
        {
            var response = await Client.GetAsync(BasePath);
            if (response.IsSuccessStatusCode)
                return await SerializePayload<List<User>>(response);

            await HandleError(response);
            return null;
        }

        public async Task<User> GetOne(string userId)
        {
            var response = await Client.GetAsync($"{BasePath}/{userId}");
            if (response.IsSuccessStatusCode)
                return await SerializePayload<User>(response);

            await HandleError(response);
            return null;
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
