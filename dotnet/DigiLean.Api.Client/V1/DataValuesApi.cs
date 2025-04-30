using DigiLean.Api.Model.V1;
using DigiLean.Api.Model.Extensions;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using DigiLean.Api.Model.Clients;

namespace DigiLean.Api.Client.V1
{
    public class DataValuesApiV1 : ApiEndpointBase
    {
        public DataValuesApiV1(HttpClient client, ILogger logger) : base(client, logger, "/v1/datasources")
        {
        }

        /// <summary>Get values from Datasource scoped by time period</summary>
        /// <remarks>If you don't filter on time period, use <see cref="GetValues(int, string?, int, int)"/> instead</remarks>
        /// <param name="filter">OData filter example: projectId eq 1</param>
        /// <param name="page">page number default 1</param>
        /// <param name="pageSize">page size default 1000, max 10000</param>
        public Task<DataValuesPaged> GetValues(int dataSourceId, DateTime from, DateTime to, string? filter = null, int page = 1, int pageSize = 1000)
        {
            // does not matter if dates are already UTC
            string fromUtc = from.ToUniversalTime().ToString("u");
            string toUtc = to.ToUniversalTime().ToString("u");

            string url = $"{BasePath}/{dataSourceId}/values?from={fromUtc}&to={toUtc}&page={page}&pageSize={pageSize}";

            if (!string.IsNullOrEmpty(filter))
                url = QueryHelpers.AddQueryString(url, "$filter", filter);

            return GetResponseAndHandleError<DataValuesPaged>(url);
        }

        /// <summary> Get values from Datasource</summary>
        /// <remarks>If you filter on time period, use <see cref="GetValues(int, DateTime, DateTime, string?, int, int)"/> instead</remarks>
        /// <param name="filter">OData filter example: projectId eq 1</param>
        /// <param name="page">page number default 1</param>
        /// <param name="pageSize">page size default 1000, max 10000</param>
        /// <example>
        /// <code>Filter example: projectId eq 1</code>
        /// </example>
        public Task<DataValuesPaged> GetValues(int dataSourceId, string? filter = null, int page = 1, int pageSize = 1000)
        {
            string url = $"{BasePath}/{dataSourceId}/values?page={page}&pageSize={pageSize}";

            if (!string.IsNullOrEmpty(filter))
                url = QueryHelpers.AddQueryString(url, "$filter", filter);

            return GetResponseAndHandleError<DataValuesPaged>(url);
        }


        /// <summary>
        /// Get all values for data source and filtered by project id, paging is handled and returning values async
        /// </summary>
        public async Task<bool> DeleteValues(int dataSourceId, List<int> listOfIdentifiers)
        {
            var url = $"{BasePath}/{dataSourceId}/values/batch";
            HttpRequestMessage request = new()
            {
                Content = listOfIdentifiers.AsJson(),
                Method = HttpMethod.Delete,
                RequestUri = new Uri(url, UriKind.Relative)
            };
            var response = await Client.SendAsync(request);
            if (!response.IsSuccessStatusCode)
                await HandleError(response, false);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteValue(DataValue dataValue, int dataSourceId)
        {
            var url = $"{BasePath}/{dataSourceId}/values/{dataValue.Id}";
            var response = await Client.DeleteAsync(url);
            if (!response.IsSuccessStatusCode)
                await HandleError(response, false);
            return response.IsSuccessStatusCode;
        }

        /// <summary>
        /// Write one datavalue
        /// </summary>
        public Task<DataValue> WriteDataValue(DataValueCreate dataValue, int dataSourceId)
        {
            if (dataSourceId == 0)
                throw new ApplicationException("DataSourceId cant be 0");

            var url = $"{BasePath}/{dataSourceId}/values";
            return PostGetResponseAndHandleError<DataValue>(url, dataValue);
        }

        /// <summary>
        /// Write many datavalues in batch
        /// </summary>
        public async Task<bool> WriteDataValues<T>(int dataSourceId, List<T> dataValues)
            where T : DataValueCreate
        {
            if (dataSourceId == 0)
                throw new ApplicationException("DataSourceId cant be 0");

            var url = $"{BasePath}/{dataSourceId}/values/batch";

            var data = dataValues.AsJson();

            var response = await Client.PostAsync(url, data);
            if (!response.IsSuccessStatusCode)
                await HandleError(response);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> BatchReplace<T>(int dataSourceId, List<T> dataValues, DateTime from, DateTime to)
            where T : DataValueCreate
        {
            if (dataSourceId == 0)
                throw new ApplicationException("DataSourceId cant be 0");

            var url = $"{BasePath}/{dataSourceId}/values/batchReplace?from={from.ToUtcIsoString()}&to={to.ToUtcIsoString()}";
            var response = await Client.PutAsync(url, dataValues.AsJson());
            if (!response.IsSuccessStatusCode)
                await HandleError(response);

            return response.IsSuccessStatusCode;
        }
    }
}
