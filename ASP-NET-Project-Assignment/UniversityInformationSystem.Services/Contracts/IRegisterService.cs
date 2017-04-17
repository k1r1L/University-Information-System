namespace UniversityInformationSystem.Services.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Models.EntityModels.Users;
    using Models.Enums;

    public interface IRegisterService
    {
        void Register(UserType userType, string appUserId);
    }
}
