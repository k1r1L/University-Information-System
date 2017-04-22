namespace UniversityInformationSystem.Services.Contracts
{
    using System.Linq;
    using Models.ViewModels.Student;

    public interface IMandatoryCoursesService
    {
        IQueryable<MandatoryCourseViewModel> GetAll(string studentUsername);
    }
}
