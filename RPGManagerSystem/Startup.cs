using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RPGManagerSystem.Startup))]
namespace RPGManagerSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
