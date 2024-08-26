using System.ComponentModel.DataAnnotations;

namespace DigiLean.Api.Model.V1.Users
{
    public class User
    {
        // not present when creating new user
        public string? Id { get; init; }

        [Required]
        [Display(Name = "User name")]
        [EmailAddress(ErrorMessage = "Invalid User name")]
        public string UserName { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        public bool UseAD { get; set; }
        public string? AzureAdObjectId { get; set; }

        [Required]
        [Display(Name = "First name")]
        public string? FirstName { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Last name")]
        public string? LastName { get; set; } = string.Empty;

        public string FullName => FirstName + " " + LastName;

        [Display(Name = "Screen name")]
        [MaxLength(6, ErrorMessage = "The screen name cannot be more than 6 characters")]
        public string? ScreenName { get; set; }

        public bool IsAdmin { get; set; }
        public bool IsBoardDesigner { get; set; }

        public bool IsA3Admin { get; set; }
        public bool IsDeviationAdmin { get; set; }
        public bool IsImprovementAdmin { get; set; }
        public bool IsProjectAdmin { get; set; }
        public bool IsStrategyAdmin { get; set; }
        public bool IsLearningAdmin { get; set; }

        public bool IsDataAdmin { get; set; }

        public bool IsMessageWriter { get; set; }

        public bool IsInfoScreenUser { get; set; }

        public bool IsMobileUser { get; set; }
        public string? PreferredLanguage { get; set; }
        public int? BusinessUnitId { get; set; }
    }
}