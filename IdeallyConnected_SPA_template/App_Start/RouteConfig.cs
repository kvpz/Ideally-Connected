using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace IdeallyConnected_SPA_template
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home",action = "Index",id = UrlParameter.Optional }
            );

            /*
                See AngularJS for ASP.NT MVC Developers video (61:00)
                "*catchall" says that customer slash anything will get us to Home/Customer
            */
            routes.MapRoute(
                name: "customer",
                url: "customer/{*catchall}",
                defaults: new { controller = "Home", action = "Customer" });
        }
    }
}
