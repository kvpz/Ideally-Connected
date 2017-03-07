using IdeallyConnected.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IdeallyConnected.Controllers
{
    public class MenuController : Controller
    {
        // GET: Menu
       [ChildActionOnly]
        public ActionResult LayoutNavBar()
        {
            LayoutMenuItemManager mgr = new LayoutMenuItemManager();
            mgr.Load(Server.MapPath("/XML/LayoutMenuItems.xml"));
            return View(mgr);
        }
    }
}