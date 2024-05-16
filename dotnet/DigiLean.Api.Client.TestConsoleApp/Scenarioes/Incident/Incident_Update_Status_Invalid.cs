using DigiLean.Api.Client.TestConsoleApp.Utilities;

namespace DigiLean.Api.Client.TestConsoleApp.Scenarioes.Incident
{
    public class Incident_Update_Status_Invalid : Scenario
    {
        public async override Task Run(DigiLeanApiClient apiClient)
        {
            var incident = await apiClient.Version1.Incidents.UpdateStatus(IncidentTestSettings.IncidentId, 9999);
            Console.WriteLine(incident.AsPrintJson());
        }
    }
}
