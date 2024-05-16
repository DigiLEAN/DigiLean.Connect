using DigiLean.Api.Model.V1.Incident;

namespace DigiLean.Api.Client.TestConsoleApp.Scenarioes.Incident
{
    public static class IncidentTestSettings
    {
        public static int IncidentId => 1835;
        public static int IncidentTypeId => 478; // Quality type
        public static int FollowUpGroupId => 4026;
        public static string ResponsibleUserId => "fa2f1545-2951-45d9-833a-c6ff0cce4dfd";//DigiLEAN support user    "43cfa621-7592-4d67-a64d-08f24921c7b7"; // Adam user id

        public static IncidentCategory CreateCategory = new IncidentCategory { Id = 2834 };

        public static List<IncidentCategory> UpdateCategories = new List<IncidentCategory>
        {
            new IncidentCategory { Id = 2837 },
            new IncidentCategory { Id = 2834 },
        };

        public static List<IncidentCause> UpdateCauses = new List<IncidentCause>
        {
            new IncidentCause { Id = 3201 },
            new IncidentCause { Id = 3199 },
        };
        public static List<IncidentConsequence> UpdateConsequences = new List<IncidentConsequence>
        {
            new IncidentConsequence { Id = 1369, Amount = 12 },
            new IncidentConsequence { Id = 1371, Amount= 1200.20 },
        };
    }
}
