using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UniversityInformationSystem.App.Startup))]
namespace UniversityInformationSystem.App
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
