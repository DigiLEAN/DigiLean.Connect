using System.Collections.Generic;

namespace DigiLean.Api.Model.V1.Incident
{
    public class Incident: IncidentBase
    {
        public string Project { get; set; }
        public string IncidentType { get; set; }
        public IEnumerable<IncidentConsequence> Consequences { get; set; } = new List<IncidentConsequence>();
        public IEnumerable<IncidentCategory> Categories { get; set; } = new List<IncidentCategory>();
        public IEnumerable<IncidentCause> Causes { get; set; } = new List<IncidentCause>();
        public IEnumerable<IncidentCustomField> CustomFields { get; set; } = new List<IncidentCustomField>();
    }
}
