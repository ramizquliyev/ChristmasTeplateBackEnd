using CristmasTeplate.Models;
using CristmasTeplate.ViewModels.Profile;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CristmasTeplate.Contollers
{
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        public ProfileController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);

            ProfileUIVM uIVM = new()
            {
                UserName = user.UserName,
                Email = user.Email,
                Age = user.Age
            };

            return View(uIVM);
        }
    }
}
