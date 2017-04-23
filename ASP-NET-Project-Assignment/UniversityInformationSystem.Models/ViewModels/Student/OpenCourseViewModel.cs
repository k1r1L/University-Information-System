namespace UniversityInformationSystem.Models.ViewModels.Student
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using Enums;

    public class OpenCourseViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int StudentId { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int CourseId { get; set; }

        [Required]
        public string CourseName { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string TeacherUsername { get; set; }

        [HiddenInput(DisplayValue = false)]
        public Grade Grade { get; set; }
    }
}
