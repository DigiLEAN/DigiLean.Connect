using DigiLean.Api.Model.Clients;
using DigiLean.Api.Model.Extensions;
using DigiLean.Api.Model.V1;
using DigiLean.Api.Model.V1.Projects;
using DigiLean.Api.Model.V1.Tasks;
using Microsoft.Extensions.Logging;

namespace DigiLean.Api.Client.V1
{
    public class ProjectsApi : ApiEndpointBase
    {
        public ProjectsApi(HttpClient client, ILogger logger) : base(client, logger, "/v1/projects")
        {
        }

        public Task<List<Project>> ListProjects()
        {
            return GetResponseAndHandleError<List<Project>>(BasePath);
        }

        public Task<Project> GetProject(string projectNumber)
        {
            var url = $"{BasePath}/{projectNumber}";
            return GetResponseAndHandleError<Project>(url);
        }

        public async Task<Project?> CreateProject(ProjectCreate pm)
        {
            var response = await Client.PostAsync(BasePath, pm.AsJson());

            if (response.IsSuccessStatusCode)
                return await SerializePayload<Project>(response);

            await HandleError(response);
            return null;
        }

        public Task<List<ProjectMilestone>> GetProjectMilestones(string projectNumber)
        {
            var url = $"{BasePath}/{projectNumber}/milestones";
            return GetResponseAndHandleError<List<ProjectMilestone>>(url);
        }

        public Task<List<TaskInfo>> GetProjectTasks(string projectNumber)
        {
            var url = $"{BasePath}/{projectNumber}/tasks";
            return GetResponseAndHandleError<List<TaskInfo>>(url);
        }
    }
}