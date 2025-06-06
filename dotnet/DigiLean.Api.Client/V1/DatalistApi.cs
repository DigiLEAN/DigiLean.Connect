﻿using DigiLean.Api.Model.Clients;
using DigiLean.Api.Model.Extensions;
using DigiLean.Api.Model.V1;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;

namespace DigiLean.Api.Client.V1
{
    public class DatalistApi : ApiEndpointBase
    {
        public DatalistApi(HttpClient client, ILogger logger) : base(client, logger, "/v1/datalists")
        {
        }

        /// <summary>
        /// Get all datalists
        /// </summary>
        public Task<List<DataList>> List(string? filter = null)
        {
            var url = BasePath;
            
            if (!string.IsNullOrEmpty(filter))
                url = QueryHelpers.AddQueryString(url, "$filter", filter);
            
            return GetResponseAndHandleError<List<DataList>>(url);
        }


        public Task <List<DataListItem>> GetItemsForList(int listId)
        {
            var url = $"{BasePath}/{listId}/items";
            return GetResponseAndHandleError<List<DataListItem>>(url);
        }


        public async Task<DataListItem> CreateDataListItem(int listId, DataListItem item)
        {
            var response = await Client.PostAsync($"{BasePath}/{listId}/items", item.AsJson());
            if (response.IsSuccessStatusCode)
                return await SerializePayload<DataListItem>(response);
            await HandleError(response);
            return null;
        }
    }
}
