using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IdeallyConnected.Models;
using IdeallyConnected.Models.Repositories;

namespace IdeallyConnected.Controllers
{
    public class pinglocationController : Controller
    {
        private Repository<Software> rep = null;
        // GET: pinglocation
        public ActionResult Index()
        {
            if(rep == null)
                rep = new Repository<Software>();
            var testSoftware = new Software { Id = "KOsystem", Type= SoftwareTypes.OperatingSystem };
            if(rep.Get(testSoftware.Id))
                rep.Add(testSoftware);
            rep.SaveChanges();
            
            return View(rep.GetAll());
        }
    }
}