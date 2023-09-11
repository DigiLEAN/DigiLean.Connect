using System.Collections.Generic;

namespace DigiLean.Api.Model.V1.Incident
{
    public class IncidentTypeConfiguration
    {
        public IncidentTypeConfiguration() { }

        public IncidentTypeConfiguration(IncidentType deviationType, 
            List<CustomField> fields, 
            List<Category> categories, 
            List<IncidentTypeConsequence> consequences, 
            List<Cause> causes)
        {
            Id = deviationType.Id;
            Title = deviationType.Title;
            Description = deviationType.Description;
            CustomFields = fields;
            Categories = categories;
            Consequences = consequences;
            Causes = causes;
        }


        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public List<CustomField> CustomFields { get; set; }
        public List<Category> Categories { get; set; }
        public List<IncidentTypeConsequence> Consequences { get; set; }
        public List<Cause> Causes { get; set; }

    }
}
