namespace UniversityInformationSystem.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Data;

    public abstract class Service
    {
        private UisDataContext dbContext;

        protected Service()
        {
            this.dbContext = new UisDataContext();
        }

        protected UisDataContext DbContext { get; set; }
    }
}
