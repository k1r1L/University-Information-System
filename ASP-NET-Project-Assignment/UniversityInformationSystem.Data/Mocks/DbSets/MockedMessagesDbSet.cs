namespace UniversityInformationSystem.Data.Mocks.DbSets
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Models.EntityModels;

    public class MockedMessagesDbSet : MockedDbSet<Message>
    {
        public override Message Find(params object[] keyValues)
        {
            int wantedId = (int)keyValues[0];
            return this.Set.FirstOrDefault(c => c.Id == wantedId);
        }
    }
}
