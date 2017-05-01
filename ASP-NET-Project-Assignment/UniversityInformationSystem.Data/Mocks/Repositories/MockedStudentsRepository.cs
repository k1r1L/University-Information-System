namespace UniversityInformationSystem.Data.Mocks.Repositories
{
    using Contracts;
    using Data.Repositories;
    using DbSets;
    using Models.EntityModels.Users;
    public class MockedStudentsRepository : DbRepository<Student>
    {
        public MockedStudentsRepository(IUisDataContext dbContext) 
            : base(dbContext)
        {
            this.DbSet = new MockedStudentsDbSet();
        }
    }
}
