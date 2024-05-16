namespace DigiLean.Api.Client.TestConsoleApp.Scenarioes.Incident
{
    public class IncidentType_GetAll : Scenario
    {
        public async override Task Run(DigiLeanApiClient apiClient)
        {
            // Incidents
            var incidentTypes = await apiClient.Version1.Incidents.GetTypes();
            foreach (var type in incidentTypes)
            {
                Console.WriteLine($"incident type:{type.Id} - {type.Title} - {type.Description}");
            }
        }
    }
}
