namespace UniversityInformationSystem.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models.EntityModels;

    public class UisDataContext : IdentityDbContext<ApplicationUser>
    {
        public UisDataContext()
            : base("name=UisDataContext")
        {
        }

        public static UisDataContext Create()
        {
            return new UisDataContext();
        }
    }
}