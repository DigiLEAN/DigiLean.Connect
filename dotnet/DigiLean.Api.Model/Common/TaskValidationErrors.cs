using System.ComponentModel.DataAnnotations;

namespace DigiLean.Api.Model.Common
{
    public class TaskValidationErrors
    {
        public static ValidationResult BoardIdNotValid { get; set; } = new ValidationResult("Board is not valid. The board Id provided is does not exist or has been deleted ", new string[] { "BoardId" });
        public static ValidationResult RowCategoryIdNotValid { get; set; } = new ValidationResult("Row for task is not valid. The RowCategoryId is either empty or not a valid row for the board", new string[] { "RowCategoryId" });
        public static ValidationResult ColumnCategoryIdNotValid { get; set; } = new ValidationResult("ColumnCategory for task is not valid. The ColumnCategoryId is either empty or not a valid column for the board", new string[] { "ColumnCategoryId" });
        public static ValidationResult DueDateRequired { get; set; } = new ValidationResult("Duedate is missing. Duedate must be set on task for this board type", new string[] { "DueDate" });
        public static ValidationResult ResponsibleUserNotValid { get; set; } = new ValidationResult("The responsible userId is not a valid member of this board. ", new string[] { "ResponsibleUserId" });
        public static ValidationResult TaskHasClone { get; set; } = new ValidationResult("The task provided is cloned, and cannot be updated by the API ", new string[] { "Task.Id" });
        public static ValidationResult ParentIdNotValid { get; set; } = new ValidationResult("The task id provided as parent for subtask is not valid", new string[] { "id" });

    }
}
