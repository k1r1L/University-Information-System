namespace UniversityInformationSystem.Models.Utillities
{
    public class ValidationConstants
    {
        public const double MinCredits = 3;
        public const double MaxCredits = 18;
        public const int PasswordMinLength = 8;
        public const int PasswordMaxLength = 16;
        public const int CourseNameLength = 50;
        public const int FacultyNumberLength = 10;
        public const int CourseDescriptionLength = 1000;
        public const int MessageTextLength = 500;
        public const string AppUserNameRegex = "^[A-Za-z]+$";
        public const string UserNameRegex = @"^[a-z\d]{5,10}$";
        public const string OpenCourseRegex = "^(Yes|No)$";

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
            public const string InvalidCourseName
                = "The course name length should not be more than 50 symbols";
            public const string InvalidCourseDescription
             = "The course name length should not be more than 1000 symbols";
            public const string InvalidOpenCourseValue
                = "You should type either Yes or No";
            public const string CourseCreditsErrorMsg
                = "A course should give between 3 and 18 credits!";
            public const string NoSuchStudentErrorMsg
                = "No such student!";
            public const string NoSuchCourseErrorMsg
                = "No such course!";
            public const string CourseHasNoTeacherErrorMsg
                = "The given course has no teacher yet!";
            public const string StudentAlreadyEnrolledMsg
                = "The student is already enrolled in the given course!";
        }
    }
}
