using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace IdeallyConnectedWebApp.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
            //return RedirectToAction("Index", "User");
        }

        public ActionResult Analysis()
        {
            ViewBag.Message = "Analysis One in progress";
            return View();
        }

        public IActionResult DataAnalysisOne()
        {
            
            return View();
        }
    }
}
