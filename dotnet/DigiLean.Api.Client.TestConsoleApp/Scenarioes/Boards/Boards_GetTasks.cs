using DigiLean.Api.Client.TestConsoleApp.Scenarioes.Incident;
using DigiLean.Api.Client.TestConsoleApp.Utilities;
using DigiLean.Api.Model.Common;

namespace DigiLean.Api.Client.TestConsoleApp.Scenarioes.Boards
{
    public class Boards_GetTasks: Scenario
    {
        public async override Task Run(DigiLeanApiClient apiClient)
        {
            // Boards
            var query = new TaskQueryParams
            {
                From = DateTime.UtcNow.AddDays(-30),
            };
            var created = await apiClient.Version1.Boards.GetTasks(TaskTestSettings.WeeklyBoardId, query);
            Console.WriteLine("Task CREATED:");
            Console.WriteLine(created.AsPrintJson());
        }
    }
}
