namespace DigiLean.Api.Model.V1.Boards
{
    public static class BoardType
    {
        private static List<TaskBoardRules> taskBoards = new List<TaskBoardRules>();
        static BoardType() { 
            taskBoards.Add(new TaskBoardRules(TaskBoardType.Weekly) { HasColumns = true, HasRows = true, HasDueDate = true});
            taskBoards.Add(new TaskBoardRules(TaskBoardType.Kanban) { HasColumns = true, HasRows = true });
            taskBoards.Add(new TaskBoardRules(TaskBoardType.SmartActionList));
            taskBoards.Add(new TaskBoardRules(TaskBoardType.Yearly) { HasRows = true, HasDueDate = true }); ;
        }

        public static bool IsTaskBoard(string boardType)
        {
            return taskBoards.Any(b => b.BoardType.ToString().ToUpper() == boardType.ToUpper());
        }

        public static bool HasRowCategory(string boardType)
        {
            return taskBoards.Any(b => b.BoardType.ToString().ToUpper() == boardType.ToUpper() && b.HasRows);
        }
        public static bool HasColumnCategory(string boardType)
        {
            return taskBoards.Any(b => b.BoardType.ToString().ToUpper() == boardType.ToUpper() && b.HasColumns);
        }

        public static bool HasDueDate(string boardType)
        {
            return taskBoards.Any(b => b.BoardType.ToString().ToUpper() == boardType.ToUpper() && b.HasDueDate);
        }
    }
}
