using DigiLean.Api.Model.Clients;
using DigiLean.Api.Model.V1;
using Microsoft.Extensions.Logging;

namespace DigiLean.Api.Client.V1
{
    public class ProjectsApi : ApiEndpointBase
    {
        public ProjectsApi(HttpClient client, ILogger logger) : base(client, logger, "/v1/projects")
        {
        }

        public async Task<List<Project>> ListProjects()
        {
            var response = await Client.GetAsync(BasePath);
            if (response.IsSuccessStatusCode)
                return await SerializePayload<List<Project>>(response);

            await HandleError(response);
            return null;
        }

        public async Task<Project> GetProject(string projectNumber)
        {
            var response = await Client.GetAsync($"{BasePath}/{projectNumber}");
            if (response.IsSuccessStatusCode)
                return await SerializePayload<Project>(response);

            await HandleError(response);
            return null;
        }
    }
}
