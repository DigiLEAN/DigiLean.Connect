using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace DigiLean.Api.Model.V1.Users
{
    public class UserNotificationUpdate
    {
        public NotificationType Type { get; set; }

        public bool Email { get; set; }

        public bool Mobile { get; set; }

    }
    public class UserNotification : UserNotificationUpdate
    {
        public DateTime? LastModified { get; set; }

        public override string ToString()
        {
            return $"Email={Email} Mobile={Mobile} - {Type}. LastModified {LastModified:u}";
        }
    }

    [JsonConverter(typeof(StringEnumConverter), typeof(DefaultNamingStrategy))]
    public enum NotificationType
    {
        All,
        TaskAssigned,
        TaskComment,
        UpdatedResponsibleSuggestion,
        ImprovementChangedStatus,
        ImprovementComment,
        NewDeviation,
        UpdatedResponsibleDeviation,
        DeviationComment,
        ProjectMessageAdded,
        A3Participant,
        A3Updated,
        PageCommentAdded,
        CommentMentions,
        WeeklyTaskStatus
    }
}
