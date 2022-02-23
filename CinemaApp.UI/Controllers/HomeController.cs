using CinemaApp.Business.DTOs;
using CinemaApp.DataAcces.DAL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaApp.UI.Controllers
{
    public class HomeController : Controller
    {
        private AppDbContext _context { get; }
        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            HomeDto homedto = new HomeDto
            {
                Movies = _context.Movies.Where(m => m.IsDeleted == false).ToList()
            };

            return View(homedto);
        }
    }
}
