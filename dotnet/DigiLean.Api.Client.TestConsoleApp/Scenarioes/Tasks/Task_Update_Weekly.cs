using DigiLean.Api.Client.TestConsoleApp.Scenarioes.Incident;
using DigiLean.Api.Client.TestConsoleApp.Utilities;
using DigiLean.Api.Model.V1.Tasks;

namespace DigiLean.Api.Client.TestConsoleApp.Scenarioes.Tasks
{
    public class Task_Update_Weekly : Scenario
    {
        public async override Task Run(DigiLeanApiClient apiClient)
        {
            // Boards
            var task = new TaskInfo
            {
                Id = TaskTestSettings.WeeklyTaskId,
                BoardId = TaskTestSettings.WeeklyBoardId, // The type of incident, should match one of your own. Use 
                Title = "Updated by Weekly 2",
                Description = "<b>Bold text here</b>",
                DueDate = DateTime.UtcNow, // All dates should be in UTC 
                ColumnCategoryId = TaskTestSettings.WeeklyColumnId,
                RowCategoryId = TaskTestSettings.WeeklyRowdId,
                Tags = new List<string> // At least one category is required
                {
                    "API", "COOL", "POLICE"
                }
            };
            var updated = await apiClient.Version1.Tasks.Update(task.Id, task);
            Console.WriteLine("Task Updated:");
            Console.WriteLine(updated.AsPrintJson());
        }
    }
}
