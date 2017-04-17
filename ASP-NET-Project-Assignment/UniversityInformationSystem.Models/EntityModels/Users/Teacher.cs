namespace UniversityInformationSystem.Models.EntityModels.Users
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Teacher
    {
        public Teacher()
        {
            this.LeadingCourses = new HashSet<Course>();
        }

        public int Id { get; set; }

        public string IdenityUserId { get; set; }

        [ForeignKey("IdenityUserId")]
        public virtual ApplicationUser IdentityUser { get; set; }

        public virtual ICollection<Course> LeadingCourses { get; set; }
    }
}
