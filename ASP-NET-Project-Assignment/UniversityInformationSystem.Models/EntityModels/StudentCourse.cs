namespace UniversityInformationSystem.Models.EntityModels
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Users;

    [Table("StudentsCourses")]
    public class StudentCourse
    {
        [Key, Column(Order = 0)]
        [ForeignKey("Student")]
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }

        [Key, Column(Order = 1)]
        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }

        public bool IsTaken { get; set; }
    }
}
