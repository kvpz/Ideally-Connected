using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IdeallyConnected.Models;
using IdeallyConnected.Models.Repositories;
using System.Threading.Tasks;

namespace IdeallyConnected.Controllers
{
    public class pinglocationController : Controller
    {
        
        // GET: pinglocation
        public ActionResult Index()
        {
            /*
            if(rep == null)
                rep = new Repository<Software>();
            var initialSoftware = new Software { Id = "KOsystem", Type= SoftwareTypes.OperatingSystem };
            if(rep.Get(initialSoftware.Id) == null)
            {
                rep.Add(initialSoftware);
                rep.SaveChanges();
            }
            */
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Details(List<ApplicationUser> model)
        {
            if(ModelState.IsValid)
            {
                System.Diagnostics.Debug.WriteLine("\nIn Details action method. The model argument is #{0}", model.ToString());
                System.Diagnostics.Debug.WriteLine("\nThe model state is valid.");
            }
            return RedirectToAction("Index", "pinglocation");
        }
    }
}