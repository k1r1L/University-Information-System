namespace UniversityInformationSystem.Services
{
    using Contracts;
    using Data.Contracts;
    using Models.EntityModels.Users;
    using Models.Enums;

    public class RegisterService : IRegisterService
    {
        private IDbRepository<Student> students;
        private IDbRepository<Teacher> teachers;

        public RegisterService(IDbRepository<Student> students, IDbRepository<Teacher> teachers)
        {
            this.students = students;
            this.teachers = teachers;
        }

        public void Register(UserType userType, string appUserId)
        { 
            switch (userType)
            {
                case UserType.Student:
                    this.students.Add(new Student()
                    {
                        IdenityUserId = appUserId
                    });
                    this.students.SaveChanges();
                    break;
                case UserType.Teacher:
                    this.teachers.Add(new Teacher()
                    {
                        IdenityUserId = appUserId
                    });
                    this.teachers.SaveChanges();
                    break;
                default:
                    break;
            }
        }

    }
}
