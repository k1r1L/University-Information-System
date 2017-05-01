namespace UniversityInformationSystem.Data.Mocks.DbSets
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Models.EntityModels.Users;

    public class MockedUsersDbSet : MockedDbSet<ApplicationUser>
    {
        public override ApplicationUser Find(params object[] keyValues)
        {
            string wantedId = (string)keyValues[0];
            return this.Set.FirstOrDefault(c => c.Id == wantedId);
        }
    }
}
