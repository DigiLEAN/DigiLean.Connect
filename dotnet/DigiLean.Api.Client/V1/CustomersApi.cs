using DigiLean.Api.Model.Clients;
using DigiLean.Api.Model.Extensions;
using DigiLean.Api.Model.V1.Projects;
using Microsoft.Extensions.Logging;

namespace DigiLean.Api.Client.V1
{
    public class CustomersApi : ApiEndpointBase
    {
        public CustomersApi(HttpClient client, ILogger logger) : base(client, logger, "/v1/customers")
        {
        }

        public Task<List<ProjectCustomer>> ListCustomers()
        {
            return GetResponseAndHandleError<List<ProjectCustomer>>(BasePath);
        }

        public Task<ProjectCustomer> GetCustomer(string customerNumber)
        {
            var url = $"{BasePath}/{customerNumber}";
            return GetResponseAndHandleError<ProjectCustomer>(url);
        }

        public async Task<bool> CreateCustomer(ProjectCustomer pm)
        {
            var response = await Client.PostAsync($"{BasePath}", pm.AsJson());
            return response.IsSuccessStatusCode;
        }
    }
}