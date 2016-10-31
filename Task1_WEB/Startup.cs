using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Task1_WEB.Startup))]
namespace Task1_WEB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
