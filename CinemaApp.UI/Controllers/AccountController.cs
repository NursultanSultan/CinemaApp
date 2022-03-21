using CinemaApp.Business.DTOs;
using CinemaApp.Business.Utilities.Email;
using CinemaApp.DataAcces.DAL;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using System.Threading.Tasks;
using static CinemaApp.Business.Utilities.Helper.Helper;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace CinemaApp.UI.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<IdentityUser> _userManager { get; }
        private SignInManager<IdentityUser> _signInManager { get; }
        private RoleManager<IdentityRole> _roleManager { get; }
        private IConfiguration _configuration { get; }
        private AppDbContext _context { get; }

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager
            , IConfiguration configuration , AppDbContext context , RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
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

            //var isExistEmail = _userManager.FindByEmailAsync(registerDto.Email);

            //if (isExistEmail != null)
            //{
            //    ModelState.AddModelError(string.Empty, "you cannot register with this email because it is  already exist");
            //    return View();
            //}

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

            await _userManager.AddToRoleAsync(newUser, UserRoles.Member.ToString());

            var token = await _userManager.GenerateEmailConfirmationTokenAsync(newUser);
            var confirmationLink = Url.Action("ConfirmEmail", "Email", new { token, email = registerDto.Email }, Request.Scheme);
            EmailHelper emailHelper = new EmailHelper(_configuration.GetSection("EmailConfirmation:fromEmail").Value, _configuration.GetSection("EmailConfirmation:fromPassword").Value);
            bool emailResponse = emailHelper.SendEmail(registerDto.Email, confirmationLink);

            if (emailResponse)
            {

                ModelState.AddModelError(string.Empty, "Succesed ");
                return View();

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

        public IActionResult ResetPassword(string token, string email)
        {
            if (token == null || email == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid operation");
                return View();
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordDto resetDto)
        {
            if (!ModelState.IsValid) return View(resetDto);

            var user = await _userManager.FindByEmailAsync(resetDto.Email);

            var result = await _userManager.ResetPasswordAsync(user, resetDto.Token, resetDto.NewPassword);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View();
            }

            return RedirectToAction("Login", "Account");
        }

        public IActionResult ForgetPassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordDto forgetDto)
        {
            if (!ModelState.IsValid) return View(forgetDto);
            var user = await _userManager.FindByEmailAsync(forgetDto.Email);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Your account is incorrect");
                return View();
            }

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var confirmationLink = Url.Action("ResetPassword", "Account", new { token, email = forgetDto.Email }, Request.Scheme);
            EmailHelper emailHelper = new EmailHelper(_configuration.GetSection("EmailConfirmation:fromEmail").Value, _configuration.GetSection("EmailConfirmation:fromPassword").Value);
            bool emailResponse = emailHelper.SendEmail(forgetDto.Email, confirmationLink);


            if (emailResponse)
            {
                ModelState.AddModelError(string.Empty, "Succesed ");
                return View();
            }

            return View();
        }

        //-------------------------------------

        //public async Task CreateRole()
        //{
        //    foreach (var role in Enum.GetValues(typeof(UserRoles)))
        //    {
        //        if (!await _roleManager.RoleExistsAsync(role.ToString()))
        //        {
        //            await _roleManager.CreateAsync(new IdentityRole { Name = role.ToString() });
        //        }
        //    }
        //}

        //-------------------------------

        public IActionResult FacebookLogin(string returnUrl)
        {
            string redirectUrl = Url.Action("SocialMediaResponse", "Account", new { returnUrl = returnUrl });
            var properties = _signInManager.ConfigureExternalAuthenticationProperties("Facebook", redirectUrl);
            return new ChallengeResult("Facebook", properties);
        }

        public IActionResult GoogleLogin(string returnUrl)
        {
            string redirectUrl = Url.Action("SocialMediaResponse", "Account", new { returnUrl = returnUrl });
            var properties = _signInManager.ConfigureExternalAuthenticationProperties("Google", redirectUrl);
            return new ChallengeResult("Google", properties);
        }

        public async Task<IActionResult> SocialMediaResponse(string returnUrl)
        {
            var loginInfo = await _signInManager.GetExternalLoginInfoAsync();
            if (loginInfo == null)
            {
                return RedirectToAction("Register");
            }
            else
            {
                var result =
                    await _signInManager.ExternalLoginSignInAsync(loginInfo.LoginProvider, loginInfo.ProviderKey, true);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    if (loginInfo.Principal.HasClaim(scl => scl.Type == ClaimTypes.Email))
                    {
                        IdentityUser user = new IdentityUser()
                        {
                            Email = loginInfo.Principal.FindFirstValue(ClaimTypes.Email),
                            UserName = loginInfo.Principal.FindFirstValue(ClaimTypes.GivenName),
                            EmailConfirmed = true
                        };
                        var createResult = await _userManager.CreateAsync(user);
                        if (createResult.Succeeded)
                        {
                            var identityLogin = await _userManager.AddLoginAsync(user, loginInfo);
                            if (identityLogin.Succeeded)
                            {
                                await _signInManager.SignInAsync(user, true);
                                return Redirect("Login");
                            }
                        }
                    }
                }
            }

            return RedirectToAction("Register");
        }



        public IActionResult SuccesSending()
        {
            return View();
        }
    }
}
