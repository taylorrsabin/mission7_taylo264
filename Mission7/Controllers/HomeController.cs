using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission7.Models;

namespace Mission7.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MovieSubmissionContext daContext { get; set; }

        public HomeController(ILogger<HomeController> logger, MovieSubmissionContext someName)
        {
            _logger = logger;
            daContext = someName;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Podcast()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Movie()
        {
            ViewBag.CategoryOptions = daContext.Categories.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Movie(ApplicationResponse ar)
        {
            if(ModelState.IsValid)
            {
                daContext.Add(ar);
                daContext.SaveChanges();

                return View("Confirmation", ar);
            }

            else
            {
                ViewBag.CategoryOptions = daContext.Categories.ToList();

                return View(ar);
            }
            
        }

[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult MovieTable()
        {
            var movies = daContext.Responses
                .Include(x => x.Category)
                .ToList();

            return View(movies);
        }

        [HttpGet]
        public IActionResult Edit(int movieid)
        {
            ViewBag.CategoryOptions = daContext.Categories.ToList();

            var movie = daContext.Responses.Single(x => x.MovieId == movieid);

            return View("Movie", movie);
        }

        [HttpPost]
        public IActionResult Edit(ApplicationResponse ar)
        {
            daContext.Update(ar);
            daContext.SaveChanges();

            return RedirectToAction("MovieTable");
        }

        [HttpGet]
        public IActionResult Delete(int movieid)
        {
            var movie = daContext.Responses.Single(x => x.MovieId == movieid);

            return View(movie);
        }

        [HttpPost]
        public IActionResult Delete(ApplicationResponse ar)
        {
            daContext.Responses.Remove(ar);
            daContext.SaveChanges();

            return RedirectToAction("MovieTable");
        }
    }
}

