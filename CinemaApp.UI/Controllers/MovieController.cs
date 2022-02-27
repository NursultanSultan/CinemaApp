using CinemaApp.DataAcces.DAL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaApp.UI.Controllers
{
    public class MovieController : Controller
    {
        private AppDbContext _context { get; }
        public MovieController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Detail(int Id)
        {
            var movie = _context.Movies.Where(m => m.Id == Id).FirstOrDefault();
            return View(movie);
        }

    }
}
