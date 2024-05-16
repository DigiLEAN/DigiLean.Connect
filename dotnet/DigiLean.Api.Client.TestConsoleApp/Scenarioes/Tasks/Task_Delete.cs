namespace DigiLean.Api.Client.TestConsoleApp.Scenarioes.Tasks
{
    public class Task_Delete : Scenario
    {
        public async override Task Run(DigiLeanApiClient apiClient)
        {
            var status = await apiClient.Version1.Tasks.Delete(182726);
            Console.WriteLine("Task Deleted status:" + status);
           
        }
    }
}
