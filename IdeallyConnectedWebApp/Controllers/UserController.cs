using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdeallyConnectedWebApp.Models;
using Microsoft.AspNetCore.Mvc;  // Controller

namespace IdeallyConnectedWebApp.Controllers
{
    public class UserController : Controller
    {
        private IdealContext _context;

        // ASP.NET dependency injection will pass an instance of IdealContext
        public UserController (IdealContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Users.ToList());
        }

        public IActionResult Create()
        {
               
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
         public IActionResult Create(Users user)
        {
            if (ModelState.IsValid)
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }

    }
}
