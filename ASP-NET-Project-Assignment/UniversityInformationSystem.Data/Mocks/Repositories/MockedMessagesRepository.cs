namespace UniversityInformationSystem.Data.Mocks.Repositories
{
    using Contracts;
    using Data.Repositories;
    using Models.EntityModels;
    public class MockedMessagesRepository : DbRepository<Message>
    {
        public MockedMessagesRepository(IUisDataContext dbContext) 
            : base(dbContext)
        {
            this.DbSet = new MockedDbSet<Message>();
        }
    }
}
