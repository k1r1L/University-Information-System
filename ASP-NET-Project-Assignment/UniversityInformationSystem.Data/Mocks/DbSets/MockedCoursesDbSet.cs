using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityInformationSystem.Data.Mocks.DbSets
{
    using Models.EntityModels;
    public class MockedCoursesDbSet : MockedDbSet<Course>
    {
        public override Course Find(params object[] keyValues)
        {
            int wantedId = (int) keyValues[0];
            return this.Set.FirstOrDefault(c => c.Id == wantedId);
        }
    }
}
