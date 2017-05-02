using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace IdeallyConnected.API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }

        public static void RegisterApis(HttpConfiguration config)
        {
            // Show response headers on the server.
            GlobalConfiguration.Configuration.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;

            //config.Formatters.Insert(0, new JsonpFormatter());

            //config.Filters.Add(new UnhandledExceptionFilter());

            //config.ParameterBindingRules.Insert(0, SimplePostVariableParameterBinding.HookupParamaeterBinding);
        }
    }
}
