using DigiLean.Api.Client.TestConsoleApp.Scenarioes.Incident;
using DigiLean.Api.Client.TestConsoleApp.Utilities;
using DigiLean.Api.Model.V1.Tasks;

namespace DigiLean.Api.Client.TestConsoleApp.Scenarioes.Tasks
{
    public class Task_Create_Weekly : Scenario
    {
        public async override Task Run(DigiLeanApiClient apiClient)
        {
            // Boards
            var task = new TaskBase
            {
                BoardId = TaskTestSettings.WeeklyBoardId, // The type of incident, should match one of your own. Use 
                Title = "Light went off",
                DueDate = DateTime.UtcNow, // All dates should be in UTC 
                ColumnCategoryId = TaskTestSettings.WeeklyColumnId,
                RowCategoryId = TaskTestSettings.WeeklyRowdId,
                Tags = new List<string> // At least one category is required
                {
                    "TAG1", "LOKO"
                }
            };
            var created = await apiClient.Version1.Tasks.Create(task);
            Console.WriteLine("Task CREATED:");
            Console.WriteLine(created.AsPrintJson());
        }
    }
}
