namespace UniversityInformationSystem.Models.ViewModels.Admin
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using Utillities;

    public class AdminCourseViewModel
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

        [Required]
        [Display(Name = "Open Course:")]
        [RegularExpression(ValidationConstants.OpenCourseRegex, ErrorMessage = ValidationConstants.ValidationErrorMessages.InvalidOpenCourseValue)]
        public string IsOpen { get; set; }

        [Required]
        [Range(ValidationConstants.MinCredits, ValidationConstants.MaxCredits,
             ErrorMessage = ValidationConstants.ValidationErrorMessages.CourseCreditsErrorMsg)]
        [Display(Name = "Credits:")]
        public double Credits { get; set; }

        [Required]
        [Display(Name = "Teacher:")]
        [UIHint("TeacherEditor")]
        public CourseTeacherViewModel Teacher { get; set; }
    }
}
