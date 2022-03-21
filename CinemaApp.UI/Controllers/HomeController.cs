using CinemaApp.Business.DTOs;
using CinemaApp.DataAcces.DAL;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaApp.UI.Controllers
{
    public class HomeController : Controller
    {
        private AppDbContext _context { get; }
        private UserManager<IdentityUser> _userManager { get; }
        public HomeController(AppDbContext context , UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index(string? moviesearch)
        {
            var dbMovies = _context.Movies.Where(m => m.IsDeleted == false);
            var movies = dbMovies.Where(m => moviesearch != null ? (
            m.MovieName.Contains(moviesearch)
            ) :true)
                    .Include(m => m.MovieCategories)
                    .ThenInclude(m => m.Category);

            HomeDto homedto = new HomeDto
            {
                Movies = movies.ToList(),
                OwlMovies = _context.Movies.Where(m => m.IsDeleted == false).Take(6)
                            .OrderByDescending(m => m.Id)
                            .Include(m => m.MovieCategories)
                            .ThenInclude(m => m.Category)
                            .ToList(),
                Cinemas = _context.Cinemas.Where(c => c.IsDeleted == false).ToList(),
                Languages = _context.Languages.Where(l => l.IsDeleted == false).ToList(),
                Categories = _context.Categories.Where(c => c.IsDeleted == false).ToList(),
                News = _context.News.Where(n => n.IsDelete == false).ToList()
                
            };

            return View(homedto);
        }

        
        public async Task<IActionResult> GetFilterMovie(int? CineId , int? LangId) 
        {
            var MovieCineIds = await _context.MovieCinemas
                    .Where(mc => (CineId != null ? mc.CinemaId == CineId : true))
                    .Select(m => m.MovieId)
                    .Distinct()
                    .ToListAsync();

            var MovieLangIds = await _context.MovieLanguages
                    .Where(ml => (LangId != null ? ml.LanguageId == LangId : true))
                    .Select(m => m.MovieId)
                    .Distinct()
                    .ToListAsync();


            var result = await _context.Movies
                                .Where(m => MovieCineIds.Contains(m.Id) && MovieLangIds.Contains(m.Id) && !m.IsDeleted)
                                .Include(m => m.MovieCategories)
                                .ThenInclude(m => m.Category)
                                .ToListAsync();

            return PartialView("_MoviePartial", result);

        }



        public async Task<IActionResult> GetSchedule()
        {
            //var sessions = await _context.Sessions
            //       .Include(x => x.MovieSessions)
            //       .ThenInclude(x => x.Movie)
            //       .ThenInclude(x => x.MovieCinemas)
            //       .ThenInclude(x => x.Movie)
            //       .ThenInclude(x => x.MovieLanguages)
            //       .ThenInclude(x => x.Movie)
            //       .ThenInclude(x => x.MovieFormats)
            //       .ToListAsync();

            var sessions = await _context.MovieSessions
                  .Include(x => x.Movie)
                  .Include(x => x.Movie.MovieCinemas)
                  .ThenInclude(x => x.Cinema)
                  .Include(x => x.Movie.MovieLanguages)
                  .ThenInclude(x => x.Language)
                  .Include(x => x.Movie.MovieFormats)
                  .ThenInclude(x => x.Format)
                  .ToListAsync();

            return Json(sessions);
        }


        

    }
}
