namespace DigiLean.Api.Model.V1.Incident
{
    public class Incident : IncidentBase
    {
        public string? Project { get; set; }
        public string? IncidentType { get; set; }
        public IncidentSeverity SeverityText => (IncidentSeverity)Severity;
        
        public string? ReportedByGroup { get; set; }
        public string? ReportedByUserId { get; set; }
        public string? ReportedBy { get; set; }
        public DateTime ReportedDate { get; set; }
        public string? FollowUpGroup { get; set; }

        public string? Responsible { get; set; }
        public string? ResponsibleDisplayName { get; set; }

        public DateTime LastModified { get; set; }

        public int NumberOfComments { get; set; }
        public int NumberOfActions { get; set; }
        public int NumberOfAttachments { get; set; }

        public IEnumerable<IncidentConsequence> Consequences { get; set; } = new List<IncidentConsequence>();
        public IEnumerable<IncidentCategory> Categories { get; set; } = new List<IncidentCategory>();
        public IEnumerable<IncidentCause> Causes { get; set; } = new List<IncidentCause>();
        public IEnumerable<IncidentCustomField> CustomFields { get; set; } = new List<IncidentCustomField>();
    }
}