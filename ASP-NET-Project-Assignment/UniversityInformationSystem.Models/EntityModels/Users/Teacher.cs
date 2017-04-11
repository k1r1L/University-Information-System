namespace UniversityInformationSystem.Models.EntityModels.Users
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Teacher
    {
        public int Id { get; set; }

        public virtual ICollection<Course> LeadingCourses { get; set; }

        [Required]
        public virtual ApplicationUser IdentityUser { get; set; }
    }
}
