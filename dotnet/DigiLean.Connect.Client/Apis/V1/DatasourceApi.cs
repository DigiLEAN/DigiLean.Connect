using DigiLean.Api.Model.V1;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace DigiLean.Connect.Client.Apis.V1
{
    public class DatasourceApi : ApiEndpointBase
    {
        public DatasourceApi(HttpClient client, ILogger logger) : base(client, logger, "/v1/datasources")
        {
        }
        
        public async Task<IEnumerable<DataSourceInfo>> Get()
        {
            var response = await Client.GetAsync(BasePath);
            if (response.IsSuccessStatusCode)
                return await SerializePayload<List<DataSourceInfo>>(response);

            await HandleError(response);
            return null;
        }

        public async Task<DataSource> GetDataSource(int dataSourceId)
        {
            var response = await Client.GetAsync($"{BasePath}/{dataSourceId}");
            if (response.IsSuccessStatusCode)
                return await SerializePayload<DataSource>(response);
            await HandleError(response);
            return null;

        }

    }
}
