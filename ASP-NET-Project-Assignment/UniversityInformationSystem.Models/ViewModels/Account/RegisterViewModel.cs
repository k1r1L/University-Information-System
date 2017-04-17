namespace UniversityInformationSystem.Models.ViewModels.Account
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Enums;
    using Utillities;

    public class RegisterViewModel
    {

        [Required]
        [RegularExpression(ValidationConstants.AppUserNameRegex, ErrorMessage = ValidationConstants.ValidationErrorMessages.AppUserNamesMessage)]
        [Display(Name = "First name:")]
        public string FirstName { get; set; }

        [Required]
        [RegularExpression(ValidationConstants.AppUserNameRegex, ErrorMessage = ValidationConstants.ValidationErrorMessages.AppUserNamesMessage)]
        [Display(Name = "Last name:")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Birth date:")]
        public DateTime BirthDate { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email:")]
        public string Email { get; set; }

        [Required]
        [MinLength(ValidationConstants.PasswordMinLength, 
            ErrorMessage = ValidationConstants.ValidationErrorMessages.PasswordErrorMsg)]
        [MaxLength(ValidationConstants.PasswordMaxLength,
            ErrorMessage = ValidationConstants.ValidationErrorMessages.PasswordErrorMsg)]
        [DataType(DataType.Password)]
        [Display(Name = "Password:")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password:")]
        [Compare("Password",
            ErrorMessage = ValidationConstants.ValidationErrorMessages.NonMatchingPassword)]
        public string ConfirmPassword { get; set; }

        [Required]
        [RegularExpression(ValidationConstants.UserNameRegex,
            ErrorMessage = ValidationConstants.ValidationErrorMessages.UserNameErrorMsg)]
        [Display(Name = "Username:")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Type of user:")]
        public UserType UserType { get; set; }
    }
}
