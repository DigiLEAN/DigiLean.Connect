using DigiLean.Api.Model.Clients;
using DigiLean.Api.Model.Extensions;
using DigiLean.Api.Model.V1.Tasks;
using Microsoft.Extensions.Logging;

namespace DigiLean.Api.Client.V1
{
    public class TasksApi : ApiEndpointBase
    {
        public TasksApi(HttpClient client, ILogger logger) : base(client, logger, "/v1/tasks")
        {
        }

        public Task<TaskInfo> Get(int taskId)
        {
            var url = $"{BasePath}/{taskId}";
            return GetResponseAndHandleError<TaskInfo>(url);
        }

        public async Task<TaskInfo> Create(TaskBase task)
        {
            var response = await Client.PostAsync($"{BasePath}/", task.AsJson());
            if (response.IsSuccessStatusCode)
                return await SerializePayload<TaskInfo>(response);
            await HandleError(response);
            return null;

        }

        public async Task<TaskInfo> CreateSubtask(int parentTaskId, TaskBase subTask)
        {
            var response = await Client.PostAsync($"{BasePath}/{parentTaskId}/SubTasks", subTask.AsJson());
            if (response.IsSuccessStatusCode)
                return await SerializePayload<TaskInfo>(response);
            await HandleError(response);
            return null;
        }

        public async Task<TaskInfo> Update(int id, TaskBase task)
        {
            var url = $"{BasePath}/{id}";
            var response = await Client.PutAsync(url, task.AsJson());
            if (response.IsSuccessStatusCode)
                return await SerializePayload<TaskInfo>(response);
            await HandleError(response);
            return null;
        }

        public async Task<bool> Delete(int taskId)
        {
            var url = $"{BasePath}/{taskId}";
            var response = await Client.DeleteAsync(url);
            if (!response.IsSuccessStatusCode)
                await HandleError(response, false);
            return response.IsSuccessStatusCode;
        }
    }
}