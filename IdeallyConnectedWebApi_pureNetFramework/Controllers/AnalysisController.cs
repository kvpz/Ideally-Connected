using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Web.Mvc;

namespace IdeallyConnectedWebApi_pureNetFramework.Controllers
{
    public class AnalysisController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.message = "This is the Analysis Controller Index";
            
            return View();
        }
    }
}