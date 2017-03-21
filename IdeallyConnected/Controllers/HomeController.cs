//using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebGrease.Css.Extensions;
using IdeallyConnected.Components;
using IdeallyConnected.Migrations;
using System.Data.Entity.Migrations;
using IdeallyConnected.Models.Repositories;

namespace IdeallyConnected.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            /*
            var configuration = new Configuration();
            var migrator = new DbMigrator(configuration);
            migrator.Update();
            */
            UserRepository userdb = new UserRepository();
            userdb.Add(new Models.ApplicationUser() { UserName = "UserOne" });
            userdb.SaveChanges();
            return View(userdb);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Connect with the right people!";
            
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult FindPeople()
        {
            return View();
        }
    }
}