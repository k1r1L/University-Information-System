namespace UniversityInformationSystem.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models.EntityModels;
    using Models.EntityModels.Users;

    internal sealed class Configuration : DbMigrationsConfiguration<UniversityInformationSystem.Data.UisDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(UniversityInformationSystem.Data.UisDataContext context)
        {
            if (!context.Roles.Any(role => role.Name == "Administrator"))
            {
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
                roleManager.Create(new IdentityRole("Administrator"));
            }

            if (!context.Roles.Any(role => role.Name == "Teacher"))
            {
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
                roleManager.Create(new IdentityRole("Teacher"));
            }

            if (!context.Roles.Any(role => role.Name == "Student"))
            {
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
                roleManager.Create(new IdentityRole("Student"));
            }

            if (!context.Users.Any())
            {
                var firstUser = new ApplicationUser()
                {
                    UserName = "kirilvk1",
                    Email = "kiril.98.kirilov@gmail.com",
                    PhoneNumber = "0895964686",
                    FirstName = "Kiril",
                    LastName = "Kirilov",
                    BirthDate = new DateTime(1996, 1, 6)
                };
                var userManager = new UserManager<ApplicationUser>
                    (new UserStore<ApplicationUser>(context));
                userManager.Create(firstUser, "");
                userManager.AddToRole(firstUser.Id, "Administrator");
            }

            context.Courses.AddOrUpdate(c => c.Name, new Course[]
                {
                    new Course()
                    {
                        Name = "Programming Basics",
                        Description = "Софтуерният университет, организира курсa \"Programming Basics\" с езика C#! Обучението е безплатно и подходящо за напълно начинаещи, като дава начални умения по програмиране с езика C#, необходими за всички технологични специалности в СофтУни.",
                        IsOpen = false
                    },
                    new Course()
                    {
                        Name = "Programming Fundamentals",
                        Description = "Курсът \"Programming Fundamentals\" разширява натрупаните до момента начални умения за писане на програмен код от курса \"Основи на програмирането\" и запознава с базови техники и инструменти за практическо програмиране отвъд писането на прости програмни конструкции.",
                        IsOpen = false
                    },
                    new Course()
                    {
                        Name = "Software Technologies",
                        Description = "Курсът \"Software Technologies\" дава начални познания по най-използваните софтуерни технологии в практиката и позволява на студентите да се ориентират кои технологии им харесват, за да ги изучават по-задълбочено. Изучават се базови концепции от front-end и back-end разработката. Курсът се състои от четири части: HTML5 разработка (HTML + CSS + JavaScript + AJAX + REST), PHP уеб разработка (PHP + MySQL), C# уеб разработка (ASP.NET MVC + Entity Framework + SQL Server) и Java уеб разработка (Java + Spring MVC + Hibernate + MySQL).",
                        IsOpen = false
                    },
                    new Course()
                    {
                        Name = "JS Fundamentals",
                        Description = "Курсът \"JavaScript Fundamentals\" изгражда базови умения по програмиране с езика JavaScript. Изучават се конструкциите на JavaScript за изграждане на програмна логика, типове данни, оператори, изрази, условни конструкции, цикли и работа с функции. Обръща се внимание на работа с масиви, стрингове и регулярни изрази, използване на обекти, асоциативни масиви и множества. Курсът е базиран на най-съвременни стандарти и JS технологии (изучава се ES2017).",
                        IsOpen = false
                    },
                     new Course()
                    {
                        Name = "Databases Basics SQL Server",
                        Description = "Интензивният курс по основи на базите данни с ще ви запознаe с една от най-широко използвани системи за управление на бази данни (DBMS), използвани при разработката на съвременни информационни системи - Microsoft SQL Server. Курсът обръща сериозно внимание на релационния модел, моделирането на данни с ER диаграми (таблици и релационни връзки) и работата езика SQL (извличане на данни, селекция, проекция, съединения, агрегация, групиране, промяна, изтриване и вмъкване).",
                        IsOpen = false
                    },
                     new Course()
                    {
                        Name = "Wordpress Basics",
                        Description = "Курсът WordPress Basics изгражда базови технически умения по разработка на уеб сайтове с WordPress: настройка на хостинг и домейн, инсталиране и конфигуриране на WordPress (WP), инсталиране и конфигуриране на теми (themes) и добавки (plugins), създаване и редактиране на уеб съдържание (ръчно и с визуални уеб редактори), създаване на страници, публикации, снимки и мултимедия.",
                        IsOpen = false
                    },
                    new Course()
                    {
                        Name = "Data Structures",
                        Description = "Курсът по структури от данни запознава участниците с най-използваните структури данни в програмирането чрез поставяне на солидни основи и много практическа работа. Ще се запознаете в дълбочина как работят списъци, опашки, стекове, хеш-таблици, дървета, графи и някои алгоритми като рекурсивно обхождане в дълбочина (DFS) и обхождане в ширина (BFS). Ще се научите да работите не само с готови програмни библиотеки, но и да имплементирате собствени структури. Ще научите как да преценявате кога коя структура данни да ползвате чрез анализ на сложността на алгоритмите за всяка операция.",
                        IsOpen = false
                    },
                     new Course()
                    {
                        Name = "Html + Css",
                        Description = "Целта на курса \"Web Fundamentals - HTML5\" е да положи основни знания по уеб технологии и по-конкретно запознаване с HTML5 и CSS3. Придобиват се начални знания в уеб разработката, уеб браузъри, инструменти за HTML/CSS/DOM разработка и се развиват практически умения за използване на езика за описание на уеб съдържание HTML и езика за стилизиране на уеб съдържание CSS. Изучават се CSS frameworks като Bootstrap.",
                        IsOpen = false
                    },
                      new Course()
                    {
                        Name = "C# OOP",
                        Description = "Курсът \"Object-Oriented Programming\" ще ви научи на принципите на обектно-ориентираното програмиране (ООП), как да работите с класове и обекти, как да ползвате обектно-ориентирано моделиране и да изграждате йерархии от класове. Ще се изучават основните принципи на ООП като абстракция (интерфейси, абстрактни класове), енкапсулация, наследяване и полиморфизъм. Ще обърнем внимание на парадигми като event-driven програмиране, функционално програмиране (ламбда функции, closures и LINQ), обработка на изключения.",
                        IsOpen = false
                    },
                     new Course()
                    {
                        Name = "Linear Algebra",
                        Description = "Много е гадна.",
                        IsOpen = false
                    },
                });


        }
    }
}
