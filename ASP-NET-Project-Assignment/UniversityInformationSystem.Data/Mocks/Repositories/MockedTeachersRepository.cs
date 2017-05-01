namespace UniversityInformationSystem.Data.Mocks.Repositories
{
    using Contracts;
    using Data.Repositories;
    using DbSets;
    using Models.EntityModels.Users;
    public class MockedTeachersRepository : DbRepository<Teacher>
    {
        public MockedTeachersRepository(IUisDataContext dbContext) 
            : base(dbContext)
        {
            this.DbSet = new MockedTeachersDbSet();
        }
    }
}
