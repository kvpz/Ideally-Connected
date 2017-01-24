using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
/*
    Another option for registering routes is to enable attribute routing. Initial
    development will setup routes using this class.
*/
namespace IdeallyConnected
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "user",
                url:  "user/{*catch-all}",
                defaults: new {
                    controller = "Home", action = "User"
                });

            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
                "Default",
                "{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = "" }
            );
            //routes.RouteExistingFiles = true;
            //routes.MapMvcAttributeRoutes();
        }
    }
}
