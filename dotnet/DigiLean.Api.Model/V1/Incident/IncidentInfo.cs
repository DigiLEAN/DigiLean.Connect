namespace DigiLean.Api.Model.V1.Incident
{
    public class IncidentInfo : IncidentBase
    {
        public int Id { get; set; }
        public string? Project { get; set; }
        public string? IncidentType { get; set; }
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
    }
}