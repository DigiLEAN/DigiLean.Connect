namespace DigiLean.Api.Model.V1.Incident
{
    public class IncidentSeverityCode
    {
        public IncidentSeverityCode(int severity = 0)
        {
            Severity = severity;
        }

        public int Severity { get; set; }
    }
}
