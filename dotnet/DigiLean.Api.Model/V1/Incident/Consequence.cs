namespace DigiLean.Api.Model.V1.Incident
{
    public class Consequence
    {
        public int Id { get; set; } // Loss type id
        public string Title { get; set; } = string.Empty;
        public double Amount { get; set; }
        public string? Unit { get; set; }
    }
}