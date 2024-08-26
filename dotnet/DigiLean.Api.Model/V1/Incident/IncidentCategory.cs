using System.ComponentModel.DataAnnotations;

namespace DigiLean.Api.Model.V1.Incident
{
    public class IncidentCategory
    {
        [Required]
        public int Id { get; set; }
        public string? Title { get; set; } = string.Empty;
    }
}
