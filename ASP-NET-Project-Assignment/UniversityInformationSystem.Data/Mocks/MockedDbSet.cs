namespace UniversityInformationSystem.Data.Mocks
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Data.Entity;

    public class MockedDbSet<T> : DbSet<T>, IEnumerable<T>, IQueryable<T>
        where T : class 
    {
        protected HashSet<T> Set;
        protected IQueryable<T> Queryable;

        public MockedDbSet()
        {
            this.Set = new HashSet<T>();
            this.Queryable = this.Set.AsQueryable();
        }

        public override T Add(T entity)
        {
            this.Set.Add(entity);
            return entity;
        }

        public override T Remove(T entity)
        {
            this.Set.Remove(entity);
            return entity;
        }

        System.Linq.Expressions.Expression IQueryable.Expression
        {
            get { return this.Queryable.Expression; }
        }

        IQueryProvider IQueryable.Provider
        {
            get { return this.Queryable.Provider; }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.Set.GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return this.Set.GetEnumerator();
        }

    }
}
