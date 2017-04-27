namespace UniversityInformationSystem.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using Contracts;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models.EntityModels;
    using Models.EntityModels.Users;

    public class UisDataContext : IdentityDbContext<ApplicationUser>, IUisDataContext
    {
        public UisDataContext()
            : base("name=UisDataContext")
        {
        }

        public virtual IDbSet<Student> Students { get; set; }

        public virtual IDbSet<Teacher> Teachers { get; set; }

        public virtual IDbSet<Course> Courses { get; set; }

        public virtual IDbSet<StudentCourse> StudentsCourses { get; set; }

        public virtual IDbSet<Message> Messages { get; set; }

        public DbContext DbContext => this;

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