using DigiLean.Api.Model.Clients;
using DigiLean.Api.Model.Common;
using DigiLean.Api.Model.Extensions;
using DigiLean.Api.Model.V1.Boards;
using DigiLean.Api.Model.V1.Tasks;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;

namespace DigiLean.Api.Client.V1
{
    public class BoardsApi : ApiEndpointBase
    {
        public BoardsApi(HttpClient client, ILogger logger) : base(client, logger, "/v1/boards")
        {
        }

        public async Task<List<BoardInfo>> GetAll()
        {
            var response = await Client.GetAsync(BasePath);
            if (response.IsSuccessStatusCode)
                return await SerializePayload<List<BoardInfo>>(response);

            await HandleError(response);
            return null;
        }

        public async Task <Board> GetBoard(int boardId)
        {
            var response = await Client.GetAsync($"{BasePath}/{boardId}");
            if (response.IsSuccessStatusCode)
                return await SerializePayload<Board>(response);
            
            await HandleError(response);
            return null;
        }

        public async Task<List<TaskInfo>> GetTasks(int boardId, TaskQueryParams query)
        {
            var url = $"{BasePath}/{boardId}/tasks";
            var urlWithParams = QueryHelpers.AddQueryString(url, query.GetQueryDictionary());
            var response = await Client.GetAsync(urlWithParams);
            if (response.IsSuccessStatusCode)
                return await SerializePayload<List<TaskInfo>>(response);
            await HandleError(response);
            return null;
        }

        public async Task<TaskInfo> CreateTask(int boardId, TaskBase task)
        {
            var response = await Client.PostAsync($"{BasePath}/{boardId}/tasks", task.AsJson());
            if (response.IsSuccessStatusCode)
                return await SerializePayload<TaskInfo>(response);
            await HandleError(response);
            return null;
        }

        public async Task<TaskPaged> GetTasksFromBoard(int id, TaskQueryParams queryParams = null)
        {
            var response = await Client.GetAsync(BasePath + $"/{id}/tasks");
            if (response.IsSuccessStatusCode)
                return await SerializePayload<TaskPaged>(response);

            await HandleError(response);
            return null;
        }

        public async Task<TaskInfo> CreateTaskForBoard(int boardId, TaskBase task)
        {
            var response = await Client.PostAsync(BasePath + $"/{boardId}/tasks", task.AsJson());
            if (response.IsSuccessStatusCode)
                return await SerializePayload<TaskInfo>(response);

            await HandleError(response);
            return null;
        }
    }
}
