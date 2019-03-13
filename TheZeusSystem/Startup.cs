using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TheZeusSystem.Startup))]
namespace TheZeusSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
