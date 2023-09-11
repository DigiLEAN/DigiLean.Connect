namespace DigiLean.Api.Model.V1.Incident
{
    public class IncidentStatusCode
    {
        public IncidentStatusCode(int status = 0)
        {
            Status = status;
        }

        public int Status { get; set; }
    }
}
