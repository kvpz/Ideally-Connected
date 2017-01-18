using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IdeallyConnected.Startup))]
namespace IdeallyConnected
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
