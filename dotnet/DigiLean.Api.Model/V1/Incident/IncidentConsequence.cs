namespace DigiLean.Api.Model.V1.Incident
{
    public class IncidentConsequence
    {
        public string Unit { get; set; } = string.Empty;
        public double? Amount { get; set; }
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
    }
}
