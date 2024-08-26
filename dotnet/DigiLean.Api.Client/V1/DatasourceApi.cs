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
        public Task<List<DataSourceInfo>> Get()
        {
            return GetResponseAndHandleError<List<DataSourceInfo>>(BasePath);
        }

        public Task<DataSource> GetDataSource(int dataSourceId)
        {
            var url = $"{BasePath}/{dataSourceId}";
            return GetResponseAndHandleError<DataSource>(url);
        }
    }
}
