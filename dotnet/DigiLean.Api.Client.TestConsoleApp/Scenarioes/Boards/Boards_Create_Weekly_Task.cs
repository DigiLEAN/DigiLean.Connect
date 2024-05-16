using DigiLean.Api.Client.TestConsoleApp.Scenarioes.Incident;
using DigiLean.Api.Client.TestConsoleApp.Utilities;
using DigiLean.Api.Model.V1.Tasks;

namespace DigiLean.Api.Client.TestConsoleApp.Scenarioes.Boards
{

    public class Boards_Create_Weekly_Task : Scenario
    {
        public async override Task Run(DigiLeanApiClient apiClient)
        {
            // Boards
            var task = new TaskBase
            {
                BoardId = TaskTestSettings.WeeklyBoardId, 
                Title = "Light went off",
                DueDate = DateTime.UtcNow, // All dates should be in UTC 
                ColumnCategoryId = TaskTestSettings.WeeklyColumnId,
                RowCategoryId = TaskTestSettings.WeeklyRowdId,
                Tags = new List<string>
                {
                    "TAG1", "LOKO"
                }
            };
            var created = await apiClient.Version1.Boards.CreateTask(TaskTestSettings.WeeklyBoardId, task);
            Console.WriteLine("Task CREATED:");
            Console.WriteLine(created.AsPrintJson());
        }
    }
}
