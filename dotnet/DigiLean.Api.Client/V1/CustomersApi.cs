using DigiLean.Api.Model.Clients;
using DigiLean.Api.Model.Extensions;
using DigiLean.Api.Model.V1;
using Microsoft.Extensions.Logging;

namespace DigiLean.Api.Client.V1
{
    public class CustomersApi : ApiEndpointBase
    {
        public CustomersApi(HttpClient client, ILogger logger) : base(client, logger, "/v1/customers")
        {
        }
        public async Task<List<ProjectCustomer>> ListCustomers()
        {
            var response = await Client.GetAsync(BasePath);
            if (response.IsSuccessStatusCode)
                return await SerializePayload<List<ProjectCustomer>>(response);

            await HandleError(response);
            return null;
        }

        public async Task<ProjectCustomer> GetCustomer(string customerNumber)
        {
            var response = await Client.GetAsync($"{BasePath}/{customerNumber}");
            if (response.IsSuccessStatusCode)
                return await SerializePayload<ProjectCustomer>(response);

            await HandleError(response);
            return null;
        }

        public async Task<bool> CreateCustomer(ProjectCustomer pm)
        {
            var response = await Client.PostAsync($"{BasePath}", pm.AsJson());
            return response.IsSuccessStatusCode;
        }
    }
}
