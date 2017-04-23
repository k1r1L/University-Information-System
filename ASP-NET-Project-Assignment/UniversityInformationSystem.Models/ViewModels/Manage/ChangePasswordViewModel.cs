namespace UniversityInformationSystem.Models.ViewModels.Manage
{
    using System.ComponentModel.DataAnnotations;
    using Utillities;

    public class ChangePasswordViewModel
    {
        [Required]
        [MinLength(ValidationConstants.PasswordMinLength,
           ErrorMessage = ValidationConstants.ValidationErrorMessages.PasswordErrorMsg)]
        [MaxLength(ValidationConstants.PasswordMaxLength,
           ErrorMessage = ValidationConstants.ValidationErrorMessages.PasswordErrorMsg)]
        [DataType(DataType.Password)]
        [Display(Name = "Current Password:")]
        public string Password { get; set; }

        [Required]
        [MinLength(ValidationConstants.PasswordMinLength,
            ErrorMessage = ValidationConstants.ValidationErrorMessages.PasswordErrorMsg)]
        [MaxLength(ValidationConstants.PasswordMaxLength,
            ErrorMessage = ValidationConstants.ValidationErrorMessages.PasswordErrorMsg)]
        [DataType(DataType.Password)]
        [Display(Name = "New Password:")]
        public string NewPassword { get; set; }


        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password:")]
        [Compare("NewPassword",
            ErrorMessage = ValidationConstants.ValidationErrorMessages.NonMatchingPassword)]
        public string ConfirmPassword { get; set; }
    }
}
