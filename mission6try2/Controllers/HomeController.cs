using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using mission6try2.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace mission6try2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MovieContext _movieContext { get; set; }
        public HomeController(ILogger<HomeController> logger, MovieContext movie)
        {
            _logger = logger;
            _movieContext = movie;
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
        public IActionResult MovieInput()
        {
            ViewBag.Categories = _movieContext.Categories.ToList();
            return View(new MovieInput());
        }

        [HttpPost]
        public IActionResult MovieInput(MovieInput mv)
        {
            if (ModelState.IsValid)
            {
                _movieContext.Add(mv);
                _movieContext.SaveChanges();
                return View("MovieSubmitted", mv);
            }
            else
            {
                ViewBag.Categories = _movieContext.Categories.ToList();

                return View(mv);
            }
            
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult MovieList()
        {
            var movies = _movieContext.Movies
                .Include(x => x.category)
                .OrderBy(x => x.Title)
                .ToList();
            return View(movies);
        }

        ////////////////////////////DELETE ACTIONS///////////////////////////////////////
        [HttpGet]
        public IActionResult Delete(int movieID)
        {
            var application = _movieContext.Movies.Single(y => y.MovieID == movieID);


            return View(application);
        }

        [HttpPost]
        public IActionResult Delete(MovieInput MI)
        {
            _movieContext.Movies.Remove(MI);
            _movieContext.SaveChanges();
            return RedirectToAction("MovieList");
        }

        ////////////////////////////EDIT ACTIONS//////////////////////////
        [HttpGet]
        public IActionResult Edit(int movieID)
        {
            ViewBag.Categories = _movieContext.Categories.ToList();
            
            var movie = _movieContext.Movies.Single(x => x.MovieID == movieID);

            return View("MovieInput", movie);
        }

        [HttpPost]
        public IActionResult Edit(MovieInput mov)
        {
            _movieContext.Update(mov);
            _movieContext.SaveChanges();

            return RedirectToAction("MovieList");
        }
    }
}
