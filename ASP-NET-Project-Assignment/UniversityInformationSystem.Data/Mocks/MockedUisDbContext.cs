namespace UniversityInformationSystem.Data.Mocks
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using Contracts;
    using DbSets;
    using Models.EntityModels;
    using Models.EntityModels.Users;

    public class MockedUisDbContext : IUisDataContext
    {
        public MockedUisDbContext()
        {
            this.Students = new MockedStudentsDbSet();
            this.Teachers = new MockedTeachersDbSet();
            this.Courses = new MockedCoursesDbSet();
            this.StudentsCourses = new MockedDbSet<StudentCourse>();
            this.Messages = new MockedMessagesDbSet();
        }

        public IDbSet<Student> Students { get; set; }
        public IDbSet<Teacher> Teachers { get; set; }
        public IDbSet<Course> Courses { get; set; }
        public IDbSet<StudentCourse> StudentsCourses { get; set; }
        public IDbSet<Message> Messages { get; set; }
        public DbSet<T> Set<T>() where T : class
        {
            return new MockedDbSet<T>();
        }

        // TODO: Implement this
        public DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public int SaveChanges()
        {
            return 0;
        }

        public DbContext DbContext { get; }

        public void Dispose()
        {
            this.DbContext.Dispose();
        }

    }
}
