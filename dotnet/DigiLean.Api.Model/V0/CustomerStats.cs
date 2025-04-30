namespace DigiLean.Api.Model.V0
{
    public record CustomerStats
    {
        public int CustomerId { get; init; }
        public DateTime ValueDate { get; init; }
        public string Action { get; init; } = string.Empty;
        public decimal ActivityCount { get; init; }
    }
}
