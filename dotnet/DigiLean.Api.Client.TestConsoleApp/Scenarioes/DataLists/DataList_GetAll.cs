namespace DigiLean.Api.Client.TestConsoleApp.Scenarioes.DataList
{
    public class DataList_GetAll : Scenario
    {
        public async override Task Run(DigiLeanApiClient apiClient)
        {
            // Datalist get all lists
            var datalists = await apiClient.Version1.Datalists.GetAll();
            foreach (var dataList in datalists)
            {
                Console.WriteLine($"List: {dataList.Name}");
            }
        }
    }
}
