using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
/*
    Another option for registering routes is to enable attribute routing. Initial
    development will setup routes using this class. 
    Note that the routes in RegisterRoutes are checked serially and ordered.
*/
namespace IdeallyConnected
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            // Ignore Http handlers
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            
            //routes.RouteExistingFiles = false;      
            //routes.AppendTrailingSlash = false; 
            /*    
            routes.MapRoute(
              name: "ICAppUsers",
              url:  "App/#!/users/{*catch-all}"
            );
            */
        }
    }
}
