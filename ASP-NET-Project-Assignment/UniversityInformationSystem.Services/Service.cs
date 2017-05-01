namespace UniversityInformationSystem.Services
{
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
            this.ApplicationUserRepository = new DbRepository<ApplicationUser>(dbContext);
            this.CoursesRepository = new DbRepository<Course>(dbContext);
            this.StudentRepository = new DbRepository<Student>(dbContext);
            this.TeacherRepository = new DbRepository<Teacher>(dbContext);
            this.StudentsCoursesRepository = new DbRepository<StudentCourse>(dbContext);
            this.MessagesRepository = new DbRepository<Message>(dbContext);
        }

        protected DbRepository<ApplicationUser> ApplicationUserRepository { get; set; }

        protected DbRepository<Student> StudentRepository { get; set; }

        protected DbRepository<Teacher> TeacherRepository { get; set; }

        protected DbRepository<Course> CoursesRepository { get; set; }

        protected DbRepository<StudentCourse> StudentsCoursesRepository { get; set; }

        protected DbRepository<Message> MessagesRepository { get; set; }

        protected IUisDataContext Context
        {
            get { return this.dbContext; }
        }

        protected int SaveChanges()
        {
            return this.dbContext.SaveChanges();
        }


        protected void SeedCourses()
        {
            foreach (Course course in dbContext.Courses)
            {
                this.CoursesRepository.Add(course);
            }
        }

        protected void SeedTeachers()
        {
            foreach (Teacher teacher in dbContext.Teachers)
            {
                this.TeacherRepository.Add(teacher);
                this.ApplicationUserRepository.Add(teacher.IdentityUser);
            }
        }

        protected void SeedStudents()
        {
            foreach (Student student in dbContext.Students)
            {
                this.StudentRepository.Add(student);
                this.ApplicationUserRepository.Add(student.IdentityUser);
            }
        }

        protected void SeedStudentsCourses()
        {
            foreach (StudentCourse studentCourse in dbContext.StudentsCourses)
            {
                this.StudentsCoursesRepository.Add(studentCourse);
            }
        }

    }
}
