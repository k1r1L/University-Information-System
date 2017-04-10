namespace UniversityInformationSystem.Models.ViewModels.Account
{
    using System.ComponentModel.DataAnnotations;

    public class LoginViewModel
    {
        [Required]
        [RegularExpression(@"^[a-z\d]{5,10}$", ErrorMessage = "The username must contain only lowercase letters and digits between 5-10")]
        [Display(Name = "Username:")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}
