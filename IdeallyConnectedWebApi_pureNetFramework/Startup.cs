using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IdeallyConnectedWebApi_pureNetFramework.Startup))]
namespace IdeallyConnectedWebApi_pureNetFramework
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
