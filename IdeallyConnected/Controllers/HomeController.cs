using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IdeallyConnected.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.directory = System.IO.Directory.GetCurrentDirectory();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        
        public ActionResult AllUsers()
        {
            ViewBag.Message = "This is the user list";

            
            return View();
        }

        public ActionResult LocalNetUsers()
        {
            ViewBag.Message = "All users in your local area network";
            return View();
        }

    }
}