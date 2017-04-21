using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityInformationSystem.Models.ViewModels.Teacher
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using Utillities;

    public class TeacherCourseViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required]
        [StringLength(ValidationConstants.CourseNameLength, ErrorMessage = ValidationConstants.ValidationErrorMessages.InvalidCourseName)]
        [Display(Name = "Name:")]
        public string Name { get; set; }

        [Required]
        [StringLength(ValidationConstants.CourseDescriptionLength, ErrorMessage = ValidationConstants.ValidationErrorMessages.InvalidCourseDescription)]
        [Display(Name = "Description:")]
        public string Description { get; set; }

        [HiddenInput(DisplayValue = false)]
        [Display(Name = "Count of enrolled students:")]
        public int StudentsCount { get; set; }
    }
}
