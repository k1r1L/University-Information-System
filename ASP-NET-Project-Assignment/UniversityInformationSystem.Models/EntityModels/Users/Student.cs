namespace UniversityInformationSystem.Models.EntityModels.Users
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Utillities;

    public class Student
    {
        public int Id { get; set; }

        public Student()
        {
            this.FacultyNumber = FacultyNumberGenerator.GenerateFacultyNumber();
            this.EnrolledCourses = new HashSet<StudentCourse>();
        }

        [StringLength(ValidationConstants.FacultyNumberLength)]
        [Index(IsUnique = true)]
        public string FacultyNumber { get; set; }

        public virtual ICollection<StudentCourse> EnrolledCourses { get; set; }

        [Required]
        public virtual ApplicationUser IdentityUser { get; set; }
    }
}
