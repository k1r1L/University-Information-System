namespace UniversityInformationSystem.Data.Mocks.Repositories
{
    using Contracts;
    using Data.Repositories;
    using DbSets;
    using Models.EntityModels.Users;
    public class MockedUsersRepository : DbRepository<ApplicationUser>
    {
        public MockedUsersRepository(IUisDataContext dbContext) 
            : base(dbContext)
        {
            this.DbSet = new MockedUsersDbSet();
        }
    }
}
