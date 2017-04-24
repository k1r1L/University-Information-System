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
                        Credits = 3,
                        IsOpen = false
                    },
                    new Course()
                    {
                        Name = "Programming Fundamentals",
                        Description = "Курсът \"Programming Fundamentals\" разширява натрупаните до момента начални умения за писане на програмен код от курса \"Основи на програмирането\" и запознава с базови техники и инструменти за практическо програмиране отвъд писането на прости програмни конструкции.",
                        Credits = 6,
                        IsOpen = false
                    },
                    new Course()
                    {
                        Name = "Software Technologies",
                        Description = "Курсът \"Software Technologies\" дава начални познания по най-използваните софтуерни технологии в практиката и позволява на студентите да се ориентират кои технологии им харесват, за да ги изучават по-задълбочено. Изучават се базови концепции от front-end и back-end разработката. Курсът се състои от четири части: HTML5 " +
                                      "разработка (HTML + CSS + JavaScript + AJAX + REST), PHP уеб разработка (PHP + MySQL), C# уеб разработка " +
                                      "(ASP.NET MVC + Entity Framework + SQL Server) и Java уеб разработка (Java + Spring MVC + Hibernate + MySQL).",
                        Credits = 12,
                        IsOpen = false
                    },
                    new Course()
                    {
                        Name = "JS Fundamentals",
                        Description = "Курсът \"JavaScript Fundamentals\" изгражда базови умения по програмиране с езика JavaScript. " +
                                      "Изучават се конструкциите на JavaScript за изграждане на програмна логика, типове данни, оператори," +
                                      " изрази, условни конструкции, цикли и работа с функции. Обръща се внимание на работа с масиви, стрингове и " +
                                      "регулярни изрази, използване на обекти, асоциативни масиви и множества. Курсът е базиран на най-съвременни стандарти" +
                                      " и JS технологии (изучава се ES2017).",
                        Credits = 9,
                        IsOpen = false
                    },
                     new Course()
                    {
                        Name = "Databases Basics SQL Server",
                        Description = "Интензивният курс по основи на базите данни с ще ви запознаe с една от най-широко използвани системи за" +
                                      " управление на бази данни (DBMS), използвани при разработката на съвременни информационни системи -" +
                                      " Microsoft SQL Server. Курсът обръща сериозно внимание на релационния модел, моделирането на данни с ER диаграми " +
                                      "(таблици и релационни връзки) и работата езика SQL (извличане на данни, селекция, проекция, съединения, агрегация," +
                                      " групиране, промяна, изтриване и вмъкване).",
                        Credits = 9,
                        IsOpen = false
                    },
                     new Course()
                    {
                        Name = "Wordpress Basics",
                        Description = "Курсът WordPress Basics изгражда базови технически умения по разработка на уеб сайтове с WordPress: " +
                                      "настройка на хостинг и домейн, инсталиране и конфигуриране на WordPress (WP), инсталиране и конфигуриране" +
                                      " на теми (themes) и добавки (plugins), създаване и редактиране на уеб съдържание (ръчно и с визуални уеб редактори)," +
                                      " създаване на страници, публикации, снимки и мултимедия.",
                        Credits = 6,
                        IsOpen = false
                    },
                    new Course()
                    {
                        Name = "Data Structures",
                        Description = "Курсът по структури от данни запознава участниците с най-използваните структури данни " +
                                      "в програмирането чрез поставяне на солидни основи и много практическа работа. " +
                                      "Ще се запознаете в дълбочина как работят списъци, опашки, стекове, хеш-таблици, дървета," +
                                      " графи и някои алгоритми като рекурсивно обхождане в дълбочина (DFS) и обхождане в ширина (BFS). " +
                                      "Ще се научите да работите не само с готови програмни библиотеки, но и да имплементирате собствени структури." +
                                      " Ще научите как да преценявате кога коя структура данни да ползвате чрез анализ на сложността на алгоритмите за " +
                                      "всяка операция.",
                        Credits = 12,
                        IsOpen = false
                    },
                     new Course()
                    {
                        Name = "Html + Css",
                        Description = "Целта на курса \"Web Fundamentals - HTML5\" е да положи основни знания по уеб технологии и по-конкретно запознаване с " +
                                      "HTML5 и CSS3. Придобиват се начални знания в уеб разработката, уеб браузъри, инструменти за HTML/CSS/DOM разработка и" +
                                      " се развиват практически умения за използване на езика за описание на уеб съдържание HTML и езика за стилизиране на уеб " +
                                      "съдържание CSS. Изучават се CSS frameworks като Bootstrap.",
                        Credits = 6,
                        IsOpen = false
                    },
                      new Course()
                    {
                        Name = "C# OOP",
                        Description = "Курсът \"Object-Oriented Programming\" ще ви научи на принципите на обектно-ориентираното програмиране (ООП), " +
                                      "как да работите с класове и обекти, как да ползвате обектно-ориентирано моделиране и да изграждате йерархии от класове. " +
                                      "Ще се изучават основните принципи на ООП като абстракция (интерфейси, абстрактни класове), енкапсулация, наследяване и " +
                                      "полиморфизъм. Ще обърнем внимание на парадигми като event-driven програмиране, функционално програмиране (ламбда функции," +
                                      " closures и LINQ), обработка на изключения.",
                        Credits = 9,
                        IsOpen = false
                    },
                     new Course()
                    {
                        Name = "Linear Algebra",
                        Description = "Много е гадна.",
                        Credits = 15,
                        IsOpen = false
                    },
                      new Course()
                    {
                        Name = "Python Basics",
                        Description = "Курсът \"Python Basics\" дава начални умения по програмиране, които включват писане на програмен код на начално ниво (basic coding skills), работа със среда за разработка (IDE), използване на променливи и данни, оператори и изрази, работа с конзолата (четене на входни данни и печатане на резултати), използване на условниконструкции (if, if-else, if-elif-else) и цикли (for, while).",
                        Credits = 3,
                        IsOpen = true
                    },
                       new Course()
                    {
                        Name = "Deep Learning",
                        Description = "Целта на курса е да запознае курсистите с най-новите напредъци в областта на изкуствения интелект – а именно техниките свързани с Deep Learning. Хората ще се запознаят с основните принципи на „дълбокото обучение“, а също така и ще имплементират собственоръчно системи за разпознаване на обекти в картини, машинен превод, автоматично предлагане на думи и други. За целта ще се използват модерни инструменти като Tensorflow, Scikit, etc.",
                        Credits = 6,
                        IsOpen = true
                    },
                      new Course()
                    {
                        Name = "ExpressJS Fundamentals",
                        Description = "Курсът е интензивен и цели да запознае учащите с разработката на End-to-end JavaScript приложения върху платформата Node.js, използвайки Express.js като framework. По време на обучението ще разберем как да създадем сървър с Node.js, ще се научим на сървър-клиент архитектурата и как да правим лесни и бързи data-driven web приложения с платформата, използвайки модерни похвати и инструменти.",
                        Credits = 12,
                        IsOpen = true
                    },
                      new Course()
                    {
                        Name = "Първи стъпки с Arduinos",
                        Description = "Курсът \"Първи стъпки с Arduino\" ще ви запознае с начина на работа и възможностите на най-популярната в света платформа за хоби електроника и интерактивни системи. Ще разберете какво представляват микроконтролерите и как работят. Ще използвате цифровите и аналогови входно-изходни пинове на Arduino, за да приемате показания от сензори и да управлявате различни уреди и компоненти, работещи с електричество. Ще се запознаете с работата на основни електронни компоненти – съпротивления, диоди, транзистори, релета и други, както и с принципите при чертането на електрически схеми.",
                        Credits = 3,
                        IsOpen = true
                    },
                        new Course()
                    {
                        Name = "Linux System Administration",
                        Description = "Целта на курса е да даде базови теоретични и практически познания в областта на Linux базираните операционни системи. Курсистите ще се запознаят с практиките от системната администрация, как да управляват достъпа до системите, да създават shell скриптове, да конфигурират мрежовата свързаност, да добавят и управляват услуги и др.",
                        Credits = 3,
                        IsOpen = true
                    },
                         new Course()
                    {
                        Name = "Databases Basics - MySQL",
                        Description = "Курсът по основи на базите данни ще ви запознаe с една от най-широко използвани безплатни системи с отворен код за управление на бази данни (DBMS), използвани при разработката на съвременни информационни системи - MySQL. Курсът обръща сериозно внимание на релационния модел, моделирането на данни с ER диаграми (таблици и релационни връзки) и работа с езика SQL (извличане на данни, селекция, проекция, съединения, агрегация, групиране, промяна, изтриване и вмъкване). Предоставят се фундаментални знания за работа с ACID транзакции и транзакционна обработка и практически съвети за настройване на производителността.",
                        Credits = 9,
                        IsOpen = true
                    },
                });


        }
    }
}
