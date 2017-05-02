namespace UniversityInformationSystem.Models.ViewModels.Admin
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using Utillities.Constants;

    public class AdminStudentCourseViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int StudentId { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int CourseId { get; set; }

        [Required]
        [Display(Name = "Username of student:")]
        public string StudentUsername { get; set; }

        [Required]
        [Display(Name = "Course name:")]
        [StringLength(ValidationConstants.CourseNameLength)]
        public string CourseName { get; set; }
    }
}
