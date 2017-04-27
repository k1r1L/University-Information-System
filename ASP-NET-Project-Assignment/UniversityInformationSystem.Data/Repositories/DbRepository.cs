namespace UniversityInformationSystem.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Data.Entity;
    using System.Data.Entity.Validation;
    using System.Diagnostics;
    using Contracts;

    public class DbRepository<T> : IDbRepository<T>
       where T : class
    {
        public DbRepository(IUisDataContext dbContext)
        {
            this.DbSet = dbContext.Set<T>();
        }

        protected IDbSet<T> DbSet { get; set; }

        public virtual IQueryable<T> All()
        {
            return this.DbSet.AsQueryable();
        }

        public virtual T GetById(object id)
        {
            return this.DbSet.Find(id);
        }

        public virtual void Add(T entity)
        {
            var entry = this.DbSet.Add(entity);
        }

        public virtual void Delete(T entity)
        {
            var entry = this.DbSet.Remove(entity);
        }

        public virtual void Delete(object id)
        {
            var entity = this.GetById(id);

            if (entity != null)
            {
                this.Delete(entity);
            }
        }
    }
}
