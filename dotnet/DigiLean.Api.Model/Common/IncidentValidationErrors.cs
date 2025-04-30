using System.ComponentModel.DataAnnotations;

namespace DigiLean.Api.Model.Common
{
    public class IncidentValidationErrors
    {
        public static ValidationResult IncidentTypeIdNotValid { get; set; } = new ValidationResult("IncidentTypeId is not valid", new string[] { "IncidentTypeId" });
        public static ValidationResult FollowUpGroupIdNotValid { get; set; } = new ValidationResult("FollowUpGroupId is not valid", new string[] { "FollowUpGroupId" });
        public static ValidationResult ReportedByGroupIdNotValid { get; set; } = new ValidationResult("ReportedByGroupId is not valid", new string[] { "ReportedByGroupId" });
        public static ValidationResult CategoryIsMissing { get; set; } = new ValidationResult("Categories is empty. At least one category is required", ["Categories"]);
        public static ValidationResult CategoryIsNotValid { get; set; } = new ValidationResult("Categories contains at least one Id that is not a valid category for this incidentType", new string[] { "Categories" });
        public static ValidationResult ConsequenceIsNotValid { get; set; } = new ValidationResult("Consequences contains at least one Id that is not a valid category for this incidentType", new string[] { "Consequence" });
        public static ValidationResult CausesIsNotValid { get; set; } = new ValidationResult("Causes contains at least one Id that is not a valid category for this incidentType", new string[] { "Causes" });
        public static ValidationResult ResponsibleNotMemberOfFollowUpGroup { get; set; } = new ValidationResult("Responsible is not member of the follow up group.", new string[] { "ResponsibleUserId" });
        public static ValidationResult ResponsibleNotValid { get; set; } = new ValidationResult("Responsible is not a valid user.", new string[] { "ResponsibleUserId" });
        public static ValidationResult ReasonIsNotValid { get; set; } = new ValidationResult("Reasons contains at least one Id that is not a valid category for this incidentType", new string[] { "Reasons" });
    }
}
