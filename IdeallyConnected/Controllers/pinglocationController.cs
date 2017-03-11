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
        private Repository<Software> rep = new Repository<Software>();
        
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
            var usersMod = new IdeallyConnected.Models.Repositories.UserRepository();
            Dictionary<String,SoftwareTypes> SoftwareDictionary = new Dictionary<String,SoftwareTypes>()
            {
                    { "Visual Studio", SoftwareTypes.TextEditor },
                    { "OSX", SoftwareTypes.OperatingSystem },
                    { "Notepad++", SoftwareTypes.TextEditor }
            };

            ApplicationUser initialUser = new ApplicationUser {
                UserName = "Uone",
                Biography = "I like programming and reading and guitar",
                Software = SoftwareDictionary
                                    .Select(st => new Software() { Id = st.Key,Type = st.Value }).ToList(),
                Email = "Uone@gewgle.com"
            };
            if(usersMod.Get(initialUser.Id) == null) {
                usersMod.Add(initialUser);
            }
            return View(usersMod.GetAll());
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