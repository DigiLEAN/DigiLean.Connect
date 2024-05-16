using DigiLean.Api.Client.TestConsoleApp.Utilities;

namespace DigiLean.Api.Client.TestConsoleApp.Scenarioes.Incident
{
    public class Incident_Update_Categories : Scenario
    {
        public async override Task Run(DigiLeanApiClient apiClient)
        {
            var incident = await apiClient.Version1.Incidents.UpdateCategories(IncidentTestSettings.IncidentId, IncidentTestSettings.UpdateCategories);
            Console.WriteLine(incident.AsPrintJson());
        }
    }
}
