using DigiLean.Api.Client.TestConsoleApp.Utilities;
using DigiLean.Api.Model.V1.Incident;

namespace DigiLean.Api.Client.TestConsoleApp.Scenarioes.Incident
{
    public class Incident_Update : Scenario
    {
        public async override Task Run(DigiLeanApiClient apiClient)
        {
            // get existing
            var existing = await apiClient.Version1.Incidents.Get(IncidentTestSettings.IncidentId);
            // Apply updates
            existing.Status = (int)IncidentStatus.InProgress;
            existing.Severity = (int)IncidentSeverity.Medium;
            existing.Title = "Updated by API - Bad stuff happened";
            existing.Text = "Some cool automatic stuff happening here";
            existing.IncidentDate = DateTime.UtcNow; // All dates should be in UTC 
            existing.EvaluationStatus = 0;
            existing.EvaluationText = "No effect";
            // Followup
            existing.FollowUpGroupId = IncidentTestSettings.FollowUpGroupId;
            existing.ResponsibleUserId = IncidentTestSettings.ResponsibleUserId;
            // Commit changes
            var incident = await apiClient.Version1.Incidents.Update(existing);
            Console.WriteLine(incident.AsPrintJson());

        }
    }
}
