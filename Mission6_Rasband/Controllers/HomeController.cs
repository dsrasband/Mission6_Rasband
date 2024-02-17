using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Collection()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Collection(Collection response)
        {
            _context.Films.Add(response); // Add the record to the Database
            _context.SaveChanges();
            
            return View("Test", response);
        }
    }
}
