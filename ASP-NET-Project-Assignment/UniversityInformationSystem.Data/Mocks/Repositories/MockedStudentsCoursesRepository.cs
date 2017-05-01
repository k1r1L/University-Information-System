namespace UniversityInformationSystem.Data.Mocks.Repositories
{
    using Contracts;
    using Data.Repositories;
    using Models.EntityModels;
    public class MockedStudentsCoursesRepository : DbRepository<StudentCourse>
    {
        public MockedStudentsCoursesRepository(IUisDataContext dbContext) 
            : base(dbContext)
        {
            this.DbSet = new MockedDbSet<StudentCourse>();
        }
    }
}
