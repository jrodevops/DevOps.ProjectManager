using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DevOps.ProjectManager.Startup))]
namespace DevOps.ProjectManager
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
