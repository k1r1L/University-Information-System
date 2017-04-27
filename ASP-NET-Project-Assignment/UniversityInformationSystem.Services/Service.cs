namespace UniversityInformationSystem.Services
{
    using Contracts;
    using Data.Contracts;
    using Data.Repositories;
    using Models.EntityModels;
    using Models.EntityModels.Users;

    public abstract class Service
    {
        private readonly IUisDataContext dbContext;

        protected Service(IUisDataContext dbContext)
        {
            this.dbContext = dbContext;
        }

        protected DbRepository<ApplicationUser> ApplicationUserRepository => new DbRepository<ApplicationUser>(this.Context);

        protected DbRepository<Student> StudentRepository => new DbRepository<Student>(this.Context);

        protected DbRepository<Teacher> TeacherRepository => new DbRepository<Teacher>(this.Context);

        protected DbRepository<Course> CoursesRepository => new DbRepository<Course>(this.Context);

        protected DbRepository<StudentCourse> StudentsCoursesRepository => new DbRepository<StudentCourse>(this.Context);

        protected DbRepository<Message> MessagesRepository => new DbRepository<Message>(this.Context);

        protected IUisDataContext Context
        {
            get { return this.dbContext; }
        }

        protected int SaveChanges()
        {
            return this.dbContext.SaveChanges();
        }
    }
}
