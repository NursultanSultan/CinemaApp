﻿using CinemaApp.DataAcces.DAL;
using CinemaApp.Entity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
            //var user = _userManager.FindByIdAsync(userId);
            //var movie = _context.Movies.Where(m => m.Id == movieId).FirstOrDefault();

            Favorite favorite = _context.Favorites.Where(f => f.UserId == userId && f.MovieId == movieId).FirstOrDefault();
            if (favorite == null && userId != null)
            {
                favorite = new Favorite
                {
                    UserId = userId,
                    MovieId = movieId,
                };
                await _context.Favorites.AddAsync(favorite);

            }

            await _context.SaveChangesAsync();

            
        }
    }
}
