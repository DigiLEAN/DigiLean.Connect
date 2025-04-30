namespace DigiLean.Api.Model.V1.Incident
{
    public class IncidentSeverityCode
    {
        public IncidentSeverityCode(IncidentSeverity severity = 0)
        {
            Severity = severity;
        }

        public IncidentSeverity Severity { get; set; }
    }
}
