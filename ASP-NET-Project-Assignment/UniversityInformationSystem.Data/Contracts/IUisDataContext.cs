namespace UniversityInformationSystem.Data.Contracts
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using Models.EntityModels;
    using Models.EntityModels.Users;

    public interface IUisDataContext : IDisposable
    {
        IDbSet<Student> Students { get; set; }

        IDbSet<Teacher> Teachers { get; set; }

        IDbSet<Course> Courses { get; set; }

        IDbSet<StudentCourse> StudentsCourses { get; set; }

        IDbSet<Message> Messages { get; set; }

        DbSet<TEntity> Set<TEntity>()
        where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity)
            where TEntity : class;

        int SaveChanges();

        DbContext DbContext { get; }
    }
}
