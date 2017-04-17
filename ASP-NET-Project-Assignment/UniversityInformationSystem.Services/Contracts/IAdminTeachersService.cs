using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityInformationSystem.Services.Contracts
{
    public interface IAdminTeachersService
    {
        bool TeacherExists(string teacherUsername);

        int GetTeacherId(string teacherUsername);
    }
}
