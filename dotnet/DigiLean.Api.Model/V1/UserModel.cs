using System.ComponentModel.DataAnnotations;

namespace DigiLean.Api.Model.V1
{
    public class User
    {
        [Required]
        [Display(Name = "User name")]
        [EmailAddress(ErrorMessage = "Invalid User name")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        public bool UseAD { get; set; }
        public string AzureAdObjectId { get; set; }

        [Required]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last name")]
        public string LastName { get; set; }


        [Display(Name = "Screen name")]
        [MaxLength(6, ErrorMessage = "The screen name cannot be more than 6 characters")]
        public string ScreenName { get; set; }

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
        public string PreferredLanguage { get; set; }
    }
}