using DigiLean.Api.Client.TestConsoleApp.Utilities;
using DigiLean.Api.Model.V1.Incident;

namespace DigiLean.Api.Client.TestConsoleApp.Scenarioes.Incident
{
    public class Incident_Update_Status : Scenario
    {
        public async override Task Run(DigiLeanApiClient apiClient)
        {
            var incident = await apiClient.Version1.Incidents.UpdateStatus(IncidentTestSettings.IncidentId, (int) IncidentStatus.InProgress);
            Console.WriteLine(incident.AsPrintJson());
        }
    }
}
