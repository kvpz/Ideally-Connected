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

            // appends only /AllUsers instead of /Home/AllUsers to url
            routes.MapRoute(
                name: "allusers",
                url: "allusers/{*catch-all}",
                defaults: new {
                    controller = "Home", action = "AllUsers"
                }
            );
                        
            routes.MapMvcAttributeRoutes();


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = "" }
            );

            
            routes.RouteExistingFiles = false;      
            routes.AppendTrailingSlash = false; 
            
            routes.MapRoute(
              name: "user",
              url:  "App/#!/users/{*catch-all}"
            );
            
            
        }
    }
}
