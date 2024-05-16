using DigiLean.Api.Client.TestConsoleApp.Utilities;
using DigiLean.Api.Model.V1.Incident;

namespace DigiLean.Api.Client.TestConsoleApp.Scenarioes.Incident
{
    public class Incident_Update_Responsible : Scenario
    {
        public async override Task Run(DigiLeanApiClient apiClient)
        {
            var incident = await apiClient.Version1.Incidents.UpdateResponsible(IncidentTestSettings.IncidentId, 
                new IncidentResponsible(IncidentTestSettings.FollowUpGroupId, IncidentTestSettings.ResponsibleUserId));
            Console.WriteLine(incident.AsPrintJson());
        }
    }
}
