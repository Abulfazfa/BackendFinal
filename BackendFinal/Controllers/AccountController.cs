using BackendFinal.Helper;
using BackendFinal.Models;
using BackendFinal.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BackendFinal.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid) return View();
            AppUser appUser = new() { 
                Fullname = registerVM.Fullname,
                Email = registerVM.Email,
                UserName = registerVM.Username
            };

            var result = await _userManager.CreateAsync(appUser, registerVM.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", errorMessage: error.Description);
                }
                return View(registerVM);
            }

            await _userManager.AddToRoleAsync(appUser, RoleEnum.User.ToString());
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Login(LoginVM loginVM, string? ReturnUrl)
        {
            if (!ModelState.IsValid) return View();
            AppUser appUser = await _userManager.FindByNameAsync(loginVM.UsernameOrEmail) ?? await _userManager.FindByEmailAsync(loginVM.UsernameOrEmail);
            if (appUser == null)
            {
                ModelState.AddModelError("", "username or password isn't true");
                return View(loginVM);
            }
            var result = await _signInManager.PasswordSignInAsync(appUser, loginVM.Password, loginVM.RememberMe, true);
            if (result.IsLockedOut)
            {
                ModelState.AddModelError("", "your profile has been blocked");
                return View(loginVM);
            }
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "username or password isn't true");
                return View(loginVM);
            }
            if (ReturnUrl != null)
            {
                return Redirect(ReturnUrl);
            }

            await _signInManager.SignInAsync(appUser, loginVM.RememberMe);
            var userList = await _userManager.GetRolesAsync(appUser);
            if (userList.Contains(RoleEnum.Admin.ToString())) return RedirectToAction("Index", "Dashboard", new { area = "adminarea" });

            return RedirectToAction("Index", "Home");



        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }

        public async Task<IActionResult> AddRole()
        {
            foreach (var item in Enum.GetValues(typeof(RoleEnum)))
            {
                await _roleManager.CreateAsync(new IdentityRole { Name = item.ToString() });
            }
            return Content("Roles added");
        }

    }
}
