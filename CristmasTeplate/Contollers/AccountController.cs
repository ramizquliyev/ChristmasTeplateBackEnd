using CristmasTeplate.Models;
using CristmasTeplate.ViewModels.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CristmasTeplate.Contollers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM reguest)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "User Name Or Password Wrong");
                return View(reguest);
            }

            var finded = await _userManager.FindByNameAsync(reguest.UserName);
            if (finded is null)
            {
                return View();
            }

            var res = await _userManager.CheckPasswordAsync(finded,reguest.Password);
            if (!res)
            {
                ModelState.AddModelError("", "User Name Or Password Wrong");
                return View(reguest);
            }

            await _signInManager.SignInAsync(finded,false);
            return RedirectToAction("index", "home");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("index","home");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAccount(RegisterCreateVM reguest)
        {

            if (!ModelState.IsValid)
            {
                return View("register", reguest);
            }
            AppUser user = new()
            {
                UserName = reguest.UserName,
                Email = reguest.Email,
                Age = reguest.Age
                
            };

            var res = await _userManager.CreateAsync(user,reguest.Password);

            if (!res.Succeeded)
            {
                foreach (var errors in res.Errors)
                {
                    ModelState.AddModelError("", errors.Description);
                }

                return View("register",reguest);
            }


            await _signInManager.SignInAsync(user,false);
            return RedirectToAction("index","home");
        }


    }
}
