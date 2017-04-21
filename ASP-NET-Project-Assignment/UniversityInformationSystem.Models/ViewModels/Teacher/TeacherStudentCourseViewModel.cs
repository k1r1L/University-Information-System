namespace UniversityInformationSystem.Models.ViewModels.Teacher
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using Enums;
    using Utillities;

    public class TeacherStudentCourseViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int StudentId { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int CourseId { get; set; }

        [Required]
        [Display(Name = "Username of student:")]
        [HiddenInput(DisplayValue = false)]
        public string StudentUsername { get; set; }

        [Required]
        [Display(Name = "Course name:")]
        [StringLength(ValidationConstants.CourseNameLength)]
        [HiddenInput(DisplayValue = false)]
        public string CourseName { get; set; }

        [Required]
        [Display(Name = "Grade:")]
        public Grade Grade { get; set; }
    }
}
