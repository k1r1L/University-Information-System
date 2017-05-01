namespace UniversityInformationSystem.Tests.Services
{
    using System;
    using App;
    using Data.Contracts;
    using Data.Mocks;
    using Models.EntityModels;
    using Models.EntityModels.Users;

    public abstract class BaseTest
    {
        protected IUisDataContext dbContext;

        protected BaseTest()
        {
            this.dbContext = new MockedUisDbContext();
            this.SeedData();
            MapperConfig.ConfigureAutomapper();
        }

        protected void SeedData()
        {
            // Seed teachers
            this.dbContext.Teachers.Add(new Teacher()
            {
                Id = 1,
                IdentityUser = new ApplicationUser()
                {
                   UserName = "kircata",
                   FirstName = "Kiril",
                   LastName = "Kirilov",
                   BirthDate = new DateTime(1998, 01, 06)
                },
                IdenityUserId = "asdasds234234ad"
            });
            this.dbContext.Teachers.Add(new Teacher()
            {
                Id = 2,
                IdentityUser = new ApplicationUser()
                {
                    UserName = "bojkata",
                    FirstName = "Bojidar",
                    LastName = "Gevechanov",
                    BirthDate = new DateTime(1996, 06, 01)
                },
                IdenityUserId = "3dg43g4szg",
            });
            this.dbContext.Teachers.Add(new Teacher()
            {
                Id = 3,
                IdentityUser = new ApplicationUser()
                {
                    UserName = "georgiev",
                    FirstName = "Georgi",
                    LastName = "Georgiev",
                    BirthDate = new DateTime(1994, 01, 06)
                },
                IdenityUserId = "65657345hgjtfr",
            });

            // Seed students
            this.dbContext.Students.Add(new Student()
            {
                Id = 1,
                IdentityUser = new ApplicationUser()
                {
                    UserName = "jicata",
                    FirstName = "Svetlin",
                    LastName = "Galov",
                    BirthDate = new DateTime(1992, 01, 06)
                },
                IdenityUserId = "asgwe343fdfh5"
            });
            this.dbContext.Students.Add(new Student()
            {
                Id = 2,
                IdentityUser = new ApplicationUser()
                {
                    UserName = "slav97",
                    FirstName = "Slav",
                    LastName = "Radev",
                    BirthDate = new DateTime(1997, 06, 01)
                },
                IdenityUserId = "12412dfgdf",
            });
            this.dbContext.Students.Add(new Student()
            {
                Id = 3,
                IdentityUser = new ApplicationUser()
                {
                    UserName = "dutskinov",
                    FirstName = "Niki",
                    LastName = "Dutskinov",
                    BirthDate = new DateTime(1995, 11, 06)
                },
                IdenityUserId = "asdfasda32423",
            });

            // Seed courses
            this.dbContext.Courses.Add(new Course()
            {
                Id = 1,
                Name = "Programming Basics",
                Description =
                    "Софтуерният университет, организира курсa \"Programming Basics\" с езика C#! Обучението е безплатно и подходящо за напълно начинаещи, като дава начални умения по програмиране с езика C#, необходими за всички технологични специалности в СофтУни.",
                Credits = 3,
                IsOpen = false,
                Teacher = this.dbContext.Teachers.Find(1)
            });
            this.dbContext.Courses.Add(new Course()
            {
                Id = 2,
                Name = "Programming Fundamentals",
                Description =
                    "Курсът \"Programming Fundamentals\" разширява натрупаните до момента начални умения за писане на програмен код от курса \"Основи на програмирането\" и запознава с базови техники и инструменти за практическо програмиране отвъд писането на прости програмни конструкции.",
                Credits = 6,
                IsOpen = true,
                Teacher = this.dbContext.Teachers.Find(2)
            });
            this.dbContext.Courses.Add(new Course()
            {
                Id = 3,
                Name = "Software Technologies",
                Description =
                    "Курсът \"Software Technologies\" дава начални познания по най-използваните софтуерни технологии в практиката и позволява на студентите да се ориентират кои технологии им харесват, за да ги изучават по-задълбочено. Изучават се базови концепции от front-end и back-end разработката. Курсът се състои от четири части: HTML5 " +
                    "разработка (HTML + CSS + JavaScript + AJAX + REST), PHP уеб разработка (PHP + MySQL), C# уеб разработка " +
                    "(ASP.NET MVC + Entity Framework + SQL Server) и Java уеб разработка (Java + Spring MVC + Hibernate + MySQL).",
                Credits = 12,
                IsOpen = false,
                Teacher = this.dbContext.Teachers.Find(3)
            });
            this.dbContext.Courses.Add(new Course()
            {
                Id = 4,
                Name = "JS Fundamentals",
                Description =
                    "Курсът \"JavaScript Fundamentals\" изгражда базови умения по програмиране с езика JavaScript. " +
                    "Изучават се конструкциите на JavaScript за изграждане на програмна логика, типове данни, оператори," +
                    " изрази, условни конструкции, цикли и работа с функции. Обръща се внимание на работа с масиви, стрингове и " +
                    "регулярни изрази, използване на обекти, асоциативни масиви и множества. Курсът е базиран на най-съвременни стандарти" +
                    " и JS технологии (изучава се ES2017).",
                Credits = 9,
                IsOpen = false,
                Teacher = this.dbContext.Teachers.Find(1)
            });
            this.dbContext.Courses.Add(new Course()
            {
                Id = 5,
                Name = "Databases Basics SQL Server",
                Description =
                    "Интензивният курс по основи на базите данни с ще ви запознаe с една от най-широко използвани системи за" +
                    " управление на бази данни (DBMS), използвани при разработката на съвременни информационни системи -" +
                    " Microsoft SQL Server. Курсът обръща сериозно внимание на релационния модел, моделирането на данни с ER диаграми " +
                    "(таблици и релационни връзки) и работата езика SQL (извличане на данни, селекция, проекция, съединения, агрегация," +
                    " групиране, промяна, изтриване и вмъкване).",
                Credits = 9,
                IsOpen = true,
                Teacher = this.dbContext.Teachers.Find(2)
            });

            // Seed student courses
            this.dbContext.StudentsCourses.Add(new StudentCourse()
            {
                Course = this.dbContext.Courses.Find(1),
                CourseId = 1,
                Student = this.dbContext.Students.Find(1),
                StudentId = 1
            });
            this.dbContext.StudentsCourses.Add(new StudentCourse()
            {
                Course = this.dbContext.Courses.Find(1),
                CourseId = 1,
                Student = this.dbContext.Students.Find(2),
                StudentId = 2
            });
            this.dbContext.StudentsCourses.Add(new StudentCourse()
            {
                Course = this.dbContext.Courses.Find(1),
                CourseId = 1,
                Student = this.dbContext.Students.Find(3),
                StudentId = 3
            });
        }
    }
}
