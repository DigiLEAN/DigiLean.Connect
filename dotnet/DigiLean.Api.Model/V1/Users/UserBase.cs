using System.ComponentModel.DataAnnotations;

namespace DigiLean.Api.Model.V1.Users
{
    public class UserBase
    {
        [Required]
        [Display(Name = "User name")]
        [EmailAddress(ErrorMessage = "Invalid User name")]
        public string UserName { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; } = string.Empty;

        public bool UseAD { get; set; }
        public string? AzureAdObjectId { get; set; }

        [Required]
        [Display(Name = "First name")]
        public string? FirstName { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Last name")]
        public string? LastName { get; set; } = string.Empty;

        [Display(Name = "Screen name")]
        [MaxLength(6, ErrorMessage = "The screen name cannot be more than 6 characters")]
        public string? ScreenName { get; set; }

        public bool IsInfoScreenUser { get; set; }
        public bool IsMobileUser { get; set; }
        
        public int? BusinessUnitId { get; set; }
    }
}