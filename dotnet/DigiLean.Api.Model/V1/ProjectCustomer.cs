using System.ComponentModel.DataAnnotations;

namespace DigiLean.Api.Model.V1
{
    public class ProjectCustomer
    {
        [Required]
        public string CustomerNumber { get; set; } = string.Empty;
        [Required]
        public string Name { get; set; } = string.Empty;
    }
}
