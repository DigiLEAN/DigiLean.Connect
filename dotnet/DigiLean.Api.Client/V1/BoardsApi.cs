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

        public Task<List<BoardInfo>> GetAll()
        {
            return GetResponseAndHandleError<List<BoardInfo>>(BasePath);
        }

        public Task <Board> GetBoard(int boardId)
        {
            var url = $"{BasePath}/{boardId}";
            return GetResponseAndHandleError<Board>(url);
        }

        public Task<List<TaskInfo>> GetTasks(int boardId, TaskQueryParams query)
        {
            var url = $"{BasePath}/{boardId}/tasks";
            var urlWithParams = QueryHelpers.AddQueryString(url, query.GetQueryDictionary());

            return GetResponseAndHandleError<List<TaskInfo>>(urlWithParams);
        }

        public async Task<TaskInfo> CreateTask(int boardId, TaskBase task)
        {
            var response = await Client.PostAsync($"{BasePath}/{boardId}/tasks", task.AsJson());
            if (response.IsSuccessStatusCode)
                return await SerializePayload<TaskInfo>(response);
            await HandleError(response);
            return null;
        }

        public Task<TaskPaged> GetTasksFromBoard(int id, TaskQueryParams queryParams = null)
        {
            var url = $"{BasePath}/{id}/tasks";
            return GetResponseAndHandleError<TaskPaged>(url);
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
