namespace UniversityInformationSystem.Models.Utillities
{
    public class ValidationConstants
    {
        public const int PasswordMinLength = 8;
        public const int PasswordMaxLength = 16;
        public const int CourseNameLength = 50;
        public const int FacultyNumberLength = 10;
        public const int CourseDescriptionLength = 200;
        public const string AppUserNameRegex = "^[A-Za-z]+$";
        public const string UserNameRegex = @"^[a-z\d]{5,10}$";

        public static class ValidationErrorMessages
        {
            public const string PasswordErrorMsg 
                = "The password must be between 8 and 16 symbols";
            public const string NonMatchingPassword 
                = "The password and confirmation password do not match.";
            public const string UserNameErrorMsg 
                = "The username must contain only lowercase letters and digits between 5-10";
            public const string AppUserNamesMessage 
                = "The user first/last name must contain only letters";
        }
    }
}
