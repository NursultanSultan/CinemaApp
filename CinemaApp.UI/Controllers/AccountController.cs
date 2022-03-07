using CinemaApp.Business.DTOs;
using CinemaApp.DataAcces.DAL;
using CinemaApp.UI.Utilities.Email;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace CinemaApp.UI.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<IdentityUser> _userManager { get; }
        private SignInManager<IdentityUser> _signInManager { get; }
        private IConfiguration _configuration { get; }
        private AppDbContext _context { get; }

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager
            , IConfiguration configuration , AppDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _context = context;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            if (!ModelState.IsValid) return View();

            IdentityUser newUser = new IdentityUser
            {
                UserName = registerDto.Username,
                Email = registerDto.Email
            };

            IdentityResult identityResult = await _userManager.CreateAsync(newUser, registerDto.Password);

            if (!identityResult.Succeeded)
            {
                foreach (var error in identityResult.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

                return View();
            }

            var token = await _userManager.GenerateEmailConfirmationTokenAsync(newUser);
            var confirmationLink = Url.Action("ConfirmEmail", "Email", new { token, email = registerDto.Email }, Request.Scheme);
            EmailHelper emailHelper = new EmailHelper(_configuration.GetSection("EmailConfirmation:fromEmail").Value, _configuration.GetSection("EmailConfirmation:fromPassword").Value);
            bool emailResponse = emailHelper.SendEmail(registerDto.Email, confirmationLink);

            if (emailResponse)
            {

                return RedirectToAction("SuccesSending", "Account");
            }

            return RedirectToAction("Index", "Home");

        }



        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginDto LoginDto, string ReturnUrl)
        {
            if (!ModelState.IsValid) return View();

            IdentityUser user = await _userManager.FindByEmailAsync(LoginDto.Email);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Email or password is wrong");
                return View(LoginDto);
            }

            SignInResult signInResult = await _signInManager
                                                .PasswordSignInAsync(user, LoginDto.Password, LoginDto.RememberMe, true);

            if (signInResult.IsLockedOut)
            {
                ModelState.AddModelError(string.Empty, "Ged koduvu oyren sonra gel");
                return View(LoginDto);
            }

            if (!signInResult.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Email or Password is wrong");
                return View(LoginDto);
            }

            if (ReturnUrl != null)
            {
                return Redirect(ReturnUrl);
            }

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Signout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }


        public async Task<IActionResult> Profile()
        {
            IdentityUser user = await _userManager.FindByNameAsync(User.Identity.Name);
            return View(user);

        }

        //public async Task<IActionResult> ShowFavorite()
        //{
        //    var userId = _userManager.GetUserId(User);

        //    var MovieIds = _context.Favorites
        //            .Where(f => f.UserId == userId)
        //            .Select(m => m.MovieId)
        //            .Distinct()
        //            .ToList();

        //    var result =  _context.Movies
        //                        .Where(m => MovieIds.Contains(m.Id) )
        //                        .ToList();

        //    //return PartialView("_FavoriteMoviePartial", result);
        //    return View(result);
        //}

        public IActionResult SuccesSending()
        {
            return View();
        }
    }
}
