using Microsoft.Extensions.Logging;
using DigiLean.Api.Model.V1.Incident;
using DigiLean.Api.Model.Common;
using DigiLean.Api.Model.Clients;
using DigiLean.Api.Model.Extensions;
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

        public async Task<Incident> Create(IncidentCreate newIncident)
        {
            var url = $"{BasePath}";

            var response = await Client.PostAsync(url, newIncident.AsJson());
            if (response.IsSuccessStatusCode)
                return await SerializePayload<Incident>(response);
            await HandleError(response);
            return null;
        }

        public async Task<Incident> Update(IncidentBase incident)
        {
            var url = $"{BasePath}";
            var response = await Client.PutAsync(url, incident.AsJson());
            if (response.IsSuccessStatusCode)
                return await SerializePayload<Incident>(response);
            await HandleError(response);
            return null;
        }

        public async Task<Incident> UpdateResponsible(int incidentId, IncidentResponsible responsible)
        {
            var url = $"{BasePath}/{incidentId}/responsible";
            var response = await Client.PutAsync(url, responsible.AsJson());
            if (response.IsSuccessStatusCode)
                return await SerializePayload<Incident>(response);
            await HandleError(response);
            return null;
        }

        public async Task<Incident> UpdateStatus(int incidentId, int statusCode)
        {
            var url = $"{BasePath}/{incidentId}/status";
            var response = await Client.PutAsync(url, new IncidentStatusCode(statusCode).AsJson());
            if (response.IsSuccessStatusCode)
                return await SerializePayload<Incident>(response);
            await HandleError(response);
            return null;
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

        public async Task<Incident> UpdateSeverity(int incidentId, int severityCode)
        {
            var url = $"{BasePath}/{incidentId}/severity";
            var response = await Client.PutAsync(url, new IncidentSeverityCode(severityCode).AsJson());
            if (response.IsSuccessStatusCode)
                return await SerializePayload<Incident>(response);
            await HandleError(response);
            return null;
        }

        public async Task<Incident> UpdateCategories(int incidentId, List<IncidentCategory> categories)
        {
            var url = $"{BasePath}/{incidentId}/categories";
            var response = await Client.PutAsync(url, categories.AsJson());
            if (response.IsSuccessStatusCode)
                return await SerializePayload<Incident>(response);
            await HandleError(response);
            return null;
        }

        public async Task<Incident> UpdateCauses(int incidentId, List<IncidentCause> causes)
        {
            var url = $"{BasePath}/{incidentId}/causes";
            var response = await Client.PutAsync(url, causes.AsJson());
            if (response.IsSuccessStatusCode)
                return await SerializePayload<Incident>(response);
            await HandleError(response);
            return null;
        }

        public async Task<Incident> UpdateConsequences(int incidentId, List<IncidentConsequence> consequences)
        {
            var url = $"{BasePath}/{incidentId}/consequences";
            var response = await Client.PutAsync(url, consequences.AsJson());
            if (response.IsSuccessStatusCode)
                return await SerializePayload<Incident>(response);
            await HandleError(response);
            return null;
        }

        public Task<Incident> Get(int id)
        {
            var url = $"{BasePath}/{id}";
            return GetResponseAndHandleError<Incident>(url);
        }

        public Task<IncidentPagedValues> GetFilteredIncidents(string filter)
        {
            var url = $"{BasePath}?$filter={filter}";
            return GetResponseAndHandleError<IncidentPagedValues>(url);
        }

        public Task<IncidentPagedValues> GetList(IncidentQueryParams queryParams)
        {
            var url = BasePath + queryParams.GetParamsAsUrl();
            return GetResponseAndHandleError<IncidentPagedValues>(url);
        }

        public Task<List<IncidentType>> GetTypes()
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