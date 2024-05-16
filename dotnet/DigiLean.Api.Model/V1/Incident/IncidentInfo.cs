using System;
using System.Collections.Generic;

namespace DigiLean.Api.Model.V1.Incident
{
    public class IncidentInfo
    {
        public int Id { get; set; }
        public int Status { get; set; }
        public IncidentStatus StatusText => (IncidentStatus)Status;
        public int DeviationTypeId { get; set; }
        public string DeviationType { get; set; }
        public int Severity { get; set; }
        public IncidentSeverity SeverityText => (IncidentSeverity)Severity;
        public int? ReportedByGroupId { get; set; }
        public string ReportedByGroup { get; set; }
        public int? FollowUpGroupId { get; set; }
        public string FollowUpGroup { get; set; }
        public string Text { get; set; }
        public string Title { get; set; }
        public DateTime LastModified { get; set; }
        public string ReportedByUserId { get; set; }
        public string ReportedBy { get; set; }
        public DateTime IncidentDate { get; set; }
        public DateTime? ResolvedDate { get; set; }
        public DateTime? DueDate { get; set; }
        public string ResponsibleUserId { get; set; }
        public string Responsible { get; set; }
        public int? ProjectId { get; set; }
        public string Project { get; set; }
        public int NumberOfComments { get; set; }
        public int NumberOfActions { get; set; }
        public int NumberOfAttachments { get; set; }
        public string ExternalId {  get; set; }
        public IEnumerable<IncidentConsequence> Consequences { get; set; } = new List<IncidentConsequence>();
        public IEnumerable<IncidentCategory> Categories { get; set; } = new List<IncidentCategory>();
        public IEnumerable<IncidentCause> Causes { get; set; } = new List<IncidentCause>();

        [Obsolete("Replaced by Causes")]
        public IEnumerable<IncidentCause> Reasons { get { return Causes; } }
        public IEnumerable<IncidentCustomField> CustomFields { get; set; } = new List<IncidentCustomField>();
    }
}
