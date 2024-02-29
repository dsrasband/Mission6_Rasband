using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission6_Rasband.Models;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace Mission6_Rasband.Controllers
{
    public class HomeController : Controller
    {
        private FilmCollectionContext _context;
        
        public HomeController(FilmCollectionContext temp) // Constructor
        {
            _context = temp;
        }
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetToKnow()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddCollection()
        {
            ViewBag.Categories = _context.Categories
                    .OrderBy(x => x.CategoryName)
                    .ToList();

            return View("AddCollection", new Movie());
        }

        [HttpPost]
        public IActionResult AddCollection(Movie response)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(response); // Add the record to the Database
                _context.SaveChanges();
            
                return View("Confirmation", response);
            }
            else
            {
                ViewBag.Categories = _context.Categories
                    .OrderBy(x => x.CategoryName)
                    .ToList();

                return View(response);
            }
        }

        public IActionResult ViewCollection()
        {
            var movies = _context.Movies.Include("Category")
                .ToList();

            return View(movies);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var movieToEdit = _context.Movies
                .Single(x => x.MovieId == id);

            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View("AddCollection", movieToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Movie updatedInfo)
        {
            _context.Update(updatedInfo);
            _context.SaveChanges();

            return RedirectToAction("ViewCollection");
        }

        [HttpGet]
        public IActionResult Delete (int id)
        {
            var movieToDelete = _context.Movies
                .Single(x => x.MovieId == id);

            return View(movieToDelete);
        }

        [HttpPost]
        public IActionResult Delete(Movie movie)
        {
            _context.Movies.Remove(movie);
            _context.SaveChanges();

            return RedirectToAction("ViewCollection");
        }
    }
}
