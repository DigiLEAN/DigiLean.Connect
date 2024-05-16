namespace DigiLean.Api.Client.TestConsoleApp.Scenarioes.Incident
{
    public class Incident_GetAll : Scenario
    {
        public async override Task Run(DigiLeanApiClient apiClient)
        {
            // Incidents
            var incidents = await apiClient.Version1.Incidents.GetList(new Model.Common.IncidentQueryParams());
            foreach (var incident in incidents.Values)
            {
                Console.WriteLine($"incident: Id: {incident.Id}, Title: {incident.Title}");
            }
        }
    }
}
