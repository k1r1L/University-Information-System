namespace UniversityInformationSystem.Models.ViewModels.Student
{
    public class StudentProfileViewModel : ProfileViewModel
    {
        public string FacultyNumber { get; set; }

        public int MandatoryCoursesCount { get; set; }

        public int OpenCoursesCount { get; set; }

        public int TakenCoursesCount { get; set; }

        public int UnTakenCoursesCount { get; set; }

        public int TotalCredits { get; set; }
    }
}
