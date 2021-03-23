using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MemesProject.Startup))]
namespace MemesProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
