using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IdeallyConnected.Startup))]
namespace IdeallyConnected
{
    public partial class Startup
    {
        /// <summary>
        /// This is called after global.asax
        /// </summary>
        /// <param name="app"></param>
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
