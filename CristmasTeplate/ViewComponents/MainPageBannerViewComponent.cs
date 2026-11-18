using CristmasTeplate.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CristmasTeplate.ViewComponents
{
    public class MainPageBannerViewComponent : ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
