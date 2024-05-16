using DigiLean.Api.Client.TestConsoleApp.Scenarioes.Incident;
using DigiLean.Api.Client.TestConsoleApp.Utilities;

namespace DigiLean.Api.Client.TestConsoleApp.Scenarioes.Tasks
{
    public class Task_Update_Existing_Kanban : Scenario
    {
        public async override Task Run(DigiLeanApiClient apiClient)
        {
        
            var task = await apiClient.Version1.Tasks.Get(McKenzieTaskTestSettings.KanbanTaskId);
            task.ColumnCategoryId = McKenzieTaskTestSettings.KanbanToDoColumnId;
            var updated = await apiClient.Version1.Tasks.Update(task.Id, task);
            Console.WriteLine("Task Updated:");
            Console.WriteLine(updated.AsPrintJson());
        }
    }
}
