namespace UniversityInformationSystem.Models.ViewModels.Admin
{
    using Enums;

    public class RegisterSuccessViewModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public UserType UserType { get; set; }
    }
}
