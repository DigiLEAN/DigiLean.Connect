using DigiLean.Api.Model.Clients;
using DigiLean.Api.Model.Extensions;
using DigiLean.Api.Model.V1.Groups;
using DigiLean.Api.Model.V1.Users;
using Microsoft.Extensions.Logging;

namespace DigiLean.Api.Client.V1
{
    public class GroupsApi : ApiEndpointBase
    {
        public GroupsApi(HttpClient client, ILogger logger) : base(client, logger, "/v1/groups")
        {
        }

        public async Task<Group> Create(Group group)
        {
            var response = await Client.PostAsync($"{BasePath}", group.AsJson());
            if (response.IsSuccessStatusCode)
                return await SerializePayload<Group>(response);
            await HandleError(response);
            return null;
        }

        public async Task<List<Group>> GetAll(GroupType? groupType = null)
        {
            var url = BasePath;
            if (groupType.HasValue)
                url += $"/?groupType={groupType}";

            var response = await Client.GetAsync(url);
            if (response.IsSuccessStatusCode)
                return await SerializePayload<List<Group>>(response);
            await HandleError(response);
            return null;
        }

        public async Task Delete(int id)
        {
            var url = $"{BasePath}/{id}";
            var response = await Client.DeleteAsync(url);
            if (response.IsSuccessStatusCode)
                return;
            await HandleError(response);
        }

        public async Task<List<UserGroupMember>> GetGroupMembers(int groupId)
        {
            var response = await Client.GetAsync($"{BasePath}/{groupId}/members");
            if (response.IsSuccessStatusCode)
                return await SerializePayload<List<UserGroupMember>>(response);
            await HandleError(response);
            return null;
        }

        public async Task<bool> AddMember(int groupId, UserGroupMember member)
        {
            var response = await Client.PutAsync($"{BasePath}/{groupId}/members", member.AsJson());
            if (response.IsSuccessStatusCode)
                return true;
            await HandleError(response);
            return false;
        }

        public async Task<bool> RemoveMember(int groupId, string userId)
        {
            var response = await Client.DeleteAsync($"{BasePath}/{groupId}/members/{userId}");
            if (response.IsSuccessStatusCode)
                return true;
            await HandleError(response);
            return false;
        }


        public async Task<List<Group>> GetOnlyAdGroups()
        {
            var groups = await GetAll();
            var groupsWithAzId = groups.Where(g => !string.IsNullOrWhiteSpace(g.ExternalId)).ToList();
            return groupsWithAzId;
        }
    }
}
