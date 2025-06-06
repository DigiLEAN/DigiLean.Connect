﻿using DigiLean.Api.Model.Clients;
using DigiLean.Api.Model.Extensions;
using DigiLean.Api.Model.V1.Groups;
using DigiLean.Api.Model.V1.Users;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;

namespace DigiLean.Api.Client.V1
{
    public class GroupsApi : ApiEndpointBase
    {
        public GroupsApi(HttpClient client, ILogger logger) : base(client, logger, "/v1/groups")
        {
        }

        public Task<Group> Create(GroupCreate group)
        {
            return PostGetResponseAndHandleError<Group>(BasePath, group);
        }

        public Task<List<Group>> List(string? filter = null)
        {
            var url = BasePath;
            if (!string.IsNullOrEmpty(filter))
                url = QueryHelpers.AddQueryString(url, "$filter", filter);

            return GetResponseAndHandleError<List<Group>>(url);
        }

        public async Task Delete(int id)
        {
            var url = $"{BasePath}/{id}";
            var response = await Client.DeleteAsync(url);
            if (response.IsSuccessStatusCode)
                return;
            await HandleError(response);
        }

        public Task<List<UserGroupMember>> GetGroupMembers(int groupId)
        {
            var url = $"{BasePath}/{groupId}/members";
            return GetResponseAndHandleError<List<UserGroupMember>>(url);
        }

        public async Task<bool> AddMember(int groupId, GroupMemberCreate member)
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


        public Task<List<Group>> GetOnlyAdGroups()
        {
            return List("externalId ne null and externalId ne ''"); // OData filter to get only those with externalId
        }
    }
}
