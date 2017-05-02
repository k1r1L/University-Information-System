namespace UniversityInformationSystem.Models.ViewModels.Account
{
    using System.ComponentModel.DataAnnotations;
    using Utillities.Constants;

    public class LoginViewModel
    {
        [Required]
        [RegularExpression(ValidationConstants.UserNameRegex, ErrorMessage = ValidationConstants.ValidationErrorMessages.UserNameErrorMsg)]
        [Display(Name = "Username:")]
        public string UserName { get; set; }

        [Required]
        [MinLength(ValidationConstants.PasswordMinLength, ErrorMessage = ValidationConstants.ValidationErrorMessages.PasswordErrorMsg)]
        [MaxLength(ValidationConstants.PasswordMaxLength, ErrorMessage = ValidationConstants.ValidationErrorMessages.PasswordErrorMsg)]
        [DataType(DataType.Password)]
        [Display(Name = "Password:")]
        public string Password { get; set; }

    }
}
