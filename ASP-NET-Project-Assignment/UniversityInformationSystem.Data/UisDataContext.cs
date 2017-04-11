namespace UniversityInformationSystem.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models.EntityModels;
    using Models.EntityModels.Users;

    public class UisDataContext : IdentityDbContext<ApplicationUser>
    {
        public UisDataContext()
            : base("name=UisDataContext")
        {
        }

        public virtual DbSet<Student> Students { get; set; }

        public virtual DbSet<Teacher> Teachers { get; set; }

        public virtual DbSet<Course> Courses { get; set; }

        public virtual DbSet<StudentCourse> StudentsCourses { get; set; }

        public static UisDataContext Create()
        {
            return new UisDataContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>()
                .HasOptional(c => c.Teacher);

            base.OnModelCreating(modelBuilder);
        }
    }
}