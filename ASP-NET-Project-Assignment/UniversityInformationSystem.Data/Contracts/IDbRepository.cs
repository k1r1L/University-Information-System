namespace UniversityInformationSystem.Data.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IDbRepository<T>
        where T : class
    {
        IQueryable<T> All();

        T GetById(object id);

        void Add(T entity);

        void Delete(T entity);

        void Delete(object id);
    }
}
