using Microsoft.Extensions.Logging;
using DigiLean.Api.Model.V1.Incident;
using DigiLean.Api.Model.Common;
using DigiLean.Api.Model.Clients;
using System.Text;
using DigiLean.Api.Model.V1.Attachments;
using DigiLean.Api.Model.V1.Tasks;

namespace DigiLean.Api.Client.V1
{
    public class IncidentsApi : ApiEndpointBase
    {
        public IncidentsApi(HttpClient client, ILogger logger) : base(client, logger, "/v1/incidents")
        {
        }

        public Task<Incident> Create(IncidentCreate newIncident)
        {
            var url = $"{BasePath}";
            return PostGetResponseAndHandleError<Incident>(url, newIncident);
        }


        public Task<Incident> Update(IncidentBase incident, int incidentId)
        {
            var url = $"{BasePath}/{incidentId}";
            return PutGetResponseAndHandleError<Incident>(url, incident);
        }

        public Task<Incident> UpdateResponsible(int incidentId, IncidentResponsible responsible)
        {
            var url = $"{BasePath}/{incidentId}/responsible";
            return PutGetResponseAndHandleError<Incident>(url, responsible);
        }

        public Task<Incident> UpdateStatus(int incidentId, IncidentStatus statusCode)
        {
            var url = $"{BasePath}/{incidentId}/status";
            return PutGetResponseAndHandleError<Incident>(url, new IncidentStatusCode(statusCode));
        }

        public async Task<Incident> UpdateExternalId(int incidentId, string externalId)
        {
            var url = $"{BasePath}/{incidentId}/externalId";
            var response = await Client.PutAsync(url, new StringContent(externalId, Encoding.UTF8, "application/json"));
            if (response.IsSuccessStatusCode)
                return await SerializePayload<Incident>(response);
            await HandleError(response);
            return null;
        }

        public Task<Incident> UpdateSeverity(int incidentId, IncidentSeverity severityCode)
        {
            var url = $"{BasePath}/{incidentId}/severity";
            return PutGetResponseAndHandleError<Incident>(url, new IncidentSeverityCode(severityCode));
        }

        public Task<Incident> UpdateCategories(int incidentId, List<IncidentCategory> categories)
        {
            var url = $"{BasePath}/{incidentId}/categories";
            return PutGetResponseAndHandleError<Incident>(url, categories);
        }

        public Task<Incident> UpdateCauses(int incidentId, List<IncidentCause> causes)
        {
            var url = $"{BasePath}/{incidentId}/causes";
            return PutGetResponseAndHandleError<Incident>(url, causes);
        }

        public Task<Incident> UpdateConsequences(int incidentId, List<IncidentConsequence> consequences)
        {
            var url = $"{BasePath}/{incidentId}/consequences";
            return PutGetResponseAndHandleError<Incident>(url, consequences);
        }

        public Task<Incident> GetIncident(int id)
        {
            var url = $"{BasePath}/{id}";
            return GetResponseAndHandleError<Incident>(url);
        }

        public Task<IncidentPagedValues> ListFilteredIncidents(string filter)
        {
            var url = $"{BasePath}?$filter={filter}";
            return GetResponseAndHandleError<IncidentPagedValues>(url);
        }

        public Task<IncidentPagedValues> List(IncidentQueryParams queryParams)
        {
            var url = BasePath + queryParams.GetParamsAsUrl();
            return GetResponseAndHandleError<IncidentPagedValues>(url);
        }

        public Task<IncidentInfoPagedValues> GetTrash()
        {
            var url = $"{BasePath}/trash";
            return GetResponseAndHandleError<IncidentInfoPagedValues>(url);
        }

        public Task<List<IncidentType>> ListTypes()
        {
            var url = $"{BasePath}/types"; ;
            return GetResponseAndHandleError<List<IncidentType>>(url);
        }

        public Task<List<IncidentComment>> GetComments(int id)
        {
            var url = $"{BasePath}/{id}/comments";
            return GetResponseAndHandleError<List<IncidentComment>>(url);
        }

        public Task<List<Attachment>> GetAttachments(int id)
        {
            var url = $"{BasePath}/{id}/attachments";
            return GetResponseAndHandleError<List<Attachment>>(url);
        }

        public Task<IncidentTypeConfiguration> GetConfiguration(int id)
        {
            var url = $"{BasePath}/types/{id}";
            return GetResponseAndHandleError<IncidentTypeConfiguration>(url);
        }

        public Task<List<TaskInfo>> GetActionPoints(int incidentId)
        {
            var url = $"{BasePath}/{incidentId}/tasks";
            return GetResponseAndHandleError<List<TaskInfo>>(url);
        }
    }
}