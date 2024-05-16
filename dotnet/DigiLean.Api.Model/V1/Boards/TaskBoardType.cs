using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace DigiLean.Api.Model.V1.Boards
{
    
    [JsonConverter(typeof(StringEnumConverter), typeof(DefaultNamingStrategy))]
    public enum TaskBoardType
    {
        Weekly,
        Kanban,
        SmartActionList,
        Yearly
    }

    public class TaskBoardRules
    {
        public TaskBoardRules(TaskBoardType boardType)
        {
            BoardType = boardType;
        }

        public bool HasRows { get; set; }
        public bool HasColumns { get; set; }
        public bool HasDueDate { get; set; }
        public TaskBoardType BoardType { get; }
    }
}
