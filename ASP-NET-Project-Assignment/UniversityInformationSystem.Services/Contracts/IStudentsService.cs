namespace UniversityInformationSystem.Services.Contracts
{
    using System.Collections.Generic;
    using Models.EntityModels.Users;
    using Models.ViewModels.Student;

    public interface IStudentsService
    {
        Student GetStudentByUsername(string username);

        StudentProfileViewModel GetStudentProfileViewModel(string username);

        int? GetStudentId(string username);

        IEnumerable<string> GetAllStudentUsernames();
    }
}
