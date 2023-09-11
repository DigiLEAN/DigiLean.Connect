using DigiLean.Api.Model.V1;
using DigiLean.Api.Model.V1.Data;
using DigiLean.Connect.Client.Extensions;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace DigiLean.Connect.Client.Apis.V1
{
    public class DataValuesApiV1 : ApiEndpointBase
    {
        public DataValuesApiV1(HttpClient client, ILogger logger) : base(client, logger, "/v1/datasources")
        {
        }

        /// <summary>
        /// Get values for data source and page, page 1 will be 1000 latest values
        /// </summary>
        public async Task<DataValuesPaged> QueryValues(int dataSourceId, TableParams tableParams)
        {
            var queryParams = JsonConvert.SerializeObject(tableParams);
            var url = $"{BasePath}/{dataSourceId}/values/query?queryparams={queryParams}";
            var response = await Client.GetAsync(url);
            if (response.IsSuccessStatusCode)
                return await SerializePayload<DataValuesPaged>(response);

            await HandleError(response);
            return null;
        }
        /// <summary>
        /// Get values for data source and page, page 1 will be 1000 latest values
        /// </summary>
        public async Task<IEnumerable<DataValue>> GetByDataSourceAndPage(int dataSourceId, int page = 1)
        {
            var url = $"{BasePath}/{dataSourceId}/values";
            var result = await GetPaged(url, page);
            return result.Values;
        }

        /// <summary>
        /// Get all values for data source, paging is handled and returning values async
        /// </summary>
        public async IAsyncEnumerable<DataValue> GetAllByDataSource(int dataSourceId)
        {
            var url = $"{BasePath}/{dataSourceId}/values";
            var totalReceived = 0;
            bool pagesLeft = true;
            int page = 1;
            while (pagesLeft)
            {
                var result = await GetPaged(url, page);
                totalReceived += result.Values.Count;
                foreach (var value in result.Values)
                    yield return value;

                if (result.Total > totalReceived)
                    page += 1;
                else
                    pagesLeft = false;
            }
        }

        /// <summary>
        /// Get all values for data source and filtered by project id, paging is handled and returning values async
        /// </summary>
        public async IAsyncEnumerable<DataValue> GetAllByDataSourceAndProject(int dataSourceId, int projectId = 0)
        {
            var url = $"{BasePath}/{dataSourceId}/values";
            var pUrl = QueryHelpers.AddQueryString(url, "projectId", projectId.ToString());

            var totalReceived = 0;
            bool pagesLeft = true;
            int page = 1;
            while (pagesLeft)
            {
                var result = await GetPaged(pUrl, page);
                totalReceived += result.Values.Count;
                foreach (var value in result.Values)
                    yield return value;
                
                if (result.Total > totalReceived)
                    page += 1;
                else
                    pagesLeft = false;
            }
        }

        public async Task<bool> DeleteValues(int dataSourceId, List<int> listOfIdentifiers)
        {
            var url = $"{BasePath}/{dataSourceId}/values/batch";
            HttpRequestMessage request = new HttpRequestMessage
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

        private async Task<DataValuesPaged> GetPaged(string url, int page = 1)
        {
            var qUrl = QueryHelpers.AddQueryString(url, "page", page.ToString());
            var response = await Client.GetAsync(qUrl);
            if (response.IsSuccessStatusCode)
                return await SerializePayload<DataValuesPaged>(response);
            
            await HandleError(response);
            return null;
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
        public async Task<bool> WriteDataValue(DataValue dataValue, int dataSourceId)
        {
            if (dataSourceId == 0)
                throw new ApplicationException("DataSourceId cant be 0");
            
            var url = $"{BasePath}/{dataSourceId}/values";
            var response = await Client.PostAsync(url, dataValue.AsJson());
            if (!response.IsSuccessStatusCode)
                await HandleError(response, false);
            return response.IsSuccessStatusCode;
        }

        /// <summary>
        /// Write many datavalues in batch
        /// </summary>
        public async Task<bool> WriteDataValues(int dataSourceId, List<DataValue> dataValues)
        {
            if (dataSourceId == 0)
                throw new ApplicationException("DataSourceId cant be 0");

            var url = $"{BasePath}/{dataSourceId}/values/batch";
            var response = await Client.PostAsync(url, dataValues.AsJson());
            if (!response.IsSuccessStatusCode)
                await HandleError(response, false);
            
            return response.IsSuccessStatusCode;
        }
    }
}
