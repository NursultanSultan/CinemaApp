using CinemaApp.Business.DTOs;
using CinemaApp.DataAcces.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
                Movies = _context.Movies.Where(m => m.IsDeleted == false).ToList(),
                Cinemas = _context.Cinemas.Where(c => c.IsDeleted == false).ToList(),
                Languages = _context.Languages.Where(l => l.IsDeleted == false).ToList()
            };

            return View(homedto);
        }

        
        public async Task<IActionResult> GetFilterMovie(int? CineId)
        {
            var MovieCineIds = await _context.MovieCinemas
                    .Where(mc => (CineId != null ? mc.CinemaId == CineId : true))
                    .Select(m => m.MovieId)
                    .Distinct()
                    .ToListAsync();

            

            var result = await _context.Movies
                                .Where(m => MovieCineIds.Contains(m.Id) )
                                .ToListAsync();

            return PartialView("_MoviePartial", result);

        }

        
    }
}
