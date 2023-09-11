using DigiLean.Api.Model.V1;
using DigiLean.Connect.Client.Extensions;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace DigiLean.Connect.Client.Apis.V1
{
    public class DatalistApi : ApiEndpointBase
    {
        public DatalistApi(HttpClient client, ILogger logger) : base(client, logger, "/v1/datalists")
        {
        }

        /// <summary>
        /// Get all datasources
        /// </summary>
        public async Task<List<DataList>> GetAll()
        {
            var response = await Client.GetAsync(BasePath);
            if (response.IsSuccessStatusCode)
                return await SerializePayload<List<DataList>>(response);

            await HandleError(response);
            return null;

        }


        public async Task <List<DataListItem>> GetItemsForList(int listId)
        {
            var response = await Client.GetAsync($"{BasePath}/{listId}/items");
            if (response.IsSuccessStatusCode)
                return await SerializePayload<List<DataListItem>>(response);
            await HandleError(response);
            return null;

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
