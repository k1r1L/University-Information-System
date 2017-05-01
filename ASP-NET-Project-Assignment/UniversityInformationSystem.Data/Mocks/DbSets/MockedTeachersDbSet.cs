using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityInformationSystem.Data.Mocks.DbSets
{
    using Models.EntityModels.Users;
    public class MockedTeachersDbSet : MockedDbSet<Teacher>
    {
        public override Teacher Find(params object[] keyValues)
        {
            int wantedId = (int)keyValues[0];
            return this.Set.FirstOrDefault(c => c.Id == wantedId);
        }
    }
}
