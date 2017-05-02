namespace UniversityInformationSystem.Services
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using AutoMapper;
    using Contracts;
    using Data.Contracts;
    using Data.Mocks.Repositories;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models.EntityModels;
    using Models.EntityModels.Users;
    using Models.Enums;
    using Models.ViewModels.Admin;

    public class UsersService : Service, IUsersService
    {
        public UsersService(IUisDataContext dbContext) 
            : base(dbContext)
        {
        }

        public UsersService(IUisDataContext dbContext, MockedUsersRepository mockedUsersRepository)
            : base(dbContext)
        {
            this.ApplicationUserRepository = mockedUsersRepository;
            this.SeedStudents();
            this.SeedTeachers();
        }

        public void Register(UserType userType, string appUserId)
        {
            switch (userType)
            {
                case UserType.Student:
                    this.StudentRepository.Add(new Student()
                    {
                        IdenityUserId = appUserId
                    });
                    this.SaveChanges();
                    break;
                case UserType.Teacher:
                    this.TeacherRepository.Add(new Teacher()
                    {
                        IdenityUserId = appUserId
                    });
                    this.SaveChanges();
                    break;
                default:
                    break;
            }
        }

        public ApplicationUser GetUserByUsername(string username)
        {
            return this.ApplicationUserRepository
                .All()
                .Single(u => u.UserName == username);;
        }

        public AdminProfileViewModel GetAdminProfileViewModel(string username)
        {
            ApplicationUser appUser = this.GetUserByUsername(username);

            return Mapper.Map<AdminProfileViewModel>(appUser);
        }

        public IQueryable<UserViewModel> GetAll()
        {
            IEnumerable<ApplicationUser> allUsersInDb = this.ApplicationUserRepository
                .All()
                .Where(u => u.UserName != "kirilvk1");
            IEnumerable<UserViewModel> allUserVms = Mapper.Map<IEnumerable<UserViewModel>>(allUsersInDb);

            return allUserVms.AsQueryable();
        }

        public bool UserExists(string userId)
        {
            return this.ApplicationUserRepository
                .All()
                .Any(u => u.Id == userId);
        }

        public void Update(UserViewModel userVm, UserManager<ApplicationUser> userManager)
        {
            UserStore<ApplicationUser> userStore = new UserStore<ApplicationUser>(this.Context.DbContext);
            ApplicationUser user = this.ApplicationUserRepository.GetById(userVm.Id);
            string newPasswordHashed = userManager.PasswordHasher.HashPassword(userVm.Password);
            userStore.SetPasswordHashAsync(user, newPasswordHashed);
            user.FirstName = userVm.FirstName;
            user.LastName = userVm.LastName;
            this.SaveChanges();
        }

        public void Delete(string userId)
        {
            ApplicationUser appUser = this.ApplicationUserRepository.GetById(userId);
            Teacher teacherEntity = this.TeacherRepository.All().FirstOrDefault(t => t.IdentityUser.Id == userId);
            Student studentEntity = this.StudentRepository.All().FirstOrDefault(s => s.IdentityUser.Id == userId);

            if (teacherEntity != null)
            {
                DeleteTeacher(teacherEntity);
            }

            if (studentEntity != null)
            {
                DeleteStudent(studentEntity);
            }

            DeleteMessages(userId);
            this.ApplicationUserRepository.Delete(appUser);
            this.SaveChanges();
        }

        private void DeleteMessages(string userId)
        {
            List<Message> messages =
                            this.MessagesRepository
                            .All()
                            .Where(m => m.ReceiverId == userId || m.SenderId == userId)
                            .ToList();
            foreach (Message message in messages)
            {
                this.Context.Entry(message).State = EntityState.Deleted;
            }

            this.SaveChanges();
        }

        private void DeleteTeacher(Teacher teacherEntity)
        {
            List<Course> courses = this.CoursesRepository
                                .All()
                                .Where(c => c.TeacherId == teacherEntity.Id)
                                .ToList();
            foreach (Course course in courses)
            {
                course.Teacher = null;
            }

            this.TeacherRepository.Delete(teacherEntity);
            this.SaveChanges();
        }

        private void DeleteStudent(Student studentEntity)
        {
            List<StudentCourse> enrolledCourses = studentEntity.EnrolledCourses.ToList();
            foreach (StudentCourse enrolledCourse in enrolledCourses)
            {
                this.Context.Entry(enrolledCourse).State = EntityState.Deleted;
            }

            this.StudentRepository.Delete(studentEntity);
            this.SaveChanges();
        }

        // Methods used for testing
        public IEnumerable<Student> GetAllStudents()
        {
            return this.StudentRepository.All();
        }

        public IEnumerable<Teacher> GetAllTeachers()
        {
            return this.TeacherRepository.All();
        }

        public string ReturnPasswordHash(string username)
        {
            return this.ApplicationUserRepository
                .All()
                .First(u => u.UserName == username)
                .PasswordHash;
        }
    }
}
