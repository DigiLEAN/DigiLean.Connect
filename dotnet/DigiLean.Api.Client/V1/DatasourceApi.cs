using DigiLean.Api.Model.Clients;
using DigiLean.Api.Model.V1;
using Microsoft.Extensions.Logging;

namespace DigiLean.Api.Client.V1
{
    public class DatasourceApiV1 : ApiEndpointBase
    {
        public DatasourceApiV1(HttpClient client, ILogger logger) : base(client, logger, "/v1/datasources")
        {
        }

        /// <summary>
        /// Get all datasources
        /// </summary>
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
