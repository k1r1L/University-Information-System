using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityInformationSystem.Services
{
    using Models.EntityModels;

    public class UsersService : Service
    {
        public ApplicationUser GetUserByUsername(string username)
        {
            return this.DbContext.Users.Single(u => u.UserName == username);
        }
    }
}
