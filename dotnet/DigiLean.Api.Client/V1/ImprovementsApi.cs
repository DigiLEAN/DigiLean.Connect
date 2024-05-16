using DigiLean.Api.Model.Clients;
using DigiLean.Api.Model.V1;
using Microsoft.Extensions.Logging;

namespace DigiLean.Api.Client.V1
{
    public class ImprovementsApi : ApiEndpointBase
    {
        public ImprovementsApi(HttpClient client, ILogger logger) : base(client, logger, "/v1/improvements")
        {
        }

        public async Task<ImprovementsPagedValues> GetList()
        {
            var url = BasePath;

            var response = await Client.GetAsync(url);
            if (response.IsSuccessStatusCode)
                return await SerializePayload<ImprovementsPagedValues>(response);
            await HandleError(response);
            return null;
        }
    }
}