using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace DigiLean.Api.Model.V0
{
    public record LogMessage
    {
        public int Id { get; init; }
        public DateTime Timestamp { get; init; }
        public string? Message { get; init; }
        public Guid? ConnectorId { get; init; }
        public int? JobId { get; init; }
        public int? JobPartId { get; init; }
        public Guid? RunId { get; init; }
        public LogMessageType Type { get; init; }
        public string? Exception { get; init; }
        public TimeSpan Age { get; init; }
    }

    [JsonConverter(typeof(StringEnumConverter), typeof(CamelCaseNamingStrategy))]
    public enum LogMessageType
    {
        Success,
        Error,
        Warning,
        Information,
        JobStarted,
        JobFinished,
        JobFailed
    }
}
