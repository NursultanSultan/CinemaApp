using CinemaApp.DataAcces.DAL;
using CinemaApp.Entity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CinemaApp.UI.Controllers
{
    public class MovieController : Controller
    {
        private AppDbContext _context { get; }
        private UserManager<IdentityUser> _userManager { get; }
        public MovieController(AppDbContext context , UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Detail(int Id)
        {
            var movie = _context.Movies.Where(m => m.Id == Id)
                .Include(m => m.Comments)
                .ThenInclude(m => m.User)
                .Include(m => m.MovieCategories)
                .ThenInclude(m => m.Category)
                .FirstOrDefault();
            return View(movie);
        }

       
        [HttpPost]
        public async Task<IActionResult> CommentAdd(int movieId , string content )
        {
            ClaimsPrincipal currentUser = User;
            var userId = _userManager.GetUserId(User);


            var comment = new Comment
            {
                UserId = userId,
                MovieId = movieId,
                Content = content
            };

            await _context.Comments.AddAsync(comment);
            await _context.SaveChangesAsync();

            var result = _context.Comments
                    .Where(m => m.MovieId == movieId && m.Content.Contains(content))
                    .Include(m => m.User)
                    .FirstOrDefault();
                                                                 

            return PartialView("_CommentPartial", result);

        }

        //[HttpPost]
        //public async Task CommentDelete(int commentId)
        //{
        //    var comment = _context.Comments.Where(c => c.Id == commentId).FirstOrDefault();

        //    _context.Comments.Remove(comment);
        //    await _context.SaveChangesAsync();
        //}

    }
}
