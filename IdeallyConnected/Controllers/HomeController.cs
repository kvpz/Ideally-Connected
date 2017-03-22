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
using System.Net.Http;
using IdeallyConnected.Models;
using System.Net;

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
            return View();
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

        [HttpGet]
        [Route("users")]   // HttpResponseMessage
        public JsonResult GetUsers() //(HttpRequestMessage request)
        {
            UserRepository userDb = new UserRepository();
            var users = userDb.GetAll();
            users = new List<ApplicationUser>() {
                new ApplicationUser() { UserName = "Timmy", FirstName = "Tim", LastName = "Johner" }
            };

            return Json(new { list = users.ToList() }, JsonRequestBehavior.AllowGet);
            //return request.CreateResponse<ApplicationUser[]>(HttpStatusCode.OK, users.ToArray());
        }
    }
}