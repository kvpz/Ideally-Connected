using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdeallyConnectedWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace IdeallyConnectedWebApp.Controllers
{
    public class BlogsController : Controller
    {
        private BloggingContext _context;

        public BlogsController(BloggingContext context)
        /*
            ASP.NET dependency injection will take care of passing an instance of BloggingContext into controller.
        */
        {
            _context = context;
        }

        /// <summary>
        /// Display all blogs in the database.
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View(_context.Blogs.ToList());
        }

        /// <summary>
        /// Insert new blogs in the database.
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Blog blog)
        {
            if (ModelState.IsValid)
            {
                _context.Blogs.Add(blog);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(blog);
        }
    }
}
