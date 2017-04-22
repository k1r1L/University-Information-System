namespace UniversityInformationSystem.Models.ViewModels.Admin
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using Utillities;

    public class UserViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public string Id { get; set; }

        [Display(Name = "Firstname:")]
        [Required]
        [RegularExpression(ValidationConstants.AppUserNameRegex, ErrorMessage = ValidationConstants.ValidationErrorMessages.AppUserNamesMessage)]
        public string FirstName { get; set; }

        [Display(Name = "Lastname:")]
        [Required]
        [RegularExpression(ValidationConstants.AppUserNameRegex, ErrorMessage = ValidationConstants.ValidationErrorMessages.AppUserNamesMessage)]
        public string LastName { get; set; }

        [Display(Name = "Username:")]
        [HiddenInput(DisplayValue = false)]
        public string UserName { get; set; }

        [Required]
        [MinLength(ValidationConstants.PasswordMinLength,
         ErrorMessage = ValidationConstants.ValidationErrorMessages.PasswordErrorMsg)]
        [MaxLength(ValidationConstants.PasswordMaxLength,
         ErrorMessage = ValidationConstants.ValidationErrorMessages.PasswordErrorMsg)]
        [DataType(DataType.Password)]
        [Display(Name = "Set new password:")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password:")]
        [System.ComponentModel.DataAnnotations.Compare("Password",
           ErrorMessage = ValidationConstants.ValidationErrorMessages.NonMatchingPassword)]
        public string PasswordConfirmed { get; set; }
    }
}
