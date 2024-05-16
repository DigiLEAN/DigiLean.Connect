using DigiLean.Api.Client.TestConsoleApp.Utilities;

namespace DigiLean.Api.Client.TestConsoleApp.Scenarioes.Incident
{
    public class Incident_Update_Consequences : Scenario
    {
        public async override Task Run(DigiLeanApiClient apiClient)
        {
            var incident = await apiClient.Version1.Incidents.UpdateConsequences(IncidentTestSettings.IncidentId,IncidentTestSettings.UpdateConsequences);
            Console.WriteLine(incident.AsPrintJson());
        }
    }
}
