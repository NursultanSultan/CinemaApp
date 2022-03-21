using CinemaApp.Business.DTOs;
using CinemaApp.Business.Exceptions.UserExceptions;
using CinemaApp.DataAcces.DAL;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangeSetting(UserSettingDto userSetting)
        {
            if (!ModelState.IsValid) return View(userSetting);
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "User is Not Found");
                return View(userSetting);
            }

            try
            {
                if (userSetting.UserName != null)
                {
                    await ChangeUserName(user, userSetting);
                }
                if (userSetting.CurrentPassword != null && userSetting.NewPassword != null)
                {
                    await ChangePassword(user, userSetting);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty, ex.Message.ToString());
                return View(userSetting);
            }

            return RedirectToAction("Index", "Home");
        }

        public async Task ChangeUserName(IdentityUser User , UserSettingDto userSettingDto)
        {
            var result = await _userManager.SetUserNameAsync(User, userSettingDto.UserName);
            if (!result.Succeeded)
            {
                throw new SetUserNameException("User name invalid");
            }
            await _signInManager.RefreshSignInAsync(User);
           
        }

        public async Task ChangePassword(IdentityUser User, UserSettingDto userSettingDto)
        {
            var result = await _userManager.ChangePasswordAsync(User, userSettingDto.CurrentPassword,
                                                                        userSettingDto.NewPassword);
            if (!result.Succeeded)
            {
                throw new SetPasswordException("Invalid Password");
            }
            await _signInManager.RefreshSignInAsync(User);

        }

        

    }
}
