using CinemaApp.Business.DTOs;
using CinemaApp.DataAcces.DAL;
using CinemaApp.Entity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CinemaApp.UI.Controllers
{
    public class FavoriteController : Controller
    {
        private UserManager<IdentityUser> _userManager { get; }
        private AppDbContext _context { get; }
        public FavoriteController(UserManager<IdentityUser> userManager , AppDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }


        public async Task AddFavorite(int movieId)
        {
            ClaimsPrincipal currentUser = User;
            var userId = _userManager.GetUserId(User);

            FavoriteAddDto favoriteAdd = new FavoriteAddDto();

            Favorite favorite = _context.Favorites
                    .Where(f => f.UserId == userId && f.MovieId == movieId)
                    .FirstOrDefault();

            if (userId != null)
            {

                if (favorite == null)
                {
                    favorite = new Favorite
                    {
                        UserId = userId,
                        MovieId = movieId,
                    };
                    await _context.Favorites.AddAsync(favorite);
                    favoriteAdd.IsFavorite = true;
                }
                else
                {
                    _context.Favorites.Remove(favorite);
                    favoriteAdd.IsFavorite = false;
                }

            }
            

            await _context.SaveChangesAsync();

        }

        public async Task<IActionResult> ShowFavorite()
        {

            var userId = _userManager.GetUserId(User);

            var MovieIds = _context.Favorites
                    .Where(f => f.UserId == userId)
                    .Select(m => m.MovieId)
                    .Distinct()
                    .ToList();

            var favMovie = _context.Movies
                                .Where(m => MovieIds.Contains(m.Id))
                                .Include(m => m.MovieCategories)
                                .ThenInclude(m => m.Category)
                                .ToList();


            return View(favMovie);

        }
    }
}
