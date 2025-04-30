namespace DigiLean.Api.Model.V1.Incident
{
    public class IncidentStatusCode
    {
        public IncidentStatusCode(IncidentStatus status = IncidentStatus.New)
        {
            Status = status;
        }

        public IncidentStatus Status { get; set; }
    }
}
