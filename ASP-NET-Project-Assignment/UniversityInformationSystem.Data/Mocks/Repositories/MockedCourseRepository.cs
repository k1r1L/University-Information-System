namespace UniversityInformationSystem.Data.Mocks.Repositories
{
    using Contracts;
    using Data.Repositories;
    using DbSets;
    using Models.EntityModels;

    public class MockedCourseRepository : DbRepository<Course>
    {
        public MockedCourseRepository(IUisDataContext dbContext) 
            : base(dbContext)
        {
            this.DbSet = new MockedCoursesDbSet();
        }
    }
}
