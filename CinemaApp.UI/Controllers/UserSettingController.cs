using CinemaApp.Business.DTOs;
using CinemaApp.DataAcces.DAL;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaApp.UI.Controllers
{
    public class UserSettingController : Controller
    {
        private UserManager<IdentityUser> _userManager { get; }
        private SignInManager<IdentityUser> _signInManager { get; }
        private RoleManager<IdentityRole> _roleManager { get; }
        private AppDbContext _context { get; }
        public UserSettingController(UserManager<IdentityUser> userManager,
                              SignInManager<IdentityUser> signInManager,
                              RoleManager<IdentityRole> roleManager,
                              AppDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _context = context;
        }

        public IActionResult ChangeSetting()
        {
            return View();
        }

        //public async Task<IActionResult> ChangeSetting(UserSettingDto userSettingDto)
        //{

        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> ChangePassword(ChangePasswordDTO password)
        //{
        //    if (!ModelState.IsValid) return View(password);
        //    var user = await _userManager.GetUserAsync(User);
        //    if (user == null)
        //    {
        //        ModelState.AddModelError(string.Empty, "User is Not Found");
        //        return View();
        //    }
        //    var checkPasword = await _userManager.CheckPasswordAsync(user, password.CurrentPassword);
        //    if (!checkPasword)
        //    {
        //        ModelState.AddModelError(string.Empty, "Incorrect Password");
        //        return View(password);
        //    }
        //    var result = await _userManager.ChangePasswordAsync(user, password.CurrentPassword,
        //                                                                password.NewPassword);
        //    if (!result.Succeeded)
        //    {
        //        foreach (var error in result.Errors)
        //        {
        //            ModelState.AddModelError(string.Empty, error.Description);
        //        }
        //        return View(password);
        //    }
        //    await _signInManager.RefreshSignInAsync(user);
        //    return RedirectToAction("Index", "Home");
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> ChangeUsername(ChangeUserNameDTO username)
        //{
        //    if (!ModelState.IsValid) return View(username);
        //    var user = await _userManager.GetUserAsync(User);
        //    if (user == null)
        //    {
        //        ModelState.AddModelError(string.Empty, "User is Not Found");
        //        return View(username);
        //    }
        //    var checkPasword = await _userManager.CheckPasswordAsync(user, username.Password);
        //    if (!checkPasword)
        //    {
        //        ModelState.AddModelError(string.Empty, "Incorrect Password");
        //        return View(username);
        //    }
        //    var result = await _userManager.SetUserNameAsync(user, username.NewUsername);
        //    if (!result.Succeeded)
        //    {
        //        foreach (var error in result.Errors)
        //        {
        //            ModelState.AddModelError(string.Empty, error.Description);
        //        }
        //        return View(username);
        //    }
        //    await _signInManager.RefreshSignInAsync(user);
        //    return RedirectToAction("Index", "Home");
        //}
    }
}
