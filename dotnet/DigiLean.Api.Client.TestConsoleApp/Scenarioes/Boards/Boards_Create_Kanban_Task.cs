using DigiLean.Api.Client.TestConsoleApp.Scenarioes.Incident;
using DigiLean.Api.Client.TestConsoleApp.Utilities;
using DigiLean.Api.Model.V1.Tasks;

namespace DigiLean.Api.Client.TestConsoleApp.Scenarioes.Boards
{
    
    public class Boards_Create_Kanban_Task : Scenario
    {
        public async override Task Run(DigiLeanApiClient apiClient)
        {
            // Boards
            var task = new TaskBase
            {
                BoardId = McKenzieTaskTestSettings.KanbanBoardId, 
                Title = "Work order title",
                DueDate = DateTime.UtcNow, // All dates should be in UTC 
                ColumnCategoryId = McKenzieTaskTestSettings.KanbanToDoColumnId,
                RowCategoryId = McKenzieTaskTestSettings.KanbanRowdId,
                Tags = new List<string> 
                {
                    "TAG1", "LOKO"
                }
            };
            var created = await apiClient.Version1.Boards.CreateTask(McKenzieTaskTestSettings.KanbanBoardId, task);
            Console.WriteLine("Task CREATED:");
            Console.WriteLine(created.AsPrintJson());
        }
    }
}
