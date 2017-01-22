/*
    For more info see: https://www.asp.net/mvc/overview/performance/bundling-and-minification
    Summary:
    Bundling and minification are two techniques to improve request load time by reducing the number of requests 
    to the server and reducing the size of requested assets. Bundling makes it easy to combine multiple files into
    a single file which translates to less HTTP requests. Minification optimizes scripts or css, such as removing
    unnecessary white space and comments and shortening variable names to one character.

    To debug javascript in a development environment set debug="true" in Web.config. The JS files will not be 
    bundled or minified as a result.

    Concerning AngularJS code and minification: https://docs.angularjs.org/tutorial/step_07 "A Note on Minification"
    Since Angular infers the controller's dependencies from the names of arguments to the controller's constructor 
    function, if you were to minify the JavaScript code for a controller, all of its function arguments would be minified 
    as well, and the dependency injector would not be able to identify services correctly.
    Workaround 1 example: SomeController.$inject = ['$http'];
    Workaround 2 example: .component("userList", {..., controller: ["$http", function UserListController($http){..}]});
        or .component(... ... ["$http", UserListController]}); where UserListController is defined elsewhere.
*/
using System.Web;
using System.Web.Optimization;

namespace IdeallyConnected
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            
            
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                       "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
        
            //bundles.Add(new ScriptBundle("~/bundles/angular").Include(
            //            "~/Scripts/angular.js",
            //            "~/Scripts/angular-route.js"));

            BundleTable.EnableOptimizations = true;
            
        }
    }
}
