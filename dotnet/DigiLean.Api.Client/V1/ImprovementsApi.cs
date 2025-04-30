using DigiLean.Api.Model.Clients;
using DigiLean.Api.Model.V1.Improvements;
using Microsoft.Extensions.Logging;

namespace DigiLean.Api.Client.V1
{
    public class ImprovementsApi : ApiEndpointBase
    {
        public ImprovementsApi(HttpClient client, ILogger logger) : base(client, logger, "/v1/improvements")
        {
        }

        public Task<ImprovementsPagedValues> GetList()
        {
            return GetResponseAndHandleError<ImprovementsPagedValues>(BasePath);
        }
    }
}