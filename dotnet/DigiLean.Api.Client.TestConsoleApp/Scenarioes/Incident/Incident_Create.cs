using DigiLean.Api.Client.TestConsoleApp.Utilities;
using DigiLean.Api.Model.V1.Incident;

namespace DigiLean.Api.Client.TestConsoleApp.Scenarioes.Incident
{
    public class Incident_Create : Scenario
    {
        public async override Task Run(DigiLeanApiClient apiClient)
        {
            // Incidents
            var newIncident = new IncidentCreate
            {
                IncidentTypeId = IncidentTestSettings.IncidentTypeId, // The type of incident, should match one of your own. Use 
                Title = "Light went off",
                Severity = 1, // 0 to 3. 0 = None, 1 = Low, 2 = Medium, 3 = High
                IncidentDate = DateTime.UtcNow, // All dates should be in UTC 
                Categories = new List<IncidentCategory> // At least one category is required
                {
                    IncidentTestSettings.CreateCategory
                }
            };
            var incident = await apiClient.Version1.Incidents.Create(newIncident);
            Console.WriteLine(incident.AsPrintJson());
            
        }
    }
}
