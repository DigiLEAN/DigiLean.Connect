using DigiLean.Api.Client.TestConsoleApp.Utilities;

namespace DigiLean.Api.Client.TestConsoleApp.Scenarioes.Incident
{
    public class IncidentType_GetConfiguration : Scenario
    {
        public async override Task Run(DigiLeanApiClient apiClient)
        {
            // Incidents

            var incidentType = await apiClient.Version1.Incidents.GetConfiguration(IncidentTestSettings.IncidentTypeId);
            Console.WriteLine(incidentType.AsPrintJson());
            
        }
    }
}
