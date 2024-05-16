using DigiLean.Api.Client.TestConsoleApp.Utilities;

namespace DigiLean.Api.Client.TestConsoleApp.Scenarioes.Incident
{
    public class Incident_Update_Causes : Scenario
    {
        public async override Task Run(DigiLeanApiClient apiClient)
        {
            var incident = await apiClient.Version1.Incidents.UpdateCauses(IncidentTestSettings.IncidentId, IncidentTestSettings.UpdateCauses);
            Console.WriteLine(incident.AsPrintJson());
        }
    }
}
