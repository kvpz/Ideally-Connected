using IdeallyConnected.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IdeallyConnected.Controllers
{
    public class UserController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        // GET: User
        public ActionResult Index()
        {
            //return View(context.UserProfile.ToList());
            return View(context.Users.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ApplicationUser user)
        {
            if(!ModelState.IsValid) return View(user);
           
            context.Users.Add(user);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}