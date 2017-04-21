using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityInformationSystem.Services
{
    using AutoMapper;
    using Contracts;
    using Data.Contracts;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models.EntityModels.Users;
    using Models.ViewModels.Admin;

    public class UserService : IUserService
    {
        private IDbRepository<ApplicationUser> userRepository;

        public UserService(IDbRepository<ApplicationUser> userRepository)
        {
            this.userRepository = userRepository;
        }

        public ApplicationUser GetUserByUsername(string username)
        {
            return this.userRepository
                .All()
                .Single(u => u.UserName == username);;
        }

        public AdminProfileViewModel GetAdminProfileViewModel(string username)
        {
            ApplicationUser appUser = this.GetUserByUsername(username);

            return Mapper.Map<AdminProfileViewModel>(appUser);
        }
    }
}
